namespace SmartIot.Tool.Core.Device.TtsDevice
{
    public interface ITtsDevice
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 展示数据
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        bool Display(string message);
    }
}