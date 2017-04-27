using NewLife.Log;
using NewLife.Model;
using System;

namespace SmartIot.Tool.DefaultServiceTool.Common
{
    public class Logger
    {
        private static Logger _current;
        private readonly ILog _logger;

        public Logger()
        {
            _logger = XTrace.Log;
        }

        /// <summary>
        /// 当前日志对象
        /// </summary>
        public static Logger Current
        {
            get
            {
                if (_current == null)
                    _current = ObjectContainer.Current.Resolve<Logger>();
                return _current;
            }
        }

        public void WriteLog(string format, params object[] args)
        {
            _logger.Write(LogLevel.Info, format, args);
        }

        public void WriteDebugLog(string format, params object[] args)
        {
            _logger.Write(LogLevel.Debug, format, args);
        }

        public void WriteWarn(string format, params object[] args)
        {
            _logger.Write(LogLevel.Warn, format, args);
        }

        public void WriteError(string format, params object[] args)
        {
            _logger.Write(LogLevel.Error, format, args);
        }

        public void WriteException(Exception ex, string message = null)
        {
            if (message.IsNullOrWhiteSpace())
            {
                _logger.Write(LogLevel.Fatal, ex.ToString());
            }
            else
            {
                _logger.Write(LogLevel.Fatal, "严重错误：{0}\r\n错误详细信息：{1}", message, ex.ToString());
            }
        }
    }
}