#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Repository
// FILENAME   ： Init.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-05 0:54
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Hxj.Repository.AhnqIot;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Dos.ORM;

#endregion

namespace AhnqIot.Hxj.Repository
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
            var dosEntityType = typeof(Dos.ORM.Entity);
            var asmModel = typeof (Device).Assembly;
            var dbModelTypes = asmModel.GetTypes().Where(t => t.BaseType == dosEntityType);
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