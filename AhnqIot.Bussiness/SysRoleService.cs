#region Code File Comment
// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： SysRoleService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-13 23:57
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Hxj.Repository.AhnqIot;
using System.Collections.Generic;
using System.Linq;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using AutoMapper;
using Smart.Redis;

namespace AhnqIot.Bussiness
{
    [InitData(3)]
    public class SysRoleService : ServiceBase<SysRole, SysRoleDto>, ISysRoleService
    {

        #region 初始化系统数据

        public override void InitData()
        {
            LogHelper.Info("初始化{0}数据", RedisKey);
            if (!Repository.Exists("R0")) Repository.Add(CreateRole("R0", "系统管理员", "拥用系统所有权限", "/nq")); ;
            if (!Repository.Exists("R1")) Repository.Add(CreateRole("R1", "农气用户", "查询所管辖区域内的物联网示范点、农田小气候仪、实景监测站的运行情况", "/nq"));
            if (!Repository.Exists("R2")) Repository.Add(CreateRole("R2", "农气管理员", "查询所管辖区域内的物联网示范点、农田小气候仪、实景监测站的运行情况，同时具有维护管理功能", "/nq"));
            if (!Repository.Exists("R3")) Repository.Add(CreateRole("R3", "企业用户", "查询企业下所有示范点基地的运行情况", "/com"));
            if (!Repository.Exists("R4")) Repository.Add(CreateRole("R4", "企业管理员", "查询企业下所有示范点基地的运行情况，同时具有维护管理功能", "/com"));
            if (!Repository.Exists("R5")) Repository.Add(CreateRole("R5", "示范点用户", "查询示范点基地的运行情况", "/com"));
            if (!Repository.Exists("R6")) Repository.Add(CreateRole("R6", "示范点管理员", "查询示范点基地的运行情况，同时具有维护管理功能", "/com"));
            var result = Repository.Commit();
            LogHelper.Info("共初始化角色数据{0}条", result);
        }


        private SysRole CreateRole(string serialnum, string name, string description, string url = "")
        {
            var a = new SysRole
            {
                Serialnum = serialnum,
                Name = name,
                IsSystem = true,
                Status = 1,
                Sort = 0,
                Url = url,
                Description = description,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            return a;
        }
        #endregion

        //public override int Add(SysRoleDto entity)
        //{
        //    RedisClient.HashSetFieldValue(RedisKey, entity.Serialnum, entity, SerializeType);
        //    return base.Add(entity);
        //}
    }
}