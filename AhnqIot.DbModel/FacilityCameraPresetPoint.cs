#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： FacilityCameraPresetPoint.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Collections.Generic;
using ProtoBuf;
#endregion

namespace AhnqIot.DbModel
{
    [ProtoContract]
    public partial class FacilityCameraPresetPoint : BaseEntity
    {
        [ProtoMember(1)]
        public string FacilityCameraSerialnum { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int PresetPoint { get; set; }
        [ProtoMember(4)]
        public virtual FacilityCamera FacilityCameraSerialnumNavigation { get; set; }
        [ProtoMember(5)]
        public virtual ICollection<FacilityPics> FacilityPics { get; set; }
  
    }
}