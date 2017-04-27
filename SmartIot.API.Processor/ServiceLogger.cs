using System;
using NewLife.Log;

namespace SmartIot.API.Processor
{
    public class ServiceLogger
    {
        public ServiceLogger()
        {
            _Logger = XTrace.Log;
        }

        private ILog _Logger;
        public ILog Logger
        {
            get
            {
                return _Logger;
            }
        }

        private static ServiceLogger _current;
        /// <summary>
        /// 当前日志对象
        /// </summary>
        public static ServiceLogger Current
        {
            get { return _current ?? (_current = new ServiceLogger()); }
        }

        public void WriteLog(string format, params object[] args)
        {
            Logger.Write(LogLevel.Info, format, args);
        }

        public void WriteDebugLog(string format, params object[] args)
        {
            Logger.Write(LogLevel.Debug, format, args);
        }

        public void WriteWarn(string format, params object[] args)
        {
            Logger.Write(LogLevel.Warn, format, args);
        }

        public void WriteError(string format, params object[] args)
        {
            Logger.Write(LogLevel.Error, format, args);
        }

        public void WriteException(Exception ex, string message = null)
        {
            if (message.IsNullOrWhiteSpace())
            {
                Logger.Write(LogLevel.Fatal, ex.ToString());
            }
            else
            {
                Logger.Write(LogLevel.Fatal, "严重错误：{0}\r\n错误详细信息：{1}", message, ex.ToString());
            }
        }
    }
}
