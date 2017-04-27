using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
   public interface IDeviceRunLogTypeService:IService<DeviceRunLogTypeDto>
    {
        /// <summary>
        /// 获取所有的设备运行日志类型
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DeviceRunLogTypeDto>> GetDeviceRunLogTypesAsny();
    }
}
