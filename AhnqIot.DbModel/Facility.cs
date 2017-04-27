#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： Facility.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace
using ProtoBuf;
using System;
using System.Collections.Generic;
#endregion

namespace AhnqIot.DbModel
{
    [Serializable]
    [ProtoContract]
    public partial class Facility : BaseEntity
    {
        public Facility()
        {
            Device = new HashSet<Device>();
            FacilityPics = new HashSet<FacilityPics>();
            FacilityProduceInfo = new HashSet<FacilityProduceInfo>();
        }
        [ProtoMember(1)]
        public string Address { get; set; }
        [ProtoMember(2)]
        public string ContactMan { get; set; }
        [ProtoMember(3)]
        public string ContactMobile { get; set; }
        [ProtoMember(4)]
        public string ContactPhone { get; set; }
        [ProtoMember(5)]
        public string FacilityTypeSerialnum { get; set; }
        [ProtoMember(6)]
        public string FarmSerialnum { get; set; }
        [ProtoMember(7)]
        public string Introduce { get; set; }
        [ProtoMember(8)]
        public string Name { get; set; }
        [ProtoMember(9)]
        public string PhotoUrl { get; set; }
        [ProtoMember(10)]
        public int Status { get; set; }
        [ProtoMember(11)]
        public virtual ICollection<Device> Device { get; set; }
        [ProtoMember(12)]
        public virtual ICollection<FacilityPics> FacilityPics { get; set; }
        [ProtoMember(13)]
        public virtual ICollection<FacilityProduceInfo> FacilityProduceInfo { get; set; }
        [ProtoMember(14)]
        public virtual FacilityType FacilityTypeSerialnumNavigation { get; set; }
        [ProtoMember(15)]
        public virtual Farm FarmSerialnumNavigation { get; set; }
    }
}