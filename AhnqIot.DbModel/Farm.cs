#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： Farm.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Collections.Generic;
using ProtoBuf;
#endregion

namespace AhnqIot.DbModel
{
    [ProtoContract]
    public partial class Farm : BaseEntity
    {
        public Farm()
        {
            Facility = new HashSet<Facility>();
        }
        [ProtoMember(1)]
        public string Address { get; set; }
        [ProtoMember(2)]
        public string APIKey { get; set; }
        [ProtoMember(3)]
        public string AreaStationSerialnum { get; set; }
        [ProtoMember(4)]
        public string CompanySerialnum { get; set; }
        [ProtoMember(5)]
        public string ContactMan { get; set; }
        [ProtoMember(6)]
        public string ContactPhone { get; set; }
        [ProtoMember(7)]
        public string Introduce { get; set; }
        [ProtoMember(8)]
        public string Latitude { get; set; }
        [ProtoMember(9)]
        public string Location { get; set; }
        [ProtoMember(10)]
        public string Lotitude { get; set; }
        [ProtoMember(11)]
        public string Name { get; set; }
        [ProtoMember(12)]
        public string PhotoUrl { get; set; }
        [ProtoMember(13)]
        public bool Status { get; set; }
        [ProtoMember(14)]
        public string SysDepartmentSerialnum { get; set; }
        [ProtoMember(15)]
        public string UploadPassword { get; set; }
        [ProtoMember(16)]
        public virtual ICollection<Facility> Facility { get; set; }
        [ProtoMember(17)]
        public virtual AreaStation AreaStationSerialnumNavigation { get; set; }
        [ProtoMember(18)]
        public virtual Company CompanySerialnumNavigation { get; set; }
        [ProtoMember(19)]
        public virtual SysDepartment SysDepartmentSerialnumNavigation { get; set; }
    }
}