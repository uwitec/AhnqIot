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
    /// <summary>企业</summary>
    [Serializable]
    [DataObject]
    [Description("企业")]
    [BindIndex("IX_Company_SysDepartmentSerialnum", false, "SysDepartmentSerialnum")]
    [BindIndex("PK__Company__E3E7488DC59D731C", true, "Serialnum")]
    [BindRelation("SysDepartmentSerialnum", false, "SysDepartment", "Serialnum")]
    [BindRelation("Serialnum", true, "CompanyPics", "CompanySerialnum")]
    [BindRelation("Serialnum", true, "CompanyUser", "CompanySerialnum")]
    [BindRelation("Serialnum", true, "Farm", "CompanySerialnum")]
    [BindTable("Company", Description = "企业", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class Company : ICompany
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

        private String _Pinyin;
        /// <summary>拼音简写</summary>
        [DisplayName("拼音简写")]
        [Description("拼音简写")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "Pinyin", "拼音简写", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Pinyin
        {
            get { return _Pinyin; }
            set { if (OnPropertyChanging(__.Pinyin, value)) { _Pinyin = value; OnPropertyChanged(__.Pinyin); } }
        }

        private String _SysDepartmentSerialnum;
        /// <summary>机构</summary>
        [DisplayName("机构")]
        [Description("机构")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(8, "SysDepartmentSerialnum", "机构", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysDepartmentSerialnum
        {
            get { return _SysDepartmentSerialnum; }
            set { if (OnPropertyChanging(__.SysDepartmentSerialnum, value)) { _SysDepartmentSerialnum = value; OnPropertyChanged(__.SysDepartmentSerialnum); } }
        }

        private String _Addr;
        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(9, "Addr", "地址", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Addr
        {
            get { return _Addr; }
            set { if (OnPropertyChanging(__.Addr, value)) { _Addr = value; OnPropertyChanged(__.Addr); } }
        }

        private String _Lontitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "Lontitude", "经度", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Lontitude
        {
            get { return _Lontitude; }
            set { if (OnPropertyChanging(__.Lontitude, value)) { _Lontitude = value; OnPropertyChanged(__.Lontitude); } }
        }

        private String _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "Latitude", "纬度", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Latitude
        {
            get { return _Latitude; }
            set { if (OnPropertyChanging(__.Latitude, value)) { _Latitude = value; OnPropertyChanged(__.Latitude); } }
        }

        private String _ContactMan;
        /// <summary>联系人</summary>
        [DisplayName("联系人")]
        [Description("联系人")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "ContactMan", "联系人", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(13, "ContactPhone", "联系电话", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ContactPhone
        {
            get { return _ContactPhone; }
            set { if (OnPropertyChanging(__.ContactPhone, value)) { _ContactPhone = value; OnPropertyChanged(__.ContactPhone); } }
        }

        private String _Introduce;
        /// <summary>介绍</summary>
        [DisplayName("介绍")]
        [Description("介绍")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(14, "Introduce", "介绍", null, "ntext", 0, 0, true)]
        public virtual String Introduce
        {
            get { return _Introduce; }
            set { if (OnPropertyChanging(__.Introduce, value)) { _Introduce = value; OnPropertyChanged(__.Introduce); } }
        }

        private Int32 _Status;
        /// <summary>状态。状态0：禁用1：正在审核中2：审核通过</summary>
        [DisplayName("状态")]
        [Description("状态。状态0：禁用1：正在审核中2：审核通过")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(15, "Status", "状态。状态0：禁用1：正在审核中2：审核通过", null, "int", 10, 0, false)]
        public virtual Int32 Status
        {
            get { return _Status; }
            set { if (OnPropertyChanging(__.Status, value)) { _Status = value; OnPropertyChanged(__.Status); } }
        }

        private DateTime _ApplyTime;
        /// <summary>审核时间</summary>
        [DisplayName("审核时间")]
        [Description("审核时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(16, "ApplyTime", "审核时间", null, "datetime", 3, 0, false)]
        public virtual DateTime ApplyTime
        {
            get { return _ApplyTime; }
            set { if (OnPropertyChanging(__.ApplyTime, value)) { _ApplyTime = value; OnPropertyChanged(__.ApplyTime); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(17, "Sort", "排序", null, "int", 10, 0, false)]
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
        [BindColumn(18, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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
                    case __.Pinyin : return _Pinyin;
                    case __.SysDepartmentSerialnum : return _SysDepartmentSerialnum;
                    case __.Addr : return _Addr;
                    case __.Lontitude : return _Lontitude;
                    case __.Latitude : return _Latitude;
                    case __.ContactMan : return _ContactMan;
                    case __.ContactPhone : return _ContactPhone;
                    case __.Introduce : return _Introduce;
                    case __.Status : return _Status;
                    case __.ApplyTime : return _ApplyTime;
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
                    case __.Pinyin : _Pinyin = Convert.ToString(value); break;
                    case __.SysDepartmentSerialnum : _SysDepartmentSerialnum = Convert.ToString(value); break;
                    case __.Addr : _Addr = Convert.ToString(value); break;
                    case __.Lontitude : _Lontitude = Convert.ToString(value); break;
                    case __.Latitude : _Latitude = Convert.ToString(value); break;
                    case __.ContactMan : _ContactMan = Convert.ToString(value); break;
                    case __.ContactPhone : _ContactPhone = Convert.ToString(value); break;
                    case __.Introduce : _Introduce = Convert.ToString(value); break;
                    case __.Status : _Status = Convert.ToInt32(value); break;
                    case __.ApplyTime : _ApplyTime = Convert.ToDateTime(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得企业字段信息的快捷方式</summary>
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

            ///<summary>拼音简写</summary>
            public static readonly Field Pinyin = FindByName(__.Pinyin);

            ///<summary>机构</summary>
            public static readonly Field SysDepartmentSerialnum = FindByName(__.SysDepartmentSerialnum);

            ///<summary>地址</summary>
            public static readonly Field Addr = FindByName(__.Addr);

            ///<summary>经度</summary>
            public static readonly Field Lontitude = FindByName(__.Lontitude);

            ///<summary>纬度</summary>
            public static readonly Field Latitude = FindByName(__.Latitude);

            ///<summary>联系人</summary>
            public static readonly Field ContactMan = FindByName(__.ContactMan);

            ///<summary>联系电话</summary>
            public static readonly Field ContactPhone = FindByName(__.ContactPhone);

            ///<summary>介绍</summary>
            public static readonly Field Introduce = FindByName(__.Introduce);

            ///<summary>状态。状态0：禁用1：正在审核中2：审核通过</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>审核时间</summary>
            public static readonly Field ApplyTime = FindByName(__.ApplyTime);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得企业字段名称的快捷方式</summary>
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

            ///<summary>拼音简写</summary>
            public const String Pinyin = "Pinyin";

            ///<summary>机构</summary>
            public const String SysDepartmentSerialnum = "SysDepartmentSerialnum";

            ///<summary>地址</summary>
            public const String Addr = "Addr";

            ///<summary>经度</summary>
            public const String Lontitude = "Lontitude";

            ///<summary>纬度</summary>
            public const String Latitude = "Latitude";

            ///<summary>联系人</summary>
            public const String ContactMan = "ContactMan";

            ///<summary>联系电话</summary>
            public const String ContactPhone = "ContactPhone";

            ///<summary>介绍</summary>
            public const String Introduce = "Introduce";

            ///<summary>状态。状态0：禁用1：正在审核中2：审核通过</summary>
            public const String Status = "Status";

            ///<summary>审核时间</summary>
            public const String ApplyTime = "ApplyTime";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>企业接口</summary>
    public partial interface ICompany
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

        /// <summary>拼音简写</summary>
        String Pinyin { get; set; }

        /// <summary>机构</summary>
        String SysDepartmentSerialnum { get; set; }

        /// <summary>地址</summary>
        String Addr { get; set; }

        /// <summary>经度</summary>
        String Lontitude { get; set; }

        /// <summary>纬度</summary>
        String Latitude { get; set; }

        /// <summary>联系人</summary>
        String ContactMan { get; set; }

        /// <summary>联系电话</summary>
        String ContactPhone { get; set; }

        /// <summary>介绍</summary>
        String Introduce { get; set; }

        /// <summary>状态。状态0：禁用1：正在审核中2：审核通过</summary>
        Int32 Status { get; set; }

        /// <summary>审核时间</summary>
        DateTime ApplyTime { get; set; }

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