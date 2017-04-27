#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： CONTENT_LIST.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;

#endregion

namespace AhnqIot.DbModel
{
    public partial class CONTENT_LIST
    {
        public decimal ID { get; set; }
        public string City { get; set; }
        public decimal? Click { get; set; }
        public string CustomType { get; set; }
        public string FileCode { get; set; }
        public string FileUser { get; set; }
        public string FLV { get; set; }
        public string HOT_ID { get; set; }
        public string HTML_PATH { get; set; }
        public string INFO_ID { get; set; }
        public string INFOSOURCE { get; set; }
        public decimal? INFOTYPE { get; set; }
        public bool? IPTV { get; set; }
        public string KEYWORD { get; set; }
        public string LONGTITLE { get; set; }
        public string MP3 { get; set; }
        public decimal? ORDERID { get; set; }
        public string PIC { get; set; }
        public bool? PROP_INDEX { get; set; }
        public bool? PROP_PIC { get; set; }
        public bool? PROP_TOP { get; set; }
        public string RELATION_ID { get; set; }
        public decimal? STATE { get; set; }
        public string SUMMARY { get; set; }
        public DateTime? TIME_LAST { get; set; }
        public DateTime? TIME_PUBLISH { get; set; }
        public DateTime? TIME_UNPUBLISH { get; set; }
        public string TITLE { get; set; }
        public string TITLE_COLOR { get; set; }
        public string URL_LINK { get; set; }
        public decimal? USER_ID { get; set; }
        public decimal? USER_ID_PUB { get; set; }
        public string USER_NAME { get; set; }
        public string USER_NAME_PUB { get; set; }
    }
}