using System;
using System.Collections.Generic;
using System.Linq;
using NewLife.Reflection;

namespace SmartIot.Service.Core
{
    /// <summary>工作</summary>
    public static class JobHelper
    {
        static readonly List<Type> _hasInited = new List<Type>();

        private static List<IJob> op_cache = new List<IJob>();

        /// <summary>所有工作组件</summary>
        public static List<IJob> Works
        {
            get
            {
                var list = LoadWork();
                foreach (var item in list)
                {
                    EnsureInit(item);
                }
                op_cache = op_cache.OrderBy(j => j.Sort).ToList();
                return op_cache;
            }
        }

        /// <summary>确保实体类已经执行完静态构造函数，因为那里实在是太容易导致死锁了</summary>
        /// <param name="type">类型</param>
        internal static void EnsureInit(Type type)
        {
            if (_hasInited.Contains(type)) return;
            // 先实例化，在锁里面添加到列表但不实例化，避免实体类的实例化过程中访问CreateOperate导致死锁产生
            var item = type.CreateInstance();
            lock (_hasInited)
                // 如果这里锁定_hasInited，还是有可能死锁，因为可能实体类A的静态构造函数中可能导致调用另一个实体类的EnsureInit
                // 其实我们这里加锁的目的，本来就是为了避免重复添加同一个type而已
                //lock ("_hasInited" + type.FullName)
            {
                if (_hasInited.Contains(type)) return;


                if (op_cache.Contains(item as IJob)) return;
                op_cache.Add(item as IJob);


                //type.CreateInstance();
                _hasInited.Add(type);
            }
        }

        /// <summary>列出所有工作接口</summary>
        /// <returns></returns>
        public static List<Type> LoadWork()
        {
            return typeof (IJob).GetAllSubclasses(true).ToList();
        }
    }
}