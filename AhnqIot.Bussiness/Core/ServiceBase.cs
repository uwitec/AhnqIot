//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Bussiness
//  FILENAME   ： ServiceBase.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 17:14
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AhnqIot.Bussiness.CacheStatistics;
using AhnqIot.Dto;
using AhnqIot.Hxj.Repository.AhnqIot;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dos.ORM;
using NewLife.Configuration;
using Smart.Redis;

namespace AhnqIot.Bussiness.Core
{
    public class ServiceBase<TDb, TDto> : IService<TDto>
        where TDto : BaseDto
        where TDb : Entity
    {
        #region 数据初始化

        /// <summary>
        /// 数据初始化，默认为不执行任何操作
        /// </summary>
        public virtual void InitData()
        {
            //子类自行实现
        }

        #endregion

        #region 属性

        #region Redis

        /// <summary>
        /// REDIS序列化协议
        /// </summary>
        /// 
        protected const DataType SerializeType = RedisSerializeType.DataType;

        /// <summary>
        /// Redis Key
        /// </summary>
        protected static readonly string RedisKey = typeof(TDb).Name;

        /// <summary>
        /// Redis Client
        /// </summary>
        protected static readonly RedisClient RedisClient;

        #endregion

        #region 缓存统计

        private static readonly bool _enableStatisticsRedisHit = false;

        /// <summary>
        /// redis命中统计
        /// </summary>
        public static IStatistics RedisHitStatistics { get; set; }

        /// <summary>
        /// redis命中显示定时器，每5分钟显示一次
        /// </summary>
        private static Timer _redisHitShowTimer;

        #endregion

        /// <summary>
        /// 数据表访问器
        /// </summary>
        public IAhnqIotRepository<TDb> Repository { get; set; }

        #endregion

        #region  构造函数

        /// <summary>
        /// <see cref="ServiceBase<TDb, TDto>"/>静态构造函数
        /// </summary>
        static ServiceBase()
        {
            RedisClient = RedisClient.DefaultDB;

            _enableStatisticsRedisHit = Config.GetConfig<bool>("enable-redis-hit-statistics", false);
            if (_enableStatisticsRedisHit)
            {
                RedisHitStatistics = new Statistics(RedisKey);
                _redisHitShowTimer = new Timer(obj => RedisHitStatistics.Show(), null, 100, 5 * 60 * 1000);
            }
        }

        /// <summary>
        /// <see cref="ServiceBase<TDb, TDto>"/>构造函数
        /// </summary>
        public ServiceBase()
        {
        }

        #endregion

        #region 类型转换

        protected virtual TDb GetDbModel(TDto entity)
        {
            return Mapper.Map<TDto, TDb>(entity);
        }

        protected virtual IEnumerable<TDb> GetDbModels(IEnumerable<TDto> entities)
        {
            return Mapper.Map<IEnumerable<TDto>, IEnumerable<TDb>>(entities);
        }

        protected virtual TDto GetDtoModel(TDb entity)
        {
            return Mapper.Map<TDb, TDto>(entity);
        }

        protected virtual IEnumerable<TDto> GetDtoModels(IEnumerable<TDb> entities)
        {
            return Mapper.Map<IEnumerable<TDb>, IEnumerable<TDto>>(entities);
        }

        #endregion

        #region 更新

        public virtual int Update(TDto entity)
        {
            Repository.Update(GetDbModel(entity));
            return Repository.Commit();
        }

        public virtual int Update(IEnumerable<TDto> entities)
        {
            if (entities == null || !entities.Any()) return 0;
            Repository.Update(GetDbModels(entities));
            return Repository.Commit();
        }

        public virtual async Task<int> UpdateAsync(TDto entity)
        {
            Repository.Update(GetDbModel(entity));
            return await Repository.CommitAsync();
        }

        public virtual async Task<int> UpdateWithRedisAsync(TDto entity)
        {
            RedisClient.HashSetFieldValue(RedisKey, entity.Serialnum, entity, SerializeType);
            return await UpdateAsync(entity);
        }

        public virtual async Task<int> UpdateAsync(IEnumerable<TDto> entities)
        {
            if (entities == null || !entities.Any()) return 0;
            Repository.Update(GetDbModels(entities));
            return await Repository.CommitAsync();
        }

        public virtual async Task<int> UpdateWithRedisAsync(IEnumerable<TDto> entities)
        {
            if (entities == null || !entities.Any()) return 0;
            entities.AsParallel().ToList().ForEach(e =>
            {
                RedisClient.HashSetFieldValue(RedisKey, e.Serialnum, e, SerializeType);
            });
            return await UpdateAsync(entities);
        }

        #endregion

        #region 增加

        public virtual int Add(TDto entity)
        {
            Repository.Add(GetDbModel(entity));
            return Repository.Commit();
        }

        public virtual int Add(IEnumerable<TDto> entities)
        {
            if (entities == null || !entities.Any()) return 0;
            Repository.Add(GetDbModels(entities));
            return Repository.Commit();
        }

        public virtual async Task<int> AddAsync(TDto entity)
        {
            Repository.Add(GetDbModel(entity));
            return await Repository.CommitAsync();
        }

        public virtual async Task<int> AddWithRedisAsync(TDto entity)
        {
            RedisClient.HashSetFieldValue(RedisKey, entity.Serialnum, entity, SerializeType);
            return await AddAsync(entity);
        }

        public virtual async Task<int> AddAsync(IEnumerable<TDto> entities)
        {
            if (entities == null || !entities.Any()) return 0;
            Repository.Add(GetDbModels(entities));
            return await Repository.CommitAsync();
        }

        public virtual async Task<int> AddWithRedisAsync(IEnumerable<TDto> entities)
        {
            if (entities == null || !entities.Any()) return 0;
            entities.AsParallel().ToList().ForEach(e =>
            {
                RedisClient.HashSetFieldValue(RedisKey, e.Serialnum, e, SerializeType);
            });
            return await AddAsync(entities);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 只处理从Redis中删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected int DeleteFromRedis(string id)
        {
            return RedisClient.HDelete(RedisKey, id);
        }

        public virtual int Delete(string id)
        {
            Repository.Delete(id);
            return Repository.Commit();
        }

        public virtual int Delete(TDto entity)
        {
            Repository.Update(GetDbModel(entity));
            return Repository.Commit();
        }

        public virtual int Delete(IEnumerable<TDto> entities)
        {
            Repository.Update(GetDbModels(entities));
            return Repository.Commit();
        }

        public virtual int Delete(Expression<Func<TDto, bool>> @where)
        {
            var exp = where.MapExpression<TDto, TDb>();
            Repository.Delete(exp);
            return Repository.Commit();
        }

        public virtual async Task<int> DeleteAsync(string id)
        {
            Repository.Delete(id);
            return await Repository.CommitAsync();
        }

        public virtual async Task<int> DeleteWithRedisAsync(string id)
        {
            DeleteFromRedis(id);
            return await DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(TDto entity)
        {
            Repository.Delete(GetDbModel(entity));
            return await Repository.CommitAsync();
        }

        public async Task<int> DeleteWithRedisAsync(TDto entity)
        {
            return await DeleteWithRedisAsync(entity.Serialnum);
        }

        public async Task<int> DeleteAsync(IEnumerable<TDto> entities)
        {
            Repository.Update(GetDbModels(entities));
            return await Repository.CommitAsync();
        }

        public async Task<int> DeleteAsync(Expression<Func<TDto, bool>> @where)
        {
            var exp = where.MapExpression<TDto, TDb>();
            Repository.Delete(exp);
            return await Repository.CommitAsync();
        }

        #endregion

        #region 查询

        public virtual TDto Get(Expression<Func<TDto, bool>> @where)
            => GetDtoModel(Repository.Get(@where.MapExpression<TDto, TDb>()));

        public virtual async Task<TDto> GetAsync(Expression<Func<TDto, bool>> @where)
        {
            return GetDtoModel(await Repository.GetAsync(@where.MapExpression<TDto, TDb>()));
        }

        public virtual TDto GetById(string id) => GetDtoModel(Repository.GetById(id));

        public virtual async Task<TDto> GetByIdAsync(string id) => GetDtoModel(await Repository.GetByIdAsync(id));

        public virtual async Task<TDto> GetByIdWithRedisAsync(string id)
        {
            if (id.IsNullOrWhiteSpace()) return null;
            RedisHitStatistics?.AddTotal();

            var model = RedisClient.HashGet<TDto>(RedisKey, id, SerializeType);
            if (model == null)
            {
                model = await GetByIdAsync(id);
                RedisClient.HashSetFieldValue(RedisKey, id, model, SerializeType);
            }
            else
                RedisHitStatistics?.AddHit();
            return model;
        }

        public virtual IEnumerable<TDto> GetAll() => GetDtoModels(Repository.GetAll());

        public virtual async Task<IEnumerable<TDto>> GetAllAsync() => GetDtoModels(await Repository.GetAllAsync());

        public virtual async Task<IEnumerable<TDto>> GetAllWidthRedisAsync()
        {
            RedisHitStatistics?.AddTotal();
            var list = RedisClient.HashGetAll<TDto>(RedisKey, DataType.Protobuf).Select(e => e.Value as TDto);
            if (!list.Any())
            {
                list = await GetAllAsync();
                list.AsParallel().ToList().ForEach(e => RedisClient.HashSetFieldValue(RedisKey, e.Serialnum, e, SerializeType));
            }
            else
            {
                RedisHitStatistics?.AddHit();
            }
            return list;
        }

        public virtual IEnumerable<TDto> GetMany(Expression<Func<TDto, bool>> @where)
            => GetDtoModels(Repository.GetMany(@where.MapExpression<TDto, TDb>()));

        public virtual async Task<IEnumerable<TDto>> GetManyAsync(Expression<Func<TDto, bool>> @where)
            => GetDtoModels(await Repository.GetManyAsync(@where.MapExpression<TDto, TDb>()));

        public virtual IEnumerable<TDto> GetPageList(Expression<Func<TDto, bool>> @where,
            Expression<Func<TDto, object>> orderBy,
            int pageIndex, int pageSize)
        //=>GetDtoModels(Repository.GetPageList(where.MapExpression<TDto, TDb>(), orderBy.MapExpression<TDto, TDb>(),pageIndex, pageSize));
        {
            throw new NotImplementedException();
        }

        public virtual List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(
            Expression<Func<TTable, object>> selector, Func<object, TDynamicEntity> maker) where TTable : class
        {
            throw new NotImplementedException();
        }

        public virtual List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(Func<TTable, object> selector,
            Func<object, TDynamicEntity> maker) where TTable : class
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 数量

        public virtual async Task<long> CountAsync() => await Repository.CountAsync();

        public virtual async Task<long> CountWidthRedisAsync()
        {
            RedisHitStatistics?.AddTotal();
            var list = RedisClient.HashGetAll<TDto>(RedisKey, DataType.Protobuf).Select(e => e.Value as TDto);
            if (!list.Any())
            {
                list = await GetAllAsync();
                list.AsParallel().ToList().ForEach(e => RedisClient.HashSetFieldValue(RedisKey, e.Serialnum, e, SerializeType));
            }
            else
            {
                RedisHitStatistics?.AddHit();
            }
            return list.Count();
        }

        public virtual async Task<long> CountByAsync(Expression<Func<TDto, bool>> @where)
            => await Repository.CountByAsync(@where.MapExpression<TDto, TDb>());

        #endregion

        #region 存在

        public virtual bool Exists(string id) => Repository.Exists(id);

        public virtual async Task<bool> ExistsAsync(string id) => await Repository.ExistsAsync(id);

        public virtual async Task<bool> ExistsWithRedisAsync(string id)
        {
            RedisHitStatistics?.AddTotal();
            var exists = RedisClient.HashFieldExists(RedisKey, id, SerializeType) > 0;
            if (!exists)
            {
                exists = await ExistsAsync(id);
            }
            else
            {
                RedisHitStatistics?.AddHit();
            }
            return exists;
        }

        public virtual bool Exists(Expression<Func<TDto, bool>> @where)
            => Repository.Exists(@where.MapExpression<TDto, TDb>());

        public virtual async Task<bool> ExistsAsync(Expression<Func<TDto, bool>> @where)
            => await Repository.ExistsAsync(@where.MapExpression<TDto, TDb>());

        #endregion
    }
}