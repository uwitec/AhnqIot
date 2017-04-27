#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： Company.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Collections.Generic;

#endregion

namespace AhnqIot.DbModel
{
    public partial class Company : BaseEntity
    {
        public Company()
        {
            CompanyPics = new HashSet<CompanyPics>();
            CompanyUser = new HashSet<CompanyUser>();
            Farm = new HashSet<Farm>();
        }

        public string Addr { get; set; }
        public DateTime? ApplyTime { get; set; }
        public string ContactMan { get; set; }
        public string ContactPhone { get; set; }
        public string Introduce { get; set; }
        public string Latitude { get; set; }
        public string Lontitude { get; set; }
        public string Name { get; set; }
        public string Pinyin { get; set; }
        public int Status { get; set; }
        public string SysDepartmentSerialnum { get; set; }
        public virtual ICollection<CompanyPics> CompanyPics { get; set; }
        public virtual ICollection<CompanyUser> CompanyUser { get; set; }
        public virtual ICollection<Farm> Farm { get; set; }
        public virtual SysDepartment SysDepartmentSerialnumNavigation { get; set; }
    }
}