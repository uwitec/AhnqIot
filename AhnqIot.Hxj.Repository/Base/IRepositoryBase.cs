#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：Sys_BaseDataLogic
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：周浩
* 电子邮箱：admin@itdos.com
* 创建日期：2014/10/1 11:00:49
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dos.ORM;

namespace AhnqIot.Hxj.Repository.Base
{
    public interface IRepositoryBase<T> where T :Entity
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
