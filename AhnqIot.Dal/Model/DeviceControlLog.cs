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
    /// <summary>企业设备控制日志</summary>
    [Serializable]
    [DataObject]
    [Description("企业设备控制日志")]
    [BindIndex("Index_设备编码", false, "DeviceSerialnum")]
    [BindIndex("IX_DeviceControlLog_DeviceShowValue", false, "DeviceShowValue")]
    [BindIndex("PK__DeviceCo__E3E7488DA0F171A6", true, "Serialnum")]
    [BindRelation("DeviceSerialnum", false, "Device", "Serialnum")]
    [BindRelation("DeviceShowValue", false, "Device", "ShowValue")]
    [BindTable("DeviceControlLog", Description = "企业设备控制日志", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class DeviceControlLog : IDeviceControlLog
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

        private String _DeviceSerialnum;
        /// <summary>设备编码</summary>
        [DisplayName("设备编码")]
        [Description("设备编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "DeviceSerialnum", "设备编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DeviceSerialnum
        {
            get { return _DeviceSerialnum; }
            set { if (OnPropertyChanging(__.DeviceSerialnum, value)) { _DeviceSerialnum = value; OnPropertyChanged(__.DeviceSerialnum); } }
        }

        private String _CommandSerialnum;
        /// <summary>指令编码</summary>
        [DisplayName("指令编码")]
        [Description("指令编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "CommandSerialnum", "指令编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CommandSerialnum
        {
            get { return _CommandSerialnum; }
            set { if (OnPropertyChanging(__.CommandSerialnum, value)) { _CommandSerialnum = value; OnPropertyChanged(__.CommandSerialnum); } }
        }

        private Decimal _DeviceValue;
        /// <summary>设备值</summary>
        [DisplayName("设备值")]
        [Description("设备值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(8, "DeviceValue", "设备值", null, "decimal", 18, 1, false)]
        public virtual Decimal DeviceValue
        {
            get { return _DeviceValue; }
            set { if (OnPropertyChanging(__.DeviceValue, value)) { _DeviceValue = value; OnPropertyChanged(__.DeviceValue); } }
        }

        private String _DeviceShowValue;
        /// <summary>设备显示值</summary>
        [DisplayName("设备显示值")]
        [Description("设备显示值")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(9, "DeviceShowValue", "设备显示值", null, "nvarchar(500)", 0, 0, true)]
        public virtual String DeviceShowValue
        {
            get { return _DeviceShowValue; }
            set { if (OnPropertyChanging(__.DeviceShowValue, value)) { _DeviceShowValue = value; OnPropertyChanged(__.DeviceShowValue); } }
        }

        private Boolean _ControlResult;
        /// <summary>控制结果</summary>
        [DisplayName("控制结果")]
        [Description("控制结果")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(10, "ControlResult", "控制结果", null, "bit", 0, 0, false)]
        public virtual Boolean ControlResult
        {
            get { return _ControlResult; }
            set { if (OnPropertyChanging(__.ControlResult, value)) { _ControlResult = value; OnPropertyChanged(__.ControlResult); } }
        }

        private String _FailReason;
        /// <summary>失败原因</summary>
        [DisplayName("失败原因")]
        [Description("失败原因")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(11, "FailReason", "失败原因", null, "nvarchar(500)", 0, 0, true)]
        public virtual String FailReason
        {
            get { return _FailReason; }
            set { if (OnPropertyChanging(__.FailReason, value)) { _FailReason = value; OnPropertyChanged(__.FailReason); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(12, "Sort", "排序", null, "int", 10, 0, false)]
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
        [BindColumn(13, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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
                    case __.DeviceSerialnum : return _DeviceSerialnum;
                    case __.CommandSerialnum : return _CommandSerialnum;
                    case __.DeviceValue : return _DeviceValue;
                    case __.DeviceShowValue : return _DeviceShowValue;
                    case __.ControlResult : return _ControlResult;
                    case __.FailReason : return _FailReason;
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
                    case __.DeviceSerialnum : _DeviceSerialnum = Convert.ToString(value); break;
                    case __.CommandSerialnum : _CommandSerialnum = Convert.ToString(value); break;
                    case __.DeviceValue : _DeviceValue = Convert.ToDecimal(value); break;
                    case __.DeviceShowValue : _DeviceShowValue = Convert.ToString(value); break;
                    case __.ControlResult : _ControlResult = Convert.ToBoolean(value); break;
                    case __.FailReason : _FailReason = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得企业设备控制日志字段信息的快捷方式</summary>
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

            ///<summary>设备编码</summary>
            public static readonly Field DeviceSerialnum = FindByName(__.DeviceSerialnum);

            ///<summary>指令编码</summary>
            public static readonly Field CommandSerialnum = FindByName(__.CommandSerialnum);

            ///<summary>设备值</summary>
            public static readonly Field DeviceValue = FindByName(__.DeviceValue);

            ///<summary>设备显示值</summary>
            public static readonly Field DeviceShowValue = FindByName(__.DeviceShowValue);

            ///<summary>控制结果</summary>
            public static readonly Field ControlResult = FindByName(__.ControlResult);

            ///<summary>失败原因</summary>
            public static readonly Field FailReason = FindByName(__.FailReason);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得企业设备控制日志字段名称的快捷方式</summary>
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

            ///<summary>设备编码</summary>
            public const String DeviceSerialnum = "DeviceSerialnum";

            ///<summary>指令编码</summary>
            public const String CommandSerialnum = "CommandSerialnum";

            ///<summary>设备值</summary>
            public const String DeviceValue = "DeviceValue";

            ///<summary>设备显示值</summary>
            public const String DeviceShowValue = "DeviceShowValue";

            ///<summary>控制结果</summary>
            public const String ControlResult = "ControlResult";

            ///<summary>失败原因</summary>
            public const String FailReason = "FailReason";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>企业设备控制日志接口</summary>
    public partial interface IDeviceControlLog
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

        /// <summary>设备编码</summary>
        String DeviceSerialnum { get; set; }

        /// <summary>指令编码</summary>
        String CommandSerialnum { get; set; }

        /// <summary>设备值</summary>
        Decimal DeviceValue { get; set; }

        /// <summary>设备显示值</summary>
        String DeviceShowValue { get; set; }

        /// <summary>控制结果</summary>
        Boolean ControlResult { get; set; }

        /// <summary>失败原因</summary>
        String FailReason { get; set; }

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