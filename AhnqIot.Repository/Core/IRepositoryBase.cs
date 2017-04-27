#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Repository
// FILENAME   ： IRepositoryBase.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-13 15:06
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

#endregion

namespace AhnqIot.Repository.Core
{
    public interface IRepositoryBase<T> where T : class
    {
        void Update(T entity);
        void Update(IEnumerable<T> entities);

        IEnumerable<T> GetPageList(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy,
            int pageIndex, int pageSize);

        void Add(T entity);
        void Add(IEnumerable<T> entities);
        void Delete(long id);
        void Delete(string id);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        void Delete(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> @where);
        Task<T> GetAsync(Expression<Func<T, bool>> @where);
        T GetById(long id);
        Task<T> GetByIdAsync(long id);
        T GetById(string id);
        Task<T> GetByIdAsync(string id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);
        IQueryable<T> IncludeSubSets(params Expression<Func<T, object>>[] includeProperties);

        List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(Expression<Func<TTable, object>> selector,
            Func<object, TDynamicEntity> maker) where TTable : class;

        List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(Func<TTable, object> selector,
            Func<object, TDynamicEntity> maker) where TTable : class;

        Task<long> CountAsync();
        Task<long> CountByAsync(Expression<Func<T, bool>> where);

        bool Exists(string id);
        bool Exists(long id);
        Task<bool> ExistsAsync(string id);
        Task<bool> ExistsAsync(long id);
        bool Exists(Expression<Func<T, bool>> @where);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> @where);

        int Commit();

        Task<int> CommitAsync();

        #region 属性

        List<T> InsertList { get; set; }
        List<T> DeleteList { get; set; }
        List<T> UpdateList { get; set; }

        #endregion
    }
}