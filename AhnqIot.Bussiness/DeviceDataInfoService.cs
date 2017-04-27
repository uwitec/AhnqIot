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
    public class DeviceDataInfoService : ServiceBase<DeviceDataInfo,DeviceDataInfoDto> ,IDeviceDataInfoService
    {
        //private readonly IAhnqIotRepository<DeviceDataInfo> _deviceDataInfoRep;
        public DeviceDataInfoService(IAhnqIotRepository<DeviceDataInfo> deviceDataInfoRep)
        {
            //_deviceDataInfoRep = deviceDataInfoRep;
        }
        /// <summary>
        /// 添加设备历史数据
        /// </summary>
        /// <param name="dtos">设备历史数据实体</param>
        /// <returns></returns>
        public async Task<bool> AddDeviceDataInfos(List<DeviceDataInfoDto> dtos)
        {
            try
            {
                var deviceDataInfos = GetDbModels(dtos);   
                 Repository.Add(deviceDataInfos);
                return await Repository.CommitAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
                //throw;
            }
  
        }
        /// <summary>
        /// 根据设备编码获取设备历史记录
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DeviceDataInfoDto>> GetDeviceDataInfoByDeviceIdAsny(string deviceId)
        {
            return GetDtoModels(await Repository.GetManyAsync(ddi => ddi.DeviceSerialnum.Equals(deviceId)));
        }
        /// <summary>
        /// 添加设备历史数据2
        /// </summary>
        /// <param name="dto">设备历史数据实体集合</param>
        /// <returns></returns>
        public async Task<bool> AddDeviceDataInfo2(IEnumerable<DeviceDataInfoDto> dto)
        {
            var result = false;
            if (!dto.Any()) return result;
            foreach (var ddi in dto)
            {
                var d = GetDbModel(ddi);
                Repository.Add(d);
                result = await Repository.CommitAsync() > 0;
            }

            return result;
        }
    }
}
