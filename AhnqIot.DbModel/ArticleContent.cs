#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： ArticleContent.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;

#endregion

namespace AhnqIot.DbModel
{
    public partial class ArticleContent : BaseEntity
    {
        public string ArticleCategoryName { get; set; }
        public string ArticleCategorySerialnum { get; set; }
        public string Content { get; set; }
        public string Cover { get; set; }
        public DateTime? PublishTime { get; set; }
        public string SourceName { get; set; }
        public string SourceUrl { get; set; }
        public string Title { get; set; }
        public int? Views { get; set; }
    }
}