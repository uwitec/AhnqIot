#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Infrastructure
// FILENAME   ： AhnqIotContainer.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-28 11:19
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using Autofac;

#endregion

namespace AhnqIot.Infrastructure.DI
{
    public class AhnqIotContainer
    {
        private static readonly object _locker = new object();


        private static IContainer _container;

        public static ContainerBuilder Builder { get; set; }

        public static IContainer Container
        {
            get
            {
                if (_container == null)
                {
                    lock (_locker)
                        if (_container == null)
                            _container = Builder.Build();
                }

                return _container;
            }
        }
    }
}