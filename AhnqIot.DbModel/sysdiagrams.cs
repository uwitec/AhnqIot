#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： sysdiagrams.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

namespace AhnqIot.DbModel
{
    public partial class sysdiagrams
    {
        public int diagram_id { get; set; }
        public byte[] definition { get; set; }
        public int principal_id { get; set; }
        public int? version { get; set; }
    }
}