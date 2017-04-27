#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： WeatherWarn.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;

#endregion

namespace AhnqIot.DbModel
{
    public partial class WeatherWarn : BaseEntity
    {
        public string Content { get; set; }
        public string Cover { get; set; }
        public DateTime PublishTime { get; set; }
        public string SourceName { get; set; }
        public string SourceUrl { get; set; }
        public string SysDepartmentSerialnum { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }
        public virtual SysDepartment SysDepartmentSerialnumNavigation { get; set; }
    }
}