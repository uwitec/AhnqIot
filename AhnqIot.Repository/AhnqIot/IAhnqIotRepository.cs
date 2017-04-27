using AhnqIot.DbModel;
using AhnqIot.Repository.Core;

namespace AhnqIot.Repository.AhnqIot
{
    /// <summary>
    /// Repository
    /// </summary>
    public partial interface IAhnqIotRepository<T> :IRepositoryBase<T> where T:BaseEntity
    {
        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
       // IQueryable<T> TableNoTracking { get; }
    }
}
