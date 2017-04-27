#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.Container
// FILENAME   ： RemoteSessionHelper.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-25 15:22
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System.Collections.Concurrent;
using NewLife.Net;

namespace SmartIot.API.ProcessorV2.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 会话其实在TcpServer里面已有管理，程序暂时先使用自己的
    /// </remarks>
    public class RemoteSessionHelper
    {
        /// <summary>
        /// 客户端会话缓存
        /// </summary>
        public static readonly ConcurrentDictionary<string, ISocketSession> RemoteSessionCache =
            new ConcurrentDictionary<string, ISocketSession>();

        public static ISocketSession GetSession(string id)
        {
            ISocketSession session;
            return !RemoteSessionCache.TryGetValue(id, out session) ? null : session;
        }
    }
}