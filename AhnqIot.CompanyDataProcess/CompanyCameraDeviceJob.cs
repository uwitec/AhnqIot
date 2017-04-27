using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using AhnqIot.Bussiness.Interface;
using AhnqIot.DataProcess.Service.Core;
using AhnqIot.Infrastructure.DI;
using Autofac;
using SmartIot.Service.Hikvision;
using AhnqIot.Dto;
using System.Threading.Tasks;
using NewLife.Threading;
using Smart.Redis;

namespace AhnqIot.CompanyDataProcess
{
    public class CompanyCameraDeviceJob : Job
    {
        /// <summary>
        /// 企业定时定点拍照存储目录
        /// </summary>
        private string _companyPicsPath = "";

        /// <summary>
        /// 定时拍照时间间隔：分钟
        /// </summary>
        private int _period = 60;

        private readonly IFarmService _farmService;
        private readonly ICompanyService _companyService;
        private readonly ISysDepartmentService _sysDepartmentService;
        private readonly IFacilityService _facilityService;
        private readonly IFacilityCameraService _facilityCameraService;
        private readonly IFacilityCameraPresetPointService _facilityCameraPresetPoinService;
        private readonly IPictureRepService _pictureRepService;
        private readonly IFacilityPicsService _facilityPicsRepService;
        private readonly IFacilityCameraRunLogService _facilityCameraRunLogRepService;
        private readonly IFacilityCameraRunStatisticsService _facilityCameraRunStatisticsRepService;
        private readonly IDeviceService _deviceService;
        /// <summary>
        ///     实例化一个redis客户端
        /// </summary>
        //private RedisClient RedisClient;
        /// <summary>
        ///     分析图片定时器
        /// </summary>
        //private TimerX _processPicsTimerX;

        public CompanyCameraDeviceJob()
        {
            // LoadLib();
            DisplayName = "企业定时拍照工作组件";
            JobInterval = _period * 60;
            _farmService = AhnqIotContainer.Container.Resolve<IFarmService>();
            _companyService = AhnqIotContainer.Container.Resolve<ICompanyService>();
            _sysDepartmentService = AhnqIotContainer.Container.Resolve<ISysDepartmentService>();
            _facilityService= AhnqIotContainer.Container.Resolve<IFacilityService>();
            _facilityCameraService = AhnqIotContainer.Container.Resolve<IFacilityCameraService>();
            _facilityCameraPresetPoinService = AhnqIotContainer.Container.Resolve<IFacilityCameraPresetPointService>();
            _pictureRepService = AhnqIotContainer.Container.Resolve<IPictureRepService>();
            _facilityPicsRepService= AhnqIotContainer.Container.Resolve<IFacilityPicsService>();
            _facilityCameraRunLogRepService= AhnqIotContainer.Container.Resolve<IFacilityCameraRunLogService>();
            _facilityCameraRunStatisticsRepService= AhnqIotContainer.Container.Resolve<IFacilityCameraRunStatisticsService>();
            //初始化RedisClient
            //RedisClient = RedisClient.DefaultDB;
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
        }

        public override bool Start()
        {
            //RedisClient.Delete("PicsRep-LIST");
            //RedisClient.Delete("FacilityPics-LIST");
            string _configPath = NewLife.Configuration.Config.GetConfig("basepath", "");
            if (!Directory.Exists(_configPath))
                Directory.CreateDirectory(_configPath);

            _companyPicsPath = Path.Combine(_configPath, "company-pics");
            if (!Directory.Exists(_companyPicsPath))
                Directory.CreateDirectory(_companyPicsPath);
            //_processPicsTimerX = new TimerX(async obj => { await ProcessPackageAsync(); }, null, 500, 50);//定时处理图片数据
            StartProcess();

            //var next = GetNextPeriod(_period);
            //var dur = next.Subtract(DateTime.Now).TotalMilliseconds;
            //_processTimer = new Timer(obj => StartProcess(), null, Convert.ToInt32(dur), _period * 1000);
            //WriteLog(dur + "秒后启动定时拍照功能");
            //WriteLog("企业定时拍照启动");
            return base.Start();
        }

        public override bool Work()
        {
            //var next = GetNextPeriod(_period);
            //var dur = next.Subtract(DateTime.Now).TotalSeconds;
            //if (dur < JobInterval)
            //    StartProcess();

            return base.Work();
        }

        public override bool Stop()
        {
            //_processTimer.Dispose();
            //WriteLog("企业定时拍照停止");
            return base.Stop();
        }

        public async void StartProcess()
        {
            try
            {
               // var facilitie = _facilityService.GetFacilitiesByFarmId("00012F001");
                //var devices = _deviceService.GetDevicesByFacilityId("00012F001G001");
                if (!Directory.Exists(_companyPicsPath))
                    Directory.CreateDirectory(_companyPicsPath);
                var farms = await _farmService.GetAllAsync();
                farms.ToList().ForEach(farm =>
                {

                    var dep = _sysDepartmentService.GetById(farm.SysDepartmentSerialnum);
                    if (dep != null)
                    {
                        var depPath = GetDepPath(dep);
                        //if (!Directory.Exists(depPath))
                        //    Directory.CreateDirectory(depPath);
                        var facilities = _facilityService.GetFacilitiesByFarmId(farm.Serialnum);
                        facilities.ToList().ForEach(fac =>
                        {
                            //if (!Directory.Exists(Path.Combine(depPath, farm.Serialnum)))
                            //    Directory.CreateDirectory(Path.Combine(depPath, farm.Serialnum));

                            var facilityPath = Path.Combine(depPath, farm.Serialnum, fac.Serialnum);
                            //if (!Directory.Exists(facilityPath))
                            //    Directory.CreateDirectory(facilityPath);
                            var facilityCameras = _facilityCameraService.GetFacilityCamerasByFacilityId(fac.Serialnum);
                            facilityCameras.ToList().ForEach(station =>
                            {
                                try
                                {
                                    CHCNetSDK.NET_DVR_Init();
                                    var userHandle = Login(station.IP, station.DataPort, station.UserID, station.UserPwd);
                                    //var userHandle = Login("120.209.96.139", 20001, "admin", "smt12345");

                                    if (userHandle != -1)
                                    {
                                        //从设备获取预置点
                                        var points = GetCameraPresetPoints(userHandle, station);

                                        var cameraStationPath = Path.Combine(facilityPath, station.IP);
                                        if (!points.Any())
                                        {
                                            var fileName = TakePhoto(userHandle, station.Channel, Path.Combine(_companyPicsPath, cameraStationPath));
                                            Process(fileName, station);
                                        }
                                        else
                                        {
                                            for (int i = 0; i < points.Count(); i++)
                                            {
                                                var point = points.ElementAt(i);
                                                //跳转到预置点
                                                bool success = GotoCameraPreset(userHandle, Convert.ToUInt32(point.PresetPoint));
                                                if (success)
                                                {
                                                    //等3秒聚焦
                                                    Thread.Sleep(3000);
                                                    //拍照
                                                    var fileName = TakePhoto(userHandle, station.Channel, Path.Combine(_companyPicsPath, cameraStationPath), i + 1);
                                                    //处理文件对应的记录
                                                    Process(fileName, station);
                                                }
                                            }
                                        }

                                        CHCNetSDK.NET_DVR_Logout(userHandle);
                                    }
                                    //设备运行记录
                                    var record = new FacilityCameraRunLogDto
                                    {
                                        //Serialnum = Guid.NewGuid().ToString(),
                                        FacilityCameraSerialnum = station.Serialnum,
                                        Status = userHandle > -1
                                    };
                                    _facilityCameraRunLogRepService.AddRunLog(record);
                                    //统计数据
                                    var list = _facilityCameraRunStatisticsRepService.GetByFacilityCameraIdAndYearAndMonth(station.Serialnum,
                                       DateTime.Now.Year, DateTime.Now.Month);
                                    var statistics = new FacilityCameraRunStatisticsDto();
                                    statistics.AllCount++;
                                    if (userHandle > -1)
                                        statistics.OnlineCount++;
                                    statistics.OnlinePercent = Math.Round((statistics.OnlineCount * 1M) / (statistics.AllCount * 1M), 1) * 100M;
                                    if (list == null || !list.Any())
                                    {
                                        //statistics.Serialnum = Guid.NewGuid().ToString();
                                        statistics.FacilityCameraSerialnum = station.Serialnum;
                                        statistics.Year = DateTime.Now.Year;
                                        statistics.Month = DateTime.Now.Month;
                                        _facilityCameraRunStatisticsRepService.Add(statistics);
                                    }
                                    else
                                    {
                                        list.ToList().ForEach(logs => {
                                            logs.AllCount++;
                                            if (userHandle > -1)
                                                logs.OnlineCount++;
                                            logs.OnlinePercent = Math.Round((logs.OnlineCount * 1M) / (logs.AllCount * 1M), 1) * 100M;
                                            _facilityCameraRunStatisticsRepService.Update(logs);
                                        });
                                    }

                                }
                                catch (Exception ex)
                                {
                                    XTrace.WriteException(ex);
                                }
                                finally
                                {
                                    // CHCNetSDK.NET_DVR_Cleanup();
                                }
                            });
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                
              //  throw;
            }
          
        }

        private  void Process(string fileName, FacilityCameraDto cam)
        {
            try
            {
                var preset = _facilityCameraPresetPoinService.GetByCameraId(cam.Serialnum);//根据摄像机编码获取摄像机预置点信息（一个摄像机只能有一个预置点？？？）

                PictureRepDto pic = new PictureRepDto
                {
                    Serialnum = Guid.NewGuid().ToString(),
                    Type = "Facility",
                    Title = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    Description = "",
                    Url = Path.Combine(_companyPicsPath, fileName),
                    Href = "company-pics" + fileName.Replace(_companyPicsPath, "").Replace("\\", "/"),
                    CreateTime = DateTime.Now
                };

                //RedisClient.Sadd("PicsRep-LIST", pic,DataType.Protobuf);
                _pictureRepService.Add(pic);
                if (preset != null)
                {
                    FacilityPicsDto fp = new FacilityPicsDto
                    {
                        Serialnum = Guid.NewGuid().ToString(),
                        FacilityCameraPresetSerialnum = preset.Serialnum,
                        FacilitySerialnum = cam.FacilitySerialnum,
                        PicSerialnum = pic.Serialnum,
                        CreateTime = DateTime.Now
                    };

                    //RedisClient.Sadd("FacilityPics-LIST", fp, DataType.Protobuf);
                    _facilityPicsRepService.Add(fp);
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
         
        }

        /// <summary>
        ///     分析数据包，并将数据放到Redis中
        /// </summary>
        /// <returns></returns>
        //private async Task ProcessPackageAsync()
        //{
        //    try
        //    {
        //        var redisClient = RedisClient.DefaultDB;
        //        var picsRepList = redisClient.Smember<PictureRepDto>("PicsRep-LIST",DataType.Protobuf);
        //        if (picsRepList != null && picsRepList.Any())
        //        {
        //            picsRepList.ForEach(picsRep =>
        //            {            
        //                var r = redisClient.Srem("PicsRep-LIST", picsRep, DataType.Protobuf);
        //                if (r > 0)
        //                {
        //                     _pictureRepService.Add(picsRep);
        //                    //var task = app.ProcessAsync();
        //                }
        //            });
        //        }

        //        var facilityPicsList = redisClient.Smember<FacilityPicsDto>("FacilityPics-LIST", DataType.Protobuf);
        //        if (facilityPicsList != null && facilityPicsList.Any())
        //        {
        //            facilityPicsList.ForEach( pics =>
        //            {
        //                var r = redisClient.Srem("FacilityPics-LIST", pics, DataType.Protobuf);
        //                if (r > 0)
        //                {
        //                    _facilityPicsRepService.Add(pics);
        //                    //var task = app.ProcessAsync();
        //                }
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}


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

            if (is64bit)
            {
                CopyLib(_64path);
            }
            else
            {
                CopyLib(_86path);
            }
        }

        public void CopyLib(String path)
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
                    WriteLog("加载拍照外接程序集");
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
            WriteLog("开始处理摄像机：{0}:{1}", ip, port);
#endif
            Int32 userHandle = CHCNetSDK.NET_DVR_Login_V30(ip, port, uid, pwd, ref DEV);
            if (userHandle == -1)
            {
                WriteLog("登录失败：{0}:{1}-{2}-{3}", ip, port, uid, pwd);
            }
            else
            {
#if DEBUG
                WriteLog("登录成功");
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
            CHCNetSDK.DVR_USER_LOGIN_INFO dvrUserLoginInfo = new CHCNetSDK.DVR_USER_LOGIN_INFO();
            dvrUserLoginInfo.sDeviceAddress = ip;
            dvrUserLoginInfo.wPort = Convert.ToInt16(port);
            dvrUserLoginInfo.sUserName = uid;
            dvrUserLoginInfo.sPassword = pwd;
            dvrUserLoginInfo.bUseAsynLogin = false;
            dvrUserLoginInfo.fLoginResultCallBack = IntPtr.Zero;

            CHCNetSDK.DVR_DEVICEINFO_V40 dvrDeviceinfoV40 = new CHCNetSDK.DVR_DEVICEINFO_V40();
            dvrDeviceinfoV40.struDeviceV30 = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

#if DEBUG
            WriteLog("开始处理摄像机：{0}:{1}", ip, port);
#endif
            Int32 userHandle = CHCNetSDK.NET_DVR_Login_V40(dvrUserLoginInfo, ref dvrDeviceinfoV40);
            if (userHandle == -1)
            {
                WriteLog("登录失败：{0}:{1}-{2}-{3}", ip, port, uid, pwd);
            }
            else
            {
#if DEBUG
                WriteLog("登录成功");
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
        private  IEnumerable<FacilityCameraPresetPointDto> GetCameraPresetPoints(int userHandle, FacilityCameraDto facilityCamera)
        {
            try
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
                    WriteLog("读取预置点失败 错误码{0}", errorCode);

                    return Enumerable.Empty<FacilityCameraPresetPointDto>();
                }
                else
                {
                    WriteLog("读取预置点成功");
                }
                cameraPreset = (CHCNetSDK.NET_DVR_GET_PRESET_NAMES)Marshal.PtrToStructure(ptrNetCfg, typeof(CHCNetSDK.NET_DVR_GET_PRESET_NAMES));
                //只取前3个
                var points = cameraPreset.StructAs.AsEnumerable().Take(5);

                List<FacilityCameraPresetPointDto> list = new List<FacilityCameraPresetPointDto>();

                var netDvrGetPresetNames = points as CHCNetSDK.NET_DVR_GET_PRESET_NAME[] ?? points.ToArray();
                for (int i = 0; i < netDvrGetPresetNames.Count(); i++)
                {
                    var p = netDvrGetPresetNames.ElementAt(i);
                    //var positon = p.wPresetNum; //设备返回的位置，只要不是0，即为处于使用状态
                    //if (!positon.Equals(0))
                    //{
                    var name = Encoding.Default.GetString(p.byName).Trim();
                    var preset = _facilityCameraPresetPoinService.GetByPointAndId(facilityCamera.Serialnum, i + 1);
                    if (preset == null)
                    {
                        preset = new FacilityCameraPresetPointDto
                        {
                            Serialnum = Guid.NewGuid().ToString(),
                            FacilityCameraSerialnum = facilityCamera.Serialnum,
                            Name = name,
                            PresetPoint = i + 1
                        };
                        _facilityCameraPresetPoinService.Add(preset);
                    }
                    else
                    {
                        if (preset.Name.Equals(name))
                            preset.Name = name;
                        _facilityCameraPresetPoinService.Update(preset);
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
            catch (Exception ex)
            {
                
                throw;
            }
          
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
                WriteLog("设置预置点信息失败");
#endif
                var errorCode = CHCNetSDK.NET_DVR_GetLastError();
                WriteLog("错误码{0}", errorCode);
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
                    WriteLog("拍照成功");
#endif
                }
                else
                {
                    var error = CHCNetSDK.NET_DVR_GetLastError();
                    WriteLog("拍照失败,错误码：{0}", error);
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
                    WriteLog("拍照成功");
#endif
                }
                else
                {
                    var error = CHCNetSDK.NET_DVR_GetLastError();
                    WriteLog("拍照失败,错误码：{0}", error);
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
        private  string GetDepPath(SysDepartmentDto dep, string tempPath = "")
        {
            if (dep != null)
            {
                SysDepartmentDto parent = null;
                if (dep.ParentSerialnum != null)
                {
                    parent =  _sysDepartmentService.GetParentByParentId(dep.ParentSerialnum); 
                }
         
                var p = dep.Name;
                var p2 = "";
                if (parent == null) { p2 = Path.Combine(tempPath, p); }
                else
                {
                    p2 = Path.Combine( GetDepPath(parent), tempPath, p);
                }
                if (!Directory.Exists(Path.Combine(_companyPicsPath, p2)))
                {
                    Directory.CreateDirectory(Path.Combine(_companyPicsPath, p2));
                    WriteLog("创建企业图库目录:" + Path.Combine(_companyPicsPath, p2));
                }
                return p2;
            }
            return null;
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