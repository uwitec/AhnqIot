using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
    public interface IDeviceControlCommandService : IService<DeviceControlCommandDto>
    {
        /// <summary>
        /// 根据设备编码获取控制指令
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        Task<DeviceControlCommandDto> GetControlCommandByDeviceIdAsny(string deviceId);
        /// <summary>
        /// 添加控制指令
        /// </summary>
        /// <param name="dto">控制指令</param>
        /// <returns></returns>
        Task<bool> AddControlCommandAsny(DeviceControlCommandDto dto);
        /// <summary>
        /// 根据设施编码获取所有设备控制指令
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        List<DeviceControlCommandDto> GetDeviceControlCmdsByFacilityId(string facilityId);
        /// <summary>
        /// 根据编码获取控制指令
        /// </summary>
        /// <param name="id">指令编码</param>
        /// <returns></returns>
        Task<DeviceControlCommandDto> GetDeviceControlCmdByIdAsny(string id);
        /// <summary>
        /// 更新控制指令
        /// </summary>
        /// <param name="dto">控制指令实体</param>
        /// <returns></returns>
        Task<bool> UpdateControlCommandAsny(DeviceControlCommandDto dto);
    }
}
