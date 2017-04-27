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
using System.Threading.Tasks;
using AhnqIot.Hxj.Repository.Helper;
using AhnqIot.Infrastructure.Log;
using Dos.ORM;

namespace AhnqIot.Hxj.Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {

        #region field
        public List<T> InsertList { get; set; }
        public List<T> DeleteList { get; set; }
        public List<T> UpdateList { get; set; }

        private static DbSession context;
        #endregion

        #region ctor
        public RepositoryBase()
        {

            context = Db.Context;
            InsertList = new List<T>();
            DeleteList = new List<T>();
            UpdateList = new List<T>();
            Db.Context.RegisterSqlLogger(delegate (string sql)
            {
                //在此可以记录sql日志
                //写日志会影响性能，建议开发版本记录sql以便调试，发布正式版本不要记录
               // LogHelper.Debug(sql, "SQL日志");
                //Console.WriteLine(sql);
            });
        }
        #endregion

        #region Method


        #region Check Model

        /// <summary>
        ///     校正Model
        /// </summary>
        protected virtual void ValidModel()
        {
        }

        #endregion

        #region Update

        public virtual void Update(T entity)
        {
            Infrastructure.Check.NotNull(entity, "entity");
            UpdateList.Add(entity);
            //Context.Set<T>().Update(entity);
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            Infrastructure.Check.NotNull(entities, "entities");
            UpdateList.AddRange(entities);
        }

        #endregion

        #region PageList

        public virtual IEnumerable<T> GetPageList(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy,
            int pageIndex, int pageSize)
        {
            if (pageIndex < 1) pageIndex = 1;
            var fs = context.From<T>().Where(where);
            fs.Page(pageSize, pageIndex);
            if (orderBy != null)
            {
                fs.OrderBy(orderBy);
            }
            return fs.ToList();
        }

        #endregion

        #region Insert

        public virtual void Add(T entity)
        {
            Infrastructure.Check.NotNull(entity, "entity");
            //排除已经存在的项(对于多线程没有任何用处)
            if (!InsertList.Exists(e => e.Equals(entity)))
            {
                InsertList.Add(entity);
            }

        }

        public virtual void Add(IEnumerable<T> entities)
        {
            Infrastructure.Check.NotNull(entities, "entities");
            InsertList.AddRange(entities);
        }

        #endregion

        #region Delete

        public virtual void Delete(long id)
        {
            throw new NotImplementedException("Delete(int id)");
        }

        public virtual void Delete(string id)
        {
            context.Delete<T>(id);
        }

        public virtual void Delete(T entity)
        {
            Infrastructure.Check.NotNull(entity, "entity");
            DeleteList.Remove(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            Infrastructure.Check.NotNull(entities, "entities");
            foreach (var x1 in DeleteList)
            {
                DeleteList.Remove(x1);
            }
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var list = DeleteList.Where(where.Compile());
            Delete(list);
        }

        #endregion

        #region Commit

        public int Commit()
        {
            ValidModel();
            try
            {
                using (var trans = DbSession.Default.BeginTransaction())
                {
                    if (InsertList != null && InsertList.Any())
                    {
                        //List<T> InsertNewList = InsertList.Distinct(new PropertyComparer<T>("Serialnum")).ToList();//按照特定规则排除重复项
                        trans.Insert(InsertList);
                    }

                    if (DeleteList != null && DeleteList.Any())
                        trans.Delete(DeleteList);
                    if (UpdateList != null && UpdateList.Any())
                    {
                       // List<T> UpdateNewList = UpdateList.Distinct(new PropertyComparer<T>("Serialnum")).ToList();//按照特定规则排除重复项
                        trans.Update(UpdateList);
                    }

                   trans.Commit();
                    if (InsertList != null && InsertList.Any())
                        InsertList.Clear();
                    if (DeleteList != null && DeleteList.Any())
                        DeleteList.Clear();
                    if (UpdateList != null && UpdateList.Any())
                        UpdateList.Clear();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
                //throw;
            }
            
        }

        public async Task<int> CommitAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                ValidModel();
                try
                {
                    using (var trans = DbSession.Default.BeginTransaction())
                    //using(DbBatch batch = DbSession.Default.BeginBatchConnection(20))
                    {
                        if (InsertList != null && InsertList.Any())
                        {
                           // List<T> InsertNewList = InsertList.Distinct(new PropertyComparer<T>("Serialnum")).ToList();//按照特定规则排除重复项
                            trans.Insert(InsertList);
                            //batch.Insert(InsertNewList.ToArray());
                        }

                        if (DeleteList != null && DeleteList.Any())
                            trans.Delete(DeleteList);
                            //DeleteList.ForEach(delete =>
                            //{
                            //    batch.Delete(delete);
                            //});

                        if (UpdateList != null && UpdateList.Any())
                        {
                            //List<T> UpdateNewList = UpdateList.Distinct(new PropertyComparer<T>("Serialnum")).ToList();//按照特定规则排除重复项
                           int i= trans.UpdateAll<T>(UpdateList);
                            //batch.UpdateAll(UpdateNewList.ToArray());
                        }
                        trans.Commit();
                        //trans.Commit();
                        if (InsertList != null && InsertList.Any())
                            InsertList.Clear();
                        if (DeleteList != null && DeleteList.Any())
                            DeleteList.Clear();
                        if (UpdateList != null && UpdateList.Any())
                            UpdateList.Clear();
                        return 1;
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                    //throw;
                }
              
            });
        }

        #endregion

        #region Query

        public virtual T Get(Expression<Func<T, bool>> @where)
        {
            return context.From<T>().Where(where).ToFirst();
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> @where)
        {
            return await Task.Factory.StartNew(() => context.From<T>().Where(where).ToFirst());
        }
        public virtual T GetById(long id)
        {
            throw new NotImplementedException("GetById(int id)");
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            throw new NotImplementedException("GetById(int id)");
        }

        public virtual T GetById(string id)
        {
            return context.From<T>().Where(new WhereClip(EntityCache.GetPrimaryKeyFields<T>()[0], id, QueryOperator.Equal)).First();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await Task.Factory.StartNew(()=> context.From<T>().Where(new WhereClip(EntityCache.GetPrimaryKeyFields<T>()[0], id, QueryOperator.Equal)).First());
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.From<T>().ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() => context.From<T>().ToList());
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return context.From<T>().Where(where).ToList();
        }

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where)
        {
            return await Task.Factory.StartNew(() => context.From<T>().Where(where).ToList());
        }

        public virtual IQueryable<T> IncludeSubSets(params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException("IncludeSubSets(params Expression<Func<T, object>>[] includeProperties)");
            //return includeProperties.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(context,
            //    (current, includeProperty) => current.Include(includeProperty));
        }

        public List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(Expression<Func<TTable, object>> selector,
            Func<object, TDynamicEntity> maker) where TTable : class
        {
            throw new NotImplementedException(" GetDynamic");
            //return ((IQueryable<TTable>)context).Select(selector.Compile()).Select(maker).ToList();
        }

        public List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(Func<TTable, object> selector,
            Func<object, TDynamicEntity> maker) where TTable : class
        {
            throw new NotImplementedException(" GetDynamic");
        }

        //    /// <summary>
        //    /// 根据条件判断是否存在数据
        //    /// </summary>
        //    /// <param name="where"></param>
        //    /// <returns></returns>
        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            return context.Exists<T>(where);
        }
        #endregion

        #region Count

        public virtual async Task<long> CountAsync()
        {
            return context.Count();
        }

        public virtual async Task<long> CountByAsync(Expression<Func<T, bool>> where)
        {
            return await Task.Factory.StartNew(() => context.From<T>().Where(@where).Count());
        }

        #endregion

        #region Exists

        public virtual bool Exists(string id)
        {
            return context.Exists<T>(new WhereClip(EntityCache.GetPrimaryKeyFields<T>()[0], id, QueryOperator.Equal));
        }

        public virtual bool Exists(long id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> ExistsAsync(string id)
        {
            return await Task.Factory.StartNew(()=> context.Exists<T>(new WhereClip(EntityCache.GetPrimaryKeyFields<T>()[0], id, QueryOperator.Equal)));
        }

        public virtual async Task<bool> ExistsAsync(long id)
        {
            throw new NotImplementedException();
        }

        public virtual bool Exists(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion


    }
}
