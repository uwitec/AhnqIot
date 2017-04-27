using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
    public interface IDeviceRunLogService : IService<DeviceRunLogDto>
    {
        /// <summary>
        /// 添加设备运行日志
        /// </summary>
        /// <param name="dtos">设备运行日志实体</param>
        /// <returns></returns>
        Task<bool> AddDeviceRunLog(List<DeviceRunLogDto> dtos);

        /// <summary>
        /// 处理设备运行记录
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        Task<bool> ProcessDeviceRunLogAsync(List<DeviceRunLogDto> dtos);
    }
}
