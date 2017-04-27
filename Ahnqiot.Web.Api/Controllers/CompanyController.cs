using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ahnqiot.Web.Api.Models;
using Ahnqiot.Web.Api.Providers.Results;
using AhnqIot.Bussiness;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using NewLife.Common;
using WebGrease.Css.Extensions;

namespace Ahnqiot.Web.Api.Controllers
{
    public class CompanyController : ApiController
    {
        public ICompanyService companyService { get; set; }
        public ICompanyUserService companyUserService { get; set; }

        /// <summary>
        /// 根据系统用户编码获取企业
        /// </summary>
        /// <param name="userId">系统用户编码</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetByUser(string userId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var companyUser = await companyUserService.GetBySysUserIdAsync(userId);
                CompanyDto company = null;
                if (companyUser != null)
                {
                    company = await companyService.GetByIdAsync(companyUser.CompanySerialnum); 
                }
                return new ApiResult(ExceptionCode.Success, "", company);
            }, userId, "success", "请检查请求参数"); 
        }
        /// <summary>
        /// 更新企业
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] CompanyModel company)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await companyService.UpdateAsync(new CompanyDto
                    {
                        Name = company.Name,
                        Pinyin = PinYin.GetFirst(company.Name).ToUpper(),
                        Sort = 0,
                        Status = 1,
                        UpdateTime = DateTime.Now
                    }) > 0; 
                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "", null);
                }, company, "success", "请检查请求参数"); 
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(string companyId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var result = await companyService.DeleteAsync(companyId) > 0;
                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "", null); 
                }, companyId, "success", "请检查请求参数"); 
        }

    }
}
