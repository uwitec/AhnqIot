#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： AreaStation.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Collections.Generic;

#endregion

namespace AhnqIot.DbModel
{
    public partial class AreaStation : BaseEntity
    {
        public AreaStation()
        {
            AreaStationDataInfo = new HashSet<AreaStationDataInfo>();
            Farm = new HashSet<Farm>();
        }

        public string Addr { get; set; }
        public decimal Atmosphere { get; set; }
        public decimal Humidity { get; set; }
        public string Latitude { get; set; }
        public string Lontitude { get; set; }
        public decimal Rainfall { get; set; }
        public string StationCode { get; set; }
        public string SysDepartmentSerialnum { get; set; }
        public decimal Temprature { get; set; }
        public int WindDirection { get; set; }
        public decimal WindSpeed { get; set; }
        public virtual ICollection<AreaStationDataInfo> AreaStationDataInfo { get; set; }
        public virtual ICollection<Farm> Farm { get; set; }
        public virtual SysDepartment SysDepartmentSerialnumNavigation { get; set; }
    }
}