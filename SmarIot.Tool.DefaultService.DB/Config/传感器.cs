using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>传感器</summary>
    [Serializable]
    [DataObject]
    [Description("传感器")]
    [BindIndex("Index_SensorCode", false, "Code")]
    [BindIndex("IX_Sensor_DeviceTypeSerialnum", false, "DeviceTypeSerialnum")]
    [BindIndex("PK__Sensor__3214EC2715DB9C7F", true, "ID")]
    [BindRelation("DeviceTypeSerialnum", false, "DeviceType", "Serialnum")]
    [BindRelation("ID", true, "SensorDeviceUnit", "SensorId")]
    [BindTable("Sensor", Description = "传感器", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class Sensor<TEntity> : ISensor
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
                    case __.Code:
                        return _Code;
                    case __.DeviceTypeSerialnum:
                        return _DeviceTypeSerialnum;
                    case __.Name:
                        return _Name;
                    case __.MaxValue:
                        return _MaxValue;
                    case __.MinValue:
                        return _MinValue;
                    case __.ExperienceMax:
                        return _ExperienceMax;
                    case __.ExperienceMin:
                        return _ExperienceMin;
                    case __.Unit:
                        return _Unit;
                    case __.Company:
                        return _Company;
                    case __.Accuracy:
                        return _Accuracy;
                    case __.ValueComputeString:
                        return _ValueComputeString;
                    case __.ShowComputeString:
                        return _ShowComputeString;
                    case __.Memo:
                        return _Memo;
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
                    case __.Code:
                        _Code = Convert.ToString(value);
                        break;
                    case __.DeviceTypeSerialnum:
                        _DeviceTypeSerialnum = Convert.ToString(value);
                        break;
                    case __.Name:
                        _Name = Convert.ToString(value);
                        break;
                    case __.MaxValue:
                        _MaxValue = Convert.ToDecimal(value);
                        break;
                    case __.MinValue:
                        _MinValue = Convert.ToDecimal(value);
                        break;
                    case __.ExperienceMax:
                        _ExperienceMax = Convert.ToDecimal(value);
                        break;
                    case __.ExperienceMin:
                        _ExperienceMin = Convert.ToDecimal(value);
                        break;
                    case __.Unit:
                        _Unit = Convert.ToString(value);
                        break;
                    case __.Company:
                        _Company = Convert.ToString(value);
                        break;
                    case __.Accuracy:
                        _Accuracy = Convert.ToInt32(value);
                        break;
                    case __.ValueComputeString:
                        _ValueComputeString = Convert.ToString(value);
                        break;
                    case __.ShowComputeString:
                        _ShowComputeString = Convert.ToString(value);
                        break;
                    case __.Memo:
                        _Memo = Convert.ToString(value);
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

        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "编号", null, "int", 10, 0, false)]
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

        private String _Code;

        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "Code", "编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code
        {
            get { return _Code; }
            set
            {
                if (OnPropertyChanging(__.Code, value))
                {
                    _Code = value;
                    OnPropertyChanged(__.Code);
                }
            }
        }

        private String _DeviceTypeSerialnum;

        /// <summary>设备类型</summary>
        [DisplayName("设备类型")]
        [Description("设备类型")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "DeviceTypeSerialnum", "设备类型", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DeviceTypeSerialnum
        {
            get { return _DeviceTypeSerialnum; }
            set
            {
                if (OnPropertyChanging(__.DeviceTypeSerialnum, value))
                {
                    _DeviceTypeSerialnum = value;
                    OnPropertyChanged(__.DeviceTypeSerialnum);
                }
            }
        }

        private String _Name;

        /// <summary>传感器名称</summary>
        [DisplayName("传感器名称")]
        [Description("传感器名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(4, "Name", "传感器名称", null, "nvarchar(50)", 0, 0, true, Master = true)]
        public virtual String Name
        {
            get { return _Name; }
            set
            {
                if (OnPropertyChanging(__.Name, value))
                {
                    _Name = value;
                    OnPropertyChanged(__.Name);
                }
            }
        }

        private Decimal _MaxValue;

        /// <summary>测量范围上限</summary>
        [DisplayName("测量范围上限")]
        [Description("测量范围上限")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(5, "MaxValue", "测量范围上限", null, "decimal", 18, 1, false)]
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

        /// <summary>测量范围下限</summary>
        [DisplayName("测量范围下限")]
        [Description("测量范围下限")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(6, "MinValue", "测量范围下限", null, "decimal", 18, 1, false)]
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

        private Decimal _ExperienceMax;

        /// <summary>经验值上限</summary>
        [DisplayName("经验值上限")]
        [Description("经验值上限")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(7, "ExperienceMax", "经验值上限", null, "decimal", 18, 1, false)]
        public virtual Decimal ExperienceMax
        {
            get { return _ExperienceMax; }
            set
            {
                if (OnPropertyChanging(__.ExperienceMax, value))
                {
                    _ExperienceMax = value;
                    OnPropertyChanged(__.ExperienceMax);
                }
            }
        }

        private Decimal _ExperienceMin;

        /// <summary>经验值下限</summary>
        [DisplayName("经验值下限")]
        [Description("经验值下限")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(8, "ExperienceMin", "经验值下限", null, "decimal", 18, 1, false)]
        public virtual Decimal ExperienceMin
        {
            get { return _ExperienceMin; }
            set
            {
                if (OnPropertyChanging(__.ExperienceMin, value))
                {
                    _ExperienceMin = value;
                    OnPropertyChanged(__.ExperienceMin);
                }
            }
        }

        private String _Unit;

        /// <summary>单位</summary>
        [DisplayName("单位")]
        [Description("单位")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(9, "Unit", "单位", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Unit
        {
            get { return _Unit; }
            set
            {
                if (OnPropertyChanging(__.Unit, value))
                {
                    _Unit = value;
                    OnPropertyChanged(__.Unit);
                }
            }
        }

        private String _Company;

        /// <summary>传感器厂家</summary>
        [DisplayName("传感器厂家")]
        [Description("传感器厂家")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "Company", "传感器厂家", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Company
        {
            get { return _Company; }
            set
            {
                if (OnPropertyChanging(__.Company, value))
                {
                    _Company = value;
                    OnPropertyChanged(__.Company);
                }
            }
        }

        private Int32 _Accuracy;

        /// <summary>精度</summary>
        [DisplayName("精度")]
        [Description("精度")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "Accuracy", "精度", null, "int", 10, 0, false)]
        public virtual Int32 Accuracy
        {
            get { return _Accuracy; }
            set
            {
                if (OnPropertyChanging(__.Accuracy, value))
                {
                    _Accuracy = value;
                    OnPropertyChanged(__.Accuracy);
                }
            }
        }

        private String _ValueComputeString;

        /// <summary>数值计算公式</summary>
        [DisplayName("数值计算公式")]
        [Description("数值计算公式")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(12, "ValueComputeString", "数值计算公式", null, "nvarchar(500)", 0, 0, true)]
        public virtual String ValueComputeString
        {
            get { return _ValueComputeString; }
            set
            {
                if (OnPropertyChanging(__.ValueComputeString, value))
                {
                    _ValueComputeString = value;
                    OnPropertyChanged(__.ValueComputeString);
                }
            }
        }

        private String _ShowComputeString;

        /// <summary>显示计算公式</summary>
        [DisplayName("显示计算公式")]
        [Description("显示计算公式")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(13, "ShowComputeString", "显示计算公式", null, "nvarchar(500)", 0, 0, true)]
        public virtual String ShowComputeString
        {
            get { return _ShowComputeString; }
            set
            {
                if (OnPropertyChanging(__.ShowComputeString, value))
                {
                    _ShowComputeString = value;
                    OnPropertyChanged(__.ShowComputeString);
                }
            }
        }

        private String _Memo;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(14, "Memo", "备注", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Memo
        {
            get { return _Memo; }
            set
            {
                if (OnPropertyChanging(__.Memo, value))
                {
                    _Memo = value;
                    OnPropertyChanged(__.Memo);
                }
            }
        }

        #endregion 属性

        #region 字段名

        /// <summary>取得传感器字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>编号</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>编码</summary>
            public static readonly Field Code = FindByName(__.Code);

            ///<summary>设备类型</summary>
            public static readonly Field DeviceTypeSerialnum = FindByName(__.DeviceTypeSerialnum);

            ///<summary>传感器名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>测量范围上限</summary>
            public static readonly Field MaxValue = FindByName(__.MaxValue);

            ///<summary>测量范围下限</summary>
            public static readonly Field MinValue = FindByName(__.MinValue);

            ///<summary>经验值上限</summary>
            public static readonly Field ExperienceMax = FindByName(__.ExperienceMax);

            ///<summary>经验值下限</summary>
            public static readonly Field ExperienceMin = FindByName(__.ExperienceMin);

            ///<summary>单位</summary>
            public static readonly Field Unit = FindByName(__.Unit);

            ///<summary>传感器厂家</summary>
            public static readonly Field Company = FindByName(__.Company);

            ///<summary>精度</summary>
            public static readonly Field Accuracy = FindByName(__.Accuracy);

            ///<summary>数值计算公式</summary>
            public static readonly Field ValueComputeString = FindByName(__.ValueComputeString);

            ///<summary>显示计算公式</summary>
            public static readonly Field ShowComputeString = FindByName(__.ShowComputeString);

            ///<summary>备注</summary>
            public static readonly Field Memo = FindByName(__.Memo);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得传感器字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编号</summary>
            public const String ID = "ID";

            ///<summary>编码</summary>
            public const String Code = "Code";

            ///<summary>设备类型</summary>
            public const String DeviceTypeSerialnum = "DeviceTypeSerialnum";

            ///<summary>传感器名称</summary>
            public const String Name = "Name";

            ///<summary>测量范围上限</summary>
            public const String MaxValue = "MaxValue";

            ///<summary>测量范围下限</summary>
            public const String MinValue = "MinValue";

            ///<summary>经验值上限</summary>
            public const String ExperienceMax = "ExperienceMax";

            ///<summary>经验值下限</summary>
            public const String ExperienceMin = "ExperienceMin";

            ///<summary>单位</summary>
            public const String Unit = "Unit";

            ///<summary>传感器厂家</summary>
            public const String Company = "Company";

            ///<summary>精度</summary>
            public const String Accuracy = "Accuracy";

            ///<summary>数值计算公式</summary>
            public const String ValueComputeString = "ValueComputeString";

            ///<summary>显示计算公式</summary>
            public const String ShowComputeString = "ShowComputeString";

            ///<summary>备注</summary>
            public const String Memo = "Memo";
        }

        #endregion 字段名
    }

    /// <summary>传感器接口</summary>
    public partial interface ISensor
    {
        #region 获取/设置 字段值

        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }

        #endregion 获取/设置 字段值

        #region 属性

        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>编码</summary>
        String Code { get; set; }

        /// <summary>设备类型</summary>
        String DeviceTypeSerialnum { get; set; }

        /// <summary>传感器名称</summary>
        String Name { get; set; }

        /// <summary>测量范围上限</summary>
        Decimal MaxValue { get; set; }

        /// <summary>测量范围下限</summary>
        Decimal MinValue { get; set; }

        /// <summary>经验值上限</summary>
        Decimal ExperienceMax { get; set; }

        /// <summary>经验值下限</summary>
        Decimal ExperienceMin { get; set; }

        /// <summary>单位</summary>
        String Unit { get; set; }

        /// <summary>传感器厂家</summary>
        String Company { get; set; }

        /// <summary>精度</summary>
        Int32 Accuracy { get; set; }

        /// <summary>数值计算公式</summary>
        String ValueComputeString { get; set; }

        /// <summary>显示计算公式</summary>
        String ShowComputeString { get; set; }

        /// <summary>备注</summary>
        String Memo { get; set; }

        #endregion 属性
    }
}