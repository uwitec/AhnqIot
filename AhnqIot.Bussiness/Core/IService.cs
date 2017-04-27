#region Code File Comment
// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： IService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-13 15:23
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AhnqIot.Dto;
using Dos.ORM;

namespace AhnqIot.Bussiness.Core
{
    public interface IService<TDto> where TDto:BaseDto
    {
        void InitData();

        int Update(TDto entity);
        int Update(IEnumerable<TDto> entities);
        Task<int> UpdateAsync(TDto entity);
        Task<int> UpdateAsync(IEnumerable<TDto> entities);
        Task<int> UpdateWithRedisAsync(TDto entity);
        Task<int> UpdateWithRedisAsync(IEnumerable<TDto> entities);

        int Add(TDto entity);
        int Add(IEnumerable<TDto> entities);
        Task<int> AddAsync(TDto entity);
        Task<int> AddWithRedisAsync(TDto entity);
        Task<int> AddAsync(IEnumerable<TDto> entities);
        Task<int> AddWithRedisAsync(IEnumerable<TDto> entities);

        int Delete(string id);
        int Delete(TDto entity);
        int Delete(IEnumerable<TDto> entities);
        int Delete(Expression<Func<TDto, bool>> where);
        Task<int> DeleteAsync(string id);
        Task<int> DeleteWithRedisAsync(string id);
        Task<int> DeleteAsync(TDto entity);
        Task<int> DeleteWithRedisAsync(TDto entity);
        Task<int> DeleteAsync(IEnumerable<TDto> entities);
        Task<int> DeleteAsync(Expression<Func<TDto, bool>> where);


        TDto Get(Expression<Func<TDto, bool>> @where);
        Task<TDto> GetAsync(Expression<Func<TDto, bool>> @where);
        
        TDto GetById(string id);
        Task<TDto> GetByIdAsync(string id);
        Task<TDto> GetByIdWithRedisAsync(string id);

        IEnumerable<TDto> GetAll();
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<IEnumerable<TDto>> GetAllWidthRedisAsync();

        IEnumerable<TDto> GetMany(Expression<Func<TDto, bool>> where);
        Task<IEnumerable<TDto>> GetManyAsync(Expression<Func<TDto, bool>> where);

        IEnumerable<TDto> GetPageList(Expression<Func<TDto, bool>> where, Expression<Func<TDto, object>> orderBy,
            int pageIndex, int pageSize);


       // IQueryable<TDto> IncludeSubSets(params Expression<Func<TDto, object>>[] includeProperties);

        List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(Expression<Func<TTable, object>> selector,
            Func<object, TDynamicEntity> maker) where TTable : class;

        List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(Func<TTable, object> selector,
            Func<object, TDynamicEntity> maker) where TTable : class;

        Task<long> CountAsync();
        Task<long> CountWidthRedisAsync();
        Task<long> CountByAsync(Expression<Func<TDto, bool>> where);

        bool Exists(string id);
        Task<bool> ExistsAsync(string id);
        Task<bool> ExistsWithRedisAsync(string id);
        bool Exists(Expression<Func<TDto, bool>> @where);
        Task<bool> ExistsAsync(Expression<Func<TDto, bool>> @where);
    }
}