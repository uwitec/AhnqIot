using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>设备数据异常记录</summary>
    [Serializable]
    [DataObject]
    [Description("设备数据异常记录")]
    [BindIndex("Index_DeviceDataExceptionLogCreateTime", false, "CreateTime")]
    [BindIndex("Index_DeviceDataExceptionLogSensorDeviceUnitID", false, "SensorDeviceUnitID")]
    [BindIndex("PK__DeviceDa__3214EC27B75454CC", true, "ID")]
    [BindRelation("SensorDeviceUnitID", false, "SensorDeviceUnit", "ID")]
    [BindTable("DeviceDataExceptionLog", Description = "设备数据异常记录", ConnName = "SmartIot-Scada-data",
        DbType = DatabaseType.SqlServer)]
    public abstract partial class DeviceDataExceptionLog<TEntity> : IDeviceDataExceptionLog
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
                    case __.SensorDeviceUnitID:
                        return _SensorDeviceUnitID;
                    case __.CreateTime:
                        return _CreateTime;
                    case __.OriginalValue:
                        return _OriginalValue;
                    case __.ProcessedValue:
                        return _ProcessedValue;
                    case __.ShowValue:
                        return _ShowValue;
                    case __.Max:
                        return _Max;
                    case __.Min:
                        return _Min;
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
                    case __.SensorDeviceUnitID:
                        _SensorDeviceUnitID = Convert.ToInt32(value);
                        break;
                    case __.CreateTime:
                        _CreateTime = Convert.ToDateTime(value);
                        break;
                    case __.OriginalValue:
                        _OriginalValue = Convert.ToInt32(value);
                        break;
                    case __.ProcessedValue:
                        _ProcessedValue = Convert.ToDecimal(value);
                        break;
                    case __.ShowValue:
                        _ShowValue = Convert.ToString(value);
                        break;
                    case __.Max:
                        _Max = Convert.ToDecimal(value);
                        break;
                    case __.Min:
                        _Min = Convert.ToDecimal(value);
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

        private Int32 _SensorDeviceUnitID;

        /// <summary>传感器设备</summary>
        [DisplayName("传感器设备")]
        [Description("传感器设备")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "SensorDeviceUnitID", "传感器设备", null, "int", 10, 0, false)]
        public virtual Int32 SensorDeviceUnitID
        {
            get { return _SensorDeviceUnitID; }
            set
            {
                if (OnPropertyChanging(__.SensorDeviceUnitID, value))
                {
                    _SensorDeviceUnitID = value;
                    OnPropertyChanged(__.SensorDeviceUnitID);
                }
            }
        }

        private DateTime _CreateTime;

        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(6, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
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

        private Int32 _OriginalValue;

        /// <summary>原始值</summary>
        [DisplayName("原始值")]
        [Description("原始值")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "OriginalValue", "原始值", null, "int", 10, 0, false)]
        public virtual Int32 OriginalValue
        {
            get { return _OriginalValue; }
            set
            {
                if (OnPropertyChanging(__.OriginalValue, value))
                {
                    _OriginalValue = value;
                    OnPropertyChanged(__.OriginalValue);
                }
            }
        }

        private Decimal _ProcessedValue;

        /// <summary>处理值</summary>
        [DisplayName("处理值")]
        [Description("处理值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(8, "ProcessedValue", "处理值", null, "decimal", 18, 1, false)]
        public virtual Decimal ProcessedValue
        {
            get { return _ProcessedValue; }
            set
            {
                if (OnPropertyChanging(__.ProcessedValue, value))
                {
                    _ProcessedValue = value;
                    OnPropertyChanged(__.ProcessedValue);
                }
            }
        }

        private String _ShowValue;

        /// <summary>显示值</summary>
        [DisplayName("显示值")]
        [Description("显示值")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(9, "ShowValue", "显示值", null, "nvarchar(50)", 0, 0, true)]
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

        private Decimal _Max;

        /// <summary>上限</summary>
        [DisplayName("上限")]
        [Description("上限")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(10, "Max", "上限", null, "decimal", 18, 1, false)]
        public virtual Decimal Max
        {
            get { return _Max; }
            set
            {
                if (OnPropertyChanging(__.Max, value))
                {
                    _Max = value;
                    OnPropertyChanged(__.Max);
                }
            }
        }

        private Decimal _Min;

        /// <summary>下限</summary>
        [DisplayName("下限")]
        [Description("下限")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(11, "Min", "下限", null, "decimal", 18, 1, false)]
        public virtual Decimal Min
        {
            get { return _Min; }
            set
            {
                if (OnPropertyChanging(__.Min, value))
                {
                    _Min = value;
                    OnPropertyChanged(__.Min);
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

        /// <summary>取得设备数据异常记录字段信息的快捷方式</summary>
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

            ///<summary>传感器设备</summary>
            public static readonly Field SensorDeviceUnitID = FindByName(__.SensorDeviceUnitID);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>原始值</summary>
            public static readonly Field OriginalValue = FindByName(__.OriginalValue);

            ///<summary>处理值</summary>
            public static readonly Field ProcessedValue = FindByName(__.ProcessedValue);

            ///<summary>显示值</summary>
            public static readonly Field ShowValue = FindByName(__.ShowValue);

            ///<summary>上限</summary>
            public static readonly Field Max = FindByName(__.Max);

            ///<summary>下限</summary>
            public static readonly Field Min = FindByName(__.Min);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得设备数据异常记录字段名称的快捷方式</summary>
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

            ///<summary>传感器设备</summary>
            public const String SensorDeviceUnitID = "SensorDeviceUnitID";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>原始值</summary>
            public const String OriginalValue = "OriginalValue";

            ///<summary>处理值</summary>
            public const String ProcessedValue = "ProcessedValue";

            ///<summary>显示值</summary>
            public const String ShowValue = "ShowValue";

            ///<summary>上限</summary>
            public const String Max = "Max";

            ///<summary>下限</summary>
            public const String Min = "Min";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>设备数据异常记录接口</summary>
    public partial interface IDeviceDataExceptionLog
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

        /// <summary>传感器设备</summary>
        Int32 SensorDeviceUnitID { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>原始值</summary>
        Int32 OriginalValue { get; set; }

        /// <summary>处理值</summary>
        Decimal ProcessedValue { get; set; }

        /// <summary>显示值</summary>
        String ShowValue { get; set; }

        /// <summary>上限</summary>
        Decimal Max { get; set; }

        /// <summary>下限</summary>
        Decimal Min { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}