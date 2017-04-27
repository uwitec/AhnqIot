#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： FarmService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-25 14:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Hxj.Repository.AhnqIot;
using Autofac;
using AutoMapper;
using Smart.Redis;

#endregion

namespace AhnqIot.Bussiness
{
    public class FarmService : ServiceBase<Farm, FarmDto>, IFarmService
    {
        static FarmService()
        {
            //初始化数据
            //Action act = async () => await LoadData();
            //act();
        }

        public FarmService(IAhnqIotRepository<Farm> farmRep)
        {
        }


        /// <summary>
        ///     获取企业下所有基地
        /// </summary>
        /// <param name="companyId">企业编码</param>
        /// <returns></returns>
        public async Task<IEnumerable<FarmDto>> GetFarmsByCompanyAsny(string companyId)
        {
            var farmList = RedisClient.HashGetAll<FarmDto>(RedisKey, DataType.Protobuf);
            if (farmList != null && farmList.Any())
            {
                return farmList.Where(e =>
                {
                    var farmDto = e.Value as FarmDto;
                    return farmDto != null && farmDto.CompanySerialnum.Equals(companyId);
                }).Select(e => e.Value as FarmDto);
            }
            else
            {
                return
                    Mapper.Map<IEnumerable<FarmDto>>(await Repository.GetAsync(f => f.CompanySerialnum.Equals(companyId)));
            }
        }

        ///// <summary>
        /////     根据编码删除基地
        ///// </summary>
        ///// <param name="id">基地编码</param>
        ///// <returns></returns>
        //public async Task<bool> DeleteAsync(string id)
        //{
        //    RedisClient.Delete(id);
        //    return await base.DeleteAsync(id) > 0;
        //}

        ///// <summary>
        /////     检测基地是否存在
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public override async Task<bool> ExistsAsync(string id)
        //{
        //    var redisExists = RedisClient.HashFieldExists(RedisKey, id, DataType.Protobuf) > 0;
        //    if (redisExists) return true;

        //    var dbExists = await base.ExistsAsync(id);
        //    return dbExists;
        //}

        ///// <summary>
        /////     初始化,将数据库中farm表的所有记录取出来放到Redis中
        ///// </summary>
        ///// <returns></returns>
        //private static async Task LoadData()
        //{
        //    var list = await AhnqIotContainer.Container.Resolve<IAhnqIotRepository<Farm>>().GetAllAsync();
        //    var dtoList = Mapper.Map<IEnumerable<FarmDto>>(list);
        //    Parallel.ForEach(dtoList,
        //        item => { RedisClient.HashSetFieldValue(RedisKey, item.Serialnum, item, DataType.Protobuf); });
        //}
    }
}