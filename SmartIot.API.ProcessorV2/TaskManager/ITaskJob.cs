#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： ITaskJob.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-29 13:34
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System.Threading.Tasks;

#endregion

namespace SmartIot.API.ProcessorV2.TaskManager
{
    public interface ITaskJob
    {
        ///// <summary>
        /////     默认的Cron表达式
        ///// </summary>
        //string CronExp { get; set; }
        /// <summary>
        /// 间隔
        /// </summary>
        int Period { get; set; }

        /// <summary>
        ///     任务名称
        /// </summary>
        string JobName { get; set; }

        /// <summary>
        /// 获取启动等待时间,单位:秒
        /// </summary>
        /// <returns></returns>
        Task<int> GetWaitForSecondsAsync();

        /// <summary>
        ///     处理核心
        /// </summary>
        /// <returns></returns>
        Task ProcessAsync();
    }
}