//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Bussiness
//  FILENAME   ： IStatistics.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 0:02
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016
namespace AhnqIot.Bussiness.CacheStatistics
{
    /// <summary>
    /// redis命中统计
    /// </summary>
    public interface IStatistics
    {
        string Name { get; set; }
        void Show();
        void AddHit();
        void AddTotal();
        void Reset();
    }
}