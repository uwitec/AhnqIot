#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Repository
// FILENAME   ： AhnqIotRepository.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-28 11:19
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AhnqIot.DbModel;
using AhnqIot.EF;
using AhnqIot.Infrastructure;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Repository.Core;
using Autofac;
using Microsoft.Data.Entity;

#endregion

namespace AhnqIot.Repository.AhnqIot
{
    /// <summary>
    ///     Ahnq Iot Repository
    /// </summary>
    public partial class AhnqIotRepository<T> : EntityRepositoryBase<T, AhnqIotContext>, IAhnqIotRepository<T>
        where T : BaseEntity
    {
        #region Delete

        public override void Delete(string id) => Delete(e => e.Serialnum == id);

        #endregion

        #region ctor

        public AhnqIotRepository()
        {
        }

        public AhnqIotRepository(string connectionString) : base(connectionString)
        {
        }

        #endregion

        #region Exists

        public override bool Exists(string id)
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.ResolveNamed<IDbContext>("AhnqIotContext",
                    new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return dbset.Any(e => e.Serialnum.Equals(id));
            }
        }

        public override async Task<bool> ExistsAsync(string id)
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.ResolveNamed<IDbContext>("AhnqIotContext",
                    new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return await dbset.AnyAsync(e => e.Serialnum.Equals(id));
            }
        }

        public override async Task<bool> ExistsAsync(Expression<Func<T, bool>> @where)
        {
            using (var scope = AhnqIotContainer.Container.BeginLifetimeScope())
            {
                var context = scope.ResolveNamed<IDbContext>("AhnqIotContext",
                    new NamedParameter("connectionString", Connectstring));
                var dbset = context.Set<T>();
                return await dbset.AnyAsync(@where);
            }
        }

        #endregion

        #region Add

        public override void Add(T entity)
        {
            try
            {
                Check.NotNull(entity, "entity");
                entity.CreateTime = entity.UpdateTime = DateTime.Now;
                if (string.IsNullOrWhiteSpace(entity.Serialnum))
                    entity.Serialnum = Guid.NewGuid().ToString();
                
                //排除已经存在的项(对于多线程没有任何用处)
                if (!InsertList.Exists(e => e.Serialnum.Equals(entity.Serialnum)))
                {
                    InsertList.Add(entity);
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }

        public override void Add(IEnumerable<T> entities)
        {
            Check.NotNull(entities, "entities");
            entities.ToList().ForEach(e =>
            {
                e.CreateTime = e.UpdateTime = DateTime.Now;
                if (string.IsNullOrWhiteSpace(e.Serialnum))
                    e.Serialnum = Guid.NewGuid().ToString();
            });
            base.Add(entities);
        }

        #endregion

        #region Update

        public override void Update(T entity)
        {
            entity.UpdateTime = DateTime.Now;
            base.Update(entity);
        }

        public override void Update(IEnumerable<T> entities)
        {
            Check.NotNull(entities, "entities");
            entities.ToList().ForEach(e => e.UpdateTime = DateTime.Now);
            base.Update(entities);
        }

        #endregion

        #region Get

        public override T GetById(string id)
        {
            return Get(e => e.Serialnum.Equals(id));
        }

        public override async Task<T> GetByIdAsync(string id)
        {
            return await GetAsync(e => e.Serialnum.Equals(id));
        }

        #endregion
    }
}