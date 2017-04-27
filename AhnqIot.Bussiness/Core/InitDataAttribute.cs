//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Bussiness
//  FILENAME   ： InitDataAttribute.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 13:56
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;

namespace AhnqIot.Bussiness.Core
{
    public class InitDataAttribute : Attribute
    {
        public int Sort { get; set; }

        public InitDataAttribute()
        {
            this.Sort = 999;
        }

        public InitDataAttribute(int sort)
        {
            this.Sort = sort;
        }
    }
}