using System;
using System.Collections.Generic;

namespace Smart.Led.Common
{
    public interface ILedDevice
    {
        /// <summary>
        /// 主机
        /// </summary>
        /// <remarks>
        /// 网络模式：IP地址
        /// 串口模式：COM1
        /// </remarks>
        string Host { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        /// <remarks>
        /// 网络模式：端口号
        /// 串口模式：波特率
        /// </remarks>
        int Args { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="host"></param>
        /// <param name="args"></param>
        void Init(string host, int args = 0);

        /// <summary>
        /// 展示数据
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        bool Display(string message);

        /// <summary>
        /// 展示数据
        /// </summary>
        /// <param name="messagesList"></param>
        /// <returns></returns>
        bool Display(List<Tuple<int, string>> messagesList);
    }
}