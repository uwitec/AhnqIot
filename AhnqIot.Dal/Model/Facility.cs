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
    /// <summary>基地设施</summary>
    [Serializable]
    [DataObject]
    [Description("基地设施")]
    [BindIndex("Index_FarmSerialnum", false, "FarmSerialnum")]
    [BindIndex("IX_Facility_FacilityTypeSerialnum", false, "FacilityTypeSerialnum")]
    [BindIndex("PK__Facility__E3E7488D8360ED6A", true, "Serialnum")]
    [BindRelation("Serialnum", true, "CompanyUser", "FacilitySerialnum")]
    [BindRelation("Serialnum", true, "Device", "FacilitySerialnum")]
    [BindRelation("FacilityTypeSerialnum", false, "FacilityType", "Serialnum")]
    [BindRelation("FarmSerialnum", false, "Farm", "Serialnum")]
    [BindRelation("Serialnum", true, "FacilityCamera", "FacilitySerialnum")]
    [BindRelation("Serialnum", true, "FacilityCameraRunStatistics", "FacilitySerialnum")]
    [BindRelation("Serialnum", true, "FacilityProduceInfo", "FacilitySerialnum")]
    [BindTable("Facility", Description = "基地设施", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class Facility : IFacility
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

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "Name", "名称", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private String _FarmSerialnum;
        /// <summary>基地编码</summary>
        [DisplayName("基地编码")]
        [Description("基地编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "FarmSerialnum", "基地编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FarmSerialnum
        {
            get { return _FarmSerialnum; }
            set { if (OnPropertyChanging(__.FarmSerialnum, value)) { _FarmSerialnum = value; OnPropertyChanged(__.FarmSerialnum); } }
        }

        private String _FacilityTypeSerialnum;
        /// <summary>设施类型</summary>
        [DisplayName("设施类型")]
        [Description("设施类型")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(8, "FacilityTypeSerialnum", "设施类型", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FacilityTypeSerialnum
        {
            get { return _FacilityTypeSerialnum; }
            set { if (OnPropertyChanging(__.FacilityTypeSerialnum, value)) { _FacilityTypeSerialnum = value; OnPropertyChanged(__.FacilityTypeSerialnum); } }
        }

        private String _Address;
        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(9, "Address", "地址", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Address
        {
            get { return _Address; }
            set { if (OnPropertyChanging(__.Address, value)) { _Address = value; OnPropertyChanged(__.Address); } }
        }

        private String _PhotoUrl;
        /// <summary>形象图片</summary>
        [DisplayName("形象图片")]
        [Description("形象图片")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(10, "PhotoUrl", "形象图片", null, "nvarchar(500)", 0, 0, true)]
        public virtual String PhotoUrl
        {
            get { return _PhotoUrl; }
            set { if (OnPropertyChanging(__.PhotoUrl, value)) { _PhotoUrl = value; OnPropertyChanged(__.PhotoUrl); } }
        }

        private String _ContactMan;
        /// <summary>联系人</summary>
        [DisplayName("联系人")]
        [Description("联系人")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "ContactMan", "联系人", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ContactMan
        {
            get { return _ContactMan; }
            set { if (OnPropertyChanging(__.ContactMan, value)) { _ContactMan = value; OnPropertyChanged(__.ContactMan); } }
        }

        private String _ContactPhone;
        /// <summary>联系电话</summary>
        [DisplayName("联系电话")]
        [Description("联系电话")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "ContactPhone", "联系电话", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ContactPhone
        {
            get { return _ContactPhone; }
            set { if (OnPropertyChanging(__.ContactPhone, value)) { _ContactPhone = value; OnPropertyChanged(__.ContactPhone); } }
        }

        private String _ContactMobile;
        /// <summary>手机</summary>
        [DisplayName("手机")]
        [Description("手机")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "ContactMobile", "手机", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ContactMobile
        {
            get { return _ContactMobile; }
            set { if (OnPropertyChanging(__.ContactMobile, value)) { _ContactMobile = value; OnPropertyChanged(__.ContactMobile); } }
        }

        private Int32 _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(14, "Status", "状态", null, "int", 10, 0, false)]
        public virtual Int32 Status
        {
            get { return _Status; }
            set { if (OnPropertyChanging(__.Status, value)) { _Status = value; OnPropertyChanged(__.Status); } }
        }

        private String _Introduce;
        /// <summary>设施介绍</summary>
        [DisplayName("设施介绍")]
        [Description("设施介绍")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(15, "Introduce", "设施介绍", null, "ntext", 0, 0, true)]
        public virtual String Introduce
        {
            get { return _Introduce; }
            set { if (OnPropertyChanging(__.Introduce, value)) { _Introduce = value; OnPropertyChanged(__.Introduce); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(16, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(17, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } }
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
                    case __.Name : return _Name;
                    case __.FarmSerialnum : return _FarmSerialnum;
                    case __.FacilityTypeSerialnum : return _FacilityTypeSerialnum;
                    case __.Address : return _Address;
                    case __.PhotoUrl : return _PhotoUrl;
                    case __.ContactMan : return _ContactMan;
                    case __.ContactPhone : return _ContactPhone;
                    case __.ContactMobile : return _ContactMobile;
                    case __.Status : return _Status;
                    case __.Introduce : return _Introduce;
                    case __.Sort : return _Sort;
                    case __.Remark : return _Remark;
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
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.FarmSerialnum : _FarmSerialnum = Convert.ToString(value); break;
                    case __.FacilityTypeSerialnum : _FacilityTypeSerialnum = Convert.ToString(value); break;
                    case __.Address : _Address = Convert.ToString(value); break;
                    case __.PhotoUrl : _PhotoUrl = Convert.ToString(value); break;
                    case __.ContactMan : _ContactMan = Convert.ToString(value); break;
                    case __.ContactPhone : _ContactPhone = Convert.ToString(value); break;
                    case __.ContactMobile : _ContactMobile = Convert.ToString(value); break;
                    case __.Status : _Status = Convert.ToInt32(value); break;
                    case __.Introduce : _Introduce = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得基地设施字段信息的快捷方式</summary>
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

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>基地编码</summary>
            public static readonly Field FarmSerialnum = FindByName(__.FarmSerialnum);

            ///<summary>设施类型</summary>
            public static readonly Field FacilityTypeSerialnum = FindByName(__.FacilityTypeSerialnum);

            ///<summary>地址</summary>
            public static readonly Field Address = FindByName(__.Address);

            ///<summary>形象图片</summary>
            public static readonly Field PhotoUrl = FindByName(__.PhotoUrl);

            ///<summary>联系人</summary>
            public static readonly Field ContactMan = FindByName(__.ContactMan);

            ///<summary>联系电话</summary>
            public static readonly Field ContactPhone = FindByName(__.ContactPhone);

            ///<summary>手机</summary>
            public static readonly Field ContactMobile = FindByName(__.ContactMobile);

            ///<summary>状态</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>设施介绍</summary>
            public static readonly Field Introduce = FindByName(__.Introduce);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得基地设施字段名称的快捷方式</summary>
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

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>基地编码</summary>
            public const String FarmSerialnum = "FarmSerialnum";

            ///<summary>设施类型</summary>
            public const String FacilityTypeSerialnum = "FacilityTypeSerialnum";

            ///<summary>地址</summary>
            public const String Address = "Address";

            ///<summary>形象图片</summary>
            public const String PhotoUrl = "PhotoUrl";

            ///<summary>联系人</summary>
            public const String ContactMan = "ContactMan";

            ///<summary>联系电话</summary>
            public const String ContactPhone = "ContactPhone";

            ///<summary>手机</summary>
            public const String ContactMobile = "ContactMobile";

            ///<summary>状态</summary>
            public const String Status = "Status";

            ///<summary>设施介绍</summary>
            public const String Introduce = "Introduce";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>基地设施接口</summary>
    public partial interface IFacility
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

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>基地编码</summary>
        String FarmSerialnum { get; set; }

        /// <summary>设施类型</summary>
        String FacilityTypeSerialnum { get; set; }

        /// <summary>地址</summary>
        String Address { get; set; }

        /// <summary>形象图片</summary>
        String PhotoUrl { get; set; }

        /// <summary>联系人</summary>
        String ContactMan { get; set; }

        /// <summary>联系电话</summary>
        String ContactPhone { get; set; }

        /// <summary>手机</summary>
        String ContactMobile { get; set; }

        /// <summary>状态</summary>
        Int32 Status { get; set; }

        /// <summary>设施介绍</summary>
        String Introduce { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        
        #endregion
    }
}