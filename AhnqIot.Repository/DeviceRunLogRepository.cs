using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
  public  class DeviceRunLogRepository
    {
        /// <summary>
        /// 根据设备编码查找设备运行日志
        /// </summary>
        /// <param name="deviceSerialnum">设备编码</param>
        /// <returns></returns>
        public IEnumerable<DeviceRunLog> GetBySerialnum(string deviceSerialnum)
        {
            if (string.IsNullOrWhiteSpace(deviceSerialnum)) throw new ArgumentNullException("deviceSerialnum");
           return DeviceRunLog.FindAllByDeviceSerialnum(deviceSerialnum);
        }
    }
}
