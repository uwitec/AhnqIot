#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Repository
// FILENAME   ： Init.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-05 0:54
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AhnqIot.DbModel;
using AhnqIot.EF;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using AhnqIot.Repository.AhnqIot;
using Autofac;
using Microsoft.Data.Entity;

#endregion

namespace AhnqIot.Repository
{
    public class RepositoryBootStraper
    {
        public static void Start()
        {
            //AhnqIotContainer.Builder.RegisterType<AhnqIotContext>().As<IDbContext>().InstancePerLifetimeScope();
            //AhnqIotContainer.Builder.RegisterType<AhnqIotContext>().Named<IDbContext>("AhnqIotContext").InstancePerLifetimeScope();

            RegisterAhnqIotTypes();
        }
        
        public static void RegisterAhnqIotTypes()
        {
            var dbModelTypes = typeof(BaseEntity).Assembly.GetTypes().Where(t => t.BaseType == typeof(BaseEntity));
            dbModelTypes.ToList().ForEach(type =>
            {
                if (type != null)
                {
                    var tfrom = typeof(IAhnqIotRepository<>).MakeGenericType(type);
                    var tto = typeof(AhnqIotRepository<>).MakeGenericType(type);
                    AhnqIotContainer.Builder.RegisterType(tto).As(tfrom).InstancePerDependency().PropertiesAutowired(); //每次解析到的都是新实例
                    //LogHelper.Trace("AhnqIot.Repository.Register:{0}=>{1}", tfrom.Name, tto.Name);
                }
            });
        }
    }
}