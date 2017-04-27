#region Code File Comment

// SOLUTION   ： AWIOT - Device
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： LedDeviceFactory.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-10-08 18:18
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Tool.Core.Device.LedDevice.LXLed;
using SmartIot.Tool.Core.Device.LedDevice.YXTD;
using SmartIot.Tool.Core.Device.LedDevice.YXTW103;
using System;

namespace SmartIot.Tool.Core.Device.LedDevice
{
    /// <summary>
    /// LED设备工厂
    /// </summary>
    public class LedDeviceFactory
    {
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static LedDeviceTypeEnum GetLedDeviceType(string type)
        {
            if (type.EqualIgnoreCase("LED-灵信"))
                return LedDeviceTypeEnum.LX;
            if (type.EqualIgnoreCase("LED-圆心-AC01"))
                return LedDeviceTypeEnum.AC01;
            if (type.EqualIgnoreCase("LED-圆心-TW10-3"))
                return LedDeviceTypeEnum.TW103;
            if (type.EqualIgnoreCase("LED-圆心-TWBI-2"))
                return LedDeviceTypeEnum.TWBI2;
            if (type.EqualIgnoreCase("LED-圆心-TDNEW"))
                return LedDeviceTypeEnum.TdNew;
            return LedDeviceTypeEnum.Unknow;
        }

        /// <summary>
        /// 创建LED设备
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ILedDevice CreateLedDevice(LedDeviceTypeEnum type)
        {
            ILedDevice device = null;
            switch (type)
            {
                case LedDeviceTypeEnum.LX:
                    device = new LXDevice();
                    break;

                case LedDeviceTypeEnum.TW103:
                    device = new YXTW103Device();
                    break;

                case LedDeviceTypeEnum.TdNew:
                    device = new YXTDNew();
                    break;

                case LedDeviceTypeEnum.Unknow:
                case LedDeviceTypeEnum.TWBI2:
                default:
                    break;
            }

            return device;
        }
    }
}