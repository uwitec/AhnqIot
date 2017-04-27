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
    public class SysMenuController : ApiController
    {
        public ISysMenuService sysMenuService { get; set; }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string id)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
           await sysMenuService.GetByIdWithRedisAsync(arg), id, "success", "请检查请求参数");
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            await sysMenuService.GetAllWidthRedisAsync(), "", "success", "请检查请求参数");
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] SysMenuModel menu)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await sysMenuService.UpdateAsync(new SysMenuDto
                    {
                        Description = menu.Description,
                        Icon = menu.Icon,
                        Name=menu.Name,
                        Necessary = menu.Necessary,
                        ParentSerialnum = menu.ParentSerialnum,
                        SysFunctionSerialnum = menu.SysFunctionSerialnum,
                        Visiable=menu.Visiable,
                        UpdateTime = DateTime.Now
                    });

                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, menu, "success", "请检查请求参数"); 
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] SysMenuModel menu)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await sysMenuService.AddAsync(new SysMenuDto
                    {
                        Description = menu.Description,
                        Icon = menu.Icon,
                        Name = menu.Name,
                        Necessary = menu.Necessary,
                        ParentSerialnum = menu.ParentSerialnum,
                        SysFunctionSerialnum = menu.SysFunctionSerialnum,
                        Visiable = menu.Visiable,
                        UpdateTime = DateTime.Now,
                        CreateTime = DateTime.Now,
                        Status=1,
                        Sort = 0
                    });

                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, menu, "success", "请检查请求参数");

        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(string id)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
           await sysMenuService.DeleteAsync(arg), id, "success", "请检查请求参数");

        }
    }
}
