//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Repository
//  FILENAME   ： EntityRepositoryBase.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 13:13
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AhnqIot.Repository.Core
{
    public class EntityRepositoryBase<T> : IRepositoryBase<T> where T :class,new()
    {
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetPageList(Expression<Func<T, bool>> @where, Expression<Func<T, object>> orderBy, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Add(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public T GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> IncludeSubSets(params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(Expression<Func<TTable, object>> selector, Func<object, TDynamicEntity> maker) where TTable : class
        {
            throw new NotImplementedException();
        }

        public List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(Func<TTable, object> selector, Func<object, TDynamicEntity> maker) where TTable : class
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> CountByAsync(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public List<T> InsertList { get; set; }
        public List<T> DeleteList { get; set; }
        public List<T> UpdateList { get; set; }
    }
}