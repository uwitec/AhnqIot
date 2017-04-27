using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIot.Tool.DefaultService.Core
{
    /// <summary>
    /// 控制工作内容
    /// </summary>
    public enum ControlJobTypeEnum
    {
        /// <summary>
        /// 打开
        /// </summary>
        Open,

        /// <summary>
        /// 关闭
        /// </summary>
        Close
    }

    public enum ControlJobTypeEnum2
    {
        /// <summary>
        /// 正转
        /// </summary>
        Positive,

        /// <summary>
        /// 反转
        /// </summary>
        Reverse,

        /// <summary>
        /// 停止
        /// </summary>
        Stop
    }
}