namespace SmartIot.Tool.Core.Device.LedDevice.YXTW103
{
    /// <summary>
    /// 字体颜色
    /// </summary>
    public enum LedFontColor : byte
    {
        /// <summary>
        /// 0 红色
        /// </summary>
        Red = 0,

        /// <summary>
        /// 1 绿色
        /// </summary>
        Green,

        /// <summary>
        /// 2 黄色
        /// </summary>
        Yellow
    }

    /// <summary>
    /// LED屏显示方式
    /// </summary>
    public enum ShowType : ushort
    {
        左移 = 1,
        右移,
        上移,
        下移,
        下覆盖,
        上覆盖,
        右覆盖,
        左覆盖,
        翻白显示,
        闪烁显示,
        立即打出
    }

    /// <summary>
    /// 子命令类型
    /// </summary>
    public enum SubCmdType : ushort
    {
        /// <summary>
        /// 发送不保存文字
        /// </summary>
        发送不保存文字 = 0x5154,

        /// <summary>
        /// 发送不保存文字
        /// </summary>
        发送保存文字 = 0x5144,

        /// <summary>
        /// 开关机
        /// </summary>
        探测指令 = 0x55,

        /// <summary>
        /// 删除单个数据
        /// </summary>
        开机 = 0x4f41,

        /// <summary>
        /// 删除全部数据
        /// </summary>
        关机 = 0x4f46,
    }
}