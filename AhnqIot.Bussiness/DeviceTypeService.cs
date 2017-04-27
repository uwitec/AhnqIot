using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.Repository.AhnqIot;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using AutoMapper;
using NewLife.Common;
using Smart.Redis;

namespace AhnqIot.Bussiness
{
    [InitData(6)]
    public class DeviceTypeService : ServiceBase<DeviceType, DeviceTypeDto>, IDeviceTypeService
    {
        #region 初始化数据
        /// <summary>
        /// 初始化设备类型
        /// </summary>
        /// <returns></returns>
        public override void InitData()
        {
            LogHelper.Info("初始化{0}数据", RedisKey);
            AddEntity("collect", "采集", "", "采集设备类型");
            //设施类
            AddEntity("collect-facility", "采集-设施类", "collect", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("温度"), "温度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("湿度"), "湿度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("空气温度"), "空气温度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("空气相对湿度"), "空气相对湿度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("光照"), "光照", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("光合有效辐射"), "光合有效辐射", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("日照时数"), "日照时数", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("二氧化碳"), "二氧化碳", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("一氧化碳"), "一氧化碳", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("氨气"), "氨气", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("硫化氢"), "硫化氢", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("土壤温度"), "土壤温度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("土壤湿度"), "土壤湿度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("土壤湿度-模拟量"), "土壤湿度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("电导率"), "电导率", "collect-facility", "设施类");

            AddEntity("collect-facility-" + PinYin.Get("设施类备用1"), "设施类备用1", "collect-facility", "设施类", "Default");
            AddEntity("collect-facility-" + PinYin.Get("设施类备用2"), "设施类备用2", "collect-facility", "设施类", "Default");
            AddEntity("collect-facility-" + PinYin.Get("设施类备用3"), "设施类备用3", "collect-facility", "设施类", "Default");
            //气象站
            AddEntity("collect-weather", "采集-气象站", "collect", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("温度"), "温度", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("湿度"), "湿度", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("光照"), "光照", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("风速"), "风速", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("风向"), "风向", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("土壤温度"), "土壤温度", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("土壤湿度"), "土壤湿度", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("光合有效辐射"), "光合有效辐射", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("日照时数"), "日照时数", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("雨雪感知"), "雨雪感知", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("降雨量"), "降雨量", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("气压"), "气压", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("电导率"), "电导率", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("蒸发"), "蒸发", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("二氧化碳"), "二氧化碳", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("气象站备用1"), "气象站备用1", "collect-weather", "气象站", "Default");
            AddEntity("collect-weather-" + PinYin.Get("气象站备用2"), "气象站备用2", "collect-weather", "气象站", "Default");
            AddEntity("collect-weather-" + PinYin.Get("气象站备用3"), "气象站备用3", "collect-weather", "气象站", "Default");
            //水产类
            AddEntity("collect-aquatic", "采集-水产类", "collect", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("溶解氧"), "溶解氧", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("PH"), "PH", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("氨氮"), "氨氮", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("水温"), "水温", "collect-aquatic", "水产类", "Shuiwen");
            AddEntity("collect-aquatic-" + PinYin.Get("水位"), "水位", "collect-aquatic", "水产类", "ShuiWei");
            AddEntity("collect-aquatic-" + PinYin.Get("重金属"), "重金属", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("亚硝酸盐"), "亚硝酸盐", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("水产类备用1"), "水产类备用1", "collect-aquatic", "水产类", "Default");
            AddEntity("collect-aquatic-" + PinYin.Get("水产类备用2"), "水产类备用2", "collect-aquatic", "水产类", "Default");
            AddEntity("collect-aquatic-" + PinYin.Get("水产类备用3"), "水产类备用3", "collect-aquatic", "水产类", "Default");


            AddEntity("control", "控制", "", "控制设备类型");
            //设施
            AddEntity("control-facility", "控制-设施类", "control", "设施类");
            AddEntity("control-facility-" + PinYin.Get("风机"), "风机", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("循环风机"), "循环风机", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("湿帘"), "湿帘", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("内遮阳"), "内遮阳", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("内保温"), "内保温", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("外遮阳"), "外遮阳", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("侧窗"), "侧窗", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("天窗"), "天窗", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("水泵"), "水泵", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("加湿器"), "加湿器", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("加热空调"), "加热空调", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("降温空调"), "降温空调", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("喷灌"), "喷灌", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("滴灌"), "滴灌", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("设施类备用1"), "设施类备用1", "control-facility", "设施类", "Default");
            AddEntity("control-facility-" + PinYin.Get("设施类备用2"), "设施类备用2", "control-facility", "设施类", "Default");
            AddEntity("control-facility-" + PinYin.Get("设施类备用3"), "设施类备用3", "control-facility", "设施类", "Default");

            //水产
            AddEntity("control-aquatic", "控制-水产类", "control", "水产类");
            AddEntity("control-aquatic-" + PinYin.Get("增氧设备"), "增氧设备", "control-aquatic", "水产类");
            AddEntity("control-aquatic-" + PinYin.Get("投料机"), "投料机", "control-aquatic", "水产类");
            AddEntity("control-aquatic-" + PinYin.Get("水产类备用1"), "水产类备用1", "control-aquatic", "水产类", "Default");
            AddEntity("control-aquatic-" + PinYin.Get("水产类备用2"), "水产类备用2", "control-aquatic", "水产类", "Default");
            AddEntity("control-aquatic-" + PinYin.Get("水产类备用3"), "水产类备用3", "control-aquatic", "水产类", "Default");

            var result = Repository.Commit();
            LogHelper.Info("共初始化设备类型数据{0}条", result);
        }
        /// <summary>
        /// 添加设备类型
        /// </summary>
        /// <param name="serialnum">设施类型编码</param>
        /// <param name="name">名称</param>
        /// <param name="parent">上街</param>
        /// <param name="description">描述</param>
        /// <param name="url">url</param>
        private void AddEntity(string serialnum, string name, string parent, string description, string url = "")
        {
            var entity = new DeviceType();
            entity.Serialnum = serialnum;
            entity.Name = name;
            entity.ParentSerialnum = parent;
            if (url.IsNullOrWhiteSpace())
                entity.PhotoUrl = "DeviceType/" + PinYin.GetFirst(name) + ".png";
            else
                entity.PhotoUrl = "DeviceType/" + url + ".png";
            entity.Introduce = description;
            entity.CreateTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;
            entity.UpdateSysUserSerialnum = "admin";
            entity.Remark = "systype";
            entity.ValueCount = 0;
            entity.Sort = 0;
            Repository.Add(entity);
        }
        #endregion

        //public override async Task<DeviceTypeDto> GetByIdAsync(string id)
        //{
        //    if (id.IsNullOrWhiteSpace()) return null;
        //    RedisHitStatistics?.AddTotal();

        //    var model = RedisClient.HashGet<DeviceTypeDto>(RedisKey, id, SerializeType);
        //    if (model == null)
        //    {
        //        model = await base.GetByIdAsync(id);
        //        RedisClient.HashSetFieldValue(RedisKey, id, model, SerializeType);
        //    }
        //    else
        //        RedisHitStatistics?.AddHit();
        //    return model;
        //}

        //public override async Task<IEnumerable<DeviceTypeDto>> GetAllAsync()
        //{
        //    RedisHitStatistics?.AddTotal();
        //    var list = RedisClient.HashGetAll<DeviceTypeDto>(RedisKey, DataType.Protobuf).Select(e => e.Value as DeviceTypeDto);
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
