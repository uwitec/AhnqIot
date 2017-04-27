using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
  public  interface IWeatherDeviceService:IService<WeatherDeviceDto>
  {
        /// <summary>
        ///  根据气象站编码获取
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        Task<IEnumerable<WeatherDeviceDto>> GetByStationIdAsny(string stationId);
    }
}
