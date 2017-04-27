using Ahnqiot.Web.Api.Models;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ahnqiot.Web.Api.Providers.Results;
using WebGrease.Css.Extensions;

namespace Ahnqiot.Web.Api.Controllers
{
    public class SysRoleController : ApiController
    {
        public ISysRoleService sysRoleService { get; set; }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string id)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            await sysRoleService.GetByIdWithRedisAsync(arg), id, "success", "请检查请求参数"); 
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return await  ResultFactory.Create(ModelState, async arg =>
             await sysRoleService.GetAllWidthRedisAsync(), "", "success", "未知");
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] SysRoleModel role)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await sysRoleService.UpdateAsync(new SysRoleDto
                    {
                        Url = role.Url,
                        Name = role.Name,
                        UpdateTime = DateTime.Now
                    }) > 0;

                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, role, "success", "请检查请求参数"); 

        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] SysRoleModel role)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await sysRoleService.AddAsync(new SysRoleDto
                    {
                        Url = role.Url,
                        Name = role.Name,
                        UpdateTime = DateTime.Now,
                        CreateTime = DateTime.Now,
                        Sort = 0
                    }) > 0;

                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, role, "success", "请检查请求参数");

        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(string roleId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await sysRoleService.DeleteAsync(roleId) > 0;
                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                } , roleId, "success", "请检查请求参数");

        }
    }
}
