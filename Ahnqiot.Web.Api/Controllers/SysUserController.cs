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
using Ahnqiot.Web.Api.Models;
using Ahnqiot.Web.Api.Providers.Results;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using WebGrease.Css.Extensions;

namespace Ahnqiot.Web.Api.Controllers
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
            return await  ResultFactory.Create(ModelState, async arg =>
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
                        CreateTime = DateTime.Now,
                        UpdateTime=DateTime.Now
                    });
                return true;
                }, user, "success", "请检查请求参数");
        }

        [HttpPost]
        public async Task<IHttpActionResult> RegisterIotUser([FromBody] UserRegisterIotModel user)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
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
                        CreateTime = DateTime.Now,
                        UpdateTime=DateTime.Now
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
                            UpdateTime=DateTime.Now,
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
                            farm.CreateTime = DateTime.Now;
                            farm.UpdateTime = DateTime.Now;
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
                return true;
            }, user, "success", "请检查请求参数");
        }

        [HttpPost]
        public async Task<IHttpActionResult> Login([FromBody] UserLoginModel user)
        {
            return await  ResultFactory.Create(ModelState, async arg => await SysUserService.LoginAsync(user.LoginName, user.Password), user.LoginName, "success", "请检查请求参数");
        }

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> UpdatePwd([FromBody] string userName, string pwd)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var user = await SysUserService.GetAsync(u => u.UserName.Equals(userName));
                    user.Password = pwd;
                    user.UpdateTime = DateTime.Now;

                    var result = await SysUserService.UpdateAsync(user) > 0;
                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                },userName, "success", "请检查请求参数");

        }

      
    }
}