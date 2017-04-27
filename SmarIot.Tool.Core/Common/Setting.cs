#region Code File Comment

// SOLUTION   ： AWIOT - Device
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： Setting.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-10-02 18:59
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using NewLife.Xml;
using System;
using System.ComponentModel;

#endregion using namespace

namespace SmartIot.Tool.Core.Common
{
    /// <summary>运行参数设置</summary>
    [DisplayName("运行参数设置")]
    [XmlConfigFile(@"Config\DefaultServiceSetting.config", 15000)]
    public class Setting : XmlConfig<Setting>
    {
        //private String _LastTool;
        ///// <summary>最后一个使用的工具</summary>
        //[DisplayName("最后一个使用的工具")]
        //public String LastTool { get { return _LastTool; } set { _LastTool = value; } }

        protected override void OnNew()
        {
            SystemName = "安徽斯玛特物联网监控系统";
            LastUpdateTime = new DateTime(2015, 10, 1);

            CollectEnable = true;
            CollectInterval = 5*60;
            //CollectInterval = 10;

            ControlEnable = true;
            ControlCommandInterval = 5;
            ControlCollectInterval = 3*60;
            //ControlCollectInterval = 10;//调试

            FarmStatusUploadEnable = true;
            FarmStatusUploadInterval = 15;
            //FarmStatusUploadInterval = 10;//调试

            ExceptionNotifyEnable = false;
            ExceptionNotifyLevel = 1;

            SyncEnable = true;
            SyncInterval = 1;

            UploadDeviceDataEnable = true;
            DeleteDeviceDataEnable = true;
            UploadDeviceDataInterval = 1;

            LedEnable = false;
            LedShowInterval = 10;

            TtsEnable = false;
            TtsShowInterval = 10;

            EnableViewServiceLog = false;
        }

        #region 采集

        [Description("启用采集")]
        public bool CollectEnable { get; set; }

        [Description("传感设备采集间隔，单位：秒")]
        public int CollectInterval { get; set; }

        #endregion 采集

        #region 控制

        [Description("启用控制")]
        public bool ControlEnable { get; set; }

        [Description("控制设备状态采集间隔，单位：秒")]
        public int ControlCollectInterval { get; set; }

        [Description("控制指令获取间隔，单位：秒")]
        public int ControlCommandInterval { get; set; }

        #endregion 控制

        #region 基地状态

        [Description("启用基地状态上传")]
        public bool FarmStatusUploadEnable { get; set; }

        [Description("基地状态上传间隔，单位：分钟")]
        public int FarmStatusUploadInterval { get; set; }

        #endregion 基地状态

        #region 同步设施设备

        [Description("启用同步设施设备")]
        public bool SyncEnable { get; set; }

        [Description("同步设施设备间隔，单位：分钟")]
        public int SyncInterval { get; set; }

        #endregion 同步设施设备

        #region 上传设备采集数据

        [Description("启用上传设备采集数据")]
        public bool UploadDeviceDataEnable { get; set; }

        [Description("是否删除设备采集数据")]
        public bool DeleteDeviceDataEnable { get; set; }

        [Description("上传设备采集数据间隔，单位：分钟")]
        public int UploadDeviceDataInterval { get; set; }

        #endregion 上传设备采集数据

        #region LED

        [Description("LED附加信息")]
        public string LedAttactInfo { get; set; }

        [Description("启用LED显示")]
        public bool LedEnable { get; set; }

        [Description("LED更新间隔，单位：分钟")]
        public int LedShowInterval { get; set; }

        #endregion LED

        #region TTS

        [Description("启用TTS播报")]
        public bool TtsEnable { get; set; }

        [Description("TTS播报间隔，单位：分钟")]
        public int TtsShowInterval { get; set; }

        #endregion TTS

        #region 异常通知

        [Description("启用异常通知")]
        public bool ExceptionNotifyEnable { get; set; }

        [Description("异常通知级别")]
        public int ExceptionNotifyLevel { get; set; }

        #endregion 异常通知

        #region 系统

        /// <summary>
        ///     系统名称
        /// </summary>
        [Description("系统名称")]
        public String SystemName { get; set; }

        /// <summary>最后更新时间</summary>
        [Description("最后更新时间")]
        public DateTime LastUpdateTime { get; set; }

        #endregion 系统

        #region Windows  Service

        /// <summary>服务名</summary>
        [Description("服务名")]
        public String ServiceName { get; set; }

        /// <summary>显示名</summary>
        [Description("显示名")]
        public String DisplayName { get; set; }

        /// <summary>服务描述</summary>
        [Description("服务描述")]
        public String Description { get; set; }

        /// <summary>查看服务运行日志</summary>
        [Description("查看服务运行日志")]
        public bool EnableViewServiceLog { get; set; }

        #endregion Windows  Service
    }
}