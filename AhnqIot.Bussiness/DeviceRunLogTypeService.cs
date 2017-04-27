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
using Smart.Redis;

namespace AhnqIot.Bussiness
{
    public class DeviceRunLogTypeService :ServiceBase<DeviceRunLogType,DeviceRunLogTypeDto>, IDeviceRunLogTypeService
    {
        //public const string HashName = "DeviceRunLogType";
        //private static readonly RedisClient _redisClient;
        //private readonly IAhnqIotRepository<DeviceRunLogType> _deviceRunLogTypeRep;

        /// <summary>
        /// 日志类型
        /// </summary>
        internal enum LogTypeEnum
        {
            正常 = 0,
            离线 = 1,
            故障 = 2
        }

        static DeviceRunLogTypeService()
        {
            //var rep = AhnqIotContainer.Container.Resolve<IAhnqIotRepository<DeviceRunLogType>>();
            ////RedisClient = RedisClient.DefaultDB;

            //var list = rep.GetAllAsync().GetAwaiter().GetResult();
            //if (list == null || !list.Any())
            //{
            //    //初始化数据
            //    list = InitData(rep);
            //}
            //Parallel.ForEach(Mapper.Map<IEnumerable<DeviceRunLogType>, IEnumerable<DeviceRunLogTypeDto>>(list), item =>
            //{
            //    RedisClient.HashSetFieldValue(RedisKey, item.Serialnum, item, DataType.Protobuf);
            //});
        }
        /// <summary>
        /// 初始化表数据
        /// </summary>
        /// <param name="rep"></param>
        private static IEnumerable<DeviceRunLogType> InitData(IAhnqIotRepository<DeviceRunLogType> rep)
        {

            var entityNormal = new DeviceRunLogType
            {
                Serialnum = "Normal",
                Name = LogTypeEnum.正常.ToString()
            };
            rep.Add(entityNormal);

            var entityOffline = new DeviceRunLogType
            {
                Serialnum = "Offline",
                Name = LogTypeEnum.离线.ToString()
            };
            rep.Add(entityOffline);

            var entityError = new DeviceRunLogType
            {
                Serialnum = "Error",
                Name = LogTypeEnum.故障.ToString()
            };
            rep.Add(entityError);

            Task.Factory.StartNew(async () => await rep.CommitAsync());

            return new DeviceRunLogType[] { entityNormal, entityOffline, entityError };
        }

        public DeviceRunLogTypeService(IAhnqIotRepository<DeviceRunLogType> deviceRunLogTypeRep)
        {
            Repository = deviceRunLogTypeRep;
        }
        /// <summary>
        /// 获取所有的设备运行日志类型
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DeviceRunLogTypeDto>> GetDeviceRunLogTypesAsny()
        {
            var list = RedisClient.HashGetAll<DeviceRunLogTypeDto>(RedisKey, DataType.Protobuf);
            if (list == null || !list.Any())
            {
                var dbList = GetDtoModels(
                    await Repository.GetAllAsync());
                //重新添加到redis中
                Parallel.ForEach(dbList, item =>
                {
                    RedisClient.HashSetFieldValue(RedisKey, item.Serialnum, item, DataType.Protobuf);
                });

                return dbList;
            }
            else
            {
                return list.Select(e => e.Value as DeviceRunLogTypeDto);
            }
        }
    }
}
