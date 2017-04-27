#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： AgrProduceCondition.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

#endregion

namespace AhnqIot.DbModel
{
    public partial class AgrProduceCondition : BaseEntity
    {
        public string AgrProductObjectSerialnum { get; set; }
        public string DevelopmentalStage { get; set; }
        public int Month { get; set; }
        public string SuitableCondition { get; set; }
        public string SysAreaSerialnum { get; set; }
        public string Ten { get; set; }
        public virtual AgrProductObject AgrProductObjectSerialnumNavigation { get; set; }
        public virtual SysArea SysAreaSerialnumNavigation { get; set; }
    }
}