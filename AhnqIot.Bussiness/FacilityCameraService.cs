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
using Smart.Redis;
using AhnqIot.Infrastructure.DI;
using Autofac;
using System.Linq.Expressions;
using AhnqIot.Bussiness.Core;

namespace AhnqIot.Bussiness
{
    public class FacilityCameraService :ServiceBase<FacilityCamera,FacilityCameraDto>, IFacilityCameraService
    {
        //private readonly IAhnqIotRepository<FacilityCamera> _facilityCameraRep;
        //public const string HashName = "FacilityCamera";
        //private static readonly RedisClient _redisClient;
        static FacilityCameraService()
        {
            //_redisClient = RedisClient.DefaultDB;
            //初始化数据
            //Action act = async () => await Init();
            //act();
        }
        public FacilityCameraService(IAhnqIotRepository<FacilityCamera> facilityCameraRep)
        {
            //_facilityCameraRep = facilityCameraRep;
        }
        /// <summary>
        /// 获取所有的设施摄像机
        /// </summary>
        /// <returns></returns>
        public async Task<FacilityCameraDto> GetByWhereAsny(Expression<Func<FacilityCameraDto, bool>> where)
        {
            //return Mapper.Map<IEnumerable<FacilityCamera>, IEnumerable<FacilityCameraDto>>(await _facilityCameraRep.GetAllAsync());
            var list = RedisClient.HashGetAll<FacilityCameraDto>(RedisKey, DataType.Protobuf);
            if (list != null && list.Any())
            {
                return list.Select(e => e.Value as FacilityCameraDto).FirstOrDefault(where.Compile());
            }
            else
            {
                var exp = where.MapExpression<FacilityCameraDto, FacilityCamera>();
                var device = await Repository.GetAsync(exp);
                return GetDtoModel(device);
            }
        }
        /// <summary>
        /// 根据设备编码获取设施摄像机
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        public async Task<FacilityCameraDto> GetFacilityCameraByIdAsny(string deviceId)
        {
            //return Mapper.Map<FacilityCamera, FacilityCameraDto>(await _facilityCameraRep.GetAsync(fs => fs.Serialnum.Equals(deviceId)));
            try
            {
                //RedisClient.Delete(RedisKey);
                var device = RedisClient.HashGet<FacilityCameraDto>(RedisKey, deviceId, DataType.Protobuf);
                if (device == null)
                {
                    var dev = await Repository.GetByIdAsync(deviceId);
                    if (dev != null)
                    {
                        var dto = GetDtoModel(dev);
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
                    return device;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 添加设施摄像机
        /// </summary>
        /// <param name="dto">设施摄像机实体</param>
        /// <returns></returns>
        public async Task<bool> AddFacilityCamera(FacilityCameraDto dto)
        {
            //if (_facilityCameraRep.GetById(dto.Serialnum) == null)
            //{
            //    var camera = Mapper.Map<FacilityCamera>(dto);
            //    _facilityCameraRep.Add(camera);
            //    return await _facilityCameraRep.CommitAsync() > 0;
            //}
            //else
            //{
            //  _facilityCameraRep.Update(Mapper.Map<FacilityCamera>(dto));
            //   return await _facilityCameraRep.CommitAsync() > 0;
            //}
            try
            {
                RedisClient.HashSetFieldValue(RedisKey, dto.Serialnum, dto, DataType.Protobuf);

                var device = GetDbModel(dto);
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
                throw;
            }

        }

        /// <summary>
        /// 更新设施摄像机
        /// </summary>
        /// <param name="dto">摄像机实体</param>
        /// <returns></returns>
        public async Task<bool> UpdateCamera(FacilityCameraDto dto)
        {
            //var camera = Mapper.Map<FacilityCamera>(dto);
            //_facilityCameraRep.Update(camera);
            //return await _facilityCameraRep.CommitAsync() > 0;
            try
            {
                RedisClient.HashSetFieldValue(RedisKey, dto.Serialnum, dto, DataType.Protobuf);

                var device = GetDbModel(dto);
                Repository.Update(device);
                return await Repository.CommitAsync() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 根据设施编码获取设施摄像机
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        public async Task<IEnumerable<FacilityCameraDto>> GetFacilityCamerasByFacilityIdAsny(string facilityId)
        {
            //return Mapper.Map<IEnumerable<FacilityCameraDto>>(await _facilityCameraRep.GetManyAsync(fc => fc.FacilitySerialnum.Equals(facilityId)));
            var list = RedisClient.HashGetAll<FacilityCameraDto>(RedisKey, DataType.Protobuf);
            if (list != null && list.Any())
            {
                return list.Select(e => e.Value as FacilityCameraDto).Where(e => e.FacilitySerialnum.Equals(facilityId));
            }
            else
            {
                return
                    GetDtoModels(
                        await Repository.GetManyAsync(c => c.FacilitySerialnum.Equals(facilityId)));
            }
        }

        /// <summary>
        /// 根据设施编码获取设施摄像机
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        public IEnumerable<FacilityCameraDto> GetFacilityCamerasByFacilityId(string facilityId)
        {
            //return Mapper.Map<IEnumerable<FacilityCameraDto>>(await _facilityCameraRep.GetManyAsync(fc => fc.FacilitySerialnum.Equals(facilityId)));
            var list = RedisClient.HashGetAll<FacilityCameraDto>(RedisKey, DataType.Protobuf);
            if (list != null && list.Any())
            {
                return list.Select(e => e.Value as FacilityCameraDto).Where(e => e.FacilitySerialnum.Equals(facilityId));
            }
            else
            {
                return
                    GetDtoModels(
                         Repository.GetMany(c => c.FacilitySerialnum.Equals(facilityId)));
            }
        }

        /// <summary>
        ///     初始化,将数据库中facilitcamera表的所有记录取出来放到Redis中
        /// </summary>
        /// <returns></returns>
        private static async Task Init()
        {
            var list = await AhnqIotContainer.Container.Resolve<IAhnqIotRepository<FacilityCamera>>().GetAllAsync();
            var dtoList = Mapper.Map<IEnumerable<FacilityCameraDto>>(list);
            Parallel.ForEach(dtoList, item => { RedisClient.HashSetFieldValue(RedisKey, item.Serialnum, item, DataType.Protobuf); });
        }

        /// <summary>
        /// 检验编码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CheckCode(string code)
        {
            return code.Substring(13, 1).Equals("S") ? true : false;
        }
    }
}
