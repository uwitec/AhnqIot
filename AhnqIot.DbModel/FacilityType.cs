#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： FacilityType.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

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
    public partial class FacilityType : BaseEntity
    {
        public FacilityType()
        {
            Facility = new HashSet<Facility>();
        }
        [ProtoMember(1)]
        public string Css { get; set; }
        [ProtoMember(2)]
        public string Introduce { get; set; }
        [ProtoMember(3)]
        public bool IsSystem { get; set; }
        [ProtoMember(4)]
        public string Name { get; set; }
        [ProtoMember(5)]
        public string ParentSerialnum { get; set; }
        [ProtoMember(6)]
        public string PhotoUrl { get; set; }
        [ProtoMember(7)]
        public virtual ICollection<Facility> Facility { get; set; }
    }
}