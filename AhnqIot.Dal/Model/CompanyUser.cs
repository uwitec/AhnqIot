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
    /// <summary>企业用户</summary>
    [Serializable]
    [DataObject]
    [Description("企业用户")]
    [BindIndex("PK_CompanyUser", true, "Serialnum")]
    [BindIndex("IX_CompanyUser_CompanySerialnum", false, "CompanySerialnum")]
    [BindIndex("IX_CompanyUser_FacilitySerialnum", false, "FacilitySerialnum")]
    [BindIndex("IX_CompanyUser_FarmSerialnum", false, "FarmSerialnum")]
    [BindIndex("IX_CompanyUser_SysUserSerialnum", false, "SysUserSerialnum")]
    [BindRelation("CompanySerialnum", false, "Company", "Serialnum")]
    [BindRelation("FacilitySerialnum", false, "Facility", "Serialnum")]
    [BindRelation("FarmSerialnum", false, "Farm", "Serialnum")]
    [BindRelation("SysUserSerialnum", false, "SysUser", "Serialnum")]
    [BindTable("CompanyUser", Description = "企业用户", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class CompanyUser : ICompanyUser
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

        private String _SysUserSerialnum;
        /// <summary>用户编码</summary>
        [DisplayName("用户编码")]
        [Description("用户编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "SysUserSerialnum", "用户编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysUserSerialnum
        {
            get { return _SysUserSerialnum; }
            set { if (OnPropertyChanging(__.SysUserSerialnum, value)) { _SysUserSerialnum = value; OnPropertyChanged(__.SysUserSerialnum); } }
        }

        private String _CompanySerialnum;
        /// <summary>企业编码</summary>
        [DisplayName("企业编码")]
        [Description("企业编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "CompanySerialnum", "企业编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CompanySerialnum
        {
            get { return _CompanySerialnum; }
            set { if (OnPropertyChanging(__.CompanySerialnum, value)) { _CompanySerialnum = value; OnPropertyChanged(__.CompanySerialnum); } }
        }

        private String _FarmSerialnum;
        /// <summary>基地编码</summary>
        [DisplayName("基地编码")]
        [Description("基地编码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "FarmSerialnum", "基地编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FarmSerialnum
        {
            get { return _FarmSerialnum; }
            set { if (OnPropertyChanging(__.FarmSerialnum, value)) { _FarmSerialnum = value; OnPropertyChanged(__.FarmSerialnum); } }
        }

        private String _FacilitySerialnum;
        /// <summary>设施编码</summary>
        [DisplayName("设施编码")]
        [Description("设施编码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "FacilitySerialnum", "设施编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FacilitySerialnum
        {
            get { return _FacilitySerialnum; }
            set { if (OnPropertyChanging(__.FacilitySerialnum, value)) { _FacilitySerialnum = value; OnPropertyChanged(__.FacilitySerialnum); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(10, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "Remark", "备注", null, "nvarchar(50)", 0, 0, true)]
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
                    case __.SysUserSerialnum : return _SysUserSerialnum;
                    case __.CompanySerialnum : return _CompanySerialnum;
                    case __.FarmSerialnum : return _FarmSerialnum;
                    case __.FacilitySerialnum : return _FacilitySerialnum;
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
                    case __.SysUserSerialnum : _SysUserSerialnum = Convert.ToString(value); break;
                    case __.CompanySerialnum : _CompanySerialnum = Convert.ToString(value); break;
                    case __.FarmSerialnum : _FarmSerialnum = Convert.ToString(value); break;
                    case __.FacilitySerialnum : _FacilitySerialnum = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得企业用户字段信息的快捷方式</summary>
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

            ///<summary>用户编码</summary>
            public static readonly Field SysUserSerialnum = FindByName(__.SysUserSerialnum);

            ///<summary>企业编码</summary>
            public static readonly Field CompanySerialnum = FindByName(__.CompanySerialnum);

            ///<summary>基地编码</summary>
            public static readonly Field FarmSerialnum = FindByName(__.FarmSerialnum);

            ///<summary>设施编码</summary>
            public static readonly Field FacilitySerialnum = FindByName(__.FacilitySerialnum);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得企业用户字段名称的快捷方式</summary>
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

            ///<summary>用户编码</summary>
            public const String SysUserSerialnum = "SysUserSerialnum";

            ///<summary>企业编码</summary>
            public const String CompanySerialnum = "CompanySerialnum";

            ///<summary>基地编码</summary>
            public const String FarmSerialnum = "FarmSerialnum";

            ///<summary>设施编码</summary>
            public const String FacilitySerialnum = "FacilitySerialnum";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>企业用户接口</summary>
    public partial interface ICompanyUser
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

        /// <summary>用户编码</summary>
        String SysUserSerialnum { get; set; }

        /// <summary>企业编码</summary>
        String CompanySerialnum { get; set; }

        /// <summary>基地编码</summary>
        String FarmSerialnum { get; set; }

        /// <summary>设施编码</summary>
        String FacilitySerialnum { get; set; }

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