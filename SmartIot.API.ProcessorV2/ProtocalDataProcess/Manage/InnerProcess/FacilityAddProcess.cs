#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： FacilityAddProcess.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-29 21:47
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Smart.Redis;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest;
using SmartIot.Api.Protocal.Meta.Model;
using AhnqIot.Dto;
using System;
using SmartIot.Api.Protocal.Common;
using AhnqIot.Infrastructure.Log;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Manage.InnerProcess
{
    public class FacilityAddProcess
    {
        private readonly IFacilityService _facilityService;
        private readonly IFacilityTypeService _facilityTypeService;
        private readonly IFarmService _farmService;
        private readonly RedisClient _redisClient;

        public FacilityAddProcess()
        {
            _redisClient = RedisClient.DefaultDB;
            _farmService = AhnqIotContainer.Container.Resolve<IFarmService>();
            _facilityService = AhnqIotContainer.Container.Resolve<IFacilityService>();
            _facilityTypeService = AhnqIotContainer.Container.Resolve<IFacilityTypeService>();
        }

        /// <summary>
        /// 处理设施添加数据
        /// </summary>
        /// <param name="facility">设施添加数据</param>
        /// <returns></returns>
        public async Task<XResponseMessage> ProcessAsync(FacilityModel facility)
        {
            if (facility == null) return null;
            if (!await _farmService.ExistsAsync(facility.Farm))
                return ResultHelper.CreateMessage("基地不存在", ErrorType.FarmNotExists);

            var facilityType = await _facilityTypeService.GetByIdAsync(facility.FacilityType); //不存在的设施类型无法添加
            if (facilityType == null)
                return ResultHelper.CreateMessage("设施类型不存在", ErrorType.FacilityTypeNotExists);

            var item = await _facilityService.GetFacilityByIdAsny(facility.Serialnum);
            //数据库中不存在该设施
            if (item != null) return null;
            item = new FacilityDto
            {
                Serialnum = facility.Serialnum,
                Name = facility.Name,
                FarmSerialnum = facility.Farm,
                FacilityTypeSerialnum = facility.FacilityType,
                CreateTime = DateTime.Now,
                UpdateTime = facility.CreateTime ?? DateTime.Now,
                Status = 1,
                Sort = 0
            };
            try
            {
                var result = await _facilityService.AddFacility(item);
                LogHelper.Info("[设施]设施{0}{1}添加{2}", item.Name, item.Serialnum, result);
                return ResultHelper.CreateMessage($"添加设施{(result ? "成功" : "失败")}",
                    result ? ErrorType.NoError : ErrorType.InternalError);
            }
            catch (AggregateException ex)
            {
                return ResultHelper.CreateExceptionMessage(ex, "添加设施失败");
            }
        }

        #region 旧版本

        /// <summary>
        /// 处理设施添加数据集合(旧的版本)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task ProcessAsync(List<FacilityAddData> list)
        {
            if (list == null || !list.Any()) return;
            var facilityAddDatas = list as IList<FacilityAddData> ?? list.ToList();
            if (!facilityAddDatas.Any()) return;
            //并行处理
            Parallel.ForEach(facilityAddDatas, async facilityAddData => { await ProcessAsync(facilityAddData); });
        }

        /// <summary>
        /// 处理设施添加数据(旧的版本)
        /// </summary>
        /// <param name="facilityAddData">设施添加数据</param>
        /// <returns></returns>
        public async Task ProcessAsync(FacilityAddData facilityAddData)
        {
            if (facilityAddData == null || facilityAddData.Facility == null) return;
            var facility = facilityAddData.Facility;
            if (!_facilityService.CheckCode(facilityAddData.Facility.Serialnum)) return;
            var facilityType = await _facilityTypeService.GetByIdAsync(facility.FacilityType); //不存在的设施类型无法添加
            if (facilityType == null) return;
            var item = await _facilityService.GetFacilityByIdAsny(facility.Serialnum);
            //数据库中不存在该设施
            if (item == null)
            {
                if (facility.CreateTime != null)
                    item = new FacilityDto
                    {
                        Serialnum = facility.Serialnum,
                        Name = facility.Name,
                        FarmSerialnum = facility.Farm,
                        FacilityTypeSerialnum = facility.FacilityType,
                        CreateTime = (DateTime) facility.CreateTime,
                        UpdateTime = (DateTime) facility.CreateTime,
                        Status = 1,
                        Sort = 0
                    };
                await _facilityService.AddFacility(item);
            }
        }

        #endregion
    }
}