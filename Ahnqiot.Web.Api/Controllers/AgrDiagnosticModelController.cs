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
    public class AgrDiagnosticModelController : ApiController
    {
        public IAgrDiagnosticModelService AgrDiagnosticModelService { get; set; }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string id)
        {
            return await ResultFactory.Create(ModelState, async arg => await AgrDiagnosticModelService.GetByIdWithRedisAsync(arg), id, "success", "请检查请求参数");
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] AgrDiagnosticModel model)
        {
            return await ResultFactory.Create(ModelState, async arg =>
            {
                var result = await AgrDiagnosticModelService.UpdateAsync(new AgrDiagnosticModelDto
                {
                    AgrProductObjectGrowthInfoSerialnum = arg.AgrProductObjectGrowthInfoSerialnum,
                    DeviceTypeSerialnum = arg.DeviceTypeSerialnum,
                    DisplayColor = arg.DisplayColor,
                    IsNotice = arg.IsNotice,
                    MaxValue = arg.MaxValue,
                    MinValue = arg.MinValue,
                    Name = arg.Name,
                    UpdateTime = DateTime.Now
                }) > 0;
                return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "", null);
            }, model, "success", "请检查请求参数");


        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] AgrDiagnosticModel model)
        {
            return await ResultFactory.Create(ModelState, async arg =>
            {
                var result = await AgrDiagnosticModelService.AddAsync(new AgrDiagnosticModelDto
                {
                    AgrProductObjectGrowthInfoSerialnum = model.AgrProductObjectGrowthInfoSerialnum,
                    DeviceTypeSerialnum = model.DeviceTypeSerialnum,
                    DisplayColor = model.DisplayColor,
                    IsNotice = model.IsNotice,
                    MaxValue = model.MaxValue,
                    MinValue = model.MinValue,
                    Name = model.Name,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    Sort = 0
                }) > 0;

                return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "", null);
            }, model, "success", "请检查请求参数");

        }

  


        [HttpPost]
        public async Task<IHttpActionResult> Delete(string modelId)
        {
            return await ResultFactory.Create(ModelState, async arg =>
            {
                var result = await AgrDiagnosticModelService.DeleteAsync(modelId) > 0;
                return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "", null);
            }, modelId, "success", "请检查请求参数");

        }

 
    }
}
