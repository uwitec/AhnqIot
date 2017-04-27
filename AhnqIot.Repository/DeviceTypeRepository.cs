using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;
namespace AhnqIot.Repository
{
  public  class DeviceTypeRepository
    {
        /// <summary>
        /// 获取所有的设备类型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DeviceType> Get()
        {
            return DeviceType.FindAll();
        }
    }
}
