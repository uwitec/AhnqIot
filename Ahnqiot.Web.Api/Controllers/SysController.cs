using System.Linq;
using System.Web.Http;
using Ahnqiot.Web.Api.Providers.Results;
using AhnqIot.Bussiness.Interface;

namespace Ahnqiot.Web.Api.Controllers
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
            return new ApiResult(ExceptionCode.Success, "", list);
        }
        /// <summary>
        /// 获取系统所有机构
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetDepartments()
        {
            var list = SysDepartmentService.GetAll().OrderBy(e => e.Sort).Select(e => new { code = e.Serialnum, name = e.Name, parent = e.ParentSerialnum });
            return new ApiResult(ExceptionCode.Success, "", list);
        }
    }
}
