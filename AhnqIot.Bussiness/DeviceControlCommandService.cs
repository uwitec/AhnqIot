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
public  class DeviceControlCommandService: ServiceBase<DeviceControlCommand,DeviceControlCommandDto>, IDeviceControlCommandService
    {
    public IAhnqIotRepository<Device> DevicepRep  { get; set; }

          public IDeviceService _deviceService { get; set; }
        public DeviceControlCommandService(IAhnqIotRepository<DeviceControlCommand> deviceControlCommandRep )
        {
            //_deviceControlCommandRep = deviceControlCommandRep;
            //_deviceService = deviceService;
        }


        //private static IDeviceService _deviceService;
        /// <summary>
        /// 根据设备编码获取控制指令
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        public async Task<DeviceControlCommandDto> GetControlCommandByDeviceIdAsny(string deviceId)
        {
            return GetDtoModel(await Repository.GetAsync(dc => dc.DeviceSerialnum.Equals(deviceId)));
        }
        /// <summary>
        /// 添加控制指令
        /// </summary>
        /// <param name="dto">控制指令</param>
        /// <returns></returns>
        public async Task<bool> AddControlCommandAsny(DeviceControlCommandDto dto)
        {
            var deviceControlCommand = GetDbModel(dto);
            Repository.Add(deviceControlCommand);
            return await Repository.CommitAsync() > 0;
        }
        /// <summary>
        /// 根据设施编码获取所有设备控制指令
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        public List<DeviceControlCommandDto> GetDeviceControlCmdsByFacilityId(string facilityId)
        {
            try
            {
                var  cmds = new List<DeviceControlCommandDto>();
                var devices = _deviceService.GetDevicesByFacilityId(facilityId).Where(d => d.DeviceTypeSerialnum.Contains("control"));//需要重写
                if (devices.Any())
                {
                    foreach (var device in devices)
                    {
                        var item= Repository.GetById(device.Serialnum);
                        DeviceControlCommandDto cmd=null;
                        if (item != null)
                        {
                            cmd = GetDtoModel(item);
                        }
                        if (cmd != null) cmds.Add(cmd);
                    }
                }
                return cmds;
            }
            catch (Exception ex)
            {

                return null;
            }
           
        }

        /// <summary>
        /// 根据编码获取控制指令
        /// </summary>
        /// <param name="id">指令编码</param>
        /// <returns></returns>
       public async Task<DeviceControlCommandDto> GetDeviceControlCmdByIdAsny(string id)
        {
            return Mapper.Map<DeviceControlCommandDto>(await Repository.GetAsync(dc => dc.Serialnum.Equals(id)));
        }

        /// <summary>
        /// 更新控制指令
        /// </summary>
        /// <param name="dto">控制指令实体</param>
        /// <returns></returns>
      public async  Task<bool> UpdateControlCommandAsny(DeviceControlCommandDto dto)
        {
            var deviceControlCommand =GetDbModel(dto);
            Repository.Update(deviceControlCommand);
            return await Repository.CommitAsync() > 0;
        }
    }
}
