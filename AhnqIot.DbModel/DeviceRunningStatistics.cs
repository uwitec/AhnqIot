#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： DeviceRunningStatistics.cs
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
    public partial class DeviceRunningStatistics : BaseEntity
    {
        [ProtoMember(1)]
        public int AllCount { get; set; }
        [ProtoMember(2)]
        public int DataExceptionCount { get; set; }
        [ProtoMember(3)]
        public decimal DataExceptionPercent { get; set; }
        [ProtoMember(4)]
        public int Day { get; set; }
        [ProtoMember(5)]
        public string DeviceSerialnum { get; set; }
        [ProtoMember(6)]
        public int Month { get; set; }
        [ProtoMember(7)]
        public int ReceiveCount { get; set; }
        [ProtoMember(8)]
        public decimal ReceivePercent { get; set; }
        [ProtoMember(9)]
        public int Year { get; set; }
        [ProtoMember(10)]
        public virtual Device DeviceSerialnumNavigation { get; set; }
    }
}