#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Infrastructure
// FILENAME   ： Ioc.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-13 15:28
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using AhnqIot.Infrastructure.Log;
using Autofac;
using System.Reflection;

#endregion

namespace AhnqIot.Infrastructure.DI
{
    public class Ioc
    {
        public static Ioc CurrentIoc = new Ioc();

        private IContainer _container;

        public ContainerBuilder Builder { get; }

        public Ioc()
        {
            Builder = new ContainerBuilder();
        }

        public void RegisterInstance(object obj)
        {
            Builder.RegisterInstance(obj).PropertiesAutowired();
        }

        public IContainer GetContainer()
        {
            return _container;
        }

        public void RegisterType<TFrom, TTo>(string name = null)
        {
            if (String.IsNullOrWhiteSpace(name))
                Builder.RegisterType<TTo>().As<TFrom>().PropertiesAutowired();
            else
            {
                Builder.RegisterType<TTo>().Named<TFrom>(name).PropertiesAutowired();
            }
        }

        public void RegisterType(Type from, Type to, string name = null)
        {
            if (String.IsNullOrWhiteSpace(name))
                Builder.RegisterType(to).As(from).PropertiesAutowired();
            else
            {
                Builder.RegisterType(to).Named(name, from).PropertiesAutowired();
            }
        }

        public void RegisterAssembly(Assembly asm)
        {
            Builder.RegisterAssemblyTypes(asm).PropertiesAutowired();
        }

        public void RegisterDone()
        {
            _container = Builder.Build();
        }

        public object Resolve(Type t, string name = null)
        {
            if (String.IsNullOrWhiteSpace(name))
                return _container.Resolve(t);
            else
            {
                return _container.ResolveNamed(name, t);
            }
        }

        public T Resolve<T>(string name = null)
        {
            if (String.IsNullOrWhiteSpace(name))
                return _container.Resolve<T>();
            else
            {
                return _container.ResolveNamed<T>(name);
            }
        }
    }
}