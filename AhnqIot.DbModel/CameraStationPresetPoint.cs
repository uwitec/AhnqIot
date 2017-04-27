#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： CameraStationPresetPoint.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Collections.Generic;

#endregion

namespace AhnqIot.DbModel
{
    public partial class CameraStationPresetPoint : BaseEntity
    {
        public CameraStationPresetPoint()
        {
            CameraStationPics = new HashSet<CameraStationPics>();
        }

        public string Name { get; set; }
        public string CameraStationsSerialnum { get; set; }
        public int PresetPoint { get; set; }
        public virtual ICollection<CameraStationPics> CameraStationPics { get; set; }
        public virtual CameraStations CameraStationsSerialnumNavigation { get; set; }
    }
}