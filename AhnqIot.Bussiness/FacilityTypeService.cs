//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： AhnqIot.Bussiness
//  FILENAME   ： FacilityTypeService.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 10:00
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#region using namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Infrastructure.Log;
using NewLife.Common;
using Smart.Redis;

#endregion

namespace AhnqIot.Bussiness
{
    [InitData(5)]
    public class FacilityTypeService : ServiceBase<FacilityType, FacilityTypeDto>, IFacilityTypeService
    {
        #region 初始化数据
        public override void InitData()
        {
            LogHelper.Info("初始化{0}数据", RedisKey);

            AddEntity("wenshi", "温室类", "", "");
            AddEntity("wenshi-" + PinYin.Get("花卉"), "花卉", "wenshi", "");
            AddEntity("wenshi-" + PinYin.Get("蔬菜"), "蔬菜", "wenshi", "");

            AddEntity("datian", "大田类", "", "");
            AddEntity("datian-" + PinYin.Get("水稻"), "水稻", "datian", "");
            AddEntity("datian-" + PinYin.Get("小麦"), "小麦", "datian", "");
            AddEntity("datian-" + PinYin.Get("茶叶"), "茶叶", "datian", "");

            AddEntity("bird", "禽类", "", "");
            AddEntity("bird-" + PinYin.Get("鸡舍"), "鸡舍", "bird", "");
            AddEntity("bird-" + PinYin.Get("鸭舍"), "鸭舍", "bird", "");

            AddEntity("livestock", "畜牧类", "", "");
            AddEntity("livestock-" + PinYin.Get("猪舍"), "猪舍", "livestock", "");
            AddEntity("livestock-" + PinYin.Get("羊舍"), "羊舍", "livestock", "");

            AddEntity("aquatic", "水产类", "", "");
            AddEntity("aquatic-" + PinYin.Get("虾"), "虾", "aquatic", "");
            AddEntity("aquatic-" + PinYin.Get("蟹"), "蟹", "aquatic", "");
            AddEntity("aquatic-" + PinYin.Get("鱼"), "鱼", "aquatic", "");

            var result = Repository.Commit();
            LogHelper.Info("共初始化设施类型数据{0}条", result);
        }

        private void AddEntity(string serialnum, string name, string parent, string description)
        {
            var entity = new FacilityType();
            entity.Serialnum = serialnum;
            entity.Name = name;
            entity.ParentSerialnum = parent;
            entity.PhotoUrl = "FacilityType/" + PinYin.GetFirst(name) + ".png";
            entity.Css = "xzss-icon xzss-icon-" + PinYin.GetFirst(name);
            entity.Introduce = description;
            entity.CreateTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;
            entity.UpdateSysUserSerialnum = "admin";
            entity.Remark = "systype";
            Repository.Add(entity);

        }
        #endregion
        //public override async Task<FacilityTypeDto> GetByIdAsync(string id)
        //{
        //    if (id.IsNullOrWhiteSpace()) return null;
        //    RedisHitStatistics?.AddTotal();

        //    var model = RedisClient.HashGet<FacilityTypeDto>(RedisKey, id, SerializeType);
        //    if (model == null)
        //    {
        //        model = await base.GetByIdAsync(id);
        //        RedisClient.HashSetFieldValue(RedisKey, id, model, SerializeType);
        //    }
        //    else
        //        RedisHitStatistics?.AddHit();
        //    return model;
        //}

        //public override async Task<IEnumerable<FacilityTypeDto>> GetAllAsync()
        //{
        //    RedisHitStatistics?.AddTotal();
        //    var list =RedisClient.HashGetAll<DeviceTypeDto>(RedisKey, DataType.Protobuf).Select(e => e.Value as FacilityTypeDto);
        //    if (!list.Any())
        //    {
        //        list = await base.GetAllAsync();
        //        list.AsParallel().ForEach(e => RedisClient.HashSetFieldValue(RedisKey, e.Serialnum, e, SerializeType));
        //    }
        //    else
        //    {
        //        RedisHitStatistics?.AddHit();
        //    }
        //    return list;
        //}


    }
}