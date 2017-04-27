using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>控制设备</summary>
    [Serializable]
    [DataObject]
    [Description("控制设备")]
    [BindIndex("Index_ControlDeviceUnitDeviceTypeSerialnum", false, "DeviceTypeSerialnum")]
    [BindIndex("Index_ControlDeviceUnitModularDeviceID", false, "ModularDeviceID")]
    [BindIndex("PK__ControlD__3214EC27ED28C55C", true, "ID")]
    [BindRelation("DeviceTypeSerialnum", false, "DeviceType", "Serialnum")]
    [BindRelation("ModularDeviceID", false, "ModularDevice", "ID")]
    [BindRelation("ID", true, "DeviceControlCommand", "ControlDeviceUnitID")]
    [BindRelation("ID", true, "DeviceControlLog", "ControlDeviceUnitID")]
    [BindRelation("GroupNum", true, "FacilityControlDeviceUnit", "ControlDeviceUnitGroupNum")]
    [BindRelation("RelayTypeId", true, "RelayType", "ID")]
    [BindRelation("ControlJobTypeId", true, "ControlJobType", "ID")]
    [BindTable("ControlDeviceUnit", Description = "控制设备", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class ControlDeviceUnit<TEntity> : IControlDeviceUnit
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
                    case __.DeviceTypeSerialnum:
                        return _DeviceTypeSerialnum;
                    case __.Function:
                        return _Function;
                    //case __.IsComposite: return _IsComposite;
                    case __.RegisterAddress1:
                        return _RegisterAddress1;
                    //case __.RegisterAddress1Name: return _RegisterAddress1Name;
                    case __.GroupNum:
                        return _GroupNum;
                    case __.RelayTypeId:
                        return _RelayTypeId;
                    //case __.GroupNum: return _GroupNum;
                    case __.OriginalValue:
                        return _OriginalValue;
                    case __.ProcessedValue:
                        return _ProcessedValue;
                    case __.UpdateTime:
                        return _UpdateTime;
                    case __.Location:
                        return _Location;
                    case __.Remark:
                        return _Remark;
                    case __.ControlJobTypeId:
                        return _ControlJobTypeId;
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
                    case __.DeviceTypeSerialnum:
                        _DeviceTypeSerialnum = Convert.ToString(value);
                        break;
                    case __.Function:
                        _Function = Convert.ToInt32(value);
                        break;
                    //case __.IsComposite: _IsComposite = Convert.ToBoolean(value); break;
                    case __.RegisterAddress1:
                        _RegisterAddress1 = Convert.ToInt32(value);
                        break;
                    //case __.RegisterAddress1Name: _RegisterAddress1Name = Convert.ToString(value); break;
                    case __.GroupNum:
                        _GroupNum = Convert.ToInt32(value);
                        break;
                    case __.RelayTypeId:
                        _RelayTypeId = Convert.ToInt32(value);
                        break;
                    //case __.GroupNum: _GroupNum = Convert.ToString(value); break;
                    case __.OriginalValue:
                        _OriginalValue = Convert.ToInt32(value);
                        break;
                    case __.ProcessedValue:
                        _ProcessedValue = Convert.ToString(value);
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
                    case __.ControlJobTypeId:
                        _ControlJobTypeId = Convert.ToInt32(value);
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
        [Category("基本属性")]
        [ReadOnly(true)]
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
        [Description("设备名称,请以{设备名称}+‘-’+{控制工作内容}’的格式填写！")]
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

        /// <summary>模块化设备</summary>
        [DisplayName("模块化设备ID")]
        [Description("模块化设备ID")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "ModularDeviceID", "模块化设备", null, "int", 10, 0, false)]
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

        private String _DeviceTypeSerialnum;

        /// <summary>设备类型</summary>
        [DisplayName("设备类型ID")]
        [Description("设备类型ID")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(4, "DeviceTypeSerialnum", "设备类型", null, "nvarchar(50)", 0, 0, true)]
        [Category("关联选项")]
        [ReadOnly(true)]
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

        //private Boolean _IsComposite;

        ///// <summary>组合设备</summary>
        //[DisplayName("组合设备")]
        //[Description("组合设备")]
        //[DataObjectField(false, false, false, 1)]
        //[BindColumn(6, "IsComposite", "组合设备", null, "bit", 0, 0, false)]
        //public virtual Boolean IsComposite
        //{
        //    get { return _IsComposite; }
        //    set { if (OnPropertyChanging(__.IsComposite, value)) { _IsComposite = value; OnPropertyChanged(__.IsComposite); } }
        //}

        private Int32 _RegisterAddress1;

        /// <summary>寄存器地址(十进制)</summary>
        [DisplayName("寄存器地址十进制")]
        [Description("寄存器地址(十进制)")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "RegisterAddress1", "寄存器地址(十进制)", null, "int", 10, 0, false)]
        [Category("基本属性")]
        public virtual Int32 RegisterAddress1
        {
            get { return _RegisterAddress1; }
            set
            {
                if (OnPropertyChanging(__.RegisterAddress1, value))
                {
                    _RegisterAddress1 = value;
                    OnPropertyChanged(__.RegisterAddress1);
                }
            }
        }

        //private String _RegisterAddress1Name;

        ///// <summary>超始地址</summary>
        //[DisplayName("超始地址")]
        //[Description("超始地址")]
        //[DataObjectField(false, false, false, 50)]
        //[BindColumn(8, "RegisterAddress1Name", "超始地址", null, "nvarchar(50)", 0, 0, true)]
        //public virtual String RegisterAddress1Name
        //{
        //    get { return _RegisterAddress1Name; }
        //    set { if (OnPropertyChanging(__.RegisterAddress1Name, value)) { _RegisterAddress1Name = value; OnPropertyChanged(__.RegisterAddress1Name); } }
        //}
        private Int32 _GroupNum;

        /// <summary>控制设备组号(十进制)</summary>
        [DisplayName("控制设备组号十进制")]
        [Description("控制设备组号(十进制)")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(9, "GroupNum", "控制设备组号(十进制)", null, "int", 10, 0, false)]
        [Category("基本属性")]
        public virtual Int32 GroupNum
        {
            get { return _GroupNum; }
            set
            {
                if (OnPropertyChanging(__.GroupNum, value))
                {
                    _GroupNum = value;
                    OnPropertyChanged(__.GroupNum);
                }
            }
        }

        private Int32 _RelayTypeId;

        /// <summary>继电器类型</summary>
        [DisplayName("继电器类型ID")]
        [Description("继电器类型ID")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(9, "RelayTypeId", "继电器类型", null, "int", 10, 0, false)]
        [Category("关联选项")]
        [ReadOnly(true)]
        public virtual Int32 RelayTypeId
        {
            get { return _RelayTypeId; }
            set
            {
                if (OnPropertyChanging(__.RelayTypeId, value))
                {
                    _RelayTypeId = value;
                    OnPropertyChanged(__.RelayTypeId);
                }
            }
        }


        //private String _GroupNum;

        ///// <summary>结束地址</summary>
        //[DisplayName("结束地址")]
        //[Description("结束地址")]
        //[DataObjectField(false, false, false, 50)]
        //[BindColumn(10, "GroupNum", "结束地址", null, "nvarchar(50)", 0, 0, true)]
        //public virtual String GroupNum
        //{
        //    get { return _GroupNum; }
        //    set { if (OnPropertyChanging(__.GroupNum, value)) { _GroupNum = value; OnPropertyChanged(__.GroupNum); } }
        //}

        private Int32 _OriginalValue;

        /// <summary>原始值</summary>
        [DisplayName("原始值")]
        [Description("原始值")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "OriginalValue", "原始值", null, "int", 10, 0, false)]
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

        private String _ProcessedValue;

        /// <summary>设备状态</summary>
        [DisplayName("设备状态")]
        [Description("设备状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "ProcessedValue", "设备状态", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String ProcessedValue
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

        private DateTime _UpdateTime;

        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
        [Category("基本属性")]
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
        [BindColumn(14, "Location", "位置", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(15, "Remark", "备注", null, "nvarchar(50)", 0, 0, true)]
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

        private Int32 _ControlJobTypeId;

        /// <summary>工作</summary>
        [DisplayName("控制工作类型ID")]
        [Description("控制工作类型ID")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(1, "ControlJobTypeId", "控制工作类型", null, "int", 10, 0, false)]
        [Category("关联选项")]
        [ReadOnly(true)]
        public virtual Int32 ControlJobTypeId
        {
            get { return _ControlJobTypeId; }
            set
            {
                if (OnPropertyChanging(__.ControlJobTypeId, value))
                {
                    _ControlJobTypeId = value;
                    OnPropertyChanged(__.ControlJobTypeId);
                }
            }
        }

        #endregion 属性

        #region 字段名

        /// <summary>取得控制设备字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>设备名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>模块化设备</summary>
            public static readonly Field ModularDeviceID = FindByName(__.ModularDeviceID);

            ///<summary>设备类型</summary>
            public static readonly Field DeviceTypeSerialnum = FindByName(__.DeviceTypeSerialnum);

            ///<summary>功能码</summary>
            public static readonly Field Function = FindByName(__.Function);

            ///<summary>组合设备</summary>
            public static readonly Field IsComposite = FindByName(__.IsComposite);

            ///<summary>寄存器地址(十进制)</summary>
            public static readonly Field RegisterAddress1 = FindByName(__.RegisterAddress1);

            /////<summary>超始地址</summary>
            //public static readonly Field RegisterAddress1Name = FindByName(__.RegisterAddress1Name);

            ///<summary>控制设备组号</summary>
            public static readonly Field GroupNum = FindByName(__.GroupNum);

            ///<summary>继电器类型</summary>
            public static readonly Field RelayTypeId = FindByName(__.RelayTypeId);

            /////<summary>结束地址</summary>
            //public static readonly Field GroupNum = FindByName(__.GroupNum);

            ///<summary>原始值</summary>
            public static readonly Field OriginalValue = FindByName(__.OriginalValue);

            ///<summary>设备状态</summary>
            public static readonly Field ProcessedValue = FindByName(__.ProcessedValue);

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            ///<summary>位置</summary>
            public static readonly Field Location = FindByName(__.Location);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            ///<summary>控制工作类型</summary>
            public static readonly Field ControlJobTypeId = FindByName(__.ControlJobTypeId);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得控制设备字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>设备名称</summary>
            public const String Name = "Name";

            ///<summary>模块化设备</summary>
            public const String ModularDeviceID = "ModularDeviceID";

            ///<summary>设备类型</summary>
            public const String DeviceTypeSerialnum = "DeviceTypeSerialnum";

            ///<summary>功能码</summary>
            public const String Function = "Function";

            ///<summary>组合设备</summary>
            public const String IsComposite = "IsComposite";

            ///<summary>寄存器地址(十进制)</summary>
            public const String RegisterAddress1 = "RegisterAddress1";

            /////<summary>超始地址</summary>
            //public const String RegisterAddress1Name = "RegisterAddress1Name";

            ///<summary>控制设备组号(十进制)</summary>
            public const String GroupNum = "GroupNum";


            ///<summary>继电器类型</summary>
            public const String RelayTypeId = "RelayTypeId";

            /////<summary>结束地址</summary>
            //public const String GroupNum = "GroupNum";

            ///<summary>原始值</summary>
            public const String OriginalValue = "OriginalValue";

            ///<summary>设备状态</summary>
            public const String ProcessedValue = "ProcessedValue";

            ///<summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            ///<summary>位置</summary>
            public const String Location = "Location";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

            ///<summary>控制工作类型</summary>
            public const String ControlJobTypeId = "ControlJobTypeId";
        }

        #endregion 字段名
    }

    /// <summary>控制设备接口</summary>
    public partial interface IControlDeviceUnit
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

        /// <summary>模块化设备</summary>
        Int32 ModularDeviceID { get; set; }

        /// <summary>设备类型</summary>
        String DeviceTypeSerialnum { get; set; }

        /// <summary>功能码</summary>
        Int32 Function { get; set; }

        ///// <summary>组合设备</summary>
        //Boolean IsComposite { get; set; }

        /// <summary>寄存器地址(十进制)</summary>
        Int32 RegisterAddress1 { get; set; }

        ///// <summary>超始地址</summary>
        //String RegisterAddress1Name { get; set; }

        /// <summary>控制设备组号(十进制)</summary>
        Int32 GroupNum { get; set; }

        /// <summary>继电器类型</summary>
        Int32 RelayTypeId { get; set; }

        ///// <summary>结束地址</summary>
        //String GroupNum { get; set; }

        /// <summary>原始值</summary>
        Int32 OriginalValue { get; set; }

        /// <summary>设备状态</summary>
        String ProcessedValue { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>位置</summary>
        String Location { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        /// <summary>控制工作类型</summary>
        Int32 ControlJobTypeId { get; set; }

        #endregion 属性
    }
}