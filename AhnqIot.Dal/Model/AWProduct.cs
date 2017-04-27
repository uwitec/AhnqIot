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
    /// <summary>农气服务产品</summary>
    [Serializable]
    [DataObject]
    [Description("农气服务产品")]
    [BindIndex("Index_Title", false, "Title")]
    [BindIndex("IX_AWProduct_AWProductTypeSerialnum", false, "AWProductTypeSerialnum")]
    [BindIndex("IX_AWProduct_SysDepartmentSerialnum", false, "SysDepartmentSerialnum")]
    [BindIndex("PK__AWProduc__E3E7488D48DBD888", true, "Serialnum")]
    [BindRelation("AWProductTypeSerialnum", false, "AWProductType", "Serialnum")]
    [BindRelation("SysDepartmentSerialnum", false, "SysDepartment", "Serialnum")]
    [BindTable("AWProduct", Description = "农气服务产品", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class AWProduct : IAWProduct
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

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(4, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(5, "UpdateSysUserSerialnum", "更新用户", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UpdateSysUserSerialnum
        {
            get { return _UpdateSysUserSerialnum; }
            set { if (OnPropertyChanging(__.UpdateSysUserSerialnum, value)) { _UpdateSysUserSerialnum = value; OnPropertyChanged(__.UpdateSysUserSerialnum); } }
        }

        private String _Title;
        /// <summary>标题</summary>
        [DisplayName("标题")]
        [Description("标题")]
        [DataObjectField(false, false, false, 500)]
        [BindColumn(6, "Title", "标题", null, "nvarchar(500)", 0, 0, true, Master=true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging(__.Title, value)) { _Title = value; OnPropertyChanged(__.Title); } }
        }

        private String _Description;
        /// <summary>内容</summary>
        [DisplayName("内容")]
        [Description("内容")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(7, "Description", "内容", null, "ntext", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging(__.Description, value)) { _Description = value; OnPropertyChanged(__.Description); } }
        }

        private String _SysDepartmentSerialnum;
        /// <summary>机构编码</summary>
        [DisplayName("机构编码")]
        [Description("机构编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(8, "SysDepartmentSerialnum", "机构编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysDepartmentSerialnum
        {
            get { return _SysDepartmentSerialnum; }
            set { if (OnPropertyChanging(__.SysDepartmentSerialnum, value)) { _SysDepartmentSerialnum = value; OnPropertyChanged(__.SysDepartmentSerialnum); } }
        }

        private String _AWProductTypeSerialnum;
        /// <summary>农气服务产品类型编码</summary>
        [DisplayName("农气服务产品类型编码")]
        [Description("农气服务产品类型编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(9, "AWProductTypeSerialnum", "农气服务产品类型编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AWProductTypeSerialnum
        {
            get { return _AWProductTypeSerialnum; }
            set { if (OnPropertyChanging(__.AWProductTypeSerialnum, value)) { _AWProductTypeSerialnum = value; OnPropertyChanged(__.AWProductTypeSerialnum); } }
        }

        private String _PhotoUrl;
        /// <summary>图片</summary>
        [DisplayName("图片")]
        [Description("图片")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(10, "PhotoUrl", "图片", null, "nvarchar(500)", 0, 0, true)]
        public virtual String PhotoUrl
        {
            get { return _PhotoUrl; }
            set { if (OnPropertyChanging(__.PhotoUrl, value)) { _PhotoUrl = value; OnPropertyChanged(__.PhotoUrl); } }
        }

        private String _Href;
        /// <summary>链接地址</summary>
        [DisplayName("链接地址")]
        [Description("链接地址")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(11, "Href", "链接地址", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Href
        {
            get { return _Href; }
            set { if (OnPropertyChanging(__.Href, value)) { _Href = value; OnPropertyChanged(__.Href); } }
        }

        private Int32 _Hits;
        /// <summary>点击次数</summary>
        [DisplayName("点击次数")]
        [Description("点击次数")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(12, "Hits", "点击次数", null, "int", 10, 0, false)]
        public virtual Int32 Hits
        {
            get { return _Hits; }
            set { if (OnPropertyChanging(__.Hits, value)) { _Hits = value; OnPropertyChanged(__.Hits); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(13, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(14, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
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
                    case __.UpdateTime : return _UpdateTime;
                    case __.UpdateSysUserSerialnum : return _UpdateSysUserSerialnum;
                    case __.Title : return _Title;
                    case __.Description : return _Description;
                    case __.SysDepartmentSerialnum : return _SysDepartmentSerialnum;
                    case __.AWProductTypeSerialnum : return _AWProductTypeSerialnum;
                    case __.PhotoUrl : return _PhotoUrl;
                    case __.Href : return _Href;
                    case __.Hits : return _Hits;
                    case __.Remark : return _Remark;
                    case __.Sort : return _Sort;
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
                    case __.UpdateTime : _UpdateTime = Convert.ToDateTime(value); break;
                    case __.UpdateSysUserSerialnum : _UpdateSysUserSerialnum = Convert.ToString(value); break;
                    case __.Title : _Title = Convert.ToString(value); break;
                    case __.Description : _Description = Convert.ToString(value); break;
                    case __.SysDepartmentSerialnum : _SysDepartmentSerialnum = Convert.ToString(value); break;
                    case __.AWProductTypeSerialnum : _AWProductTypeSerialnum = Convert.ToString(value); break;
                    case __.PhotoUrl : _PhotoUrl = Convert.ToString(value); break;
                    case __.Href : _Href = Convert.ToString(value); break;
                    case __.Hits : _Hits = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得农气服务产品字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>编码</summary>
            public static readonly Field Serialnum = FindByName(__.Serialnum);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>创建用户</summary>
            public static readonly Field CreateSysUserSerialnum = FindByName(__.CreateSysUserSerialnum);

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            ///<summary>更新用户</summary>
            public static readonly Field UpdateSysUserSerialnum = FindByName(__.UpdateSysUserSerialnum);

            ///<summary>标题</summary>
            public static readonly Field Title = FindByName(__.Title);

            ///<summary>内容</summary>
            public static readonly Field Description = FindByName(__.Description);

            ///<summary>机构编码</summary>
            public static readonly Field SysDepartmentSerialnum = FindByName(__.SysDepartmentSerialnum);

            ///<summary>农气服务产品类型编码</summary>
            public static readonly Field AWProductTypeSerialnum = FindByName(__.AWProductTypeSerialnum);

            ///<summary>图片</summary>
            public static readonly Field PhotoUrl = FindByName(__.PhotoUrl);

            ///<summary>链接地址</summary>
            public static readonly Field Href = FindByName(__.Href);

            ///<summary>点击次数</summary>
            public static readonly Field Hits = FindByName(__.Hits);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得农气服务产品字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编码</summary>
            public const String Serialnum = "Serialnum";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>创建用户</summary>
            public const String CreateSysUserSerialnum = "CreateSysUserSerialnum";

            ///<summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            ///<summary>更新用户</summary>
            public const String UpdateSysUserSerialnum = "UpdateSysUserSerialnum";

            ///<summary>标题</summary>
            public const String Title = "Title";

            ///<summary>内容</summary>
            public const String Description = "Description";

            ///<summary>机构编码</summary>
            public const String SysDepartmentSerialnum = "SysDepartmentSerialnum";

            ///<summary>农气服务产品类型编码</summary>
            public const String AWProductTypeSerialnum = "AWProductTypeSerialnum";

            ///<summary>图片</summary>
            public const String PhotoUrl = "PhotoUrl";

            ///<summary>链接地址</summary>
            public const String Href = "Href";

            ///<summary>点击次数</summary>
            public const String Hits = "Hits";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

        }
        
        #endregion
    }

    /// <summary>农气服务产品接口</summary>
    public partial interface IAWProduct
    {
        #region 属性
        /// <summary>编码</summary>
        String Serialnum { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>创建用户</summary>
        String CreateSysUserSerialnum { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>更新用户</summary>
        String UpdateSysUserSerialnum { get; set; }

        /// <summary>标题</summary>
        String Title { get; set; }

        /// <summary>内容</summary>
        String Description { get; set; }

        /// <summary>机构编码</summary>
        String SysDepartmentSerialnum { get; set; }

        /// <summary>农气服务产品类型编码</summary>
        String AWProductTypeSerialnum { get; set; }

        /// <summary>图片</summary>
        String PhotoUrl { get; set; }

        /// <summary>链接地址</summary>
        String Href { get; set; }

        /// <summary>点击次数</summary>
        Int32 Hits { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        
        #endregion
    }
}