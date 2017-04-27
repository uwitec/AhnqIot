using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>设备控制日志</summary>
    [Serializable]
    [DataObject]
    [Description("设备控制日志")]
    [BindIndex("Index_ControlDeviceUnitID", false, "ControlDeviceUnitID")]
    [BindIndex("IX_DeviceControlLog_DeviceControlCommandID", false, "DeviceControlCommandID")]
    [BindIndex("PK__DeviceCo__3214EC27EF53CE14", true, "ID")]
    [BindRelation("ControlDeviceUnitID", false, "ControlDeviceUnit", "ID")]
    [BindRelation("DeviceControlCommandID", false, "DeviceControlCommand", "ID")]
    [BindTable("DeviceControlLog", Description = "设备控制日志", ConnName = "SmartIot-Scada-data",
        DbType = DatabaseType.SqlServer)]
    public abstract partial class DeviceControlLog<TEntity> : IDeviceControlLog
    {
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
                    case __.ID:
                        return _ID;
                    case __.Code1:
                        return _Code1;
                    case __.Code2:
                        return _Code2;
                    case __.Code3:
                        return _Code3;
                    case __.ControlDeviceUnitID:
                        return _ControlDeviceUnitID;
                    case __.DeviceControlCommandID:
                        return _DeviceControlCommandID;
                    case __.DeviceValue:
                        return _DeviceValue;
                    case __.ShowValue:
                        return _ShowValue;
                    case __.ControlResult:
                        return _ControlResult;
                    case __.FailReason:
                        return _FailReason;
                    case __.CreateTime:
                        return _CreateTime;
                    case __.Remark:
                        return _Remark;
                    default:
                        return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID:
                        _ID = Convert.ToInt32(value);
                        break;
                    case __.Code1:
                        _Code1 = Convert.ToString(value);
                        break;
                    case __.Code2:
                        _Code2 = Convert.ToString(value);
                        break;
                    case __.Code3:
                        _Code3 = Convert.ToString(value);
                        break;
                    case __.ControlDeviceUnitID:
                        _ControlDeviceUnitID = Convert.ToInt32(value);
                        break;
                    case __.DeviceControlCommandID:
                        _DeviceControlCommandID = Convert.ToInt32(value);
                        break;
                    case __.DeviceValue:
                        _DeviceValue = Convert.ToInt32(value);
                        break;
                    case __.ShowValue:
                        _ShowValue = Convert.ToString(value);
                        break;
                    case __.ControlResult:
                        _ControlResult = Convert.ToBoolean(value);
                        break;
                    case __.FailReason:
                        _FailReason = Convert.ToString(value);
                        break;
                    case __.CreateTime:
                        _CreateTime = Convert.ToDateTime(value);
                        break;
                    case __.Remark:
                        _Remark = Convert.ToString(value);
                        break;
                    default:
                        base[name] = value;
                        break;
                }
            }
        }

        #endregion 获取/设置 字段值

        #region 属性

        private Int32 _ID;

        /// <summary>ID</summary>
        [DisplayName("ID")]
        [Description("ID")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "ID", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set
            {
                if (OnPropertyChanging(__.ID, value))
                {
                    _ID = value;
                    OnPropertyChanged(__.ID);
                }
            }
        }

        private String _Code1;

        /// <summary>编码1</summary>
        [DisplayName("编码1")]
        [Description("编码1")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "Code1", "编码1", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code1
        {
            get { return _Code1; }
            set
            {
                if (OnPropertyChanging(__.Code1, value))
                {
                    _Code1 = value;
                    OnPropertyChanged(__.Code1);
                }
            }
        }

        private String _Code2;

        /// <summary>编码2</summary>
        [DisplayName("编码2")]
        [Description("编码2")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "Code2", "编码2", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code2
        {
            get { return _Code2; }
            set
            {
                if (OnPropertyChanging(__.Code2, value))
                {
                    _Code2 = value;
                    OnPropertyChanged(__.Code2);
                }
            }
        }

        private String _Code3;

        /// <summary>编码3</summary>
        [DisplayName("编码3")]
        [Description("编码3")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Code3", "编码3", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code3
        {
            get { return _Code3; }
            set
            {
                if (OnPropertyChanging(__.Code3, value))
                {
                    _Code3 = value;
                    OnPropertyChanged(__.Code3);
                }
            }
        }

        private Int32 _ControlDeviceUnitID;

        /// <summary>控制设备</summary>
        [DisplayName("控制设备")]
        [Description("控制设备")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "ControlDeviceUnitID", "控制设备", null, "int", 10, 0, false)]
        public virtual Int32 ControlDeviceUnitID
        {
            get { return _ControlDeviceUnitID; }
            set
            {
                if (OnPropertyChanging(__.ControlDeviceUnitID, value))
                {
                    _ControlDeviceUnitID = value;
                    OnPropertyChanged(__.ControlDeviceUnitID);
                }
            }
        }

        private Int32 _DeviceControlCommandID;

        /// <summary>控制指令</summary>
        [DisplayName("控制指令")]
        [Description("控制指令")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "DeviceControlCommandID", "控制指令", null, "int", 10, 0, false)]
        public virtual Int32 DeviceControlCommandID
        {
            get { return _DeviceControlCommandID; }
            set
            {
                if (OnPropertyChanging(__.DeviceControlCommandID, value))
                {
                    _DeviceControlCommandID = value;
                    OnPropertyChanged(__.DeviceControlCommandID);
                }
            }
        }

        private Int32 _DeviceValue;

        /// <summary>设备值</summary>
        [DisplayName("设备值")]
        [Description("设备值")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "DeviceValue", "设备值", null, "int", 10, 0, false)]
        public virtual Int32 DeviceValue
        {
            get { return _DeviceValue; }
            set
            {
                if (OnPropertyChanging(__.DeviceValue, value))
                {
                    _DeviceValue = value;
                    OnPropertyChanged(__.DeviceValue);
                }
            }
        }

        private String _ShowValue;

        /// <summary>设备状态</summary>
        [DisplayName("设备状态")]
        [Description("设备状态")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(8, "ShowValue", "设备状态", null, "nvarchar(500)", 0, 0, true)]
        public virtual String ShowValue
        {
            get { return _ShowValue; }
            set
            {
                if (OnPropertyChanging(__.ShowValue, value))
                {
                    _ShowValue = value;
                    OnPropertyChanged(__.ShowValue);
                }
            }
        }

        private Boolean _ControlResult;

        /// <summary>控制结果</summary>
        [DisplayName("控制结果")]
        [Description("控制结果")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(9, "ControlResult", "控制结果", null, "bit", 0, 0, false)]
        public virtual Boolean ControlResult
        {
            get { return _ControlResult; }
            set
            {
                if (OnPropertyChanging(__.ControlResult, value))
                {
                    _ControlResult = value;
                    OnPropertyChanged(__.ControlResult);
                }
            }
        }

        private String _FailReason;

        /// <summary>失败原因</summary>
        [DisplayName("失败原因")]
        [Description("失败原因")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(10, "FailReason", "失败原因", null, "nvarchar(500)", 0, 0, true)]
        public virtual String FailReason
        {
            get { return _FailReason; }
            set
            {
                if (OnPropertyChanging(__.FailReason, value))
                {
                    _FailReason = value;
                    OnPropertyChanged(__.FailReason);
                }
            }
        }

        private DateTime _CreateTime;

        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(11, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateTime
        {
            get { return _CreateTime; }
            set
            {
                if (OnPropertyChanging(__.CreateTime, value))
                {
                    _CreateTime = value;
                    OnPropertyChanged(__.CreateTime);
                }
            }
        }

        private String _Remark;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(12, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Remark
        {
            get { return _Remark; }
            set
            {
                if (OnPropertyChanging(__.Remark, value))
                {
                    _Remark = value;
                    OnPropertyChanged(__.Remark);
                }
            }
        }

        #endregion 属性

        #region 字段名

        /// <summary>取得设备控制日志字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>编码1</summary>
            public static readonly Field Code1 = FindByName(__.Code1);

            ///<summary>编码2</summary>
            public static readonly Field Code2 = FindByName(__.Code2);

            ///<summary>编码3</summary>
            public static readonly Field Code3 = FindByName(__.Code3);

            ///<summary>控制设备</summary>
            public static readonly Field ControlDeviceUnitID = FindByName(__.ControlDeviceUnitID);

            ///<summary>控制指令</summary>
            public static readonly Field DeviceControlCommandID = FindByName(__.DeviceControlCommandID);

            ///<summary>设备值</summary>
            public static readonly Field DeviceValue = FindByName(__.DeviceValue);

            ///<summary>设备状态</summary>
            public static readonly Field ShowValue = FindByName(__.ShowValue);

            ///<summary>控制结果</summary>
            public static readonly Field ControlResult = FindByName(__.ControlResult);

            ///<summary>失败原因</summary>
            public static readonly Field FailReason = FindByName(__.FailReason);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得设备控制日志字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>编码1</summary>
            public const String Code1 = "Code1";

            ///<summary>编码2</summary>
            public const String Code2 = "Code2";

            ///<summary>编码3</summary>
            public const String Code3 = "Code3";

            ///<summary>控制设备</summary>
            public const String ControlDeviceUnitID = "ControlDeviceUnitID";

            ///<summary>控制指令</summary>
            public const String DeviceControlCommandID = "DeviceControlCommandID";

            ///<summary>设备值</summary>
            public const String DeviceValue = "DeviceValue";

            ///<summary>设备状态</summary>
            public const String ShowValue = "ShowValue";

            ///<summary>控制结果</summary>
            public const String ControlResult = "ControlResult";

            ///<summary>失败原因</summary>
            public const String FailReason = "FailReason";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>设备控制日志接口</summary>
    public partial interface IDeviceControlLog
    {
        #region 获取/设置 字段值

        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }

        #endregion 获取/设置 字段值

        #region 属性

        /// <summary>ID</summary>
        Int32 ID { get; set; }

        /// <summary>编码1</summary>
        String Code1 { get; set; }

        /// <summary>编码2</summary>
        String Code2 { get; set; }

        /// <summary>编码3</summary>
        String Code3 { get; set; }

        /// <summary>控制设备</summary>
        Int32 ControlDeviceUnitID { get; set; }

        /// <summary>控制指令</summary>
        Int32 DeviceControlCommandID { get; set; }

        /// <summary>设备值</summary>
        Int32 DeviceValue { get; set; }

        /// <summary>设备状态</summary>
        String ShowValue { get; set; }

        /// <summary>控制结果</summary>
        Boolean ControlResult { get; set; }

        /// <summary>失败原因</summary>
        String FailReason { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}