using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
   public class DeviceRunLogTypeRepository
    {
        /// <summary>
        /// 获取所有的设备运行日志类型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DeviceRunLogType> GetAll()
        {
            return DeviceRunLogType.FindAll();
        }
    }
}
