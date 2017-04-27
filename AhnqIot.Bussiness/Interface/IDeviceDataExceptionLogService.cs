using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
   public interface IDeviceDataExceptionLogService:IService<DeviceDataExceptionLogDto>
    {
        /// <summary>
        /// 根据设备编码获取设备数据异常记录
        /// </summary>
        /// <param name="deviceId">基地编码</param>
        /// <returns></returns>
        Task<DeviceDataExceptionLogDto> GetDeviceDataExceptionLogByDeviceIdAsny(string deviceId);
        /// <summary>
        /// 添加设备异常日志
        /// </summary>
        /// <param name="dtos">设备异常日志实体</param>
        /// <returns></returns>
        Task<bool> AddDeviceDataExceptionLog(List<DeviceDataExceptionLogDto> dtos);
    }
}
