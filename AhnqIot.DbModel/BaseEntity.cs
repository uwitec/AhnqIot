#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： BaseEntity.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 16:21
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using ProtoBuf;

#endregion

namespace AhnqIot.DbModel
{
    [Serializable]
    [ProtoContract]
    [ProtoInclude(10, typeof(AgrDiagnosticModel))]
    [ProtoInclude(11, typeof(Facility))]
    [ProtoInclude(12, typeof(Device))]
    [ProtoInclude(13, typeof(DeviceType))]
    [ProtoInclude(14, typeof(FacilityCamera))]
    [ProtoInclude(15, typeof(FacilityProduceInfo))]
    [ProtoInclude(16, typeof(FacilityType))]
    [ProtoInclude(17, typeof(Farm))]
    [ProtoInclude(18, typeof(Company))]
    [ProtoInclude(19, typeof(AgrDiagnosticInfo))]
    public class BaseEntity
    {
        [ProtoMember(1)]
        /// <summary>
        ///     编码
        /// </summary>
        public string Serialnum { get; set; }
        [ProtoMember(2)]
        /// <summary>
        ///     创建用户
        /// </summary>
        public string CreateSysUserSerialnum { get; set; }
        [ProtoMember(3)]
        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        [ProtoMember(4)]
        /// <summary>
        ///     更新用户
        /// </summary>
        public string UpdateSysUserSerialnum { get; set; }
        [ProtoMember(5)]
        /// <summary>
        ///     更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        [ProtoMember(6)]
        /// <summary>
        ///     顺序
        /// </summary>
        public int Sort { get; set; }
        [ProtoMember(7)]
        /// <summary>
        ///     备注
        /// </summary>
        public string Remark { get; set; }

        //public byte[] TimeStamp { get; set; }

        public BaseEntity()
        {
            Sort = 0;
        }
    }
}