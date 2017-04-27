using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Web.Http;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Web.Areas.apiV1.ApiResult;

namespace AhnqIot.Web.Areas.apiV1.Controllers
{

    /// <summary>
    /// 系统数据
    /// </summary>
    public class SysController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        public ISysRoleService SysRoleService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ISysDepartmentService SysDepartmentService { get; set; }

        /// <summary>
        /// 获取系统所有角色
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetRoles()
        {
            var list = SysRoleService.GetAll().OrderBy(e => e.Sort).Select(e => new { code = e.Serialnum, name = e.Name });
            return new ApiV1Result(ResultMessageType.Success, "", list);
        }
        /// <summary>
        /// 获取系统所有机构
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetDepartments()
        {
            var list = SysDepartmentService.GetAll().OrderBy(e => e.Sort).Select(e => new { code = e.Serialnum, name = e.Name, parent = e.ParentSerialnum });
            return new ApiV1Result(ResultMessageType.Success, "", list);
        }
    }
}
