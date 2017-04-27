#region Code File Comment

// SOLUTION   ： AWIOT - Device
// PROJECT    ： AWIOT.Service.Core
// FILENAME   ： ServiceLogger.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-30 10:55
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using NewLife.Log;
using System.Collections.Generic;
using System.Security.AccessControl;
using AhnqIot.Infrastructure.Log;
using NewLife.Net;

#endregion

namespace SmartIot.Service.Core
{
    /// <summary>
    ///     日志
    /// </summary>
    public class NewlifeLogger : ILog
    {
        public bool Enable { get; set; }
        public LogLevel Level { get; set; }

        public void Write(LogLevel level, string format, params object[] args)
        {
            switch (level)
            {
                case LogLevel.Debug: LogHelper.Trace(format, args); break;
                case LogLevel.Info: LogHelper.Trace(format, args); break;
                case LogLevel.Warn: LogHelper.Trace(format, args); break;
                case LogLevel.Error: LogHelper.Trace(format, args); break;
                case LogLevel.Fatal: LogHelper.Trace(format, args); break;
                case LogLevel.All: LogHelper.Trace(format, args); break;
                default: LogHelper.Info(format, args); break;
            }
        }

        public void Debug(string format, params object[] args)
        {
            LogHelper.Debug(format, args);
        }

        public void Info(string format, params object[] args)
        {
            LogHelper.Info(format, args);
        }

        public void Warn(string format, params object[] args)
        {
            LogHelper.Warn(format, args);
        }

        public void Error(string format, params object[] args)
        {
            LogHelper.Error(format, args);
        }

        public void Fatal(string format, params object[] args)
        {
            LogHelper.Fatal(format, args);
        }
    }
}