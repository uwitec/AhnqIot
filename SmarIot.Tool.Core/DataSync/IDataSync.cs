using System;

namespace SmartIot.Tool.Core.DataSync
{
    public interface IDataSync
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 同步后立即删除
        /// </summary>
        bool EnableDelete { get; set; }

        /* bool Start();

         bool Stop();*/

        bool Sync(DateTime dataTime);
    }
}