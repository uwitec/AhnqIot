#region Code File Comment
// SOLUTION   ： AWIOT
// PROJECT    ： AWIOT.API.Processor.Container
// FILENAME   ： ApiService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 14:08
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using XAgent;
using SmartIot.Service.Core;

namespace SmartIot.API.Container
{
    public class ApiService : AgentServiceBase<ApiService>
    {

        /// <summary>显示名字</summary>
        public override string DisplayName { get { return "物联网数据中心工作组件"; } }

        /// <summary>容器线程数，根据插件数动态调整</summary>
        public override int ThreadCount { get { return JobHelper.Works.Count; } }


        protected override void OnStart(string[] args)
        {
            WriteLine("{0}开始工作", DisplayName);
            base.OnStart(args);
        }

        /// <summary>启动</summary>
        public override void StartWork()
        {
            Intervals = new int[ThreadCount + 1];
            base.StartWork();
        }

        public override void StartWork(int index)
        {
            Intervals[index] = JobHelper.Works[index].JobInterval;
            JobHelper.Works[index].Start();
            base.StartWork(index);
        }

        /// <summary>执行工作</summary>
        /// <param name="index">线程序号</param>
        /// <returns></returns>
        public override bool Work(int index)
        {
            //WriteLine(Intervals[index].ToString() + " - " + JobHelper.Works[index].JobInterval.ToString());
            JobHelper.Works[index].Work();
            return false;
        }

        public override void StopWork(int index)
        {
            JobHelper.Works[index].Stop();
            base.StopWork(index);
        }

        /// <summary>停止</summary>
        public override void StopWork()
        {
            WriteLine("{0}停止工作", DisplayName);
            base.StopWork();
        }
    }
}