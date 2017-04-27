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
   public class WeatherDeviceService: ServiceBase<WeatherDevice, WeatherDeviceDto>, IWeatherDeviceService
    {

        /// <summary>
        ///  根据气象站编码获取
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<WeatherDeviceDto>> GetByStationIdAsny(string stationId)
       {
            return GetDtoModels(await Repository.GetManyAsync(w => w.WeatherStationSerialnum.Equals(stationId)));
        }
    }
}
