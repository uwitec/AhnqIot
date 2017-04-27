#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： DeviceDataInfo.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace
using ProtoBuf;
#endregion

namespace AhnqIot.DbModel
{
    [ProtoContract]
    public partial class DeviceDataInfo : BaseEntity
    {
        [ProtoMember(1)]
        public string DeviceSerialnum { get; set; }
        [ProtoMember(2)]
        public bool IsException { get; set; }
        [ProtoMember(3)]
        public decimal Max { get; set; }
        [ProtoMember(4)]
        public decimal Min { get; set; }
        [ProtoMember(5)]
        public int OriginalData { get; set; }
        [ProtoMember(6)]
        public decimal ProcessedValue { get; set; }
        [ProtoMember(7)]
        public string ShowValue { get; set; }
        [ProtoMember(8)]
        public virtual Device DeviceSerialnumNavigation { get; set; }
    }
}