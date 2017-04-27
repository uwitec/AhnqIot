using SmartIot.Service.Core;
using System.Linq;
using XAgent;

namespace SmartIot.Tool.Container
{
    /// <summary>服务容器</summary>
    public class MainContainer : AgentServiceBase<MainContainer>
    {
        /// <summary>显示名字</summary>
        public override string DisplayName => "物联网服务";

        //public override string DisplayName { get { return "智慧农业系统软件 V1.0"; } }

        /// <summary>容器线程数，根据插件数动态调整</summary>
        public override int ThreadCount
        {
            get { return JobHelper.Works.Count(w => w.JobInterval > 0); }
        }

        protected override void OnStart(string[] args)
        {
            WriteLine("{0}开始工作", DisplayName);
            base.OnStart(args);
        }

        /// <summary>启动</summary>
        public override void StartWork()
        {
            base.StartWork();
        }

        public override void StartWork(int index)
        {
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