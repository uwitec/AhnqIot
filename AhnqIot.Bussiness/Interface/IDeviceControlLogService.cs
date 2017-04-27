using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
   public interface IDeviceControlLogService:IService<DeviceControlLogDto>
    {
        /// <summary>
        /// 添加设备控制日志
        /// </summary>
        /// <param name="dto">设备控制日至实体</param>
        /// <returns></returns>
        Task<bool> AddControlLog(DeviceControlLogDto dto);
    }
}
