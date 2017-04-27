/*
 * XCoder v6.5.5847.16174
 * 作者：soft-cq/CQ-PC
 * 时间：2016-01-04 13:59:42
 * 版权：版权所有 (C) 安徽斯玛特物联网科技有限公司 2011~2016
 * http://www.smartah.cc
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace AhnqIot.Dal
{
    /// <summary>文章内容</summary>
    [Serializable]
    [DataObject]
    [Description("文章内容")]
    [BindIndex("IX_ArticleContent_ArticleCategoryName", false, "ArticleCategoryName")]
    [BindIndex("IX_ArticleContent_ArticleCategorySerialnum", false, "ArticleCategorySerialnum")]
    [BindIndex("PK__ArticleC__E3E7488D8084C476", true, "Serialnum")]
    [BindRelation("ArticleCategorySerialnum", false, "ArticleCategory", "Serialnum")]
    [BindRelation("ArticleCategoryName", false, "ArticleCategory", "Name")]
    [BindTable("ArticleContent", Description = "文章内容", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class ArticleContent : IArticleContent
    {
        #region 属性
        
        private String _Serialnum;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(1, "Serialnum", "编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Serialnum
        {
            get { return _Serialnum; }
            set { if (OnPropertyChanging(__.Serialnum, value)) { _Serialnum = value; OnPropertyChanged(__.Serialnum); } }
        }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(2, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateTime
        {
            get { return _CreateTime; }
            set { if (OnPropertyChanging(__.CreateTime, value)) { _CreateTime = value; OnPropertyChanged(__.CreateTime); } }
        }

        private String _CreateSysUserSerialnum;
        /// <summary>创建用户</summary>
        [DisplayName("创建用户")]
        [Description("创建用户")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "CreateSysUserSerialnum", "创建用户", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateSysUserSerialnum
        {
            get { return _CreateSysUserSerialnum; }
            set { if (OnPropertyChanging(__.CreateSysUserSerialnum, value)) { _CreateSysUserSerialnum = value; OnPropertyChanged(__.CreateSysUserSerialnum); } }
        }

        private String _CreateSysUserUserName;
        /// <summary>创建用户</summary>
        [DisplayName("创建用户")]
        [Description("创建用户")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "CreateSysUserUserName", "创建用户", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateSysUserUserName
        {
            get { return _CreateSysUserUserName; }
            set { if (OnPropertyChanging(__.CreateSysUserUserName, value)) { _CreateSysUserUserName = value; OnPropertyChanged(__.CreateSysUserUserName); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(5, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging(__.UpdateTime, value)) { _UpdateTime = value; OnPropertyChanged(__.UpdateTime); } }
        }

        private String _UpdateSysUserSerialnum;
        /// <summary>更新用户</summary>
        [DisplayName("更新用户")]
        [Description("更新用户")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "UpdateSysUserSerialnum", "更新用户", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UpdateSysUserSerialnum
        {
            get { return _UpdateSysUserSerialnum; }
            set { if (OnPropertyChanging(__.UpdateSysUserSerialnum, value)) { _UpdateSysUserSerialnum = value; OnPropertyChanged(__.UpdateSysUserSerialnum); } }
        }

        private String _UpdateSysUserUserName;
        /// <summary>更新用户</summary>
        [DisplayName("更新用户")]
        [Description("更新用户")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "UpdateSysUserUserName", "更新用户", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UpdateSysUserUserName
        {
            get { return _UpdateSysUserUserName; }
            set { if (OnPropertyChanging(__.UpdateSysUserUserName, value)) { _UpdateSysUserUserName = value; OnPropertyChanged(__.UpdateSysUserUserName); } }
        }

        private String _Title;
        /// <summary>标题</summary>
        [DisplayName("标题")]
        [Description("标题")]
        [DataObjectField(false, false, false, 200)]
        [BindColumn(8, "Title", "标题", null, "nvarchar(200)", 0, 0, true, Master=true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging(__.Title, value)) { _Title = value; OnPropertyChanged(__.Title); } }
        }

        private String _ArticleCategorySerialnum;
        /// <summary>分类</summary>
        [DisplayName("分类")]
        [Description("分类")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "ArticleCategorySerialnum", "分类", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ArticleCategorySerialnum
        {
            get { return _ArticleCategorySerialnum; }
            set { if (OnPropertyChanging(__.ArticleCategorySerialnum, value)) { _ArticleCategorySerialnum = value; OnPropertyChanged(__.ArticleCategorySerialnum); } }
        }

        private String _ArticleCategoryName;
        /// <summary>分类名称</summary>
        [DisplayName("分类名称")]
        [Description("分类名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "ArticleCategoryName", "分类名称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ArticleCategoryName
        {
            get { return _ArticleCategoryName; }
            set { if (OnPropertyChanging(__.ArticleCategoryName, value)) { _ArticleCategoryName = value; OnPropertyChanged(__.ArticleCategoryName); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(12, "Remark", "备注", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } }
        }

        private Int32 _Views;
        /// <summary>访问量</summary>
        [DisplayName("访问量")]
        [Description("访问量")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(13, "Views", "访问量", null, "int", 10, 0, false)]
        public virtual Int32 Views
        {
            get { return _Views; }
            set { if (OnPropertyChanging(__.Views, value)) { _Views = value; OnPropertyChanged(__.Views); } }
        }

        private String _SourceName;
        /// <summary>来源名称</summary>
        [DisplayName("来源名称")]
        [Description("来源名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "SourceName", "来源名称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SourceName
        {
            get { return _SourceName; }
            set { if (OnPropertyChanging(__.SourceName, value)) { _SourceName = value; OnPropertyChanged(__.SourceName); } }
        }

        private String _SourceUrl;
        /// <summary>来源地址</summary>
        [DisplayName("来源地址")]
        [Description("来源地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "SourceUrl", "来源地址", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SourceUrl
        {
            get { return _SourceUrl; }
            set { if (OnPropertyChanging(__.SourceUrl, value)) { _SourceUrl = value; OnPropertyChanged(__.SourceUrl); } }
        }

        private String _Cover;
        /// <summary>封面</summary>
        [DisplayName("封面")]
        [Description("封面")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(16, "Cover", "封面", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Cover
        {
            get { return _Cover; }
            set { if (OnPropertyChanging(__.Cover, value)) { _Cover = value; OnPropertyChanged(__.Cover); } }
        }

        private DateTime _PublishTime;
        /// <summary>发布时间</summary>
        [DisplayName("发布时间")]
        [Description("发布时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(17, "PublishTime", "发布时间", null, "datetime", 3, 0, false)]
        public virtual DateTime PublishTime
        {
            get { return _PublishTime; }
            set { if (OnPropertyChanging(__.PublishTime, value)) { _PublishTime = value; OnPropertyChanged(__.PublishTime); } }
        }

        private String _Content;
        /// <summary>内容</summary>
        [DisplayName("内容")]
        [Description("内容")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(18, "Content", "内容", null, "ntext", 0, 0, true)]
        public virtual String Content
        {
            get { return _Content; }
            set { if (OnPropertyChanging(__.Content, value)) { _Content = value; OnPropertyChanged(__.Content); } }
        }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.Serialnum : return _Serialnum;
                    case __.CreateTime : return _CreateTime;
                    case __.CreateSysUserSerialnum : return _CreateSysUserSerialnum;
                    case __.CreateSysUserUserName : return _CreateSysUserUserName;
                    case __.UpdateTime : return _UpdateTime;
                    case __.UpdateSysUserSerialnum : return _UpdateSysUserSerialnum;
                    case __.UpdateSysUserUserName : return _UpdateSysUserUserName;
                    case __.Title : return _Title;
                    case __.ArticleCategorySerialnum : return _ArticleCategorySerialnum;
                    case __.ArticleCategoryName : return _ArticleCategoryName;
                    case __.Sort : return _Sort;
                    case __.Remark : return _Remark;
                    case __.Views : return _Views;
                    case __.SourceName : return _SourceName;
                    case __.SourceUrl : return _SourceUrl;
                    case __.Cover : return _Cover;
                    case __.PublishTime : return _PublishTime;
                    case __.Content : return _Content;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Serialnum : _Serialnum = Convert.ToString(value); break;
                    case __.CreateTime : _CreateTime = Convert.ToDateTime(value); break;
                    case __.CreateSysUserSerialnum : _CreateSysUserSerialnum = Convert.ToString(value); break;
                    case __.CreateSysUserUserName : _CreateSysUserUserName = Convert.ToString(value); break;
                    case __.UpdateTime : _UpdateTime = Convert.ToDateTime(value); break;
                    case __.UpdateSysUserSerialnum : _UpdateSysUserSerialnum = Convert.ToString(value); break;
                    case __.UpdateSysUserUserName : _UpdateSysUserUserName = Convert.ToString(value); break;
                    case __.Title : _Title = Convert.ToString(value); break;
                    case __.ArticleCategorySerialnum : _ArticleCategorySerialnum = Convert.ToString(value); break;
                    case __.ArticleCategoryName : _ArticleCategoryName = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    case __.Views : _Views = Convert.ToInt32(value); break;
                    case __.SourceName : _SourceName = Convert.ToString(value); break;
                    case __.SourceUrl : _SourceUrl = Convert.ToString(value); break;
                    case __.Cover : _Cover = Convert.ToString(value); break;
                    case __.PublishTime : _PublishTime = Convert.ToDateTime(value); break;
                    case __.Content : _Content = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得文章内容字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>编码</summary>
            public static readonly Field Serialnum = FindByName(__.Serialnum);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>创建用户</summary>
            public static readonly Field CreateSysUserSerialnum = FindByName(__.CreateSysUserSerialnum);

            ///<summary>创建用户</summary>
            public static readonly Field CreateSysUserUserName = FindByName(__.CreateSysUserUserName);

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            ///<summary>更新用户</summary>
            public static readonly Field UpdateSysUserSerialnum = FindByName(__.UpdateSysUserSerialnum);

            ///<summary>更新用户</summary>
            public static readonly Field UpdateSysUserUserName = FindByName(__.UpdateSysUserUserName);

            ///<summary>标题</summary>
            public static readonly Field Title = FindByName(__.Title);

            ///<summary>分类</summary>
            public static readonly Field ArticleCategorySerialnum = FindByName(__.ArticleCategorySerialnum);

            ///<summary>分类名称</summary>
            public static readonly Field ArticleCategoryName = FindByName(__.ArticleCategoryName);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            ///<summary>访问量</summary>
            public static readonly Field Views = FindByName(__.Views);

            ///<summary>来源名称</summary>
            public static readonly Field SourceName = FindByName(__.SourceName);

            ///<summary>来源地址</summary>
            public static readonly Field SourceUrl = FindByName(__.SourceUrl);

            ///<summary>封面</summary>
            public static readonly Field Cover = FindByName(__.Cover);

            ///<summary>发布时间</summary>
            public static readonly Field PublishTime = FindByName(__.PublishTime);

            ///<summary>内容</summary>
            public static readonly Field Content = FindByName(__.Content);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得文章内容字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编码</summary>
            public const String Serialnum = "Serialnum";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>创建用户</summary>
            public const String CreateSysUserSerialnum = "CreateSysUserSerialnum";

            ///<summary>创建用户</summary>
            public const String CreateSysUserUserName = "CreateSysUserUserName";

            ///<summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            ///<summary>更新用户</summary>
            public const String UpdateSysUserSerialnum = "UpdateSysUserSerialnum";

            ///<summary>更新用户</summary>
            public const String UpdateSysUserUserName = "UpdateSysUserUserName";

            ///<summary>标题</summary>
            public const String Title = "Title";

            ///<summary>分类</summary>
            public const String ArticleCategorySerialnum = "ArticleCategorySerialnum";

            ///<summary>分类名称</summary>
            public const String ArticleCategoryName = "ArticleCategoryName";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

            ///<summary>访问量</summary>
            public const String Views = "Views";

            ///<summary>来源名称</summary>
            public const String SourceName = "SourceName";

            ///<summary>来源地址</summary>
            public const String SourceUrl = "SourceUrl";

            ///<summary>封面</summary>
            public const String Cover = "Cover";

            ///<summary>发布时间</summary>
            public const String PublishTime = "PublishTime";

            ///<summary>内容</summary>
            public const String Content = "Content";

        }
        
        #endregion
    }

    /// <summary>文章内容接口</summary>
    public partial interface IArticleContent
    {
        #region 属性
        /// <summary>编码</summary>
        String Serialnum { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>创建用户</summary>
        String CreateSysUserSerialnum { get; set; }

        /// <summary>创建用户</summary>
        String CreateSysUserUserName { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>更新用户</summary>
        String UpdateSysUserSerialnum { get; set; }

        /// <summary>更新用户</summary>
        String UpdateSysUserUserName { get; set; }

        /// <summary>标题</summary>
        String Title { get; set; }

        /// <summary>分类</summary>
        String ArticleCategorySerialnum { get; set; }

        /// <summary>分类名称</summary>
        String ArticleCategoryName { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        /// <summary>访问量</summary>
        Int32 Views { get; set; }

        /// <summary>来源名称</summary>
        String SourceName { get; set; }

        /// <summary>来源地址</summary>
        String SourceUrl { get; set; }

        /// <summary>封面</summary>
        String Cover { get; set; }

        /// <summary>发布时间</summary>
        DateTime PublishTime { get; set; }

        /// <summary>内容</summary>
        String Content { get; set; }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        
        #endregion
    }
}