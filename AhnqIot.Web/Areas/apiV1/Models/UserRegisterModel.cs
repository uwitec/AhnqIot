//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： AhnqIot.Web
//  FILENAME   ： UserRegisterModel.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 14:49
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016
namespace AhnqIot.Web.Areas.apiV1.Models
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