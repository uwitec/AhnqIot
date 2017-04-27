#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Infrastructure
// FILENAME   ： LogHelper.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-14 1:03
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using NLog;

#endregion

#region Autofac.Extras.NLog
//Install-Package Autofac.Extras.NLog
#endregion

namespace AhnqIot.Infrastructure.Log
{
    public class LogHelper
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static void Trace(string info, params object[] args)
        {
            Logger.Trace(info, args);
        }

        public static void Debug(string info, params object[] args)
        {
            Logger.Debug(info, args);
        }

        public static void Info(string info, params object[] args)
        {
            Logger.Info(info, args);
        }

        public static void Warn(string info, params object[] args)
        {
            Logger.Warn(info, args);
        }

        public static void Error(string info, params object[] args)
        {
            Logger.Error(info, args);
        }

        public static void Fatal(string info, params object[] args)
        {
            Logger.Fatal(info, args);
        }
    }
}