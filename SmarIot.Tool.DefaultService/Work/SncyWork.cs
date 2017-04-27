using SmartIot.Tool.Core.DataSync;
using SmartIot.Service.Core;
using NewLife.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using SmartIot.Tool.Core.Common;

namespace SmartIot.Tool.DefaultService.Work
{
    public sealed class SncyWork : Job
    {
        private IEnumerable<IDataSync> _uploadObjs;

        public SncyWork()
        {
            DisplayName = "同步设施设备组件";
            Sort = 4;
            if (Setting.Current.SyncEnable)
            {
                JobInterval = Setting.Current.SyncInterval*60;
            }
            else
            {
                JobInterval = -1; //禁用此组件
            }
        }

        private static IEnumerable<IDataSync> InitPlugins()
        {
            var ps = AssemblyX.FindAllPlugins(typeof (IDataSync), true);
            return ps.Select(e => (IDataSync) TypeX.CreateInstance(e));
        }

        public override bool Start()
        {
            _uploadObjs = InitPlugins();
            return base.Start();
        }

        public override bool Work()
        {
            var dataTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour,
                DateTime.Now.Minute/5*5, 0);
            if (_uploadObjs.Any())
            {
                _uploadObjs.ToList().ForEach(e => e.Sync(dataTime));
            }

            return base.Work();
        }
    }
}