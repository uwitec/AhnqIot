#region Code File Comment
// SOLUTION   ： SmartIot - DeviceCode
// PROJECT    ： SmartIot.API.Processor
// FILENAME   ： DeviceCommandType.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-29 0:38
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System.ComponentModel;

namespace SmartIot.API.Processor.Common
{
    /// <summary>
    /// 控制指令状态
    /// </summary>
    public enum DeviceCommandTypeEnum
    {
        Created,
        Getted,
        ActionSuccess,
        ActionError
    }
}