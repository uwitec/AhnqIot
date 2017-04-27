using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
  public  interface IDeviceExceptionSetService:IService<DeviceExceptionSetDto>
    {
        /// <summary>
        /// 根据设备编码获取设备参数最新异常区间
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        Task<DeviceExceptionSetDto> GetDeviceExceptionSetByDeviceIdAsny(string deviceId);
        /// <summary>
        /// 根据设备编码获取设备参数最新异常区间
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        DeviceExceptionSetDto GetDeviceExceptionSetByDeviceId(string deviceId);
        /// <summary>
        /// 根据设备编码获取设备参数异常区间
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        IEnumerable<DeviceExceptionSetDto> GetDeviceExceptionSetsByDeviceId(string deviceId);
        /// <summary>
        /// 根据设备编码获取设备参数异常区间
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        Task<IEnumerable<DeviceExceptionSetDto>> GetDeviceExceptionSetsByDeviceIdAsny(string deviceId);
        /// <summary>
        /// 添加设备异常区间
        /// </summary>
        /// <param name="dto">设备异常区间实体</param>
        /// <returns></returns>
        Task<bool> AddDeviceExceptionSet(DeviceExceptionSetDto dto);
        /// <summary>
        /// 更新设备异常区间
        /// </summary>
        /// <param name="dto">设备异常区间</param>
        /// <returns></returns>
        Task<bool> UpdateAsny(DeviceExceptionSetDto dto);
    }
}
