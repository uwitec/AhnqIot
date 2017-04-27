#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Repository
// FILENAME   ： DbCommandLogger.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-14 11:48
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using AhnqIot.Infrastructure;
using Microsoft.Extensions.Logging;

#endregion

namespace AhnqIot.Repository.Log.EFLogger
{
    internal class DbCommandLogger : ILogger
    {
        private readonly Action<string> _writeAction;

        public DbCommandLogger(Action<string> writeAction)
        {
            Check.NotNull(writeAction, nameof(writeAction));
            _writeAction = writeAction;
        }

        public void Log(LogLevel logLevel, int eventId, object state, Exception exception,
            Func<object, Exception, string> formatter)
        {
            var message = $"{Environment.NewLine}{formatter(state, exception)}";
            _writeAction(message);
        }

        public bool IsEnabled(LogLevel logLevel) => logLevel == LogLevel.Verbose;

        public IDisposable BeginScopeImpl(object state) => null;
    }
}