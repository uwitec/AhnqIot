#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Repository
// FILENAME   ： RepositoryBase.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-25 14:29
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AhnqIot.EF;
using AhnqIot.Infrastructure;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Microsoft.Data.Entity;
using AhnqIot.Repository.Helper;
using AhnqIot.Repository.Log.EFLogger;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.Logging;

#endregion

namespace AhnqIot.Repository.Core
{
    public class EntityRepositoryBase<T, TContext> : IRepositoryBase<T> where T : class
        where TContext : ContextBase, IDbContext, IDisposable, new()
    {
        public List<T> InsertList { get; set; }
        public List<T> DeleteList { get; set; }
        public List<T> UpdateList { get; set; }

        #region field

        protected readonly string Connectstring;

        /// <summary>
        /// </summary>
        //protected readonly IDbContext Context;

        ///// <summary>
        ///// </summary>
        //protected readonly DbSet<T> Dbset;

        #endregion

        #region ctor

        /// <summary>
        ///     使用默认连接字符串name=connName
        /// </summary>
        public EntityRepositoryBase() : this("")
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public EntityRepositoryBase(string connectionString)
        {
            InsertList = new List<T>();
            DeleteList = new List<T>();
            UpdateList = new List<T>();

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                var conn = ConfigurationManager.ConnectionStrings;
                var connStr = conn["connName"].ConnectionString;
                connectionString = connStr;
            }
            Connectstring = connectionString;
            //Context = new TContext {ConnectionString = connectionString};
            //Dbset = Context.Set<T>();

            //var loggerFactory = ((DbContext)Context).GetService<ILoggerFactory>();
            //loggerFactory.AddProvider(new DbLoggerProvider(Console.WriteLine));
            //loggerFactory.AddConsole(minLevel: LogLevel.Warning);
        }

        //public EntityRepositoryBase(TContext context)
        //{
        //    Context = context;
        //    Dbset = Context.Set<T>();
        //}

        #endregion

        #region Method

        //public virtual IDbContext GetDbContext(ILifetimeScope scope)
        //{

        //}

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
            Check.NotNull(entity, "entity");
            UpdateList.Add(entity);
            //Context.Set<T>().Update(entity);
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            Check.NotNull(entities, "entities");
            UpdateList.AddRange(entities);
        }

        #endregion

        #region PageList

        public virtual IEnumerable<T> GetPageList(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy,
            int pageIndex, int pageSize)
        {
            if (pageIndex < 1) pageIndex = 1;
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                return context.Set<T>().Where(where).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        #endregion

        #region Insert

        public virtual void Add(T entity)
        {
            Check.NotNull(entity, "entity");
            //排除已经存在的项(对于多线程没有任何用处)
            if (!InsertList.Exists(e => e.Equals(entity)))
            {
                InsertList.Add(entity);
            }

        }

        //private ICollection<T> GetTT(IEnumerable<T> entities)
        //{
        //    return  entities;
        //} 
        public virtual void Add(IEnumerable<T> entities)
        {
            Check.NotNull(entities, "entities");
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
            throw new NotImplementedException("Delete(string id)");
        }

        public virtual void Delete(T entity)
        {
            Check.NotNull(entity, "entity");
            DeleteList.Remove(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            Check.NotNull(entities, "entities");
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

            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));

                var loggerFactory = ((DbContext)context).GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new DbLoggerProvider(Console.WriteLine));

                var dbset = context.Set<T>();
                if (InsertList != null && InsertList.Any())
                {
                    List<T> InsertNewList = InsertList.Distinct(new PropertyComparer<T>("Serialnum")).ToList();//按照特定规则排除重复项
                    dbset.AddRange(InsertNewList);
                }

                if (DeleteList != null && DeleteList.Any())
                    dbset.RemoveRange(DeleteList);
                if (UpdateList != null && UpdateList.Any())
                {
                    List<T> UpdateNewList = UpdateList.Distinct(new PropertyComparer<T>("Serialnum")).ToList();//按照特定规则排除重复项
                    dbset.UpdateRange(UpdateNewList);
                }

                var result = context.SaveChanges();
                if (InsertList != null && InsertList.Any())
                    InsertList.Clear();
                if (DeleteList != null && DeleteList.Any())
                    DeleteList.Clear();
                if (UpdateList != null && UpdateList.Any())
                    UpdateList.Clear();
                return result;
            }
        }

        public async Task<int> CommitAsync()
        {
            ValidModel();

            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var loggerFactory = ((DbContext)context).GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new DbLoggerProvider(Console.WriteLine));
                var dbset = context.Set<T>();
                if (InsertList != null && InsertList.Any())
                {
                    List<T> InsertNewList = InsertList.Distinct(new PropertyComparer<T>("Serialnum")).ToList();//按照特定规则排除重复项
                    dbset.AddRange(InsertNewList);
                }

                if (DeleteList != null && DeleteList.Any())
                    dbset.RemoveRange(DeleteList);
                //try
                //{
                if (UpdateList != null && UpdateList.Any())
                {
                    List<T> UpdateNewList = UpdateList.Distinct(new PropertyComparer<T>("Serialnum")).ToList();//按照特定规则排除重复项
                    dbset.UpdateRange(UpdateNewList);
                }
                var result = await context.SaveChangesAsync();
                //return result;
                //}
                //catch (Exception ex)
                //{
                //    Console.Clear();
                //    Console.WriteLine(ex.ToString());
                //    throw;
                //}

                if (InsertList != null && InsertList.Any())
                    InsertList.Clear();
                if (DeleteList != null && DeleteList.Any())
                    DeleteList.Clear();
                if (UpdateList != null && UpdateList.Any())
                    UpdateList.Clear();
                return result;
            }
        }

        #endregion

        #region Query

        public virtual T Get(Expression<Func<T, bool>> @where)
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return dbset.FirstOrDefault(where);
            }
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> @where)
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return await dbset.FirstOrDefaultAsync(where);
            }
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
            throw new NotImplementedException("GetById(int id)");
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException("GetById(int id)");
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return dbset.ToList();
            }
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return await dbset.ToListAsync();
            }
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return dbset.Where(@where).ToList();
            }
        }

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where)
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return await dbset.Where(@where).ToListAsync();
            }
        }

        public virtual IQueryable<T> IncludeSubSets(params Expression<Func<T, object>>[] includeProperties)
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return includeProperties.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(dbset,
                    (current, includeProperty) => current.Include(includeProperty));
            }
        }

        public List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(Expression<Func<TTable, object>> selector,
            Func<object, TDynamicEntity> maker) where TTable : class
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return ((IQueryable<TTable>)dbset).Select(selector.Compile()).Select(maker).ToList();
            }
        }

        public List<TDynamicEntity> GetDynamic<TTable, TDynamicEntity>(Func<TTable, object> selector,
            Func<object, TDynamicEntity> maker) where TTable : class
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return ((IQueryable<TTable>)dbset).Select(selector).Select(maker).ToList();
            }
        }

        #endregion

        #region Count

        public virtual async Task<long> CountAsync()
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return await dbset.LongCountAsync();
            }
        }

        public virtual async Task<long> CountByAsync(Expression<Func<T, bool>> where)
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>(new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return await dbset.Where(@where).LongCountAsync();
            }
        }

        #endregion

        #region Exists

        public virtual bool Exists(string id)
        {
            throw new NotImplementedException();
        }

        public virtual bool Exists(long id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> ExistsAsync(string id)
        {
            throw new NotImplementedException();
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