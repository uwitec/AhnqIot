#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： SysUser.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Collections.Generic;

#endregion

namespace AhnqIot.DbModel
{
    public partial class SysUser : BaseEntity
    {
        public SysUser()
        {
            CompanyUser = new HashSet<CompanyUser>();
        }

        public string Email { get; set; }
        public string LastIP { get; set; }
        public DateTime? LastTime { get; set; }
        public string LastUrl { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string QQ { get; set; }
        public int Status { get; set; }
        public string SysDepartmentSerialnum { get; set; }
        public string SysRoleSerialnum { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<CompanyUser> CompanyUser { get; set; }
        public virtual SysDepartment SysDepartmentSerialnumNavigation { get; set; }
        public virtual SysRole SysRoleSerialnumNavigation { get; set; }
    }
}