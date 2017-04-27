#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： SysFunction.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Collections.Generic;

#endregion

namespace AhnqIot.DbModel
{
    public partial class SysFunction : BaseEntity
    {
        public SysFunction()
        {
            SysMenu = new HashSet<SysMenu>();
        }

        public string Action { get; set; }
        public string Controller { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ParentSerialnum { get; set; }
        public int Status { get; set; }
        public virtual ICollection<SysMenu> SysMenu { get; set; }
    }
}