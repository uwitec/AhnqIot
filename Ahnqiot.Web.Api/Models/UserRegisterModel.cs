//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Web
//  FILENAME   ： UserRegisterModel.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 14:49
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016
namespace Ahnqiot.Web.Api.Models
{
    public class UserRegisterBaseModel
    {
        public string LoginName { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string RoleCode { get; set; }

        public string DepartmentCode { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }
}