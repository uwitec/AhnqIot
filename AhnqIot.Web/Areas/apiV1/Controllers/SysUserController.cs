//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： AhnqIot.Web
//  FILENAME   ： SysUserController.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 13:44
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Web.Areas.apiV1.ApiResult;
using AhnqIot.Web.Areas.apiV1.Models;
using WebGrease.Css.Extensions;

namespace AhnqIot.Web.Areas.apiV1.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    //  [RouteArea("api")]
//    [System.Web.Http.RoutePrefix("User")]
    public class SysUserController : ApiController
    {
        public ISysUserService SysUserService { get; set; }

        public ICompanyService CompanyService { get; set; }

        public IFarmService FarmService { get; set; }

        [HttpPost]
        public async Task<IHttpActionResult> Register([FromBody] UserRegisterBaseModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await SysUserService.AddAsync(new SysUserDto()
                    {
                        LoginName = user.LoginName,
                        UserName = user.Name,
                        Password = user.Password,
                        Email = user.Email,
                        SysRoleSerialnum = user.RoleCode,
                        SysDepartmentSerialnum = user.DepartmentCode,
                        Status = 0,
                        CreateTime = DateTime.Now
                    });
                }
                catch (AggregateException ex)
                {
                    if (ex.InnerExceptions.Any())
                    {
                        ex.InnerExceptions.ForEach(e => { ModelState.AddModelError(e.HResult.ToString(), e); });
                    }
                }
            }
            else
            {
                ModelState.AddModelError("user", "用户添加失败");
            }
            return new ApiV1Result(ModelState.IsValid ? ResultMessageType.Success : ResultMessageType.InternalError,
                ModelState.ToString());
        }

        [HttpPost]
        public async Task<IHttpActionResult> RegisterIotUser([FromBody] UserRegisterIotModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await SysUserService.AddAsync(new SysUserDto()
                    {
                        LoginName = user.LoginName,
                        UserName = user.Name,
                        Password = user.Password,
                        Email = user.Email,
                        SysRoleSerialnum = user.RoleCode,
                        SysDepartmentSerialnum = user.DepartmentCode,
                        Status = 0,
                        CreateTime = DateTime.Now
                    });
                    if (result > 0)
                    {
                        //添加企业
                        var company = new CompanyDto
                        {
                            Serialnum = user.DepartmentCode + "", //todo 生成企业编码
                            Name = user.CompanyName,
                            Addr = user.Location,
                            Status = 0,
                            CreateTime = DateTime.Now,
                            SysDepartmentSerialnum = user.DepartmentCode,
                            ContactMan = user.Name,
                            ContactPhone = user.Mobile
                        };

                        var companyInsertResult = await CompanyService.AddAsync(company);
                        if (companyInsertResult > 0)
                        {
                            //添加基地
                            var farm = new FarmDto();
                            farm.Serialnum = company.Serialnum;
                            farm.APIKey = Guid.NewGuid().ToString();
                            farm.UploadPassword = "123456"; //上传密码应随机生成
                            farm.Name = company.Name + "-默认基地";
                            farm.CompanySerialnum = company.Serialnum;
                            farm.Address = company.Addr;
                            farm.ContactMan = user.Name;
                            farm.ContactPhone = user.Mobile;
                            farm.Status = false;
                            farm.SysDepartmentSerialnum = user.DepartmentCode;

                            await FarmService.AddAsync(farm);
                        }
                        else
                        {
                            ModelState.AddModelError("farm", "默认基地生成失败");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("company", "企业添加失败");
                    }
                }
                catch (AggregateException ex)
                {
                    if (ex.InnerExceptions.Any())
                    {
                        ex.InnerExceptions.ForEach(e => { ModelState.AddModelError(e.HResult.ToString(), e); });
                    }
                }
            }
            else
            {
                ModelState.AddModelError("user", "用户添加失败");
            }
            return new ApiV1Result(ModelState.IsValid ? ResultMessageType.Success : ResultMessageType.InternalError,
                ModelState.ToString(), null);
        }
        
        [HttpPost]
        public async Task<IHttpActionResult> Login([FromBody] UserLoginModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await SysUserService.LoginAsync(user.LoginName, user.Password);
                    return new ApiV1Result(result ? ResultMessageType.Success : ResultMessageType.InternalError, "",
                        null);
                }
                catch (AggregateException ex)
                {
                    if (ex.InnerExceptions.Any())
                    {
                        ex.InnerExceptions.ForEach(e => { ModelState.AddModelError(e.HResult.ToString(), e); });
                    }
                    return new ApiV1Result(ResultMessageType.InternalError, ModelState.ToString(), null);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}