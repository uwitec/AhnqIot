#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： WeatherStation.cs
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
    public partial class WeatherStation : BaseEntity
    {
        public WeatherStation()
        {
            WeatherDevice = new HashSet<WeatherDevice>();
        }

        public string Introduce { get; set; }
        public string Latitude { get; set; }
        public string Location { get; set; }
        public string Lotitude { get; set; }
        public DateTime? SetupTime { get; set; }
        public string SysDepartmentSerialnum { get; set; }
        public int? UploadExperiod { get; set; }
        public virtual ICollection<WeatherDevice> WeatherDevice { get; set; }
        public virtual SysDepartment SysDepartmentSerialnumNavigation { get; set; }
    }
}