#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.DbModel
// FILENAME   ： CompanyPics.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-11 15:27
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

#endregion

namespace AhnqIot.DbModel
{
    public partial class CompanyPics : BaseEntity
    {
        public string CompanySerialnum { get; set; }
        public string PicSerialnum { get; set; }
        public virtual Company CompanySerialnumNavigation { get; set; }
        public virtual PictureRep PicSerialnumNavigation { get; set; }
    }
}