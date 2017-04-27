#region Code File Comment
// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Dto
// FILENAME   ： SysDepartment.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-13 17:39
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion
using ProtoBuf;
namespace AhnqIot.Dto
{
    [ProtoContract]
    public class SysDepartmentDto : BaseDto
    {
        [ProtoMember(1)]
        public string Description { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string ParentSerialnum { get; set; }
        [ProtoMember(4)]
        public int Status { get; set; }
        [ProtoMember(5)]
        public string SysAreaSerialnum { get; set; }

    }
}