#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： RedisKeyString.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-25 17:32
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

namespace SmartIot.API.Tool
{
    /// <summary>
    /// redis key 设置
    /// </summary>
    public class RedisKeyString
    {
        /// <summary>
        ///     远程客户端的数据包存储KEY
        /// </summary>
        public const string PackageList = "PACKAGE-LIST";

        /// <summary>
        ///     物联网传感器数据列表
        /// </summary>
        public const string SensorDataList = "SensorData-List";

        /// <summary>
        ///     设备历史数据列表
        /// </summary>
        public const string DataInfoList = "DataInfo-List";

        /// <summary>
        ///     设备数据异常记录列表
        /// </summary>
        public const string DeviceDataExceptionLog = "DeviceDataExceptionLog-List";

        /// <summary>
        ///     设备运行日志
        /// </summary>
        public const string DeviceRunLog = "DeviceRunLog-List";

        /// <summary>
        ///     视频运行日志
        /// </summary>
        public const string CameraRunLog = "CameraRunLog-List";

        /// <summary>
        ///     设备分时统计列表
        /// </summary>
        public const string DeviceTimeSharingStatistics = "TimeSharingStatistics-Hash";
    }
}