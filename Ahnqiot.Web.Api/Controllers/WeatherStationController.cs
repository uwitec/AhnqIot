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
    public class WeatherStationController : ApiController
    {
        public IWeatherStationService weatherStationService { get; set; }
        public IWeatherDeviceService weatherDeviceService { get; set; }
        public IWeatherStationOnlineStatisticsService weatherStationOnlineStatisticsService { get; set; }


        [HttpGet]
        public async Task<IHttpActionResult> GetStationByDepart(string sysDepart)
        {
            return await  ResultFactory.Create(ModelState, async arg => await weatherStationService.GetManyAsync(w => w.SysDepartmentSerialnum.Equals(arg)) , sysDepart, "success", "请检查请求参数");
        }

        //GetDevice
        [HttpGet]
        public async Task<IHttpActionResult> GetDevice(string stationId)
        {
            return await  ResultFactory.Create(ModelState, async arg => await weatherDeviceService.GetManyAsync(w => w.WeatherStationSerialnum.Equals(arg)), stationId, "success", "请检查请求参数");
        }

        //GetStationOnlineStatistics
        [HttpGet]
        public async Task<IHttpActionResult> GetStationOnlineStatistics(string deviceId,int year,int month)
        {
            return await  ResultFactory.Create(ModelState, async arg =>
           await weatherStationOnlineStatisticsService.GetByDeviceIdAndTimeAsny(deviceId,year,month), deviceId, "success", "请检查请求参数");
        }
    }
}
