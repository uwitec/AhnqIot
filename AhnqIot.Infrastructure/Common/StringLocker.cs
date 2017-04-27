#region Code File Comment
// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Infrastructure
// FILENAME   ： StringLocker.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-25 14:35
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AhnqIot.Infrastructure.Common
{
    public class StringLocker
    {
        private const int ExpireMinutes = 10;

        private static readonly Timer _timer;
        private static readonly Dictionary<string, LockObj> _dict = new Dictionary<string, LockObj>();

        static StringLocker()
        {
            //_timer = new Timer(60000);
            //_timer.Elapsed += (s, e) =>
            //{
            //    RemovedExired();
            //};
            //_timer.Start();
            _timer = new Timer(RemovedExired, null, 100, 600000);
        }

        public static void Run(string key, Action action)
        {
            LockObj lockObj = null;
            lock (_dict)
            {
                if (!_dict.ContainsKey(key))
                {
                    _dict[key] = new LockObj();
                }
                lockObj = _dict[key];
                lockObj.Time = DateTime.Now;
            }
            lock (lockObj)
            {
                action();
            }
        }

        public static void RemovedExired(object obj)
        {
            lock (_dict)
            {
                var keys = _dict.Where(x => x.Value.IsExpired()).Select(x => x.Key).ToList();
                foreach (var key in keys)
                {
                    _dict.Remove(key);
                }
            }
        }

        private class LockObj
        {
            public DateTime Time { private get; set; }

            public bool IsExpired()
            {
                return this.Time < DateTime.Now.AddMinutes(-ExpireMinutes);
            }
        }
    }
}