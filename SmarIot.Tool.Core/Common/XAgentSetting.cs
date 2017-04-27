#region Code File Comment

// SOLUTION   ： AWIOT - Device
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： XAgentSetting.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-10-02 21:39
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using NewLife.Configuration;
using NewLife.Xml;
using System;
using System.ComponentModel;

namespace SmartIot.Tool.Core.Common
{
    /// <summary>服务设置</summary>
    [DisplayName("服务设置")]
    [XmlConfigFile(@"Config\XAgent.config", 15000)]
    public class XAgentSetting : XmlConfig<XAgentSetting>
    {
        #region 方法

        /// <summary>新建时调用</summary>
        protected override void OnNew()
        {
            Debug = Config.GetConfig<Boolean>("XAgent.Debug", false);
            ServiceName = Config.GetConfig<String>("XAgent.ServiceName");
            DisplayName = Config.GetConfig<String>("XAgent.DisplayName");
            Description = Config.GetConfig<String>("XAgent.Description");
            Intervals = Config.GetConfig<String>("XAgent.Interval", Config.GetConfig<String>("Interval", "60"));
            MaxActive = Config.GetConfig<Int32>("XAgent.MaxActive");
            MaxMemory = Config.GetConfig<Int32>("XAgent.MaxMemory");
            MaxThread = Config.GetConfig<Int32>("XAgent.MaxThread");
            AutoRestart = Config.GetConfig<Int32>("XAgent.AutoRestart");
            WatchDog = Config.GetConfig<String>("XAgent.WatchDog");
        }

        #endregion 方法

        #region 属性

        /// <summary>是否启用全局调试。默认为不启用</summary>
        [Description("全局调试")]
        public Boolean Debug { get; set; }

        /// <summary>服务名</summary>
        [Description("服务名")]
        public String ServiceName { get; set; }

        /// <summary>显示名</summary>
        [Description("显示名")]
        public String DisplayName { get; set; }

        /// <summary>服务描述</summary>
        [Description("服务描述")]
        public String Description { get; set; }

        /// <summary>工作线程间隔，单位：秒。不同工作线程的时间间隔用逗号或分号隔开。可以通过设置任务的时间间隔小于0来关闭指定任务</summary>
        [Description("工作线程间隔，单位：秒。不同工作线程的时间间隔用逗号或分号隔开。可以通过设置任务的时间间隔小于0来关闭指定任务")]
        public String Intervals { get; set; } = "3";

        /// <summary>最大活动时间，单位：秒。超过最大活动时间都还没有响应的线程将会被重启，防止线程执行时间过长。默认0秒，表示无限</summary>
        [Description("最大活动时间，单位：秒。超过最大活动时间都还没有响应的线程将会被重启，防止线程执行时间过长。默认0秒，表示无限")]
        public Int32 MaxActive { get; set; }

        /// <summary>最大占用内存，单位： M。超过最大占用时，整个服务进程将会重启，以释放资源。默认0秒，表示无限</summary>
        [Description("最大占用内存，单位： M。超过最大占用时，整个服务进程将会重启，以释放资源。默认0秒，表示无限")]
        public Int32 MaxMemory { get; set; }

        /// <summary>最大总线程数，单位：个。超过最大占用时，整个服务进程将会重启，以释放资源。默认0个，表示无限</summary>
        [Description("最大总线程数，单位：个。超过最大占用时，整个服务进程将会重启，以释放资源。默认0个，表示无限")]
        public Int32 MaxThread { get; set; }

        /// <summary>自动重启时间，单位：分。到达自动重启时间时，整个服务进程将会重启，以释放资源。默认0分，表示无限</summary>
        [Description("自动重启时间，单位：分。到达自动重启时间时，整个服务进程将会重启，以释放资源。默认0分，表示无限")]
        public Int32 AutoRestart { get; set; }

        /// <summary>看门狗，保护其它服务，每分钟检查一次。多个服务名逗号分隔</summary>
        [Description("看门狗，保护其它服务，每分钟检查一次。多个服务名逗号分隔")]
        public String WatchDog { get; set; }

        #endregion 属性
    }
}