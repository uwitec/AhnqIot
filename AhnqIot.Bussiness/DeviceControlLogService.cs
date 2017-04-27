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
  public  class DeviceControlLogService:ServiceBase<DeviceControlLog,DeviceControlLogDto>, IDeviceControlLogService
    {
        //private readonly IAhnqIotRepository<DeviceControlLog> _deviceControlLogRep;
        public DeviceControlLogService() { }
        /// <summary>
        /// 添加设备控制日志
        /// </summary>
        /// <param name="dto">设备控制日至实体</param>
        /// <returns></returns>
      public async  Task<bool> AddControlLog(DeviceControlLogDto dto)
        {
            var deviceControlLogDto = GetDbModel(dto);
            Repository.Add(deviceControlLogDto);
            return await Repository.CommitAsync() > 0;
        }
    }
}
