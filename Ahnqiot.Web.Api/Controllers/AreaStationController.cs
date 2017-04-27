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
    public class AreaStationController : ApiController
    {
        public IAreaStationService areaStationService { get; set; }
        public IAreaStationDataInfoService areaStationDataInfoService { get; set; }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string stationId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var station = await areaStationService.GetByIdWithRedisAsync(stationId);
                return new ApiResult(ExceptionCode.Success, "", station);
                //return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                //    null);
            }, stationId, "success", "请检查请求参数"); 
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return await  ResultFactory.Create(ModelState, async arg =>
           await areaStationService.GetAllWidthRedisAsync(), "", "success", "未知"); 
        }


        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] AreaStationModel station)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var result = await areaStationService.UpdateAsync(new AreaStationDto
                {
                    SysDepartmentSerialnum = station.SysDepartmentSerialnum,
                    StationCode = station.StationCode,
                    Temprature = station.Temprature,
                    Humidity = station.Humidity,
                    Atmosphere = station.Atmosphere,
                    WindDirection = station.WindDirection,
                    WindSpeed = station.WindSpeed,
                    Rainfall = station.Rainfall,
                    UpdateTime = DateTime.Now
                }) > 0;

                return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                    null);
            }, station, "success", "请检查请求参数"); 
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] AreaStationModel station)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var result = await areaStationService.AddAsync(new AreaStationDto
                {
                    SysDepartmentSerialnum = station.SysDepartmentSerialnum,
                    StationCode = station.StationCode,
                    Temprature = station.Temprature,
                    Humidity = station.Humidity,
                    Atmosphere = station.Atmosphere,
                    WindDirection = station.WindDirection,
                    WindSpeed = station.WindSpeed,
                    Rainfall = station.Rainfall,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    Sort = 0
                }) > 0;

                return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                    null);
            }, station, "success","请检查请求参数"); 

        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(string stationId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var result = await areaStationService.DeleteAsync(stationId) > 0;
                return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                    null);
            }, stationId, "success", "请检查请求参数"); 

        }

        [HttpGet]
        public async Task<IHttpActionResult> GetRunLog(string stationId)
        {
            return await  ResultFactory.Create(ModelState, async arg => await areaStationDataInfoService.GetManyAsync(l => l.AreaStationSerialnum.Equals(arg)), stationId, "success", "请检查请求参数"); 

        }
    }
}
