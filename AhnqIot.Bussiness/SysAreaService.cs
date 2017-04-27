//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： AhnqIot.Bussiness
//  FILENAME   ： SysAreaService.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 10:00
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Infrastructure.Log;

namespace AhnqIot.Bussiness
{
    [InitData(0)]
    public class SysAreaService : ServiceBase<SysArea, SysAreaDto>, ISysAreaService
    {
        #region 初始化系统数据

        public override void InitData()
        {
            LogHelper.Info("初始化{0}数据", RedisKey);

            var parent1 = "00001";
            if (!Exists(parent1)) AddSysArea(parent1, "沿淮淮北", null, 1);
            var key2 = "00002";
            if (!Exists(key2)) AddSysArea(key2, "沿淮", parent1, 1);
            var key3 = "00003";
            if (!Exists(key3)) AddSysArea(key3, "淮北", parent1, 2);

            var parent2 = "00004";
            if (!Exists(parent2)) AddSysArea(parent2, "江淮之间", null, 2);
            var key5 = "00005";
            if (!Exists(key5)) AddSysArea(key5, "江淮", parent2, 1);
            var key6 = "00006";
            if (!Exists(key6)) AddSysArea(key6, "大别山区", parent2, 2);

            var parent3 = "00007";
            if (!Exists(parent3)) AddSysArea(parent3, "沿江江南", null, 3);
            var key8 = "00008";
            if (!Exists(key8)) AddSysArea(key8, "沿江", parent3, 1);
            var key9 = "00009";
            if (!Exists(key9)) AddSysArea(key9, "皖南山区", parent3, 2);

            var result = Repository.Commit();
            Console.WriteLine("共初始化区域数据{0}条", result);
        }

        public void AddSysArea(string serialnum, string name, string parent = null, int sort = 0)
        {
            var entity = new SysArea
            {
                Serialnum = serialnum,
                AwCode = serialnum,
                Name = name,
                ParentSerialnum = parent,
                Status = 1,
                Description = "",
                Sort = sort,
                Remark = ""
            };
            entity.CreateTime = entity.UpdateTime = DateTime.Now;
            Repository.Add(entity);
        }

        #endregion

        public override async Task<IEnumerable<SysAreaDto>> GetAllAsync()
        {
            RedisHitStatistics?.AddTotal();
            var list = RedisClient.HashGetAll<SysAreaDto>(RedisKey, SerializeType).Select(e => e.Value as SysAreaDto);
            if (list.Any())
            {
                RedisHitStatistics?.AddHit();
            }
            else
            {
                list = await base.GetAllAsync();
            }
            return list;
        }
    }
}