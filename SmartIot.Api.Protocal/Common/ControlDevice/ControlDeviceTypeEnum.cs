#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： ControlDeviceTypeEnum.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-09 15:22
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

namespace SmartIot.Api.Protocal.Common.ControlDevice
{
    public enum ControlDeviceTypeEnum
    {
        /// <summary>
        /// 保持式单继电器控制，有开、关两种状态
        /// </summary>
        // ReSharper disable once InconsistentNaming
        Hold_Two_Status,

        /// <summary>
        /// 保持式双继电器控制，有正转、反转、停止三种状态
        /// </summary>
        // ReSharper disable once InconsistentNaming
        Hold_Three_Status,

        /// <summary>
        /// 脉冲式双继电器控制，有开、关两种状态
        /// </summary>
        // ReSharper disable once InconsistentNaming
        Pluse_Two_Status,

        /// <summary>
        /// 脉冲式三继电器控制，有正转、反转、停止三种状态
        /// </summary>
        // ReSharper disable once InconsistentNaming
        Pluse_Three_Status,

        /// <summary>
        /// 未知，不处理
        /// </summary>
        // ReSharper disable once InconsistentNaming
        Unknow
    }
}