#region Code File Comment
// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Dto
// FILENAME   ： SysUserDto.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-13 15:24
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;

namespace AhnqIot.Dto
{
    public class SysUserDto : BaseDto
    {
        public string Email { get; set; }
        public string LastIP { get; set; }
        public DateTime? LastTime { get; set; }
        public string LastUrl { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string QQ { get; set; }
        public int Status { get; set; }
        public string SysDepartmentSerialnum { get; set; }
        public string SysRoleSerialnum { get; set; }
        public string UserName { get; set; }
    }
}