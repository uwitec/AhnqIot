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
    /// <summary>企业基地</summary>
    [Serializable]
    [DataObject]
    [Description("企业基地")]
    [BindIndex("Index_CompanySerialnum", false, "CompanySerialnum")]
    [BindIndex("Index_DepartmentSerialnum", false, "SysDepartmentSerialnum")]
    [BindIndex("IX_Farm_RelationWeatherStationSerialnum", false, "AreaStationSerialnum")]
    [BindIndex("PK__Farm__E3E7488D147CBC3C", true, "Serialnum")]
    [BindRelation("Serialnum", true, "CompanyUser", "FarmSerialnum")]
    [BindRelation("Serialnum", true, "Facility", "FarmSerialnum")]
    [BindRelation("AreaStationSerialnum", false, "AreaStation", "Serialnum")]
    [BindRelation("CompanySerialnum", false, "Company", "Serialnum")]
    [BindRelation("SysDepartmentSerialnum", false, "SysDepartment", "Serialnum")]
    [BindTable("Farm", Description = "企业基地", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class Farm : IFarm
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

        private String _SysDepartmentSerialnum;
        /// <summary>机构</summary>
        [DisplayName("机构")]
        [Description("机构")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "SysDepartmentSerialnum", "机构", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysDepartmentSerialnum
        {
            get { return _SysDepartmentSerialnum; }
            set { if (OnPropertyChanging(__.SysDepartmentSerialnum, value)) { _SysDepartmentSerialnum = value; OnPropertyChanged(__.SysDepartmentSerialnum); } }
        }

        private String _CompanySerialnum;
        /// <summary>企业</summary>
        [DisplayName("企业")]
        [Description("企业")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(8, "CompanySerialnum", "企业", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CompanySerialnum
        {
            get { return _CompanySerialnum; }
            set { if (OnPropertyChanging(__.CompanySerialnum, value)) { _CompanySerialnum = value; OnPropertyChanged(__.CompanySerialnum); } }
        }

        private String _AreaStationSerialnum;
        /// <summary>关联气象站</summary>
        [DisplayName("关联气象站")]
        [Description("关联气象站")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "AreaStationSerialnum", "关联气象站", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AreaStationSerialnum
        {
            get { return _AreaStationSerialnum; }
            set { if (OnPropertyChanging(__.AreaStationSerialnum, value)) { _AreaStationSerialnum = value; OnPropertyChanged(__.AreaStationSerialnum); } }
        }

        private String _UploadPassword;
        /// <summary>上传密码</summary>
        [DisplayName("上传密码")]
        [Description("上传密码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "UploadPassword", "上传密码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UploadPassword
        {
            get { return _UploadPassword; }
            set { if (OnPropertyChanging(__.UploadPassword, value)) { _UploadPassword = value; OnPropertyChanged(__.UploadPassword); } }
        }

        private String _APIKey;
        /// <summary>数据接口访问KEY</summary>
        [DisplayName("数据接口访问KEY")]
        [Description("数据接口访问KEY")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(11, "APIKey", "数据接口访问KEY", null, "nvarchar(500)", 0, 0, true)]
        public virtual String APIKey
        {
            get { return _APIKey; }
            set { if (OnPropertyChanging(__.APIKey, value)) { _APIKey = value; OnPropertyChanged(__.APIKey); } }
        }

        private String _Address;
        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(12, "Address", "地址", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Address
        {
            get { return _Address; }
            set { if (OnPropertyChanging(__.Address, value)) { _Address = value; OnPropertyChanged(__.Address); } }
        }

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(13, "Location", "位置", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Location
        {
            get { return _Location; }
            set { if (OnPropertyChanging(__.Location, value)) { _Location = value; OnPropertyChanged(__.Location); } }
        }

        private String _Lotitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "Lotitude", "经度", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Lotitude
        {
            get { return _Lotitude; }
            set { if (OnPropertyChanging(__.Lotitude, value)) { _Lotitude = value; OnPropertyChanged(__.Lotitude); } }
        }

        private String _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "Latitude", "纬度", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Latitude
        {
            get { return _Latitude; }
            set { if (OnPropertyChanging(__.Latitude, value)) { _Latitude = value; OnPropertyChanged(__.Latitude); } }
        }

        private String _Introduce;
        /// <summary>基地介绍</summary>
        [DisplayName("基地介绍")]
        [Description("基地介绍")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(16, "Introduce", "基地介绍", null, "ntext", 0, 0, true)]
        public virtual String Introduce
        {
            get { return _Introduce; }
            set { if (OnPropertyChanging(__.Introduce, value)) { _Introduce = value; OnPropertyChanged(__.Introduce); } }
        }

        private String _PhotoUrl;
        /// <summary>形象图片</summary>
        [DisplayName("形象图片")]
        [Description("形象图片")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(17, "PhotoUrl", "形象图片", null, "nvarchar(500)", 0, 0, true)]
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
        [BindColumn(18, "ContactMan", "联系人", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(19, "ContactPhone", "联系电话", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ContactPhone
        {
            get { return _ContactPhone; }
            set { if (OnPropertyChanging(__.ContactPhone, value)) { _ContactPhone = value; OnPropertyChanged(__.ContactPhone); } }
        }

        private Boolean _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(20, "Status", "状态", null, "bit", 0, 0, false)]
        public virtual Boolean Status
        {
            get { return _Status; }
            set { if (OnPropertyChanging(__.Status, value)) { _Status = value; OnPropertyChanged(__.Status); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(21, "Sort", "排序", null, "int", 10, 0, false)]
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
        [BindColumn(22, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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
                    case __.SysDepartmentSerialnum : return _SysDepartmentSerialnum;
                    case __.CompanySerialnum : return _CompanySerialnum;
                    case __.AreaStationSerialnum : return _AreaStationSerialnum;
                    case __.UploadPassword : return _UploadPassword;
                    case __.APIKey : return _APIKey;
                    case __.Address : return _Address;
                    case __.Location : return _Location;
                    case __.Lotitude : return _Lotitude;
                    case __.Latitude : return _Latitude;
                    case __.Introduce : return _Introduce;
                    case __.PhotoUrl : return _PhotoUrl;
                    case __.ContactMan : return _ContactMan;
                    case __.ContactPhone : return _ContactPhone;
                    case __.Status : return _Status;
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
                    case __.SysDepartmentSerialnum : _SysDepartmentSerialnum = Convert.ToString(value); break;
                    case __.CompanySerialnum : _CompanySerialnum = Convert.ToString(value); break;
                    case __.AreaStationSerialnum : _AreaStationSerialnum = Convert.ToString(value); break;
                    case __.UploadPassword : _UploadPassword = Convert.ToString(value); break;
                    case __.APIKey : _APIKey = Convert.ToString(value); break;
                    case __.Address : _Address = Convert.ToString(value); break;
                    case __.Location : _Location = Convert.ToString(value); break;
                    case __.Lotitude : _Lotitude = Convert.ToString(value); break;
                    case __.Latitude : _Latitude = Convert.ToString(value); break;
                    case __.Introduce : _Introduce = Convert.ToString(value); break;
                    case __.PhotoUrl : _PhotoUrl = Convert.ToString(value); break;
                    case __.ContactMan : _ContactMan = Convert.ToString(value); break;
                    case __.ContactPhone : _ContactPhone = Convert.ToString(value); break;
                    case __.Status : _Status = Convert.ToBoolean(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得企业基地字段信息的快捷方式</summary>
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

            ///<summary>机构</summary>
            public static readonly Field SysDepartmentSerialnum = FindByName(__.SysDepartmentSerialnum);

            ///<summary>企业</summary>
            public static readonly Field CompanySerialnum = FindByName(__.CompanySerialnum);

            ///<summary>关联气象站</summary>
            public static readonly Field AreaStationSerialnum = FindByName(__.AreaStationSerialnum);

            ///<summary>上传密码</summary>
            public static readonly Field UploadPassword = FindByName(__.UploadPassword);

            ///<summary>数据接口访问KEY</summary>
            public static readonly Field APIKey = FindByName(__.APIKey);

            ///<summary>地址</summary>
            public static readonly Field Address = FindByName(__.Address);

            ///<summary>位置</summary>
            public static readonly Field Location = FindByName(__.Location);

            ///<summary>经度</summary>
            public static readonly Field Lotitude = FindByName(__.Lotitude);

            ///<summary>纬度</summary>
            public static readonly Field Latitude = FindByName(__.Latitude);

            ///<summary>基地介绍</summary>
            public static readonly Field Introduce = FindByName(__.Introduce);

            ///<summary>形象图片</summary>
            public static readonly Field PhotoUrl = FindByName(__.PhotoUrl);

            ///<summary>联系人</summary>
            public static readonly Field ContactMan = FindByName(__.ContactMan);

            ///<summary>联系电话</summary>
            public static readonly Field ContactPhone = FindByName(__.ContactPhone);

            ///<summary>状态</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得企业基地字段名称的快捷方式</summary>
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

            ///<summary>机构</summary>
            public const String SysDepartmentSerialnum = "SysDepartmentSerialnum";

            ///<summary>企业</summary>
            public const String CompanySerialnum = "CompanySerialnum";

            ///<summary>关联气象站</summary>
            public const String AreaStationSerialnum = "AreaStationSerialnum";

            ///<summary>上传密码</summary>
            public const String UploadPassword = "UploadPassword";

            ///<summary>数据接口访问KEY</summary>
            public const String APIKey = "APIKey";

            ///<summary>地址</summary>
            public const String Address = "Address";

            ///<summary>位置</summary>
            public const String Location = "Location";

            ///<summary>经度</summary>
            public const String Lotitude = "Lotitude";

            ///<summary>纬度</summary>
            public const String Latitude = "Latitude";

            ///<summary>基地介绍</summary>
            public const String Introduce = "Introduce";

            ///<summary>形象图片</summary>
            public const String PhotoUrl = "PhotoUrl";

            ///<summary>联系人</summary>
            public const String ContactMan = "ContactMan";

            ///<summary>联系电话</summary>
            public const String ContactPhone = "ContactPhone";

            ///<summary>状态</summary>
            public const String Status = "Status";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>企业基地接口</summary>
    public partial interface IFarm
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

        /// <summary>机构</summary>
        String SysDepartmentSerialnum { get; set; }

        /// <summary>企业</summary>
        String CompanySerialnum { get; set; }

        /// <summary>关联气象站</summary>
        String AreaStationSerialnum { get; set; }

        /// <summary>上传密码</summary>
        String UploadPassword { get; set; }

        /// <summary>数据接口访问KEY</summary>
        String APIKey { get; set; }

        /// <summary>地址</summary>
        String Address { get; set; }

        /// <summary>位置</summary>
        String Location { get; set; }

        /// <summary>经度</summary>
        String Lotitude { get; set; }

        /// <summary>纬度</summary>
        String Latitude { get; set; }

        /// <summary>基地介绍</summary>
        String Introduce { get; set; }

        /// <summary>形象图片</summary>
        String PhotoUrl { get; set; }

        /// <summary>联系人</summary>
        String ContactMan { get; set; }

        /// <summary>联系电话</summary>
        String ContactPhone { get; set; }

        /// <summary>状态</summary>
        Boolean Status { get; set; }

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