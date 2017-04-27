using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ahnqiot.Web.Api.Models;
using Ahnqiot.Web.Api.Providers.Results;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using WebGrease.Css.Extensions;

namespace Ahnqiot.Web.Api.Controllers
{
    public class FarmController : ApiController
    {
        public IFarmService farmService { get; set; }
        public ICompanyUserService companyUserService { get; set; }


        [HttpGet]
        public async Task<IHttpActionResult> GetByUser(string userId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var companyUser = await companyUserService.GetBySysUserIdAsync(userId);
                FarmDto farm = null;
                    if (companyUser != null)
                    {
                         farm = await farmService.GetByIdWithRedisAsync(companyUser.FarmSerialnum);
                    }
                return new ApiResult(ExceptionCode.Success, "", farm); 
            }, userId, "success", "请检查请求参数"); 
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUploadPwd(string farmId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
           (await farmService.GetByIdWithRedisAsync(arg)).UploadPassword, farmId, "success", "请检查请求参数"); 
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetApiKey(string farmId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
           (await farmService.GetByIdWithRedisAsync(arg)).APIKey, farmId, "success", "请检查请求参数");

        }
        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] FarmModel farm)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await farmService.UpdateAsync(new FarmDto
                    {
                        APIKey = farm.APIKey,
                        AreaStationSerialnum = farm.AreaStationSerialnum,
                        CompanySerialnum = farm.CompanySerialnum,
                        Name = farm.Name,
                        SysDepartmentSerialnum = farm.SysDepartmentSerialnum,
                        UploadPassword = farm.UploadPassword,
                        UpdateTime = DateTime.Now
                    }) > 0;

                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, farm, "success", "请检查请求参数"); 
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] FarmModel farm)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await farmService.AddAsync(new FarmDto
                    {
                        APIKey = farm.APIKey,
                        AreaStationSerialnum = farm.AreaStationSerialnum,
                        CompanySerialnum = farm.CompanySerialnum,
                        Name = farm.Name,
                        SysDepartmentSerialnum = farm.SysDepartmentSerialnum,
                        UploadPassword = farm.UploadPassword,
                        UpdateTime = DateTime.Now,
                        CreateTime=DateTime.Now,
                        Sort=0,
                        Status=true
                    }) > 0;

                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, farm, "success", "请检查请求参数"); 
        }
    }
}
