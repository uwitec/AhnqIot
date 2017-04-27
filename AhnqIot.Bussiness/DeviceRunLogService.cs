using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Hxj.Repository.AhnqIot;
using Autofac;
using AutoMapper;
namespace AhnqIot.Bussiness
{
    public class DeviceRunLogService :ServiceBase<DeviceRunLog,DeviceRunLogDto>, IDeviceRunLogService
    {
        public  IAhnqIotRepository<DeviceRunLogType> _deviceRunLogTypeRep { get; set; }
        //private readonly IAhnqIotRepository<DeviceRunLogType> _deviceRunLogTypeRep;
        public DeviceRunLogService(IAhnqIotRepository<DeviceRunLog> deviceRunLogRep)
        {
            //_deviceRunLogRep = deviceRunLogRep;
            //_deviceRunLogTypeRep = AhnqIotContainer.Container.Resolve<IAhnqIotRepository<DeviceRunLogType>>();
            //_deviceRunLogRep = AhnqIotContainer.Container.Resolve<IAhnqIotRepository<DeviceRunLog>>();
        }
        /// <summary>
        /// 添加设备运行日志
        /// </summary>
        /// <param name="dtos">设备运行日志实体</param>
        /// <returns></returns>
        public async Task<bool> AddDeviceRunLog(List<DeviceRunLogDto> dtos)
        {
            try
            {
                var deviceRunLogs = GetDbModels(dtos); 
                Repository.Add(deviceRunLogs);
                return await Repository.CommitAsync() > 0;
            }
            catch (Exception ex)
            {               
                //throw;
                return false;
            }

        }

        /// <summary>
        /// 处理设备运行日志(此方法能自动分析日志类型)
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public async Task<bool> ProcessDeviceRunLogAsync(List<DeviceRunLogDto> dtos)
        {
            var deviceRunLogDtos = new List<DeviceRunLogDto>();
            dtos.ForEach( dto =>
            {
                var normal =

                        _deviceRunLogTypeRep.Get(
                            e => e.Name.Equals(DeviceRunLogTypeService.LogTypeEnum.正常.ToString()));
                dto.DeviceRunLogTypeSerialnum = normal != null ? normal.Serialnum : "Normal";

                if ((DateTime.Now.Subtract(dto.UpdateTime).TotalMinutes > 20))
                {
                    //离线
                    var offline =

                            _deviceRunLogTypeRep.Get(
                                e => e.Name.Equals(DeviceRunLogTypeService.LogTypeEnum.离线.ToString()));
                    dto.DeviceRunLogTypeSerialnum = offline == null ? "Offline" : offline.Serialnum;
                }
                //else if   // todo 判断设备处理故障状态
                //{ 
                //    var Error = await _deviceRunLogTypeRep.GetAsync(e => e.Name.Equals(DeviceRunLogTypeService.LogTypeEnum.故障.ToString()));
                //}
                deviceRunLogDtos.Add(dto);
            });
            return await AddDeviceRunLog(deviceRunLogDtos);
        }
    }
}
