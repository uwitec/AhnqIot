using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.DataProcess.Service.Core;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using NewLife.Log;
using SmartIot.Service.Hikvision;

namespace AhnqIot.CameraStationDataProcess
{
   public class CameraDeviceJob:Job
    {    
        /// <summary>
        /// 实景监测站存储目录
        /// </summary>
        private string _picsPath = "";

        /// <summary>
        /// 定时拍照时间间隔：分钟
        /// </summary>
        private int _period = 15;

        /// <summary>
        /// 拍照定时器
        /// </summary>
        //private Timer _processTimer;
        private readonly ICameraStationsService _cameraStationsService;
        private readonly ISysDepartmentService _sysDepartmentService;
        private readonly ICameraStationPresetPointService _cameraStationPresetPointService;
        private readonly IPictureRepService _pictureRepService;
        private readonly ICameraStationPicsService _cameraStationPicsService;
        private readonly ICameraStationRunLogService _cameraStationRunLogService;
        private readonly ICameraStationOnlineStatisticsService _cameraStationOnlineStatisticsService;
        public CameraDeviceJob()
        {
            LoadLib();
            DisplayName = "实景定时拍照工作组件";
            JobInterval = _period * 60;
            _cameraStationsService = AhnqIotContainer.Container.Resolve<ICameraStationsService>();
            _sysDepartmentService = AhnqIotContainer.Container.Resolve<ISysDepartmentService>();
            _cameraStationPresetPointService = AhnqIotContainer.Container.Resolve<ICameraStationPresetPointService>();
            _pictureRepService = AhnqIotContainer.Container.Resolve<IPictureRepService>();
            _cameraStationPicsService = AhnqIotContainer.Container.Resolve<ICameraStationPicsService>();
            _cameraStationRunLogService = AhnqIotContainer.Container.Resolve<ICameraStationRunLogService>();
            _cameraStationOnlineStatisticsService = AhnqIotContainer.Container.Resolve<ICameraStationOnlineStatisticsService>();
        }

        public override bool Start()
        {
            string _configPath = NewLife.Configuration.Config.GetConfig("basepath", "");
            if (!Directory.Exists(_configPath))
                Directory.CreateDirectory(_configPath);

            _picsPath = Path.Combine(_configPath, "CameraStation-pics");
            if (!Directory.Exists(_picsPath))
                Directory.CreateDirectory(_picsPath);

            StartProcess();

            //var next = GetNextPeriod(_period);
            //var dur = next.Subtract(DateTime.Now).TotalMilliseconds;
            //_processTimer = new Timer(obj => StartProcess(), null, Convert.ToInt32(dur), _period * 60 * 1000);
            //WriteLog(dur + "秒后启动定时拍照功能");
            // WriteLog("实景监测启动定时拍照功能");
            return base.Start();
        }

        public override bool Work()
        {
            var next = GetNextPeriod(_period);
            var dur = next.Subtract(DateTime.Now).TotalSeconds;
            if (dur < JobInterval)
                StartProcess();

            return base.Work();
        }


        /// <summary>
        /// 开始拍照
        /// </summary>
        public async void StartProcess()
        {
            if (!Directory.Exists(_picsPath))
                Directory.CreateDirectory(_picsPath);
            var cameraStations = (await _cameraStationsService.GetAllAsny()).ToList();
            cameraStations.ForEach(async station =>
            {
                var dep = await _sysDepartmentService.GetByIdAsync(station.SysDepartmentSerialnum);
                if (dep != null)
                {
                    var depPath = GetDepPath(dep);
                    //if (!Directory.Exists(depPath))
                    //    Directory.CreateDirectory(depPath);

                    try
                    {
                        CHCNetSDK.NET_DVR_Init();
                        var userHandle = Login(station.IP, station.DataPort, station.UserID, station.UserPwd);
                        //var userHandle = Login("120.209.96.139", 20001, "admin", "smt12345");

                        if (userHandle != -1)
                        {
                            //从设备获取预置点
                            var points = await GetCameraPresetPoints(userHandle, station);

                            var cameraStationPath = Path.Combine(await depPath, station.IP);
                            var cameraStationPresetPoints = points as CameraStationPresetPointDto[] ?? points.ToArray();
                            if (!cameraStationPresetPoints.Any())
                            {
                                var fileName = TakePhoto(userHandle, station.Channel, Path.Combine(_picsPath, cameraStationPath));
                                cameraStationPresetPoints.ToList().ForEach(cameraStationPresetPoint =>
                                {
                                    Process(fileName, cameraStationPresetPoint);
                                });

                            }
                            else
                            {
                                for (int i = 0; i < cameraStationPresetPoints.Count(); i++)
                                {
                                    var point = cameraStationPresetPoints.ElementAt(i);
                                    //跳转到预置点
                                    bool success = GotoCameraPreset(userHandle, Convert.ToUInt32(point.PresetPoint));
                                    if (success)
                                    {
                                        //等3秒聚焦
                                        Thread.Sleep(3000);
                                        //拍照
                                        var fileName = TakePhoto(userHandle, station.Channel, Path.Combine(_picsPath, cameraStationPath), i + 1);
                                        //处理文件对应的记录
                                        cameraStationPresetPoints.ToList().ForEach(cameraStationPresetPoint =>
                                        {
                                            Process(fileName, cameraStationPresetPoint);
                                        });
                                    }
                                }
                            }
                            CHCNetSDK.NET_DVR_Logout(userHandle);
                        }
                        //(待处理。。。。。。)
                        //设备运行记录
                        CameraStationRunLogDto record = new CameraStationRunLogDto();
                        record.CameraStationsSerialnum = station.Serialnum;
                        record.Status = userHandle > -1;
                        await _cameraStationRunLogService.AddAsny(record);

                        //运行统计数据
                        var list = await _cameraStationOnlineStatisticsService.GetByCameraStationIdAndYearAndMonthAsny(station.Serialnum,
                            DateTime.Now.Year, DateTime.Now.Month);

                        CameraStationOnlineStatisticsDto statistics = null;
                        if (list == null || !list.Any())
                        {
                            statistics = new CameraStationOnlineStatisticsDto();
                            statistics.CameraStationsSerialnum = station.Serialnum;
                            statistics.Year = DateTime.Now.Year;
                            statistics.Month = DateTime.Now.Month;
                        }
                        else
                        {
                            statistics = list.ToList()[0];
                        }

                        statistics.AllCount++;
                        if (userHandle > -1)
                            statistics.OnlineCount++;
                        statistics.OnlinePercent = Math.Round((statistics.OnlineCount * 1M) / (statistics.AllCount * 1M), 1) * 100M;
                        await _cameraStationOnlineStatisticsService.AddAsny(statistics);
                    }
                    catch (Exception ex)
                    {
                        XTrace.WriteException(ex);
                    }
                    finally
                    {
                        // CHCNetSDK.NET_DVR_Cleanup();
                    }
                }
            });
        }

        /// <summary>
        /// 处理文件及记录
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="station"></param>
        private async void Process(string fileName, CameraStationPresetPointDto preset)
        {
            //图片记录
            PictureRepDto pic = new PictureRepDto();
            pic.Serialnum = Guid.NewGuid().ToString();
            pic.Type = "CameraStation";
            pic.Title = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            pic.Description = "";
            pic.Url = Path.Combine(_picsPath, fileName);
            pic.Href = "CameraStation-pics" + fileName.Replace(_picsPath, "").Replace("\\", "/");
            pic.CreateTime = DateTime.Now;
            await _pictureRepService.AddAsync(pic);

            //映射关系
            CameraStationPicsDto fp = new CameraStationPicsDto();
            fp.Serialnum = Guid.NewGuid().ToString();
            fp.CameraStationsPresetSerialnum = preset.Serialnum;//预置点编码？？？
            fp.PicSerialnum = pic.Serialnum;
            fp.CreateTime = DateTime.Now;
            await _cameraStationPicsService.AddAsny(fp);
        }

        #region 摄像机操作

        #region 视频类库加载

        /// <summary>
        /// 加载海康播放库
        /// </summary>
        public void LoadLib()
        {
            String p = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lib");
            //获取计算机平台
            var is64bit = Environment.Is64BitOperatingSystem;
            String _86path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lib\\x86");
            String _64path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lib\\x64");

            CopyLib(!is64bit ? _86path : _64path);
        }

        public void CopyLib(string path)
        {
            var files = Directory.GetFiles(path);
            var desPath = AppDomain.CurrentDomain.BaseDirectory;
            foreach (var f in files)
            {
                FileInfo fi = new FileInfo(f);
                var fileName = fi.Name;
                var desFile = Path.Combine(desPath, fileName);
                if (File.Exists(desFile))
                    File.Delete(desFile);
                if (File.Exists(f))
                {
                    File.Copy(f, desFile);
                    LogHelper.Debug("加载拍照外接程序集");
                }
            }
        }

        #endregion 视频类库加载

        /// <summary>
        /// 登录V30
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login(string ip, int port, string uid, string pwd)
        {
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DEV = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

#if DEBUG
            LogHelper.Debug("开始处理摄像机：{0}:{1}", ip, port);
#endif
            Int32 userHandle = CHCNetSDK.NET_DVR_Login_V30(ip, port, uid, pwd, ref DEV);
            if (userHandle == -1)
            {
                LogHelper.Error("登录失败：{0}:{1}-{2}-{3}", ip, port, uid, pwd);
            }
            else
            {
#if DEBUG
                LogHelper.Debug("登录成功");
#endif
            }
            return userHandle;
        }

        /// <summary>
        /// 登录V30
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login_V40(string ip, int port, string uid, string pwd)
        {
            CHCNetSDK.DVR_USER_LOGIN_INFO dvrUserLoginInfo = new CHCNetSDK.DVR_USER_LOGIN_INFO
            {
                sDeviceAddress = ip,
                wPort = Convert.ToInt16(port),
                sUserName = uid,
                sPassword = pwd,
                bUseAsynLogin = false,
                fLoginResultCallBack = IntPtr.Zero
            };

            CHCNetSDK.DVR_DEVICEINFO_V40 dvrDeviceinfoV40 = new CHCNetSDK.DVR_DEVICEINFO_V40
            {
                struDeviceV30 = new CHCNetSDK.NET_DVR_DEVICEINFO_V30()
            };

#if DEBUG
            LogHelper.Debug("开始处理摄像机：{0}:{1}", ip, port);
#endif
            Int32 userHandle = CHCNetSDK.NET_DVR_Login_V40(dvrUserLoginInfo, ref dvrDeviceinfoV40);
            if (userHandle == -1)
            {
                LogHelper.Error("登录失败：{0}:{1}-{2}-{3}", ip, port, uid, pwd);
            }
            else
            {
#if DEBUG
                LogHelper.Debug("登录成功");
#endif
            }
            return userHandle;
        }

        public void FLoginResultCallBack(int lUserID, short dwResult, CHCNetSDK.NET_DVR_DEVICEINFO_V30 lpDeviceInfo, IntPtr pUser)
        {
        }

        /// <summary>
        /// 获取摄像机上配置的预置点
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="camStation"></param>
        /// <returns></returns>
        private async Task<IEnumerable<CameraStationPresetPointDto>> GetCameraPresetPoints(int userHandle, CameraStationsDto camStation)
        {
            var cameraPreset = new CHCNetSDK.NET_DVR_GET_PRESET_NAMES();
            Int32 dwSize = Marshal.SizeOf(typeof(CHCNetSDK.NET_DVR_GET_PRESET_NAMES));
            IntPtr ptrNetCfg = Marshal.AllocHGlobal(dwSize);
            Marshal.StructureToPtr(cameraPreset, ptrNetCfg, false);

            UInt32 uiOutBufferSize = 0;
            bool bGetCfg = false;
            bGetCfg = CHCNetSDK.NET_DVR_GetDVRConfig(userHandle, 3383, 1, ptrNetCfg, dwSize, ref uiOutBufferSize);

            if (bGetCfg == false)
            {
                var errorCode = CHCNetSDK.NET_DVR_GetLastError();
                LogHelper.Error("读取预置点失败 错误码{0}", errorCode);

                return Enumerable.Empty<CameraStationPresetPointDto>();
            }
            else
            {
                LogHelper.Debug("读取预置点成功");
            }
            cameraPreset = (CHCNetSDK.NET_DVR_GET_PRESET_NAMES)Marshal.PtrToStructure(ptrNetCfg, typeof(CHCNetSDK.NET_DVR_GET_PRESET_NAMES));
            //只取前3个
            var points = cameraPreset.StructAs.AsEnumerable().Take(5);

            List<CameraStationPresetPointDto> list = new List<CameraStationPresetPointDto>();

            for (int i = 0; i < points.Count(); i++)
            {
                var p = points.ElementAt(i);
                //var positon = p.wPresetNum; //设备返回的位置，只要不是0，即为处于使用状态
                //if (!positon.Equals(0))
                //{
                var name = Encoding.Default.GetString(p.byName).Trim();
                var preset = await _cameraStationPresetPointService.GetByPointAndIdAsny(camStation.Serialnum, i + 1);
                if (preset == null)
                {
                    preset = new CameraStationPresetPointDto();
                    preset.Serialnum = Guid.NewGuid().ToString();
                    preset.CameraStationsSerialnum = camStation.Serialnum;
                    preset.Name = name;
                    preset.PresetPoint = i + 1;
                    await _cameraStationPresetPointService.AddAsny(preset);
                }
                else
                {
                    if (preset.Name.Equals(name))
                        preset.Name = name;
                    await _cameraStationPresetPointService.UpdateAsny(preset);
                }
                list.Add(preset);
                //}
                //else
                //{
                //    CameraStationPresetPoint.DeleteByPosition(camStation.Serialnum, i + 1);
                //}
            }

            //释放非托管资源
            Marshal.FreeHGlobal(ptrNetCfg);

            return list;
        }

        /// <summary>
        /// 设置预置点 
        /// </summary>
        /// <param name="userHandle">登录句柄</param>
        /// <param name="name">预置点名称</param>
        /// <param name="lPresetNumber">位置</param>
        /// <returns></returns>
        public bool SetCameraPreset(int userHandle, string name, short lPresetNumber)
        {
            var obj = new CHCNetSDK.NET_DVR_GET_PRESET_NAME();
            obj.wPresetNum = lPresetNumber;
            var nameBytes = name.GetBytes(Encoding.Default);
            obj.byName = new byte[CHCNetSDK.NAME_LEN];
            Array.Copy(nameBytes, 0, obj.byName, 0, nameBytes.Length);
            obj.byRes1 = new byte[2];
            obj.byRes = new byte[64];

            Int32 dwSize = Marshal.SizeOf(typeof(CHCNetSDK.NET_DVR_GET_PRESET_NAME));
            obj.dwSize = dwSize;
            IntPtr ptrNetCfg = Marshal.AllocHGlobal(dwSize);
            Marshal.StructureToPtr(obj, ptrNetCfg, true);

            bool bGetCfg = false;
            bGetCfg = CHCNetSDK.NET_DVR_SetDVRConfig(userHandle, 3382, 1, ptrNetCfg, dwSize);

            if (!bGetCfg)
            {
#if DEBUG
                LogHelper.Error("设置预置点信息失败");
#endif
                var errorCode = CHCNetSDK.NET_DVR_GetLastError();
                LogHelper.Error("错误码{0}", errorCode);
            }

            return bGetCfg;
        }

        /// <summary>
        /// 调用预置点
        /// </summary>
        /// <param name="lPresetNumber"></param>
        /// <returns></returns>
        public bool GotoCameraPreset(int userHandle, uint lPresetNumber)
        {
            //CHCNetSDK.NET_DVR_CLIENTINFO lpClientInfo = new CHCNetSDK.NET_DVR_CLIENTINFO();
            //lpClientInfo.hPlayWnd = IntPtr.Zero;//RealPlayWnd.Handle;
            //lpClientInfo.lChannel = 1;
            //lpClientInfo.lLinkMode = 0x0000;
            //lpClientInfo.sMultiCastIP = "";

            //CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);
            //IntPtr pUser = new IntPtr();
            //var m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V30(userHandle, ref lpClientInfo, RealData, pUser, 1);
            //if (m_lRealHandle == -1)
            //{
            //    return false;
            //}
            //else
            //{
            //    return CHCNetSDK.NET_DVR_PTZPreset(m_lRealHandle, 39, lPresetNumber);
            //}
            return CHCNetSDK.NET_DVR_PTZPreset_Other(userHandle, 1, 39, lPresetNumber);
        }

        /// <summary>
        /// 视频播放回调函数
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwDataType"></param>
        /// <param name="pBuffer"></param>
        /// <param name="dwBufSize"></param>
        /// <param name="pUser"></param>
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
        }

        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="channel"></param>
        /// <param name="cameraStationPath"></param>
        /// <returns></returns>
        public string TakePhoto(int userHandle, int channel, string cameraStationPath, int preset = 0)
        {
            if (userHandle != -1)
            {
                CHCNetSDK.NET_DVR_JPEGPARA para = new CHCNetSDK.NET_DVR_JPEGPARA();
                para.wPicSize = 2;
                para.wPicQuality = 1;
                if (!Directory.Exists(cameraStationPath))
                {
                    Directory.CreateDirectory(cameraStationPath);
                }

                string year_Path = Path.Combine(cameraStationPath, DateTime.Now.Year.ToString());
                if (!Directory.Exists(year_Path))
                {
                    Directory.CreateDirectory(year_Path);
                }
                String fileName = Path.Combine(year_Path, String.Format("{0}{1}.jpg", DateTime.Now.ToString("yyyyMMddHHmm"), preset == 0 ? "" : "-" + preset.ToString()));

                bool flag = CHCNetSDK.NET_DVR_CaptureJPEGPicture(userHandle, channel, ref para, fileName);
                if (flag)
                {
#if DEBUG
                    LogHelper.Debug("拍照成功");
#endif
                }
                else
                {
                    var error = CHCNetSDK.NET_DVR_GetLastError();
                    LogHelper.Error("拍照失败,错误码：{0}", error);
                }

                return fileName;
            }
            return null;
        }

        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <param name="channel"></param>
        /// <param name="facilityPath"></param>
        /// <returns></returns>
        public string TakePhoto(string ip, int port, string uid, string pwd, int channel, string facilityPath)
        {
            CHCNetSDK.NET_DVR_Init();

            var userHandle = Login(ip, port, uid, pwd);
            if (userHandle != -1)
            {
                CHCNetSDK.NET_DVR_JPEGPARA para = new CHCNetSDK.NET_DVR_JPEGPARA();
                para.wPicSize = 2;
                para.wPicQuality = 1;
                string firstFolderName = Path.Combine(facilityPath, ip);
                if (!Directory.Exists(firstFolderName))
                {
                    Directory.CreateDirectory(firstFolderName);
                }

                String fileName = Path.Combine(firstFolderName,
                    String.Format("{0}.jpg", DateTime.Now.ToString("yyyy-MM-dd-HH-mm")));
                bool flag = CHCNetSDK.NET_DVR_CaptureJPEGPicture(userHandle, channel, ref para, fileName);
                if (flag)
                {
#if DEBUG
                    LogHelper.Debug("拍照成功");
#endif
                }
                else
                {
                    var error = CHCNetSDK.NET_DVR_GetLastError();
                    LogHelper.Error("拍照失败,错误码：{0}", error);
                }
                CHCNetSDK.NET_DVR_Logout(userHandle);
                CHCNetSDK.NET_DVR_Cleanup();

                return fileName;
            }
            return null;
        }

        #endregion 摄像机操作

        /// <summary>
        /// 获取机构路径
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="tempPath"></param>
        /// <returns></returns>
        private async Task<string> GetDepPath(SysDepartmentDto dep, string tempPath = "")
        {
            var parent = await _sysDepartmentService.GetParentByParentIdAsny(dep.ParentSerialnum);
            var p = dep.Name;
            var p2 = "";
            if (parent == null) { p2 = Path.Combine(tempPath, p); }
            else
            {
                p2 = Path.Combine(await GetDepPath(parent), tempPath, p);
            }
            if (!Directory.Exists(Path.Combine(_picsPath, p2)))
            {
                Directory.CreateDirectory(Path.Combine(_picsPath, p2));
                LogHelper.Debug("创建实景监测点图库目录:" + Path.Combine(_picsPath, p2));
            }
            return p2;
        }

        /// <summary>
        /// 获取下个周期的开始时间
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        private DateTime GetNextPeriod(int period)
        {
            var now = DateTime.Now;
            var totalMins = now.Subtract(DateTime.Today).TotalMinutes;
            var minus = totalMins % period;
            var next = now.AddMinutes(period - minus);
            return next;
        }
    }
}
