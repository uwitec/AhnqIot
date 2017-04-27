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
    public class DeviceController : ApiController
    {
        public IDeviceService deviceService { get; set; }
        public ICompanyUserService companyUserService { get; set; }
        public IDeviceTypeService deviceTypeService { get; set; }
        public IDeviceControlCommandService deviceControlCmdService { get; set; }
        public IDeviceControlLogService deviceControlLogService { get; set; }
        public IDeviceRunLogService deviceRunLogService { get; set; }
        public IDeviceDataInfoService deviceDataInfoService { get; set; }
        public IDeviceRunningStatisticsService deviceRunningStatisticsService { get; set; }


        [HttpGet]
        public async Task<IHttpActionResult> GetByUser(string userId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var companyUser = await companyUserService.GetBySysUserIdAsync(userId);
                IEnumerable<DeviceDto> devices = null;
                if (companyUser != null)
                {
                    devices = await deviceService.GetDevicesByFacilityIdAsync(companyUser.FacilitySerialnum);

                }
                return new ApiResult(ExceptionCode.Success, "", devices.ToList());
                //return devices.ToList();
            }, userId, "success", "请检查请求参数"); 
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] DeviceModel device)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var result = await deviceService.UpdateAsync(new DeviceDto
                {
                    DeviceTypeSerialnum = device.DeviceTypeSerialnum,
                    FacilitySerialnum = device.FacilitySerialnum,
                    Name = device.Name,
                    UpdateTime = DateTime.Now
                }) > 0;

                return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                    null);
            }, device, "success", "请检查请求参数"); 
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] DeviceModel device)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var result = await deviceService.AddAsync(new DeviceDto
                {
                    DeviceTypeSerialnum = device.DeviceTypeSerialnum,
                    FacilitySerialnum = device.FacilitySerialnum,
                    Name = device.Name,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    Sort = 0,
                    Status = 1,
                    IsException = false,
                    OnlineStatus = true
                }) > 0;

                return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                    null);
            }, device, "success", "请检查请求参数"); 
        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(string deviceId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var result = await deviceService.DeleteAsync(deviceId) > 0;
                return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                    null);
            }, deviceId, "success", "请检查请求参数"); 
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetDeviceType(string deviceId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                var device = await deviceService.GetByIdAsync(deviceId);
                DeviceTypeDto deviceType = null;
                if (device != null)
                {
                     deviceType = await deviceTypeService.GetByIdWithRedisAsync(device.DeviceTypeSerialnum);
                }
                return new ApiResult(ExceptionCode.Success, "", deviceType); 
            }, deviceId, "success", "请检查请求参数"); 
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetControlCmd(string deviceId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
         await deviceControlCmdService.GetControlCommandByDeviceIdAsny(arg), deviceId, "success", "请检查请求参数");  
        }



        [HttpPost]
        public async Task<IHttpActionResult> AddControlLog([FromBody] DeviceControlLogModel log)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
            {
                    var result = await deviceControlLogService.AddAsync(new DeviceControlLogDto
                    {
                        CommandSerialnum = log.CommandSerialnum,
                        ControlResult = log.ControlResult,
                        DeviceSerialnum = log.DeviceSerialnum,
                        DeviceValue = log.DeviceValue,
                        UpdateTime = DateTime.Now,
                        CreateTime = DateTime.Now,
                        Sort = 0,
                    }) > 0;

                    return new ApiResult(result ? ExceptionCode.Success : ExceptionCode.InternalError, "",
                        null);
                }, log, "success", "请检查请求参数"); 
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetRunLog(string deviceId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
             await deviceRunLogService.GetManyAsync(l => l.DeviceSerialnum.Equals(arg)), deviceId, "success", "请检查请求参数"); 
        }

        //GetDataInfo
        [HttpGet]
        public async Task<IHttpActionResult> GetDataInfo(string deviceId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
           await deviceDataInfoService.GetManyAsync(l => l.DeviceSerialnum.Equals(arg)), deviceId, "success", "请检查请求参数");

        }

        //GetRunningStatistics
        [HttpGet]
        public async Task<IHttpActionResult> GetRunningStatistics(string deviceId)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
           await deviceRunningStatisticsService.GetManyAsync(l => l.DeviceSerialnum.Equals(arg)), deviceId, "success", "请检查请求参数"); 
        }
    }
}
