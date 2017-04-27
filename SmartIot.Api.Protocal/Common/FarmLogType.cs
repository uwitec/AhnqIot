#region Code File Comment

// SOLUTION   ： SmartIot - DeviceCode
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： FarmLogType.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-28 21:14
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

using System.Runtime.Serialization;

namespace SmartIot.Api.Protocal.Common
{
    /// <summary>
    /// 基地状态类型
    /// </summary>
    public enum FarmLogTypeEnum
    {
        [EnumMember(Value = "正常")] Normal,
        [EnumMember(Value = "网络故障")] NetError,
        [EnumMember(Value = "未知")] Unknow
    }
}