#region Code File Comment
// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Web
// FILENAME   ： SystemError.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-18 21:07
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016
#endregion
namespace AhnqIot.Web.Core.ConfigInfo
{
    public class SystemError
    {
        public bool ErrorToDeveloper { get; set; }

        public string DeveloperEmail { get; set; }

        public string DeveloperWechat { get; set; }
    }
}