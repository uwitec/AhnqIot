using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.Repository.AhnqIot;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AutoMapper;
namespace AhnqIot.Bussiness
{
  public class DeviceDataExceptionLogService:ServiceBase<DeviceDataExceptionLog,DeviceDataExceptionLogDto>, IDeviceDataExceptionLogService
    {
        public DeviceDataExceptionLogService(IAhnqIotRepository<DeviceDataExceptionLog> deviceDataExceptionLogRep)
        {
            //_deviceDataExceptionLogRep = deviceDataExceptionLogRep;
        }
        //private readonly IAhnqIotRepository<DeviceDataExceptionLog> _deviceDataExceptionLogRep;
        /// <summary>
        /// 根据设备编码获取设备数据异常记录
        /// </summary>
        /// <param name="deviceId">基地编码</param>
        /// <returns></returns>
        public async  Task<DeviceDataExceptionLogDto> GetDeviceDataExceptionLogByDeviceIdAsny(string deviceId)
        {
            return GetDtoModel(await Repository.GetAsync(ddl => ddl.DeviceSerialnum.Equals(deviceId)));
        }
        /// <summary>
        /// 添加设备异常日志
        /// </summary>
        /// <param name="dtos">设备异常日志实体</param>
        /// <returns></returns>
       public async Task<bool> AddDeviceDataExceptionLog(List<DeviceDataExceptionLogDto> dtos)
        {
            var deviceExceptionLogs = GetDbModels(dtos);
            Repository.Add(deviceExceptionLogs);
            return await Repository.CommitAsync() > 0;
        }
    }
}
