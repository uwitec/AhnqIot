using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>分时统计数据</summary>
    [Serializable]
    [DataObject]
    [Description("分时统计数据")]
    [BindIndex("Index_TimeSharingStatisticsCreateTime", false, "CreateTime")]
    [BindIndex("Index_TimeSharingStatisticsSensorDeviceUnitID", false, "SensorDeviceUnitID")]
    [BindIndex("Index_TimeSharingStatisticsTimeSharing", false, "TimeSharing")]
    [BindIndex("PK__TimeShar__3214EC27D5006A90", true, "ID")]
    [BindRelation("SensorDeviceUnitID", false, "SensorDeviceUnit", "ID")]
    [BindTable("TimeSharingStatistics", Description = "分时统计数据", ConnName = "SmartIot-Scada-data",
        DbType = DatabaseType.SqlServer)]
    public abstract partial class TimeSharingStatistics<TEntity> : ITimeSharingStatistics
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
                    case __.TimeSharing:
                        return _TimeSharing;
                    case __.AvgValue:
                        return _AvgValue;
                    case __.StartValue:
                        return _StartValue;
                    case __.EndValue:
                        return _EndValue;
                    case __.MaxValue:
                        return _MaxValue;
                    case __.MinValue:
                        return _MinValue;
                    case __.Count:
                        return _Count;
                    case __.Max:
                        return _Max;
                    case __.Min:
                        return _Min;
                    case __.ExceptionCount:
                        return _ExceptionCount;
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
                    case __.SensorDeviceUnitID:
                        _SensorDeviceUnitID = Convert.ToInt32(value);
                        break;
                    case __.TimeSharing:
                        _TimeSharing = Convert.ToInt32(value);
                        break;
                    case __.AvgValue:
                        _AvgValue = Convert.ToDecimal(value);
                        break;
                    case __.StartValue:
                        _StartValue = Convert.ToDecimal(value);
                        break;
                    case __.EndValue:
                        _EndValue = Convert.ToDecimal(value);
                        break;
                    case __.MaxValue:
                        _MaxValue = Convert.ToDecimal(value);
                        break;
                    case __.MinValue:
                        _MinValue = Convert.ToDecimal(value);
                        break;
                    case __.Count:
                        _Count = Convert.ToInt32(value);
                        break;
                    case __.Max:
                        _Max = Convert.ToDecimal(value);
                        break;
                    case __.Min:
                        _Min = Convert.ToDecimal(value);
                        break;
                    case __.ExceptionCount:
                        _ExceptionCount = Convert.ToInt32(value);
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

        private Int32 _TimeSharing;

        /// <summary>分时时段</summary>
        [DisplayName("分时时段")]
        [Description("分时时段")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "TimeSharing", "分时时段", null, "int", 10, 0, false)]
        public virtual Int32 TimeSharing
        {
            get { return _TimeSharing; }
            set
            {
                if (OnPropertyChanging(__.TimeSharing, value))
                {
                    _TimeSharing = value;
                    OnPropertyChanged(__.TimeSharing);
                }
            }
        }

        private Decimal _AvgValue;

        /// <summary>平均</summary>
        [DisplayName("平均")]
        [Description("平均")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(7, "AvgValue", "平均", null, "decimal", 18, 1, false)]
        public virtual Decimal AvgValue
        {
            get { return _AvgValue; }
            set
            {
                if (OnPropertyChanging(__.AvgValue, value))
                {
                    _AvgValue = value;
                    OnPropertyChanged(__.AvgValue);
                }
            }
        }

        private Decimal _StartValue;

        /// <summary>开始值</summary>
        [DisplayName("开始值")]
        [Description("开始值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(8, "StartValue", "开始值", null, "decimal", 18, 1, false)]
        public virtual Decimal StartValue
        {
            get { return _StartValue; }
            set
            {
                if (OnPropertyChanging(__.StartValue, value))
                {
                    _StartValue = value;
                    OnPropertyChanged(__.StartValue);
                }
            }
        }

        private Decimal _EndValue;

        /// <summary>结束值</summary>
        [DisplayName("结束值")]
        [Description("结束值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(9, "EndValue", "结束值", null, "decimal", 18, 1, false)]
        public virtual Decimal EndValue
        {
            get { return _EndValue; }
            set
            {
                if (OnPropertyChanging(__.EndValue, value))
                {
                    _EndValue = value;
                    OnPropertyChanged(__.EndValue);
                }
            }
        }

        private Decimal _MaxValue;

        /// <summary>最大值</summary>
        [DisplayName("最大值")]
        [Description("最大值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(10, "MaxValue", "最大值", null, "decimal", 18, 1, false)]
        public virtual Decimal MaxValue
        {
            get { return _MaxValue; }
            set
            {
                if (OnPropertyChanging(__.MaxValue, value))
                {
                    _MaxValue = value;
                    OnPropertyChanged(__.MaxValue);
                }
            }
        }

        private Decimal _MinValue;

        /// <summary>处理值</summary>
        [DisplayName("处理值")]
        [Description("处理值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(11, "MinValue", "处理值", null, "decimal", 18, 1, false)]
        public virtual Decimal MinValue
        {
            get { return _MinValue; }
            set
            {
                if (OnPropertyChanging(__.MinValue, value))
                {
                    _MinValue = value;
                    OnPropertyChanged(__.MinValue);
                }
            }
        }

        private Int32 _Count;

        /// <summary>样本数量</summary>
        [DisplayName("样本数量")]
        [Description("样本数量")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(12, "Count", "样本数量", null, "int", 10, 0, false)]
        public virtual Int32 Count
        {
            get { return _Count; }
            set
            {
                if (OnPropertyChanging(__.Count, value))
                {
                    _Count = value;
                    OnPropertyChanged(__.Count);
                }
            }
        }

        private Decimal _Max;

        /// <summary>上限</summary>
        [DisplayName("上限")]
        [Description("上限")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(13, "Max", "上限", null, "decimal", 18, 1, false)]
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
        [DataObjectField(false, false, true, 18)]
        [BindColumn(14, "Min", "下限", null, "decimal", 18, 1, false)]
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

        private Int32 _ExceptionCount;

        /// <summary>异常次数</summary>
        [DisplayName("异常次数")]
        [Description("异常次数")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(15, "ExceptionCount", "异常次数", null, "int", 10, 0, false)]
        public virtual Int32 ExceptionCount
        {
            get { return _ExceptionCount; }
            set
            {
                if (OnPropertyChanging(__.ExceptionCount, value))
                {
                    _ExceptionCount = value;
                    OnPropertyChanged(__.ExceptionCount);
                }
            }
        }

        private DateTime _CreateTime;

        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(16, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(17, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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

        /// <summary>取得分时统计数据字段信息的快捷方式</summary>
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

            ///<summary>分时时段</summary>
            public static readonly Field TimeSharing = FindByName(__.TimeSharing);

            ///<summary>平均</summary>
            public static readonly Field AvgValue = FindByName(__.AvgValue);

            ///<summary>开始值</summary>
            public static readonly Field StartValue = FindByName(__.StartValue);

            ///<summary>结束值</summary>
            public static readonly Field EndValue = FindByName(__.EndValue);

            ///<summary>最大值</summary>
            public static readonly Field MaxValue = FindByName(__.MaxValue);

            ///<summary>处理值</summary>
            public static readonly Field MinValue = FindByName(__.MinValue);

            ///<summary>样本数量</summary>
            public static readonly Field Count = FindByName(__.Count);

            ///<summary>上限</summary>
            public static readonly Field Max = FindByName(__.Max);

            ///<summary>下限</summary>
            public static readonly Field Min = FindByName(__.Min);

            ///<summary>异常次数</summary>
            public static readonly Field ExceptionCount = FindByName(__.ExceptionCount);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得分时统计数据字段名称的快捷方式</summary>
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

            ///<summary>分时时段</summary>
            public const String TimeSharing = "TimeSharing";

            ///<summary>平均</summary>
            public const String AvgValue = "AvgValue";

            ///<summary>开始值</summary>
            public const String StartValue = "StartValue";

            ///<summary>结束值</summary>
            public const String EndValue = "EndValue";

            ///<summary>最大值</summary>
            public const String MaxValue = "MaxValue";

            ///<summary>处理值</summary>
            public const String MinValue = "MinValue";

            ///<summary>样本数量</summary>
            public const String Count = "Count";

            ///<summary>上限</summary>
            public const String Max = "Max";

            ///<summary>下限</summary>
            public const String Min = "Min";

            ///<summary>异常次数</summary>
            public const String ExceptionCount = "ExceptionCount";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>分时统计数据接口</summary>
    public partial interface ITimeSharingStatistics
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

        /// <summary>分时时段</summary>
        Int32 TimeSharing { get; set; }

        /// <summary>平均</summary>
        Decimal AvgValue { get; set; }

        /// <summary>开始值</summary>
        Decimal StartValue { get; set; }

        /// <summary>结束值</summary>
        Decimal EndValue { get; set; }

        /// <summary>最大值</summary>
        Decimal MaxValue { get; set; }

        /// <summary>处理值</summary>
        Decimal MinValue { get; set; }

        /// <summary>样本数量</summary>
        Int32 Count { get; set; }

        /// <summary>上限</summary>
        Decimal Max { get; set; }

        /// <summary>下限</summary>
        Decimal Min { get; set; }

        /// <summary>异常次数</summary>
        Int32 ExceptionCount { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}