using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;
using AhnqIot.Repository.Model;
namespace AhnqIot.Repository
{
    public class DeviceDataInfoRepository
    {
        /// <summary>
        /// 根据设备编码查找设备数据历史记录
        /// </summary>
        /// <param name="deviceSerialnum">设备编码</param>
        /// <returns></returns>
        public IEnumerable<DeviceDataInfo> GetBySerialnum(string deviceSerialnum)
        {
            if (string.IsNullOrWhiteSpace(deviceSerialnum)) throw new ArgumentNullException("deviceSerialnum");
            return DeviceDataInfo.FindAllByDeviceSerialnum(deviceSerialnum);
        }
        /// <summary>
        /// 添加设备历史数据
        /// </summary>
        /// <param name="deviceData">设备数据实体</param>
        /// <returns></returns>
        public bool AddDeviceData(IEnumerable<DeviceDataModel> deviceData)
        {
            var result = false;
            if (deviceData.Count() <= 0 || !deviceData.Any()) result= false;
            try
            {
                deviceData.ToList().ForEach(dd =>
                {
                    var ddi = new DeviceDataInfo
                    {
                        DeviceSerialnum = dd.Serialnum,
                        CreateTime = dd.CreateTime,
                        UpdateTime = DateTime.Now,
                        Serialnum = dd.Serialnum + "-" + dd.CreateTime,
                        ShowValue = dd.ShowValue,
                        OriginalData = dd.OriginalData,
                        ProcessedValue = dd.ProcessedValue,
                    };
                    ddi.Save();
                });
                result = true;
            }
            catch (Exception ex)
            {

                //throw;
                result = false;
                
            }
            return result;

        }
    }
}
