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
    /// <summary>用户</summary>
    [Serializable]
    [DataObject]
    [Description("用户")]
    [BindIndex("PK__SysUser__E3E7488D18D9B3AD", true, "Serialnum")]
    [BindIndex("IX_SysUser_SysDepartmentSerialnum", false, "SysDepartmentSerialnum")]
    [BindIndex("IX_SysUser_SysRoleSerialnum", false, "SysRoleSerialnum")]
    [BindRelation("Serialnum", true, "CompanyUser", "SysUserSerialnum")]
    [BindRelation("SysDepartmentSerialnum", false, "SysDepartment", "Serialnum")]
    [BindRelation("SysRoleSerialnum", false, "SysRole", "Serialnum")]
    [BindTable("SysUser", Description = "用户", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class SysUser : ISysUser
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

        private String _LoginName;
        /// <summary>登录名</summary>
        [DisplayName("登录名")]
        [Description("登录名")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "LoginName", "登录名", null, "nvarchar(50)", 0, 0, true)]
        public virtual String LoginName
        {
            get { return _LoginName; }
            set { if (OnPropertyChanging(__.LoginName, value)) { _LoginName = value; OnPropertyChanged(__.LoginName); } }
        }

        private String _UserName;
        /// <summary>姓名</summary>
        [DisplayName("姓名")]
        [Description("姓名")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "UserName", "姓名", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserName
        {
            get { return _UserName; }
            set { if (OnPropertyChanging(__.UserName, value)) { _UserName = value; OnPropertyChanged(__.UserName); } }
        }

        private String _Email;
        /// <summary>邮箱</summary>
        [DisplayName("邮箱")]
        [Description("邮箱")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(8, "Email", "邮箱", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Email
        {
            get { return _Email; }
            set { if (OnPropertyChanging(__.Email, value)) { _Email = value; OnPropertyChanged(__.Email); } }
        }

        private String _QQ;
        /// <summary>QQ</summary>
        [DisplayName("QQ")]
        [Description("QQ")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(9, "QQ", "QQ", null, "nvarchar(50)", 0, 0, true)]
        public virtual String QQ
        {
            get { return _QQ; }
            set { if (OnPropertyChanging(__.QQ, value)) { _QQ = value; OnPropertyChanged(__.QQ); } }
        }

        private String _Password;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(10, "Password", "密码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Password
        {
            get { return _Password; }
            set { if (OnPropertyChanging(__.Password, value)) { _Password = value; OnPropertyChanged(__.Password); } }
        }

        private Int32 _Status;
        /// <summary>状态。状态（1：启用，0：禁用，2...）</summary>
        [DisplayName("状态")]
        [Description("状态。状态（1：启用，0：禁用，2...）")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "Status", "状态。状态（1：启用，0：禁用，2...）", null, "int", 10, 0, false)]
        public virtual Int32 Status
        {
            get { return _Status; }
            set { if (OnPropertyChanging(__.Status, value)) { _Status = value; OnPropertyChanged(__.Status); } }
        }

        private String _LastIP;
        /// <summary>最后登录IP</summary>
        [DisplayName("最后登录IP")]
        [Description("最后登录IP")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "LastIP", "最后登录IP", null, "nvarchar(50)", 0, 0, true)]
        public virtual String LastIP
        {
            get { return _LastIP; }
            set { if (OnPropertyChanging(__.LastIP, value)) { _LastIP = value; OnPropertyChanged(__.LastIP); } }
        }

        private DateTime _LastTime;
        /// <summary>最后登录时间</summary>
        [DisplayName("最后登录时间")]
        [Description("最后登录时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "LastTime", "最后登录时间", null, "datetime", 3, 0, false)]
        public virtual DateTime LastTime
        {
            get { return _LastTime; }
            set { if (OnPropertyChanging(__.LastTime, value)) { _LastTime = value; OnPropertyChanged(__.LastTime); } }
        }

        private String _LastUrl;
        /// <summary>上次URL</summary>
        [DisplayName("上次URL")]
        [Description("上次URL")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(14, "LastUrl", "上次URL", null, "nvarchar(500)", 0, 0, true)]
        public virtual String LastUrl
        {
            get { return _LastUrl; }
            set { if (OnPropertyChanging(__.LastUrl, value)) { _LastUrl = value; OnPropertyChanged(__.LastUrl); } }
        }

        private String _SysRoleSerialnum;
        /// <summary>角色</summary>
        [DisplayName("角色")]
        [Description("角色")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(15, "SysRoleSerialnum", "角色", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysRoleSerialnum
        {
            get { return _SysRoleSerialnum; }
            set { if (OnPropertyChanging(__.SysRoleSerialnum, value)) { _SysRoleSerialnum = value; OnPropertyChanged(__.SysRoleSerialnum); } }
        }

        private String _SysDepartmentSerialnum;
        /// <summary>所属机构</summary>
        [DisplayName("所属机构")]
        [Description("所属机构")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(16, "SysDepartmentSerialnum", "所属机构", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysDepartmentSerialnum
        {
            get { return _SysDepartmentSerialnum; }
            set { if (OnPropertyChanging(__.SysDepartmentSerialnum, value)) { _SysDepartmentSerialnum = value; OnPropertyChanged(__.SysDepartmentSerialnum); } }
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
                    case __.LoginName : return _LoginName;
                    case __.UserName : return _UserName;
                    case __.Email : return _Email;
                    case __.QQ : return _QQ;
                    case __.Password : return _Password;
                    case __.Status : return _Status;
                    case __.LastIP : return _LastIP;
                    case __.LastTime : return _LastTime;
                    case __.LastUrl : return _LastUrl;
                    case __.SysRoleSerialnum : return _SysRoleSerialnum;
                    case __.SysDepartmentSerialnum : return _SysDepartmentSerialnum;
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
                    case __.LoginName : _LoginName = Convert.ToString(value); break;
                    case __.UserName : _UserName = Convert.ToString(value); break;
                    case __.Email : _Email = Convert.ToString(value); break;
                    case __.QQ : _QQ = Convert.ToString(value); break;
                    case __.Password : _Password = Convert.ToString(value); break;
                    case __.Status : _Status = Convert.ToInt32(value); break;
                    case __.LastIP : _LastIP = Convert.ToString(value); break;
                    case __.LastTime : _LastTime = Convert.ToDateTime(value); break;
                    case __.LastUrl : _LastUrl = Convert.ToString(value); break;
                    case __.SysRoleSerialnum : _SysRoleSerialnum = Convert.ToString(value); break;
                    case __.SysDepartmentSerialnum : _SysDepartmentSerialnum = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得用户字段信息的快捷方式</summary>
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

            ///<summary>登录名</summary>
            public static readonly Field LoginName = FindByName(__.LoginName);

            ///<summary>姓名</summary>
            public static readonly Field UserName = FindByName(__.UserName);

            ///<summary>邮箱</summary>
            public static readonly Field Email = FindByName(__.Email);

            ///<summary>QQ</summary>
            public static readonly Field QQ = FindByName(__.QQ);

            ///<summary>密码</summary>
            public static readonly Field Password = FindByName(__.Password);

            ///<summary>状态。状态（1：启用，0：禁用，2...）</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>最后登录IP</summary>
            public static readonly Field LastIP = FindByName(__.LastIP);

            ///<summary>最后登录时间</summary>
            public static readonly Field LastTime = FindByName(__.LastTime);

            ///<summary>上次URL</summary>
            public static readonly Field LastUrl = FindByName(__.LastUrl);

            ///<summary>角色</summary>
            public static readonly Field SysRoleSerialnum = FindByName(__.SysRoleSerialnum);

            ///<summary>所属机构</summary>
            public static readonly Field SysDepartmentSerialnum = FindByName(__.SysDepartmentSerialnum);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得用户字段名称的快捷方式</summary>
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

            ///<summary>登录名</summary>
            public const String LoginName = "LoginName";

            ///<summary>姓名</summary>
            public const String UserName = "UserName";

            ///<summary>邮箱</summary>
            public const String Email = "Email";

            ///<summary>QQ</summary>
            public const String QQ = "QQ";

            ///<summary>密码</summary>
            public const String Password = "Password";

            ///<summary>状态。状态（1：启用，0：禁用，2...）</summary>
            public const String Status = "Status";

            ///<summary>最后登录IP</summary>
            public const String LastIP = "LastIP";

            ///<summary>最后登录时间</summary>
            public const String LastTime = "LastTime";

            ///<summary>上次URL</summary>
            public const String LastUrl = "LastUrl";

            ///<summary>角色</summary>
            public const String SysRoleSerialnum = "SysRoleSerialnum";

            ///<summary>所属机构</summary>
            public const String SysDepartmentSerialnum = "SysDepartmentSerialnum";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>用户接口</summary>
    public partial interface ISysUser
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

        /// <summary>登录名</summary>
        String LoginName { get; set; }

        /// <summary>姓名</summary>
        String UserName { get; set; }

        /// <summary>邮箱</summary>
        String Email { get; set; }

        /// <summary>QQ</summary>
        String QQ { get; set; }

        /// <summary>密码</summary>
        String Password { get; set; }

        /// <summary>状态。状态（1：启用，0：禁用，2...）</summary>
        Int32 Status { get; set; }

        /// <summary>最后登录IP</summary>
        String LastIP { get; set; }

        /// <summary>最后登录时间</summary>
        DateTime LastTime { get; set; }

        /// <summary>上次URL</summary>
        String LastUrl { get; set; }

        /// <summary>角色</summary>
        String SysRoleSerialnum { get; set; }

        /// <summary>所属机构</summary>
        String SysDepartmentSerialnum { get; set; }

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