#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： SysDepartment.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Collections.Generic;

#endregion

namespace AhnqIot.DbModel
{
    public partial class SysDepartment : BaseEntity
    {
        public SysDepartment()
        {
            AreaStation = new HashSet<AreaStation>();
            AWProduct = new HashSet<AWProduct>();
            CameraStations = new HashSet<CameraStations>();
            Company = new HashSet<Company>();
            Farm = new HashSet<Farm>();
            SysUser = new HashSet<SysUser>();
            WeatherStation = new HashSet<WeatherStation>();
            WeatherWarn = new HashSet<WeatherWarn>();
        }

        public string Description { get; set; }
        public string Name { get; set; }
        public string ParentSerialnum { get; set; }
        public int Status { get; set; }
        public string SysAreaSerialnum { get; set; }
        public virtual ICollection<AreaStation> AreaStation { get; set; }
        public virtual ICollection<AWProduct> AWProduct { get; set; }
        public virtual ICollection<CameraStations> CameraStations { get; set; }
        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<Farm> Farm { get; set; }
        public virtual ICollection<SysUser> SysUser { get; set; }
        public virtual ICollection<WeatherStation> WeatherStation { get; set; }
        public virtual ICollection<WeatherWarn> WeatherWarn { get; set; }
        public virtual SysArea SysAreaSerialnumNavigation { get; set; }
    }
}