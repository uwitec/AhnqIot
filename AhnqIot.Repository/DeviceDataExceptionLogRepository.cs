using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
  public  class DeviceDataExceptionLogRepository
    {
        /// <summary>
        /// 根据设备编码查找设备数据异常记录
        /// </summary>
        /// <param name="deviceSerialnum">设备编码</param>
        /// <returns></returns>
        public IEnumerable<DeviceDataExceptionLog> GetBySerialnum(string deviceSerialnum)
        {
            if (string.IsNullOrWhiteSpace(deviceSerialnum)) throw new ArgumentNullException("deviceSerialnum");
            return DeviceDataExceptionLog.FindAllByDeviceSerialnum(deviceSerialnum);
        }
    }
}
