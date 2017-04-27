#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： StatisticsProcessor.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-29 17:26
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Smart.Redis;
using SmartIot.API.ProcessorV2.Common;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Collect.InnerProcess
{
    /// <summary>
    /// 设备统计数据分析
    /// </summary>
    public class StatisticsProcessor
    {
        /// <summary>
        /// 根据设备数据时间和统计间隔计算KEY
        /// </summary>
        /// <param name="dt">设备时间</param>
        /// <param name="period">分钟</param>
        /// <param name="deviceSerialnum">设备编码</param>
        /// <returns></returns>
        public static string GetStatisticsKey(DateTime dt, int period, string deviceSerialnum)
        {
            var range = GetTimeRange(dt, period);
            string key;
            if (period < 60)
            {
                key =
                    $"{"Statistics"}[{deviceSerialnum}][{period}]{dt.ToString("yyyyMMddHH")}[{range.Item1.ToString("mm:ss")}-{range.Item2.ToString("mm:ss")}]";
            }
            else if (period < 60*24)
            {
                key =
                    $"{"Statistics"}[{deviceSerialnum}][{period}]{dt.ToString("yyyyMMdd")}[{range.Item1.ToString("HH:mm:ss")}-{range.Item2.ToString("HH:mm:ss")}]";
            }
            else
            {
                key =
                    $"{"Statistics"}[{deviceSerialnum}][{period}]{dt.ToString("yyyyMM")}[{range.Item1.ToString("dd")}-{range.Item2.ToString("dd")}]";
            }
            return key;
        }

        /// <summary>
        /// 获取时间间隔的开始时间和结束时间
        /// </summary>
        /// <param name="dt">时间</param>
        /// <param name="period">时间间隔</param>
        /// <returns></returns>
        public static Tuple<DateTime, DateTime> GetTimeRange(DateTime dt, int period = 15)
        {
            var today = new DateTime(dt.Year, dt.Month, dt.Day);
            var span = dt.Subtract(today);
            var count = Convert.ToInt32(Math.Floor(span.TotalMinutes/period));
            var begin = today.AddMinutes(count*period);
            var end = today.AddMinutes((count + 1)*period).AddMilliseconds(-1);

            return new Tuple<DateTime, DateTime>(begin, end);
        }
    }
}