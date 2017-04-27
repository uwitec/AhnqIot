#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： DeviceRunLogType.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace
using ProtoBuf;
using System.Collections.Generic;

#endregion

namespace AhnqIot.DbModel
{
    [ProtoContract]
    public partial class DeviceRunLogType : BaseEntity
    {
        public DeviceRunLogType()
        {
            DeviceRunLog = new HashSet<DeviceRunLog>();
        }
        [ProtoMember(1)]
        public string Introduce { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public virtual ICollection<DeviceRunLog> DeviceRunLog { get; set; }
    }
}