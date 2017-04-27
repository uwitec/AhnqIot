//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： AhnqIot.Bussiness
//  FILENAME   ： Statistics.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 15:06
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.Text;
using System.Threading;
using AhnqIot.Infrastructure.Log;

namespace AhnqIot.Bussiness.CacheStatistics
{
    public class Statistics : IStatistics
    {
        public string Name { get; set; }

        public long Total;

        public long Hit;

        public Statistics(string name)
        {
            this.Name = name;
        }

        public void Show()
        {
            if (Total > 0)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("实体缓存<{0,-20}>", Name);
                sb.AppendFormat("总次数{0,7:n0}", Total);
                if (Hit > 0) sb.AppendFormat("，命中{0,7:n0}（{1,6:P02}）", Hit, (Double)Hit / Total);
                //  if (Shoot2 > 0) sb.AppendFormat("，二级命中{0,3:n0}（{1,6:P02}）", Shoot2, (Double)Shoot2 / Total);

                LogHelper.Debug(sb.ToString());
            }
        }

        public void AddHit()
        {
            Interlocked.Increment(ref Hit);
        }
        public void AddTotal()
        {
            Interlocked.Increment(ref Total);
        }

        public void Reset()
        {
            Interlocked.Add(ref Total, -1 * Total);
            Interlocked.Add(ref Hit, -1 * Hit);
        }
    }
}