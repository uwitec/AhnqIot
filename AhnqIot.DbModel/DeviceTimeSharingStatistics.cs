#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： DeviceTimeSharingStatistics.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace
using ProtoBuf;
using System;
#endregion

namespace AhnqIot.DbModel
{
    [Serializable]
    [ProtoContract]
    public partial class DeviceTimeSharingStatistics : BaseEntity
    {
        [ProtoMember(1)]
        public decimal AvgValue { get; set; }
        [ProtoMember(2)]
        public int Count { get; set; }
        [ProtoMember(3)]
        public string DeviceSerialnum { get; set; }
        [ProtoMember(4)]
        public decimal EndValue { get; set; }
        [ProtoMember(5)]
        public int ExceptionCount { get; set; }
        [ProtoMember(6)]
        public decimal Max { get; set; }
        [ProtoMember(7)]
        public decimal MaxValue { get; set; }
        [ProtoMember(8)]
        public decimal Min { get; set; }
        [ProtoMember(9)]
        public decimal MinValue { get; set; }
        [ProtoMember(10)]
        public decimal StartValue { get; set; }
        [ProtoMember(11)]
        public int TimeSharing { get; set; }
        [ProtoMember(12)]
        public virtual Device DeviceSerialnumNavigation { get; set; }
    }
}