using SmartIot.Tool.DefaultService.DB.Common;
using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>传感器设备</summary>
    [Serializable]
    [DataObject]
    [Description("传感器设备")]
    [BindIndex("Index_SensorDeviceUnitModularDeviceID", false, "ModularDeviceID")]
    [BindIndex("Index_SensorDeviceUnitSensorId", false, "SensorId")]
    [BindIndex("PK__SensorDe__3214EC27D4154CBB", true, "ID")]
    [BindRelation("ID", true, "DeviceData", "SensorDeviceUnitID")]
    [BindRelation("ID", true, "DeviceDataExceptionLog", "SensorDeviceUnitID")]
    [BindRelation("ID", true, "FacilitySensorDeviceUnit", "SensorDeviceUnitID")]
    [BindRelation("ModularDeviceID", false, "ModularDevice", "ID")]
    [BindRelation("SensorId", false, "Sensor", "ID")]
    [BindRelation("ID", true, "ShowData", "SensorDeviceUnitID")]
    [BindRelation("ID", true, "TimeSharingStatistics", "SensorDeviceUnitID")]
    [BindTable("SensorDeviceUnit", Description = "传感器设备", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class SensorDeviceUnit<TEntity> : ISensorDeviceUnit
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
                    case __.Name:
                        return _Name;
                    case __.ModularDeviceID:
                        return _ModularDeviceID;
                    case __.SensorId:
                        return _SensorId;
                    case __.Function:
                        return _Function;
                    case __.RegisterAddress:
                        return _RegisterAddress;
                    case __.RegisterSize:
                        return _RegisterSize;
                    case __.OriginalValue:
                        return _OriginalValue;
                    case __.ProcessedValue:
                        return _ProcessedValue;
                    case __.ShowValue:
                        return _ShowValue;
                    case __.UpdateTime:
                        return _UpdateTime;
                    case __.Location:
                        return _Location;
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
                    case __.Name:
                        _Name = Convert.ToString(value);
                        break;
                    case __.ModularDeviceID:
                        _ModularDeviceID = Convert.ToInt32(value);
                        break;
                    case __.SensorId:
                        _SensorId = Convert.ToInt32(value);
                        break;
                    case __.Function:
                        _Function = Convert.ToInt32(value);
                        break;
                    case __.RegisterAddress:
                        _RegisterAddress = Convert.ToInt32(value);
                        break;
                    case __.RegisterSize:
                        _RegisterSize = Convert.ToInt32(value);
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
                    case __.UpdateTime:
                        _UpdateTime = Convert.ToDateTime(value);
                        break;
                    case __.Location:
                        _Location = Convert.ToString(value);
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
        [Category("基本属性"), ReadOnly(true)]
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

        private String _Name;

        /// <summary>设备名称</summary>
        [DisplayName("设备名称")]
        [Description("设备名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "Name", "设备名称", null, "nvarchar(50)", 0, 0, true, Master = true)]
        [Category("基本属性")]
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

        private Int32 _ModularDeviceID;

        /// <summary>模块化设备编号</summary>
        [DisplayName("模块化设备编号")]
        [Description("模块化设备编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "ModularDeviceID", "模块化设备编号", null, "int", 10, 0, false)]
        [Category("关联选项")]
        [ReadOnly(true)]
        public virtual Int32 ModularDeviceID
        {
            get { return _ModularDeviceID; }
            set
            {
                if (OnPropertyChanging(__.ModularDeviceID, value))
                {
                    _ModularDeviceID = value;
                    OnPropertyChanged(__.ModularDeviceID);
                }
            }
        }

        private Int32 _SensorId;

        /// <summary>传感器编号</summary>
        [DisplayName("传感器编号")]
        [Description("传感器编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(4, "SensorId", "传感器编号", null, "int", 10, 0, false)]
        [Category("关联选项")]
        [ReadOnly(true)]
        public virtual Int32 SensorId
        {
            get { return _SensorId; }
            set
            {
                if (OnPropertyChanging(__.SensorId, value))
                {
                    _SensorId = value;
                    OnPropertyChanged(__.SensorId);
                }
            }
        }

        private Int32 _Function;

        /// <summary>功能码</summary>
        [DisplayName("功能码")]
        [Description("功能码")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "Function", "功能码", null, "int", 10, 0, false)]
        [Category("基本属性")]
        public virtual Int32 Function
        {
            get { return _Function; }
            set
            {
                if (OnPropertyChanging(__.Function, value))
                {
                    _Function = value;
                    OnPropertyChanged(__.Function);
                }
            }
        }

        private Int32 _RegisterAddress;

        /// <summary>寄存器地址(十进制)</summary>
        [DisplayName("寄存器地址十进制")]
        [Description("寄存器地址(十进制)")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "RegisterAddress", "寄存器地址(十进制)", null, "int", 10, 0, false)]
        [Category("基本属性")]
        public virtual Int32 RegisterAddress
        {
            get { return _RegisterAddress; }
            set
            {
                if (OnPropertyChanging(__.RegisterAddress, value))
                {
                    _RegisterAddress = value;
                    OnPropertyChanged(__.RegisterAddress);
                }
            }
        }

        private Int32 _RegisterSize;

        /// <summary>寄存器长度</summary>
        [DisplayName("寄存器长度")]
        [Description("寄存器长度")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "RegisterSize", "寄存器长度", null, "int", 10, 0, false)]
        [Category("基本属性")]
        public virtual Int32 RegisterSize
        {
            get { return _RegisterSize; }
            set
            {
                if (OnPropertyChanging(__.RegisterSize, value))
                {
                    _RegisterSize = value;
                    OnPropertyChanged(__.RegisterSize);
                }
            }
        }

        private Int32 _OriginalValue;

        /// <summary>原始值</summary>
        [DisplayName("原始值")]
        [Description("原始值")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(8, "OriginalValue", "原始值", null, "int", 10, 0, false)]
        [Category("基本属性")]
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
        [BindColumn(9, "ProcessedValue", "处理值", null, "decimal", 18, 1, false)]
        [Category("基本属性")]
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
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "ShowValue", "显示值", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
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

        private DateTime _UpdateTime;

        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(11, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
        [Category("基本属性")]
        [ReadOnly(true)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set
            {
                if (OnPropertyChanging(__.UpdateTime, value))
                {
                    _UpdateTime = value;
                    OnPropertyChanged(__.UpdateTime);
                }
            }
        }

        private String _Location;

        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "Location", "位置", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Location
        {
            get { return _Location; }
            set
            {
                if (OnPropertyChanging(__.Location, value))
                {
                    _Location = value;
                    OnPropertyChanged(__.Location);
                }
            }
        }

        private String _Remark;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "Remark", "备注", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
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

        /// <summary>取得传感器设备字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>设备名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>变送器编号</summary>
            public static readonly Field ModularDeviceID = FindByName(__.ModularDeviceID);

            ///<summary>传感器编号</summary>
            public static readonly Field SensorId = FindByName(__.SensorId);

            ///<summary>功能码</summary>
            public static readonly Field Function = FindByName(__.Function);

            ///<summary>寄存器地址(十进制)</summary>
            public static readonly Field RegisterAddress = FindByName(__.RegisterAddress);

            ///<summary>寄存器长度</summary>
            public static readonly Field RegisterSize = FindByName(__.RegisterSize);

            ///<summary>原始值</summary>
            public static readonly Field OriginalValue = FindByName(__.OriginalValue);

            ///<summary>处理值</summary>
            public static readonly Field ProcessedValue = FindByName(__.ProcessedValue);

            ///<summary>显示值</summary>
            public static readonly Field ShowValue = FindByName(__.ShowValue);

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            ///<summary>位置</summary>
            public static readonly Field Location = FindByName(__.Location);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);


            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得传感器设备字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>设备名称</summary>
            public const String Name = "Name";

            ///<summary>变送器编号</summary>
            public const String ModularDeviceID = "ModularDeviceID";

            ///<summary>传感器编号</summary>
            public const String SensorId = "SensorId";

            ///<summary>功能码</summary>
            public const String Function = "Function";

            ///<summary>寄存器地址(十进制)</summary>
            public const String RegisterAddress = "RegisterAddress";

            ///<summary>寄存器长度</summary>
            public const String RegisterSize = "RegisterSize";

            ///<summary>原始值</summary>
            public const String OriginalValue = "OriginalValue";

            ///<summary>处理值</summary>
            public const String ProcessedValue = "ProcessedValue";

            ///<summary>显示值</summary>
            public const String ShowValue = "ShowValue";

            ///<summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            ///<summary>位置</summary>
            public const String Location = "Location";

            ///<summary>备注</summary>
            public const String Remark = "Remark";



        }

        #endregion 字段名
    }

    /// <summary>传感器设备接口</summary>
    public partial interface ISensorDeviceUnit
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

        /// <summary>设备名称</summary>
        String Name { get; set; }

        /// <summary>变送器编号</summary>
        Int32 ModularDeviceID { get; set; }

        /// <summary>传感器编号</summary>
        Int32 SensorId { get; set; }

        /// <summary>功能码</summary>
        Int32 Function { get; set; }

        /// <summary>寄存器地址(十进制)</summary>
        Int32 RegisterAddress { get; set; }

        /// <summary>寄存器长度</summary>
        Int32 RegisterSize { get; set; }

        /// <summary>原始值</summary>
        Int32 OriginalValue { get; set; }

        /// <summary>处理值</summary>
        Decimal ProcessedValue { get; set; }

        /// <summary>显示值</summary>
        String ShowValue { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>位置</summary>
        String Location { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }


        #endregion 属性
    }
}