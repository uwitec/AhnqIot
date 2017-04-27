#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： FacilityAddProcess.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-29 21:47
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Smart.Redis;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest;
using SmartIot.Api.Protocal.Meta.Model;
using AhnqIot.Dto;
using System;
using System.Linq;
using SmartIot.Api.Protocal.Common;
using AhnqIot.Infrastructure.Log;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Manage.InnerProcess
{
    public class FacilityUpdateProcess
    {
        private readonly IFacilityService _facilityService;
        private readonly IFacilityTypeService _facilityTypeService;
        private readonly RedisClient _redisClient;

        public FacilityUpdateProcess()
        {
            _redisClient = RedisClient.DefaultDB;
            _facilityService = AhnqIotContainer.Container.Resolve<IFacilityService>();
            _facilityTypeService = AhnqIotContainer.Container.Resolve<IFacilityTypeService>();
        }

        /// <summary>
        /// 更新设施
        /// </summary>
        /// <param name="facility">设施更新数据</param>
        /// <returns></returns>
        public async Task<XResponseMessage> ProcessAsync(FacilityModel facility)
        {
            if (facility == null) return null;
            if (!_facilityService.CheckCode(facility.Serialnum))
                return ResultHelper.CreateMessage("设施不存在", ErrorType.FacilityNotExists);
            var facilityType = await _facilityTypeService.GetByIdAsync(facility.FacilityType); //不存在的设施类型无法更新
            if (facilityType == null) return ResultHelper.CreateMessage("设施类型不存在", ErrorType.FacilityTypeNotExists);
            var item = await _facilityService.GetFacilityByIdAsny(facility.Serialnum);
            //数据库中存在该设施并且创建时间大于最新的更新时间
            if (item == null || !(facility.CreateTime > item.UpdateTime)) return null;
            item.Serialnum = facility.Serialnum;
            item.Name = facility.Name;
            item.FarmSerialnum = facility.Farm;
            item.FacilityTypeSerialnum = facility.FacilityType;
            item.UpdateTime = facility.CreateTime ?? DateTime.Now;
            item.FarmSerialnum = facility.Farm;
            try
            {
                var result = await _facilityService.UpdateFacilityAsnyc(item);
                LogHelper.Info("[设施]设施{0}{1}更新{2}", item.Name, item.Serialnum, result);
                return ResultHelper.CreateMessage($"更新设施{(result ? "成功" : "失败")}",
                    result ? ErrorType.NoError : ErrorType.InternalError);
            }
            catch (AggregateException ex)
            {
                return ResultHelper.CreateExceptionMessage(ex, "更新设施失败");
            }

            return null;
        }

        #region 旧版本

        /// <summary>
        /// 处理设施更新数据集合(旧的版本)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task ProcessAsync(List<FacilityUpdateData> list)
        {
            if (list == null || !list.Any()) return;
            var facilityUpdateDatas = list as IList<FacilityUpdateData> ?? list.ToList();
            if (!facilityUpdateDatas.Any()) return;
            //并行处理
            Parallel.ForEach(facilityUpdateDatas,
                async facilityUpdateData => { await ProcessAsync(facilityUpdateData); });
        }

        /// <summary>
        /// 处理设施更新数据(旧的版本)
        /// </summary>
        /// <param name="facilityUpdateData">设施添加数据</param>
        /// <returns></returns>
        public async Task ProcessAsync(FacilityUpdateData facilityUpdateData)
        {
            if (facilityUpdateData == null) return;
            if (!_facilityService.CheckCode(facilityUpdateData.Serialnum)) return;
            var facilityType = await _facilityTypeService.GetByIdAsync(facilityUpdateData.Type); //不存在的设施类型无法添加
            if (facilityType == null) return;
            var item = await _facilityService.GetFacilityByIdAsny(facilityUpdateData.Serialnum);
            //数据库中不存在该设施
            if (item == null)
            {
                item.Serialnum = facilityUpdateData.Serialnum;
                item.Name = facilityUpdateData.Name;
                item.FacilityTypeSerialnum = facilityUpdateData.Type;
                item.UpdateTime = DateTime.Now;
                await _facilityService.AddFacility(item);
            }
        }

        #endregion
    }
}