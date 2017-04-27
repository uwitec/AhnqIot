#region Code File Comment
// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Repository
// FILENAME   ： Class1.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-14 1:21
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;
using Microsoft.Extensions.Logging;

namespace AhnqIot.Repository.Log.EFLogger
{
    internal class NullLogger : ILogger
    {
        private static NullLogger _instance = new NullLogger();

        public static NullLogger Instance => _instance;

        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        { }

        public bool IsEnabled(LogLevel logLevel)
        {
            return false;
        }

        public IDisposable BeginScopeImpl(object state)
        {
            return null;
        }
    }
}