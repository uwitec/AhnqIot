#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： WeatherDeviceType.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Collections.Generic;

#endregion

namespace AhnqIot.DbModel
{
    public partial class WeatherDeviceType : BaseEntity
    {
        public WeatherDeviceType()
        {
            WeatherDevice = new HashSet<WeatherDevice>();
        }

        public string Calc { get; set; }
        public string Introduce { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string ParentSerialnum { get; set; }
        public string Unit { get; set; }
        public virtual ICollection<WeatherDevice> WeatherDevice { get; set; }
    }
}