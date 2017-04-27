#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： DeviceService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-25 13:59
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using AhnqIot.Hxj.Repository.AhnqIot;
using Autofac;
using AutoMapper;
using Smart.Redis;

#endregion

namespace AhnqIot.Bussiness
{
    public class DeviceService : ServiceBase<Device, DeviceDto>, IDeviceService
    {
        /// <summary>  w3w
        /// 数据持久化到数据库定时器
        /// </summary>
        private static readonly Timer SyncToDbTimer;
        /// <summary>
        /// 待更新设备信息
        /// </summary>
        private static List<DeviceDto> UpdateList;


        static DeviceService()
        {
            UpdateList = new List<DeviceDto>();

            ////初始化数据
            //Action act = async () => await Init();
            //act();
            try
            {
                SyncToDbTimer = new Timer(obj =>
                {
                    if (UpdateList.Any())
                    {
                        List<DeviceDto> list = null;
                        lock (UpdateList)
                        {
                            list = new List<DeviceDto>(UpdateList);
                            UpdateList.Clear();
                        }
                        if (list.Any())
                        {
                            var rep = AhnqIotContainer.Container.Resolve<IAhnqIotRepository<Device>>();
                            rep.Update(Mapper.Map<IEnumerable<Device>>(list));
                            Action updateAction = async () => await rep.CommitAsync();
                            updateAction();
                            //LogHelper.Info("rep updatelist count:",rep.UpdateList.Count.ToString());
                            //LogHelper.Info("app updatelist count:", UpdateList.Count.ToString());
                        }
                    }
                }, null, 10 * 1000, 10 * 1000);
            }
            catch (Exception ex)
            {
                LogHelper.Debug(ex.ToString());
            }

        }

        public DeviceService(IAhnqIotRepository<Device> deviceRep)
        {
        }

        /// <summary>
        ///     根据编码获取设备
        /// </summary>
        /// <param name="id">设备编码</param>
        /// <returns></returns>
        public async Task<DeviceDto> GetDeviceByIdAsny(string id)
        {
            //RedisHitStatistics?.AddTotal();
            try
            {
                RedisClient.Delete(RedisKey);
                var device = RedisClient.HashGet<DeviceDto>(RedisKey, id, DataType.Protobuf);
                if (device == null)
                {
                    var dev = await Repository.GetByIdAsync(id);
                    if (dev != null)
                    {
                        var dto = Mapper.Map<DeviceDto>(dev);
                        RedisClient.HashSetFieldValue(RedisKey, dto.Serialnum, dto, DataType.Protobuf);
                        return dto;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                   RedisHitStatistics?.AddHit();
                    return device;
                }
            }
            //catch (AggregateException ex)
            //{
            //    ex.InnerExceptions.ForEach(iex =>
            //    {
            //         LogHelper.Info(iex);
            //    });
            //}
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///     根据lamda条件获取设备
        /// </summary>
        /// <returns></returns>
        public async Task<DeviceDto> GetDeviceAsny(Expression<Func<DeviceDto, bool>> where)
        {
            var list = RedisClient.HashGetAll<DeviceDto>(RedisKey, DataType.Protobuf);
            if (list != null && list.Any())
            {
                return list.Select(e => e.Value as DeviceDto).FirstOrDefault(where.Compile());
            }
            else
            {
                var exp = where.MapExpression<DeviceDto, Device>();
                var device = await Repository.GetAsync(exp);
                return Mapper.Map<DeviceDto>(device);
            }
        }

        /// <summary>
        ///     添加设备
        /// </summary>
        /// <param name="dto">设备实体</param>
        /// <returns></returns>
        public async Task<bool> AddDevice(DeviceDto dto)
        {
            try
            {
                RedisClient.HashSetFieldValue(RedisKey, dto.Serialnum, dto, DataType.Protobuf);

                var device = Mapper.Map<Device>(dto);
                Repository.Add(device);
                return await Repository.CommitAsync() > 0;
            }
            //catch(AggregateException ex)
            //{
            //    ex.InnerExceptions.ForEach(iex => {
            //    });
            //}
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        ///     更新设备
        /// </summary>
        /// <param name="dto">设备实体</param>
        /// <returns></returns>
        public async Task<bool> UpdateDevice(DeviceDto dto)
        {
            try
            {
                //RedisClient.HashSetFieldValue(RedisKey, dto.Serialnum, dto, DataType.Protobuf);

                //var device = Mapper.Map<Device>(dto);
                //_deviceRep.Update(device);
                //return await _deviceRep.CommitAsync() > 0;
                UpdateList.Add(dto);
                return true;
            }
            catch (Exception ex)
            {
                //throw;
                return false;
            }
        }

        /// <summary>
        ///     根据设施编码获取所有设备
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        public IEnumerable<DeviceDto> GetDevicesByFacilityId(string facilityId)
        {
            var list = RedisClient.HashGetAll<DeviceDto>(RedisKey, DataType.Protobuf);
            if (list != null && list.Any())
            {
                return list.Select(e => e.Value as DeviceDto).Where(e => e.FacilitySerialnum.Equals(facilityId));
            }
            else
            {
                return
                    Mapper.Map<IEnumerable<DeviceDto>>(Repository.GetMany(c => c.FacilitySerialnum.Equals(facilityId)));
            }
        }

        /// <summary>
        ///     根据设施编码获取所有设备
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        public async Task<IEnumerable<DeviceDto>> GetDevicesByFacilityIdAsync(string facilityId)
        {
            var list = RedisClient.HashGetAll<DeviceDto>(RedisKey, DataType.Protobuf);
            if (list != null && list.Any())
            {
                return list.Select(e => e.Value as DeviceDto).Where(e => e.FacilitySerialnum.Equals(facilityId));
            }
            else
            {
                return
                    Mapper.Map<IEnumerable<Device>, IEnumerable<DeviceDto>>(
                        await Repository.GetManyAsync(c => c.FacilitySerialnum.Equals(facilityId)));
            }
        }

        public override void InitData()
        {
            try
            {
                var list = AhnqIotContainer.Container.Resolve<IAhnqIotRepository<Device>>().GetAll();
                var dtoList = GetDtoModels(list);
                //Parallel.ForEach(dtoList, item => { RedisClient.HashSetFieldValue(RedisKey, item.Serialnum, item, DataType.Protobuf); });
                dtoList.ToList().ForEach(item =>
                {
                    RedisClient.HashSetFieldValue(RedisKey, item.Serialnum, item, DataType.Protobuf);
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检验编码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CheckCode(string code)
        {
            return code.Substring(13, 1).Equals("C") || code.Substring(13, 1).Equals("K") ? true : false;
        }
    }
}