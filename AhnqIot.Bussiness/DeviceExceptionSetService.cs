using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.Repository.AhnqIot;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AutoMapper;
using System.Linq.Expressions;
using AhnqIot.Bussiness.Core;

namespace AhnqIot.Bussiness
{
    public class DeviceExceptionSetService :ServiceBase<DeviceExceptionSet,DeviceExceptionSetDto>, IDeviceExceptionSetService
    {
        //private readonly IAhnqIotRepository<DeviceExceptionSet> _deviceExceptionSetRep;
        public DeviceExceptionSetService(IAhnqIotRepository<DeviceExceptionSet> deviceExceptionSetRep) { /*this._deviceExceptionSetRep = deviceExceptionSetRep;*/ }
        /// <summary>
        /// 根据设备编码获取设备参数最新异常区间
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        public async Task<DeviceExceptionSetDto> GetDeviceExceptionSetByDeviceIdAsny(string deviceId)
        {
            return GetDtoModel((await Repository.GetManyAsync(des => des.DeviceSerialnum.Equals(deviceId))
                ).ToList().OrderByDescending(e => e.CreateTime).FirstOrDefault());
        }
        /// <summary>
        /// 根据设备编码获取设备参数最新异常区间
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        public DeviceExceptionSetDto GetDeviceExceptionSetByDeviceId(string deviceId)
        {
            return GetDtoModel((Repository.GetMany(des => des.DeviceSerialnum.Equals(deviceId))
                ).ToList().OrderByDescending(e => e.CreateTime).FirstOrDefault());
        }
        /// <summary>
        /// 根据设备编码获取设备参数异常区间
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        public IEnumerable<DeviceExceptionSetDto> GetDeviceExceptionSetsByDeviceId(string deviceId)
        {
            return GetDtoModels(Repository.GetMany(des => des.DeviceSerialnum.Equals(deviceId)));
        }

        /// <summary>
        /// 根据设备编码获取设备参数异常区间
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        public async Task<IEnumerable<DeviceExceptionSetDto>> GetDeviceExceptionSetsByDeviceIdAsny(string deviceId)
        {
            return GetDtoModels(await Repository.GetManyAsync(des => des.DeviceSerialnum.Equals(deviceId)));
        }

        /// <summary>
        /// 添加设备异常区间
        /// </summary>
        /// <param name="dto">设备异常区间实体</param>
        /// <returns></returns>
        public async Task<bool> AddDeviceExceptionSet(DeviceExceptionSetDto dto)
        {
            try
            {
                var deviceExceptionSet = GetDbModel(dto);
                Repository.Add(deviceExceptionSet);
                return await Repository.CommitAsync() > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        /// <summary>
        /// 更新设备异常区间
        /// </summary>
        /// <param name="dto">设备异常区间</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsny(DeviceExceptionSetDto dto)
        {
            try
            {
                var deviceExceptionSet = GetDbModel(dto);
                Repository.Update(deviceExceptionSet);
                return await Repository.CommitAsync() > 0;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
