#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： SysRole.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Collections.Generic;

#endregion

namespace AhnqIot.DbModel
{
    public partial class SysRole : BaseEntity
    {
        public SysRole()
        {
            SysRoleMenu = new HashSet<SysRoleMenu>();
            SysUser = new HashSet<SysUser>();
        }

        public string Description { get; set; }
        public bool IsSystem { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }
        public int Status { get; set; }
        public string Url { get; set; }
        public virtual ICollection<SysRoleMenu> SysRoleMenu { get; set; }
        public virtual ICollection<SysUser> SysUser { get; set; }
    }
}