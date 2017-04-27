using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Hxj.Repository.AhnqIot;
using AutoMapper;

namespace AhnqIot.Bussiness
{
    public class WeatherStationOnlineStatisticsService :
        ServiceBase<WeatherStationOnlineStatistics, WeatherStationOnlineStatisticsDto>,
        IWeatherStationOnlineStatisticsService
    {

        /// <summary>
        /// 根据气象仪设备编码以及时间获取
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<IEnumerable<WeatherStationOnlineStatisticsDto>> GetByDeviceIdAndTimeAsny(string deviceId,
            int year, int month)
        {
            return
                Mapper.Map<IEnumerable<WeatherStationOnlineStatisticsDto>>(
                    await
                        Repository.GetManyAsync(
                            w =>
                                w.WeatherDeviceSerialnum.Equals(deviceId) && w.Year.Equals(year) &&
                                w.Month.Equals(month)));
        }
    }
}
