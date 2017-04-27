#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： NewClassByContent.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;

#endregion

namespace AhnqIot.DbModel
{
    public partial class NewClassByContent
    {
        public int ID { get; set; }
        public int? AnswerNum { get; set; }
        public int? BeNew { get; set; }
        public int? BeOnly { get; set; }
        public int? Click { get; set; }
        public Guid? ContentGUID { get; set; }
        public DateTime? DateTime { get; set; }
        public int? Enable { get; set; }
        public Guid? NewsClass { get; set; }
        public int? Serial { get; set; }
        public string Title { get; set; }
        public string Title1 { get; set; }
    }
}