#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： DeviceControlCommand.cs
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
    public partial class DeviceControlCommand : BaseEntity
    {
        public DeviceControlCommand()
        {
            DeviceControlLog = new HashSet<DeviceControlLog>();
        }
        [ProtoMember(1)]
        public string Command { get; set; }
        [ProtoMember(2)]
        public int ControlContinueTime { get; set; }
        [ProtoMember(3)]
        public string DeviceSerialnum { get; set; }
        [ProtoMember(4)]
        public int Status { get; set; }
        [ProtoMember(5)]
        public virtual ICollection<DeviceControlLog> DeviceControlLog { get; set; }
        [ProtoMember(6)]
        public virtual Device DeviceSerialnumNavigation { get; set; }
    }
}