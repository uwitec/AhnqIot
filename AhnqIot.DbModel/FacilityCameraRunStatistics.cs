#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： FacilityCameraRunStatistics.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

#endregion

namespace AhnqIot.DbModel
{
    public partial class FacilityCameraRunStatistics : BaseEntity
    {
        public int AllCount { get; set; }
        public int Day { get; set; }
        public string FacilityCameraSerialnum { get; set; }
        public int Month { get; set; }
        public int OnlineCount { get; set; }
        public decimal OnlinePercent { get; set; }
        public int Year { get; set; }
        public virtual FacilityCamera FacilityCameraSerialnumNavigation { get; set; }
    }
}