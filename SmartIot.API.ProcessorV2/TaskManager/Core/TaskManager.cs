#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： TaskManager.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-01 22:54
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AhnqIot.Infrastructure.Log;
using NewLife.Reflection;

#endregion

namespace SmartIot.API.ProcessorV2.TaskManager.Core
{
    /// <summary>
    /// 计划任务管理器
    /// </summary>
    public class TaskManager
    {
        private readonly ITaskJob[] _jobPlugins;
        private readonly Timer[] _jobProcessTimer;

        public TaskManager()
        {
            var ps = typeof (ITaskJob).GetAllSubclasses();
            _jobPlugins = ps.Where(e => e.IsClass).Select(e => TypeX.CreateInstance(e) as ITaskJob).ToArray();
            _jobProcessTimer = new Timer[_jobPlugins.Length];
        }

        /// <summary>
        ///     启动
        /// </summary>
        public void Start()
        {
            Parallel.For(0, _jobPlugins.Length, async index =>
            {
                var job = _jobPlugins[index];
                var dur = await job.GetWaitForSecondsAsync(); //启动等待时间
                _jobProcessTimer[index] = new Timer(async obj =>
                {
                    try
                    {
                        await job.ProcessAsync();
                        LogHelper.Info("任务:{0}正在执行", job.JobName);
                    }
                    catch (AggregateException ex)
                    {
                        LogHelper.Info("任务:{0}执行出现错误", ex.Message);
                        LogHelper.Fatal(ex.ToString());
                    }
                }, null, dur*1000,
                    job.Period*1000);
                LogHelper.Info("启动任务:{0}", job.JobName);
            });
        }
       
        /// <summary>
        ///     停止
        /// </summary>
        public void Stop()
        {
            Parallel.For(0, _jobPlugins.Length - 1, index =>
            {
                var timer = _jobProcessTimer[index];
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                LogHelper.Info("停止任务:{0}", _jobPlugins[index].JobName);
            });
        }
    }
}