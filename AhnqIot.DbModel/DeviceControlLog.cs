#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： DeviceControlLog.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace
using ProtoBuf;
#endregion

namespace AhnqIot.DbModel
{
    [ProtoContract]
    public partial class DeviceControlLog : BaseEntity
    {
        [ProtoMember(1)]
        public string CommandSerialnum { get; set; }
        [ProtoMember(2)]
        public bool ControlResult { get; set; }
        [ProtoMember(3)]
        public string DeviceSerialnum { get; set; }
        [ProtoMember(4)]
        public string DeviceShowValue { get; set; }
        [ProtoMember(5)]
        public decimal DeviceValue { get; set; }
        [ProtoMember(6)]
        public string FailReason { get; set; }
        [ProtoMember(7)]
        public virtual DeviceControlCommand CommandSerialnumNavigation { get; set; }
        [ProtoMember(8)]
        public virtual Device DeviceSerialnumNavigation { get; set; }
    }
}