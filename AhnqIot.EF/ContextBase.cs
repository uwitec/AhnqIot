#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.EF
// FILENAME   ： ContextBase.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-12 15:07
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System.Threading.Tasks;
using Microsoft.Data.Entity;

#endregion

namespace AhnqIot.EF
{
    /// <summary>
    /// 数据库会话基类
    /// </summary>
    public class ContextBase : DbContext, IDbContext
    {
        #region 属性

        /// <summary>
        ///     数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        #endregion

        /// <summary>
        ///     保存更改
        /// </summary>
        /// <returns></returns>
        public virtual async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        /// <summary>
        ///     配置
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(ConnectionString);
        }

        #region 构造函数

        public ContextBase()
        {
        }

        public ContextBase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        #endregion
    }
}