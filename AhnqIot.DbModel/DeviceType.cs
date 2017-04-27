#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： DeviceType.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace
using ProtoBuf;
using System.Collections.Generic;

#endregion

namespace AhnqIot.DbModel
{
    [ProtoContract]
    public partial class DeviceType : BaseEntity
    {
        public DeviceType()
        {
            AgrDiagnosticModel = new HashSet<AgrDiagnosticModel>();
            Device = new HashSet<Device>();
        }
        [ProtoMember(1)]
        public string Introduce { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string ParentSerialnum { get; set; }
        [ProtoMember(4)]
        public string PhotoUrl { get; set; }
        [ProtoMember(5)]
        public int ValueCount { get; set; }
        [ProtoMember(6)]
        public virtual ICollection<AgrDiagnosticModel> AgrDiagnosticModel { get; set; }
        [ProtoMember(7)]
        public virtual ICollection<Device> Device { get; set; }
    }
}