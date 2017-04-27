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
    public class CameraStationsController : ApiController
    {
        public ICameraStationsService cameraStationService { get; set; }
        public ICameraStationOnlineStatisticsService cameraStationOnlineStatisticsService { get; set; }
        public ICameraStationRunLogService cameraStationRunLogService { get; set; }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string stationId)
        {
            return await ResultFactory.Create(ModelState, async arg => await cameraStationService.GetByIdWithRedisAsync(arg), stationId, "success", "请检查请求参数");      
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return await  ResultFactory.Create(ModelState, async arg => await cameraStationService.GetAllWidthRedisAsync(), "", "success", "未知");  
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] CameraStationsModel camera)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await cameraStationService.UpdateAsync(new CameraStationsDto
                    {
                        SysDepartmentSerialnum = camera.SysDepartmentSerialnum,
                        HttpPort=camera.HttpPort,
                        RtspPort=camera.RtspPort,
                        DataPort=camera.DataPort,
                        Channel=camera.Channel,
                        SetupTime=camera.SetupTime,
                        Name = camera.Name,
                        UpdateTime = DateTime.Now
                    }) > 0;

                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, camera, "success", "请检查请求参数"); 
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] CameraStationsModel camera)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await cameraStationService.AddAsync(new CameraStationsDto
                    {
                        SysDepartmentSerialnum = camera.SysDepartmentSerialnum,
                        HttpPort = camera.HttpPort,
                        RtspPort = camera.RtspPort,
                        DataPort = camera.DataPort,
                        Channel = camera.Channel,
                        SetupTime = camera.SetupTime,
                        Name = camera.Name,
                        UpdateTime = DateTime.Now,
                        CreateTime=DateTime.Now,
                        Sort=0                       
                    }) > 0;

                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, camera, "success", "请检查请求参数");   
        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(string stationId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await cameraStationService.DeleteAsync(stationId) > 0;
                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, stationId, "success", "请检查请求参数"); 
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetStationOnlineStatistics(string stationId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var statistics = await cameraStationOnlineStatisticsService.GetManyAsync(s => s.CameraStationsSerialnum.Equals(stationId));
                return new ApiResult(ExceptionCode.Success, "", statistics); 
            }, stationId, "success", "请检查请求参数");
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetRunLog(string stationId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var logs = await cameraStationRunLogService.GetManyAsync(l => l.CameraStationsSerialnum.Equals(stationId));
                    return new ApiResult(ExceptionCode.Success, "", logs); 
                }, stationId, "success", "请检查请求参数");  
        }
    }
}
