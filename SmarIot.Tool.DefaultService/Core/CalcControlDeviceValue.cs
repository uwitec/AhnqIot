using SmartIot.Api.Protocal.Common.ControlDevice;
using SmartIot.Tool.DefaultService.Core;
using SmartIot.Tool.DefaultService.DB;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIot.Tool.Core.Device.ControlDevice
{
    public class CalcControlDeviceValue
    {
        /// <summary>
        /// 计算控制设备的原始值
        /// </summary>
        /// <param name="dev">设施控制设备</param>
        /// <returns></returns>
        public static int CalcOriginal(FacilityControlDeviceUnit dev)
        {
            var value = 0; //控制设备数值
            if (dev == null) return value;
            var relayType = dev.ControlDeviceUnits[0].RelayTypeName;
            //Hold-Two
            if (GetRelayType(relayType) == ControlDeviceTypeEnum.Hold_Two_Status)
            {
                value = dev.ControlDeviceUnits[0].OriginalValue;
            }
            ////Hold-Three
            //if (GetRelayType(relayType) == ControlDeviceTypeEnum.Hold_Three_Status)
            //{
            dev.ControlDeviceUnits.ForEach(d =>
            {
                //负责正转的继电器
                if (GetType(relayType, d.ControlJobTypeName)
                    .controlJob.Equals(Hold_Three_ControlCommandEnum.Positive)
                    && d.OriginalValue == 1) value = 1;
                //负责反转的继电器
                if (GetType(relayType, d.ControlJobTypeName)
                    .controlJob.Equals(Hold_Three_ControlCommandEnum.Reverse)
                    && d.OriginalValue == 1) value = -1;
                //负责打开的继电器
                if (GetType(relayType, d.ControlJobTypeName).controlJob.Equals(Pluse_Two_ControlCommandEnum.Open)
                    && d.OriginalValue == 1) value = 1;
                //负责正转的继电器
                if (GetType(relayType, d.ControlJobTypeName)
                    .controlJob.Equals(Pluse_Three_ControlCommandEnum.Positive)
                    && d.OriginalValue == 1) value = 1;
                //负责反转的继电器
                if (GetType(relayType, d.ControlJobTypeName)
                    .controlJob.Equals(Pluse_Three_ControlCommandEnum.Reverse)
                    && d.OriginalValue == 1) value = -1;
            });
            //}
            ////Pluse-Two
            //if (GetRelayType(relayType) == ControlDeviceTypeEnum.Pluse_Two_Status)
            //{
            //dev.ControlDeviceUnits.ForEach(d =>
            //    {

            //    });
            //}

            ////Pluse-Three
            //if (GetRelayType(relayType) == ControlDeviceTypeEnum.Pluse_Three_Status)
            //{
            //dev.ControlDeviceUnits.ForEach(d =>
            //{

            //});
            //}
            return value;
        }

        /// <summary>
        /// 根据原始值计算控制设备的处理值
        /// </summary>
        /// <param name="fc">设施控制设备</param>
        /// <returns></returns>
        public static string CalcProcessValue(FacilityControlDeviceUnit fc)
        {
            var value = "关闭";
            var devs = fc.ControlDeviceUnits;
            devs.ForEach(dev =>
            {
                //负责总控的继电器
                if (GetType(dev.RelayTypeName, dev.ControlJobTypeName)
                    .controlJob.Equals(Hold_Two_ControlCommandEnum.Open)
                    && dev.OriginalValue == 1) value = "打开";
                //负责正转的继电器
                if (GetType(dev.RelayTypeName, dev.ControlJobTypeName)
                    .controlJob.Equals(Hold_Three_ControlCommandEnum.Positive)
                    && dev.OriginalValue == 1) value = "正转";
                //负责反转的继电器
                if (GetType(dev.RelayTypeName, dev.ControlJobTypeName)
                    .controlJob.Equals(Hold_Three_ControlCommandEnum.Reverse)
                    && dev.OriginalValue == 1) value = "反转";
                //负责停止的继电器
                if (GetType(dev.RelayTypeName, dev.ControlJobTypeName)
                    .controlJob.Equals(Hold_Three_ControlCommandEnum.Stop)
                    && dev.OriginalValue == 1) value = "停止";
                //负责打开的继电器
                if (GetType(dev.RelayTypeName, dev.ControlJobTypeName)
                    .controlJob.Equals(Pluse_Two_ControlCommandEnum.Open)
                    && dev.OriginalValue == 1) value = "打开";
                //负责正转的继电器
                if (GetType(dev.RelayTypeName, dev.ControlJobTypeName)
                    .controlJob.Equals(Pluse_Three_ControlCommandEnum.Positive)
                    && dev.OriginalValue == 1) value = "正转";
                //负责反转的继电器
                if (GetType(dev.RelayTypeName, dev.ControlJobTypeName)
                    .controlJob.Equals(Pluse_Three_ControlCommandEnum.Reverse)
                    && dev.OriginalValue == 1) value = "反转";
                //负责停止的继电器
                if (GetType(dev.RelayTypeName, dev.ControlJobTypeName)
                    .controlJob.Equals(Pluse_Three_ControlCommandEnum.Stop)
                    && dev.OriginalValue == 1) value = "停止";
            });
            return value;
        }


        /// <summary>
        /// 获取继电器和控制工作类型
        /// </summary>
        /// <param name="relayType">继电器类型</param>
        /// <param name="controlJobType">控制工作类型</param>
        /// <returns></returns>
        public static dynamic GetType(string relayType, string controlJobType)
        {
            dynamic type = new ExpandoObject();
            //type.relay = relayType;
            //type.controlJob = controlJobType;
            if (relayType.EqualIgnoreCase("Hold_Two"))
            {
                if (controlJobType.EqualIgnoreCase("Full")) type.controlJob = Hold_Two_ControlCommandEnum.Colse; //特殊情况
                if (controlJobType.EqualIgnoreCase("Open")) type.controlJob = Hold_Two_ControlCommandEnum.Open;
                if (controlJobType.EqualIgnoreCase("Close")) type.controlJob = Hold_Two_ControlCommandEnum.Colse;
                type.relay = ControlDeviceTypeEnum.Hold_Two_Status;
                return type;
            }
            if (relayType.EqualIgnoreCase("Hold_Three"))
            {
                if (controlJobType.EqualIgnoreCase("Positive"))
                    type.controlJob = Hold_Three_ControlCommandEnum.Positive;
                if (controlJobType.EqualIgnoreCase("Reverse")) type.controlJob = Hold_Three_ControlCommandEnum.Reverse;
                if (controlJobType.EqualIgnoreCase("Stop")) type.controlJob = Hold_Three_ControlCommandEnum.Stop;
                type.relay = ControlDeviceTypeEnum.Hold_Three_Status;
                return type;
            }
            if (relayType.EqualIgnoreCase("Pluse_Two"))

            {
                if (controlJobType.EqualIgnoreCase("Open")) type.controlJob = Pluse_Two_ControlCommandEnum.Open;
                if (controlJobType.EqualIgnoreCase("Close")) type.controlJob = Pluse_Two_ControlCommandEnum.Colse;
                type.relay = ControlDeviceTypeEnum.Pluse_Two_Status;
                return type;
            }
            if (relayType.EqualIgnoreCase("Pluse_Three"))
            {
                if (controlJobType.EqualIgnoreCase("Positive"))
                    type.controlJob = Pluse_Three_ControlCommandEnum.Positive;
                if (controlJobType.EqualIgnoreCase("Reverse")) type.controlJob = Pluse_Three_ControlCommandEnum.Reverse;
                if (controlJobType.EqualIgnoreCase("Stop")) type.controlJob = Pluse_Three_ControlCommandEnum.Stop;
                type.relay = ControlDeviceTypeEnum.Pluse_Three_Status;
                return type;
            }
            type.controlJob = "unknow";
            type.relay = ControlDeviceTypeEnum.Unknow;
            return type;
        }


        /// <summary>
        /// 获取继电器类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ControlDeviceTypeEnum GetRelayType(string type)
        {
            if (type.EqualIgnoreCase("Hold_Two"))
                return ControlDeviceTypeEnum.Hold_Two_Status;
            if (type.EqualIgnoreCase("Hold_Three"))
                return ControlDeviceTypeEnum.Hold_Three_Status;
            if (type.EqualIgnoreCase("Pluse_Two"))
                return ControlDeviceTypeEnum.Pluse_Two_Status;
            if (type.EqualIgnoreCase("Pluse_Three"))
                return ControlDeviceTypeEnum.Pluse_Three_Status;
            return ControlDeviceTypeEnum.Unknow;
        }
    }
}