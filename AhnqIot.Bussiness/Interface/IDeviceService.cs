#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： IDeviceService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-28 11:19
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

#endregion

namespace AhnqIot.Bussiness.Interface
{
    public interface IDeviceService : IService<DeviceDto>
    {
        /// <summary>
        ///     根据编码获取设备
        /// </summary>
        /// <param name="id">设备编码</param>
        /// <returns></returns>
        Task<DeviceDto> GetDeviceByIdAsny(string id);

        /// <summary>
        ///     根据lamda条件获取所有设备
        /// </summary>
        /// <returns></returns>
        Task<DeviceDto> GetDeviceAsny(Expression<Func<DeviceDto, bool>> where);

        /// <summary>
        ///     添加设备
        /// </summary>
        /// <param name="dto">设备实体</param>
        /// <returns></returns>
        Task<bool> AddDevice(DeviceDto dto);

        /// <summary>
        ///     更新设备
        /// </summary>
        /// <param name="dto">设备实体</param>
        /// <returns></returns>
        Task<bool> UpdateDevice(DeviceDto dto);

        /// <summary>
        ///     根据设施编码获取所有设备
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        IEnumerable<DeviceDto> GetDevicesByFacilityId(string facilityId);

        /// <summary>
        ///     根据设施编码获取所有设备
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        Task<IEnumerable<DeviceDto>> GetDevicesByFacilityIdAsync(string facilityId);

        /// <summary>
        /// 检验编码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool CheckCode(string code);


    }
}