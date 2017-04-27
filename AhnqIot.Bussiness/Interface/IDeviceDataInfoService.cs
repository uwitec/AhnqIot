using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
   public interface IDeviceDataInfoService:IService<DeviceDataInfoDto>
    {
        /// <summary>
        /// 根据设备编码获取设备历史记录
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        Task<IEnumerable<DeviceDataInfoDto>> GetDeviceDataInfoByDeviceIdAsny(string deviceId);

        /// <summary>
        /// 添加设备历史数据
        /// </summary>
        /// <param name="dtos">设备历史数据实体</param>
        /// <returns></returns>
        Task<bool> AddDeviceDataInfos(List<DeviceDataInfoDto> dtos);

        /// <summary>
        /// 添加设备历史数据2
        /// </summary>
        /// <param name="dto">设备历史数据实体集合</param>
        /// <returns></returns>
        Task<bool> AddDeviceDataInfo2(IEnumerable<DeviceDataInfoDto> dto);
    }
}
