using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLife.Configuration;
using NewLife.Log;

namespace AhnqIot.DataProcess.Service.Core
{
    /// <summary>工作接口</summary>
    public interface IJob
    {
        /// <summary>
        /// 工作组件顺序
        /// </summary>
        int Sort { get; set; }

        /// <summary>
        /// 间隔时间
        /// </summary>
        int JobInterval { get; set; }

        /// <summary>启动</summary>
        /// <returns></returns>
        bool Start();

        /// <summary>停止</summary>
        /// <returns></returns>
        bool Stop();

        /// <summary>工作</summary>
        bool Work();

        //void WriteLog(string format, params object[] args);
    }

    /// <summary>基础工作组件</summary>
    public class Job : IJob
    {
        ///// <summary>
        ///// 是否执行
        ///// </summary>
        //public bool IsExcute { get; set; }

        public Job()
        {
            Sort = 0;
            DisplayName = "基础工作组件";
            JobInterval = 60; //默认60秒
            //IsExcute = true;//默认执行
        }

        /// <summary>工作组件名</summary>
        public virtual string DisplayName { get; set; }

        /// <summary>工作组件顺序</summary>
        public virtual int Sort { get; set; }

        /// <summary>
        /// 时间间隔
        /// </summary>
        public int JobInterval { get; set; }

        /// <summary>启动</summary>
        public virtual bool Start()
        {
            WriteLog("开始工作");
            return false;
        }

        /// <summary>停止</summary>
        /// <returns></returns>
        public virtual bool Stop()
        {
            WriteLog("停止工作");
            return false;
        }

        /// <summary>工作</summary>
        public virtual bool Work()
        {
            WriteLog("正在运行");
            return false;
        }

        public virtual void WriteLog(string format, params object[] args)
        {
            //XTrace.WriteLine("[" + this.GetType() + "] [" + DisplayName + "]  " + format, args);
            XTrace.WriteLine("[" + DisplayName + "]  " + format, args);
        }
    }
}