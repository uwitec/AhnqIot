using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
  public  interface IWeatherStationOnlineStatisticsService: IService<WeatherStationOnlineStatisticsDto>
    {
        /// <summary>
        /// 根据气象仪设备编码以及时间获取
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<IEnumerable<WeatherStationOnlineStatisticsDto>> GetByDeviceIdAndTimeAsny(string deviceId, int year,int month);
    }
}
