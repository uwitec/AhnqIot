#region Code File Comment
// SOLUTION   ： SmartIot
// PROJECT    ： SmartIot.API.Processor
// FILENAME   ： FarmStatus.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-15 18:02
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;
using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Meta.Request;
using NewLife.Log;
using System.Threading;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Request.DataContent.RuntimeDataRequest;
using SmartIot.API.Processor.Common;
using NewLife.Threading;

namespace SmartIot.API.Processor.DataObject.CoreProcessor
{
    public class FarmStatusProcessor
    {
        //private static readonly ConcurrentQueue<FarmRunLog> FarmRunLogQueue = new ConcurrentQueue<FarmRunLog>();
        /// <summary>
        /// 保存定时器，10秒保存一次
        /// </summary>
        private static TimerX _processTimerX;
        static FarmStatusProcessor()
        {
            //Process();
            //System.Threading.ThreadStart threadStart = new System.Threading.ThreadStart(() => Process());
            //_processTimerX = new TimerX(obj => Process(), null, 5000, 10000);
        }

        ///// <summary>
        ///// 循环处理队列
        ///// </summary>
        //private static void Process()
        //{
        //    if (!FarmRunLogQueue.IsEmpty)
        //    //if (true)
        //    {
        //        try
        //        {
        //            //保存原始数据
        //            var list = FarmRunLogQueue.ToArray();
        //            var entityList = new EntityList<FarmRunLog>(list);
        //            entityList.Save(true);
        //            //处理统计信息
        //            entityList.ForEach(ProcessStatistics);

        //            //清除刚取出来的数据
        //            FarmRunLog log = null;
        //            for (int i = 0; i < list.Length; i++)
        //            {
        //                FarmRunLogQueue.TryDequeue(out log);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ServiceLogger.Current.WriteException(ex);
        //        }
        //    }
        //}
        /// <summary>
        /// 处理<see cref="FarmStatus"/>数据
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static XResponseMessage Process(FarmStatus status)
        {
            if (status == null) throw new ArgumentNullException("status");
            //#if DEBUG
            //            Stopwatch sw = new Stopwatch();
            //            sw.Start();
            //#endif
            try
            {
                //ProcessLog(status);
            }
            catch (Exception ex)
            {
                return ResultHelper.CreateMessage("", ErrorType.InternalError, null, ex);
            }

            //#if DEBUG
            //            sw.Stop();
            //            ServiceLogger.Current.WriteDebugLog("基地上传耗时：" + sw.ElapsedMilliseconds + "ms");
            //#endif
            return null;
        }

        //private static void ProcessLog(FarmStatus status)
        //{
        //    var type = FarmRunLogType.FindByName(status.InfoType.ToString());
        //    if (type == null)
        //        type = FarmRunLogType.FindByName(FarmRunLogTypeEnum.正常.ToString());

        //    FarmRunLog frl = new FarmRunLog
        //    {
        //        FarmSerialnum = status.FarmSerialnum,
        //        CPUUsage = status.CpuUsage,
        //        MemoryUsage = status.MemoryUsage,
        //        FarmRunLogTypeSerialnum = type.Serialnum,
        //        Description = status.Description,
        //        CreateTime = status.Time,
        //        UpdateTime =  status.Time
        //    };
        //    // frl.Save();

        //    FarmRunLogQueue.Enqueue(frl);
        //}

        //private static void ProcessStatistics(FarmRunLog log)
        //{
        //    var year = log.CreateTime.Year;
        //    var month = log.CreateTime.Month;
        //    var day = log.CreateTime.Day;

        //    var statistics = DAL.Company.FarmRunningStatistics.FindByArgs(log.FarmSerialnum, year, month, day);

        //    if (statistics == null)
        //    {
        //        statistics = new FarmRunningStatistics();
        //        statistics.FarmSerialnum = log.FarmSerialnum;
        //        statistics.Year = year;
        //        statistics.Month = month;
        //        statistics.Day = day;
        //    }
        //    //应收次数此处不作处理
        //    statistics.AllCount++;
        //    statistics.ReceiveCount++;
        //    statistics.ReceivePercent = Math.Round((statistics.ReceiveCount * 1M) / (statistics.AllCount * 1M), 1) * 100M;
        //    statistics.Save();
        //}
    }
}