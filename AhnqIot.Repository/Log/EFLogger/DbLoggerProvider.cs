#region Code File Comment
// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Repository
// FILENAME   ： DbLoggerProvider.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-14 1:23
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;
using AhnqIot.Infrastructure;
using AhnqIot.Infrastructure.Log;
using Microsoft.Extensions.Logging;

namespace AhnqIot.Repository.Log.EFLogger
{
    internal class DbLoggerProvider : ILoggerProvider
    {
        private readonly Action<string> _writeAction;

        public DbLoggerProvider(Action<string> writeAction)
        {
            Check.NotNull(writeAction, nameof(writeAction));

            _writeAction = writeAction;
        }

        private static readonly string[] _whitelist =
        {
            //typeof(Storage.Internal.RelationalCommandBuilderFactory).FullName
            "Microsoft.Data.Entity.Storage.Internal.RelationalCommandBuilderFactory",
            "Microsoft.Data.Entity.Storage.Internal.SqlServerConnection",
            "Microsoft.Data.Entity.DbContext"
        };

        public ILogger CreateLogger(string name)
        {
            //Console.WriteLine("CreateLogger : " + name);
            //if (_whitelist.Contains(name))
            //{
            //    return new DbSimpleLogger(_writeAction);
            //}
            ILogger logger;
            switch (name)
            {
                case "Microsoft.Data.Entity.Storage.Internal.RelationalCommandBuilderFactory":
                    logger = new DbCommandLogger(str=>LogHelper.Debug(str));
                    break;
                case "Microsoft.Data.Entity.Storage.Internal.SqlServerConnection":
                    logger = new DbContextLogger(str => LogHelper.Debug(str));
                    break;
                case "Microsoft.Data.Entity.DbContext":
                    logger = new DbContextLogger(str => LogHelper.Trace(str));
                    break;
                default:
                    logger = NullLogger.Instance;
                    break;
            }

            return logger;
        }

        public void Dispose()
        {
        }
    }
}