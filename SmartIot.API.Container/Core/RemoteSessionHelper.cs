#region Code File Comment
// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.API.Container
// FILENAME   ： RemoteSessionHelper.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-25 15:22
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016
#endregion

using System.Collections.Concurrent;
using System.Net.Sockets;
using NewLife.Net;

namespace SmartIot.API.Container.Core
{
    public class RemoteSessionHelper
    {
        /// <summary>
        /// 客户端会话缓存
        /// </summary>
        public static readonly ConcurrentDictionary<string, ISocketSession> RemoteSessionCache = new ConcurrentDictionary<string, ISocketSession>();


    }
}