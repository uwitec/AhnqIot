#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.EF
// FILENAME   ： IDbContext.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 23:40
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System.Collections.Generic;
using System.Threading.Tasks;
using AhnqIot.DbModel;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.ChangeTracking;

#endregion

namespace AhnqIot.EF
{
    public interface IDbContext
    {
        /// <summary>
        ///     连接字符串
        /// </summary>
        string ConnectionString { get; set; }

        DbSet<T> Set<T>() where T : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        ///     保存
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        ///     异步保存
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        ///// <summary>
        /////     Execute stores procedure and load a list of entities at the end
        ///// </summary>
        ///// <typeparam name="TEntity">Entity type</typeparam>
        ///// <param name="commandText">Command text</param>
        ///// <param name="parameters">Parameters</param>
        ///// <returns>Entities</returns>
        //IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
        //    where TEntity : BaseEntity, new();

        ///// <summary>
        /////     Creates a raw SQL query that will return elements of the given generic type.  The type can be any type that has
        /////     properties that match the names of the columns returned from the query, or can be a simple primitive type. The type
        /////     does not have to be an entity type. The results of this query are never tracked by the context even if the type of
        /////     object returned is an entity type.
        ///// </summary>
        ///// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        ///// <param name="sql">The SQL query string.</param>
        ///// <param name="parameters">The parameters to apply to the SQL query string.</param>
        ///// <returns>Result</returns>
        //IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
    }
}