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
    /// <summary>导航</summary>
    [Serializable]
    [DataObject]
    [Description("导航")]
    [BindIndex("PK__SysMenu__E3E7488D8D914D10", true, "Serialnum")]
    [BindIndex("IX_SysMenu_SysFunctionSerialnum", false, "SysFunctionSerialnum")]
    [BindRelation("SysFunctionSerialnum", false, "SysFunction", "Serialnum")]
    [BindRelation("Serialnum", true, "SysRoleMenu", "SysMenuSerialnum")]
    [BindTable("SysMenu", Description = "导航", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class SysMenu : ISysMenu
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
        /// <summary>导航名称</summary>
        [DisplayName("导航名称")]
        [Description("导航名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "Name", "导航名称", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private String _ParentSerialnum;
        /// <summary>上级</summary>
        [DisplayName("上级")]
        [Description("上级")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "ParentSerialnum", "上级", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ParentSerialnum
        {
            get { return _ParentSerialnum; }
            set { if (OnPropertyChanging(__.ParentSerialnum, value)) { _ParentSerialnum = value; OnPropertyChanged(__.ParentSerialnum); } }
        }

        private String _SysFunctionSerialnum;
        /// <summary>权限子项。逗号分隔，每个权限子项名值竖线分隔</summary>
        [DisplayName("权限子项")]
        [Description("权限子项。逗号分隔，每个权限子项名值竖线分隔")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "SysFunctionSerialnum", "权限子项。逗号分隔，每个权限子项名值竖线分隔", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysFunctionSerialnum
        {
            get { return _SysFunctionSerialnum; }
            set { if (OnPropertyChanging(__.SysFunctionSerialnum, value)) { _SysFunctionSerialnum = value; OnPropertyChanged(__.SysFunctionSerialnum); } }
        }

        private String _Icon;
        /// <summary>图标</summary>
        [DisplayName("图标")]
        [Description("图标")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(9, "Icon", "图标", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Icon
        {
            get { return _Icon; }
            set { if (OnPropertyChanging(__.Icon, value)) { _Icon = value; OnPropertyChanged(__.Icon); } }
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

        private Boolean _Visiable;
        /// <summary>是否可见</summary>
        [DisplayName("是否可见")]
        [Description("是否可见")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(12, "Visiable", "是否可见", null, "bit", 0, 0, false)]
        public virtual Boolean Visiable
        {
            get { return _Visiable; }
            set { if (OnPropertyChanging(__.Visiable, value)) { _Visiable = value; OnPropertyChanged(__.Visiable); } }
        }

        private Boolean _Necessary;
        /// <summary>必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色</summary>
        [DisplayName("必要的菜单")]
        [Description("必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(13, "Necessary", "必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色", null, "bit", 0, 0, false)]
        public virtual Boolean Necessary
        {
            get { return _Necessary; }
            set { if (OnPropertyChanging(__.Necessary, value)) { _Necessary = value; OnPropertyChanged(__.Necessary); } }
        }

        private String _Description;
        /// <summary>显示名</summary>
        [DisplayName("显示名")]
        [Description("显示名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "Description", "显示名", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging(__.Description, value)) { _Description = value; OnPropertyChanged(__.Description); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(15, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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
                    case __.ParentSerialnum : return _ParentSerialnum;
                    case __.SysFunctionSerialnum : return _SysFunctionSerialnum;
                    case __.Icon : return _Icon;
                    case __.Sort : return _Sort;
                    case __.Status : return _Status;
                    case __.Visiable : return _Visiable;
                    case __.Necessary : return _Necessary;
                    case __.Description : return _Description;
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
                    case __.ParentSerialnum : _ParentSerialnum = Convert.ToString(value); break;
                    case __.SysFunctionSerialnum : _SysFunctionSerialnum = Convert.ToString(value); break;
                    case __.Icon : _Icon = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Status : _Status = Convert.ToInt32(value); break;
                    case __.Visiable : _Visiable = Convert.ToBoolean(value); break;
                    case __.Necessary : _Necessary = Convert.ToBoolean(value); break;
                    case __.Description : _Description = Convert.ToString(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得导航字段信息的快捷方式</summary>
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

            ///<summary>导航名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>上级</summary>
            public static readonly Field ParentSerialnum = FindByName(__.ParentSerialnum);

            ///<summary>权限子项。逗号分隔，每个权限子项名值竖线分隔</summary>
            public static readonly Field SysFunctionSerialnum = FindByName(__.SysFunctionSerialnum);

            ///<summary>图标</summary>
            public static readonly Field Icon = FindByName(__.Icon);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>状态。状态（1：启用，0：禁用，2...）</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>是否可见</summary>
            public static readonly Field Visiable = FindByName(__.Visiable);

            ///<summary>必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色</summary>
            public static readonly Field Necessary = FindByName(__.Necessary);

            ///<summary>显示名</summary>
            public static readonly Field Description = FindByName(__.Description);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得导航字段名称的快捷方式</summary>
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

            ///<summary>导航名称</summary>
            public const String Name = "Name";

            ///<summary>上级</summary>
            public const String ParentSerialnum = "ParentSerialnum";

            ///<summary>权限子项。逗号分隔，每个权限子项名值竖线分隔</summary>
            public const String SysFunctionSerialnum = "SysFunctionSerialnum";

            ///<summary>图标</summary>
            public const String Icon = "Icon";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>状态。状态（1：启用，0：禁用，2...）</summary>
            public const String Status = "Status";

            ///<summary>是否可见</summary>
            public const String Visiable = "Visiable";

            ///<summary>必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色</summary>
            public const String Necessary = "Necessary";

            ///<summary>显示名</summary>
            public const String Description = "Description";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>导航接口</summary>
    public partial interface ISysMenu
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

        /// <summary>导航名称</summary>
        String Name { get; set; }

        /// <summary>上级</summary>
        String ParentSerialnum { get; set; }

        /// <summary>权限子项。逗号分隔，每个权限子项名值竖线分隔</summary>
        String SysFunctionSerialnum { get; set; }

        /// <summary>图标</summary>
        String Icon { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>状态。状态（1：启用，0：禁用，2...）</summary>
        Int32 Status { get; set; }

        /// <summary>是否可见</summary>
        Boolean Visiable { get; set; }

        /// <summary>必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色</summary>
        Boolean Necessary { get; set; }

        /// <summary>显示名</summary>
        String Description { get; set; }

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