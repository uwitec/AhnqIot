#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： FacilityCamera.cs
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
    public partial class FacilityCamera : BaseEntity
    {
        public FacilityCamera()
        {
            FacilityCameraPresetPoint = new HashSet<FacilityCameraPresetPoint>();
            FacilityCameraRunLog = new HashSet<FacilityCameraRunLog>();
            FacilityCameraRunStatistics = new HashSet<FacilityCameraRunStatistics>();
        }
        [ProtoMember(1)]
        public int Channel { get; set; }
        [ProtoMember(2)]
        public int DataPort { get; set; }
        [ProtoMember(3)]
        public string FacilitySerialnum { get; set; }
        [ProtoMember(4)]
        public int HttpPort { get; set; }
        [ProtoMember(5)]
        public string IP { get; set; }
        [ProtoMember(6)]
        public string Location { get; set; }
        [ProtoMember(7)]
        public string Name { get; set; }
        [ProtoMember(8)]
        public int RtspPort { get; set; }
        [ProtoMember(9)]
        public bool Status { get; set; }
        [ProtoMember(10)]
        public string UserID { get; set; }
        [ProtoMember(11)]
        public string UserPwd { get; set; }
        [ProtoMember(12)]
        public virtual ICollection<FacilityCameraPresetPoint> FacilityCameraPresetPoint { get; set; }
        [ProtoMember(13)]
        public virtual ICollection<FacilityCameraRunLog> FacilityCameraRunLog { get; set; }
        [ProtoMember(14)]
        public virtual ICollection<FacilityCameraRunStatistics> FacilityCameraRunStatistics { get; set; }
    }
}