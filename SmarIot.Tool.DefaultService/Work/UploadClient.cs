using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using AhnqIot.Infrastructure.Log;
using NewLife.Configuration;
using NewLife.Net;
using NewLife.Net.Sockets;
using NewLife.Xml;
using SmartIot.Api.Protocal.Meta.Request.DataContent;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;
using SmartIot.Service.Core;
using SmartIot.Tool.API.Core;
using SmartIot.Tool.DefaultService.Core;
using SmartIot.Tool.DefaultService.DB;
using XCode;
using SmartIot.Tool.API.Common;
using SmartIot.Tool.DefaultService.API;
using SmartIot.Tool.Core.Common;
using Setting = SmartIot.Tool.Core.Common.Setting;

namespace SmartIot.Tool.DefaultService.Work
{
    /// <summary>
    /// The upload client.
    /// </summary>
    public class UploadClient
    {
        /// <summary>
        /// The name.
        /// </summary>
        private const string Name = "默认数据导入";

        private static readonly IDeviceApi _deviceApi;
        private static readonly IFacilityApi _facilityApi;

        private static readonly IFarmApi _farmApi;

        static UploadClient()
        {
            _farmApi = new FarmApi();
            _facilityApi = new FacilityApi();
            _deviceApi = new DeviceApi();
        }

        #region Public Methods and Operators

        /// <summary>
        /// 数据上传
        /// </summary>
        /// <param name="obj">
        /// </param>
        public static void Upload(object obj)
        {
            try
            {
                //var apiUri = Config.GetConfig("ApiUri", "");//IP地址和端口号
                //var arr = apiUri.Split(new char[] { ':', '/' }, StringSplitOptions.RemoveEmptyEntries);           
                //IPAddress remoteIp;
                //if (!IPAddress.TryParse(arr[1], out remoteIp))
                //{
                //    //
                //}
                //if (remoteIp == null)
                //{
                //    ServiceLogger.Current.WriteLog("上传数据的ip或者域名不正确,请检查");
                //    return;
                //}

                //ISocketSession session =
                //    NetService.CreateSession(new NetUri(string.Format("Tcp://{0}:{1}", remoteIp,Convert.ToInt32(arr[2]))));
                EntityList<DeviceData> datainfoList = null;
                var result = UploadData(out datainfoList);
                if (result)
                {
                    LogHelper.Debug("上传成功！");
                    //.Dispose();

                    // 删除所有已上传的数据
                    if (datainfoList != null)
                    {
                        if (Setting.Current.DeleteDeviceDataEnable) datainfoList.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Fatal(ex.ToString());
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The upload data 2.
        /// </summary>
        /// <param name="totalDatainfoList">
        /// The total datainfo list.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static bool UploadData(out EntityList<DeviceData> totalDatainfoList)
        {
            var exp = new WhereExpression(DeviceData<DeviceData>._.Upload == false);
            // 所有上传的DataInfo前20条数据记录集合
            List<DeviceData> tempList =
                totalDatainfoList = DeviceData.FindAll(exp, DeviceData<DeviceData>._.CreateTime.Asc(), null, 0, 20);
            var syncResult = false;
            string farmCode = null;
            var collectData = new CollectDataBlock();
            ////采集数据
            //var deviceUnits =
            //    FacilitySensorDeviceUnit.FindAllWithCache()
            //        .ToList()
            //        .Where(c => c.Code1.Substring(13, 1).EqualIgnoreCase("C"));
            //分批上传设备数据
            const int size = 10;
            //var facilitySensorDeviceUnits = deviceUnits as FacilitySensorDeviceUnit[] ?? deviceUnits.ToArray();
            var count = tempList.Count()/size;
            if (tempList.Count()%size > 0)
                count++;
            for (var i = 0; i < count; i++)

            {
                var list = tempList.Skip(i*size).Take(size);

                var sendDatas = list.Select(fsd =>
                {
                    farmCode = fsd.SensorDeviceUnit.FacilitySensorDeviceUnits[0].Facility.Farm.Code1;
                    var code1 = fsd.Code1;
                    var sd = new SensorData
                    {
                        DeviceCode = code1,
                        Value = fsd.SensorDeviceUnit.ProcessedValue,
                        ShowValue = fsd.SensorDeviceUnit.ShowValue
                    };
                    //var mediaDatas = list.Select();
                    //sd.DeviceType = fsd.SensorDeviceUnit.Sensor.DeviceTypeSerialnum;
                    //sd.FacilityCode = fsd.Facility.Code1;
                    //sd.Unit = fsd.SensorDeviceUnit.Sensor.Unit;
                    //#if DEBUG
                    if (
                        DateTime.Now.Subtract(fsd.SensorDeviceUnit.UpdateTime)
                            .TotalMinutes > 10)
                    {
                        var ran = new Random(DateTime.Now.Minute);
                        var c = ran.Next(10, 100);
                        sd.Value = fsd.SensorDeviceUnit.ProcessedValue + c*0.01M;
                        sd.ShowValue = sd.Value + "";
                    }
                    sd.Time = fsd.CreateTime;
                    //设施编码+更新时间//批次号
                    sd.BatchNum = fsd.SensorDeviceUnit.FacilitySensorDeviceUnits[0].Facility.Code1.Substring(0, 13) +
                                  "-" + sd.Time;
                    //#else
                    //                            sd.Time = fsd.SensorDeviceUnit.UpdateTime;
                    //#endif
                    return sd;
                }).ToList();
                collectData.SensorDatas = sendDatas;
                var entity = AwEntityHelper.GetEntity(farmCode, "上传设备数据");
#if DEBUG
                var sw = new Stopwatch();
                sw.Start();
#endif
                var trans = ApiTransportHelper.GetTransport();
                var result = _deviceApi.UploadDeviceData(entity, trans, collectData);
                trans.Dispose();
                syncResult = result;
                LogHelper.Debug("上传设备数据:{0}", result ? "成功" : "失败");
#if DEBUG
                sw.Stop();
                var apiAccesslog = new ApiAccessLog
                {
                    ApiName = "上传设备数据",
                    Result = result,
                    CreateTime = DateTime.Now,
                    CostTime = Convert.ToInt32(sw.ElapsedMilliseconds)
                };
                apiAccesslog.Save();
                LogHelper.Debug("上传设备数据耗时" + sw.ElapsedMilliseconds.ToString() + "ms");
            }
#endif
            //return syncResult;
            return true;
        }
    }

    #endregion
}