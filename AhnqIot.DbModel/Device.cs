#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： Device.cs
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
    public partial class Device : BaseEntity
    { 
      
        public Device()
        {
            DeviceControlCommand = new HashSet<DeviceControlCommand>();
            DeviceControlLog = new HashSet<DeviceControlLog>();
            DeviceDataExceptionLog = new HashSet<DeviceDataExceptionLog>();
            DeviceDataInfo = new HashSet<DeviceDataInfo>();
            DeviceExceptionSet = new HashSet<DeviceExceptionSet>();
            DeviceRunLog = new HashSet<DeviceRunLog>();
            DeviceRunningStatistics = new HashSet<DeviceRunningStatistics>();
            DeviceTimeSharingStatistics = new HashSet<DeviceTimeSharingStatistics>();
        }
        [ProtoMember(1)]
        public string DeviceTypeSerialnum { get; set; }
        [ProtoMember(2)]
        public string FacilitySerialnum { get; set; }
        [ProtoMember(3)]
        public bool IsException { get; set; }
        [ProtoMember(4)]
        public string Location { get; set; }
        [ProtoMember(5)]
        public string Name { get; set; }
        [ProtoMember(6)]
        public bool OnlineStatus { get; set; }
        [ProtoMember(7)]
        public string PhotoUrl { get; set; }
        [ProtoMember(8)]
        public decimal ProcessedValue { get; set; }
        [ProtoMember(9)]
        public string ShowValue { get; set; }
        [ProtoMember(10)]
        public int Status { get; set; }
        [ProtoMember(11)]
        public string Unit { get; set; }
        [ProtoMember(13)]
        public string RelayType { get; set; }
        [ProtoMember(14)]
        public virtual ICollection<DeviceControlCommand> DeviceControlCommand { get; set; }
        [ProtoMember(15)]
        public virtual ICollection<DeviceControlLog> DeviceControlLog { get; set; }
        [ProtoMember(16)]
        public virtual ICollection<DeviceDataExceptionLog> DeviceDataExceptionLog { get; set; }
        [ProtoMember(17)]
        public virtual ICollection<DeviceDataInfo> DeviceDataInfo { get; set; }
        [ProtoMember(18)]
        public virtual ICollection<DeviceExceptionSet> DeviceExceptionSet { get; set; }
        [ProtoMember(19)]
        public virtual ICollection<DeviceRunLog> DeviceRunLog { get; set; }
        [ProtoMember(20)]
        public virtual ICollection<DeviceRunningStatistics> DeviceRunningStatistics { get; set; }
        [ProtoMember(21)]
        public virtual ICollection<DeviceTimeSharingStatistics> DeviceTimeSharingStatistics { get; set; }
        [ProtoMember(22)]
        public virtual DeviceType DeviceTypeSerialnumNavigation { get; set; }
        [ProtoMember(23)]
        public virtual Facility FacilitySerialnumNavigation { get; set; }
    }
}