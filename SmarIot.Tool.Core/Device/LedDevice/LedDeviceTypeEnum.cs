#region Code File Comment

// SOLUTION   ： AWIOT - Device
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： LedDeviceTypeEntum.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-10-08 18:07
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

namespace SmartIot.Tool.Core.Device.LedDevice
{
    /// <summary>
    /// LED显示屏类型
    /// </summary>
    public enum LedDeviceTypeEnum
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknow,

        /// <summary>
        /// 灵信
        /// </summary>
        LX,

        /// <summary>
        /// 圆心AC01
        /// </summary>
        AC01,

        /// <summary>
        /// 圆心TW10-3
        /// </summary>
        TW103,

        /// <summary>
        /// 圆心TWBI-2
        /// </summary>
        TWBI2,

        /// <summary>
        /// 通用版（小卡）
        /// </summary>
        PTP,

        /// <summary>
        /// 通用版（大卡）
        /// </summary>
        PArm,

        /// <summary>
        /// 大卡升级版
        /// </summary>
        TdNew
    }
}