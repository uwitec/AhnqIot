using AhnqIot.Bussiness.Interface;
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
    public class AWProductController : ApiController
    {
        public IAWProductService aWProductService { get; set; }
        public IAWProductTypeService aWProductTypeService { get; set; }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string id)
        {
            return await  ResultFactory.Create(ModelState, async arg => await aWProductService.GetByIdWithRedisAsync(arg), id,"success","请检查请求参数");
      
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return await  ResultFactory.Create(ModelState, async arg =>
             await aWProductService.GetAllAsync(), "", "success", "未知");
           
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByType(string typeId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
await aWProductService.GetAsync(p => p.AWProductTypeSerialnum.Equals(arg)), typeId, "success", "请检查请求参数");
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByTime(string id,int year,int month)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            await aWProductService.GetByTimeAsync(id, year, month),id ,"success", "请检查请求参数");
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTypes()
        {
                return await  ResultFactory.Create(ModelState, async arg => await aWProductTypeService.GetAllWidthRedisAsync(), "", "success", "未知");    
        }

    }
}
