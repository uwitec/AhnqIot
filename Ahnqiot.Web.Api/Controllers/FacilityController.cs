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
    public class FacilityController : ApiController
    {
        public IFacilityService facilityService { get; set; }
        public ICompanyUserService companyUserService { get; set; }
        public IFacilityTypeService facilityTypeService { get; set; }


        [HttpGet]
        public async Task<IHttpActionResult> GetByUser(string userId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var companyUser = await companyUserService.GetBySysUserIdAsync(userId);
                FacilityDto facility = null;
                if (companyUser != null)
                {
                    facility = await facilityService.GetByIdWithRedisAsync(companyUser.FacilitySerialnum);
                }
                return new ApiResult(ExceptionCode.Success, "", facility); 
            }, userId, "success", "请检查请求参数"); 
        }


        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] FacilityModel facitity)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await facilityService.UpdateAsync(new FacilityDto
                    {
                        FacilityTypeSerialnum = facitity.FacilityTypeSerialnum,
                        FarmSerialnum = facitity.FarmSerialnum,
                        Name = facitity.Name,
                        UpdateTime = DateTime.Now
                    }) > 0;

                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, facitity, "success", "请检查请求参数"); 
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] FacilityModel facitity)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await facilityService.AddAsync(new FacilityDto
                    {
                        FacilityTypeSerialnum = facitity.FacilityTypeSerialnum,
                        FarmSerialnum = facitity.FarmSerialnum,
                        Name = facitity.Name,
                        UpdateTime = DateTime.Now,
                        CreateTime = DateTime.Now,
                        Sort = 0,
                        Status = 1
                    }) > 0;

                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, facitity, "success", "请检查请求参数");

        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(string facilityId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await facilityService.DeleteAsync(facilityId) > 0;
                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
            }, facilityId, "success", "请检查请求参数");

        }

        [HttpGet]
        public async Task<IHttpActionResult> GetFacilityType(string facilityId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var facility = await facilityService.GetByIdWithRedisAsync(facilityId);
                FacilityTypeDto facilityType = null;
                    if (facility != null)
                    {
                         facilityType = await facilityTypeService.GetByIdWithRedisAsync(facility.FacilityTypeSerialnum);
                    }
                return new ApiResult(ExceptionCode.Success, "", facilityType); 
            }, facilityId, "success", "请检查请求参数");

        }
    }
}
