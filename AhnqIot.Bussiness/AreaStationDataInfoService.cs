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
  public  class AreaStationDataInfoService: ServiceBase<AreaStationDataInfo, AreaStationDataInfoDto>, IAreaStationDataInfoService
    {
        //private readonly IAhnqIotRepository<AreaStationDataInfo> _areaStationDataInfoRep;

        public AreaStationDataInfoService(IAhnqIotRepository<AreaStationDataInfo> areaStationDataInfoRep)
        {
            //_areaStationDataInfoRep = areaStationDataInfoRep;
        }
        /// <summary>
        /// 根据设备编码获取
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public async Task<AreaStationDataInfoDto> GetByIdAsny(string deviceId)
      {
          return GetDtoModel(await Repository.GetAsync(a=>a.AreaStationSerialnum.Equals(deviceId)));
      }

      /// <summary>
      /// 添加
      /// </summary>
      /// <param name="dto"></param>
      /// <returns></returns>
      public async Task<bool> AddAsny(AreaStationDataInfoDto dto)
      {
          try
          {
                var info =GetDbModel(dto);
                Repository.Add(info);
                return await Repository.CommitAsync() > 0;
            }
          catch (Exception ex)
          {

                return false;
          }

      }
    }
}
