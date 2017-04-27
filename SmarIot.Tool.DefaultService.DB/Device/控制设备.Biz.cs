/*
 * XCoder v6.5.5660.22154
 * 作者：soft-cq/CQ-PC
 * 时间：2015-08-02 20:28:32
 * 版权：版权所有 (C) 新生命开发团队 2002~2015
*/

using NewLife.Data;
using SmartIot.Tool.DefaultService.DB.Common;
using System;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>控制设备</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class ControlDeviceUnit : ControlDeviceUnit<ControlDeviceUnit>
    {
    }

    /// <summary>控制设备</summary>
    public partial class ControlDeviceUnit<TEntity> : LogEntity<TEntity>
        where TEntity : ControlDeviceUnit<TEntity>, new()
    {
        #region 高级查询

        // 以下为自定义高级查询的例子

        /// <summary>查询满足条件的记录集，分页、排序</summary>
        /// <param name="userid">用户编号</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="key">关键字</param>
        /// <param name="param">分页排序参数，同时返回满足条件的总记录数</param>
        /// <returns>实体集</returns>
        public static EntityList<TEntity> Search(Int32 userid, DateTime start, DateTime end, String key,
            PageParameter param)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索，第二个参数可指定要搜索的字段
            var exp = SearchWhereByKeys(key, null, null);

            // 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符
            //if (userid > 0) exp &= _.OperatorID == userid;
            //if (isSign != null) exp &= _.IsSign == isSign.Value;
            //exp &= _.OccurTime.Between(start, end); // 大于等于start，小于end，当start/end大于MinValue时有效

            return FindAll(exp, param);
        }

        #endregion 高级查询

        #region 对象操作

        static ControlDeviceUnit()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            var entity = new TEntity();
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew"></param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            //if (String.IsNullOrEmpty(Name)) throw new ArgumentNullException(_.Name, _.Name.DisplayName + "无效！");
            //if (!isNew && ID < 1) throw new ArgumentOutOfRangeException(_.ID, _.ID.DisplayName + "必须大于0！");

            // 建议先调用基类方法，基类方法会对唯一索引的数据进行验证
            base.Valid(isNew);

            // 在新插入数据或者修改了指定字段时进行唯一性验证，CheckExist内部抛出参数异常
            //if (isNew || Dirtys[__.Name]) CheckExist(__.Name);

            if (!Dirtys[__.UpdateTime]) UpdateTime = DateTime.Now;
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    base.InitData();

        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    // Meta.Count是快速取得表记录数
        //    if (Meta.Count > 0) return;

        //    // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}[{1}]数据……", typeof(TEntity).Name, Meta.Table.DataTable.DisplayName);

        //    var entity = new ControlDeviceUnit();
        //    entity.Name = "abc";
        //    entity.ModularDeviceID = 0;
        //    entity.DeviceTypeSerialnum = "abc";
        //    entity.Function = 0;
        //    entity.IsComposite = true;
        //    entity.RegisterAddress1 = 0;
        //    entity.RegisterAddress2 = 0;
        //    entity.OriginalValue = 0;
        //    entity.ProcessedValue = "abc";
        //    entity.UpdateTime = DateTime.Now;
        //    entity.Remark = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof(TEntity).Name, Meta.Table.DataTable.DisplayName);
        //}

        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            if (DeviceControlCommands != null) DeviceControlCommands.Delete();
            if (DeviceControlLogs != null) DeviceControlLogs.Delete();
            if (FacilityControlDeviceUnits != null) FacilityControlDeviceUnits.Delete();

            return base.OnDelete();
        }

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnInsert()
        //{
        //    return base.OnInsert();
        //}

        #endregion 对象操作

        #region 扩展属性

        [NonSerialized] private DeviceType _DeviceType;

        /// <summary>该控制设备所对应的设备类型</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("该控制设备所对应的设备类型")]
        [Description("该控制设备所对应的设备类型")]
        public DeviceType DeviceType
        {
            get
            {
                if (_DeviceType == null && !String.IsNullOrEmpty(DeviceTypeSerialnum) &&
                    !Dirtys.ContainsKey("DeviceType"))
                {
                    _DeviceType = DeviceType.FindBySerialnum(DeviceTypeSerialnum);
                    Dirtys["DeviceType"] = true;
                }
                return _DeviceType;
            }
            set { _DeviceType = value; }
        }

        /// <summary>该控制设备所对应的设备类型名称</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("该控制设备所对应的设备类型名称")]
        [Description("该控制设备所对应的设备类型名称"), TypeConverter(typeof(ExpandableObjectConverter))]
        public String DeviceTypeName
        {
            get { return DeviceType != null ? DeviceType.Name : String.Empty; }
        }

        [NonSerialized] private RelayType _RelayType;

        /// <summary>该控制设备所对应的继电器类型</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("该控制设备所对应的继电器类型")]
        [Description("该控制设备所对应的继电器类型")]
        public RelayType RelayType
        {
            get
            {
                if (_RelayType == null && !String.IsNullOrEmpty(RelayTypeId.ToString()) &&
                    !Dirtys.ContainsKey("RelayType"))
                {
                    _RelayType = RelayType.FindById(RelayTypeId);
                    Dirtys["RelayType"] = true;
                }
                return _RelayType;
            }
            set { _RelayType = value; }
        }

        /// <summary>该控制设备所对应的继电器类型名称</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("该控制设备所对应的继电器类型名称")]
        [Description("该控制设备所对应的继电器类型名称"), TypeConverter(typeof(ExpandableObjectConverter))]
        public String RelayTypeName
        {
            get { return RelayType != null ? RelayType.Name : String.Empty; }
        }

        /// <summary>该控制设备所对应的继电器类型中文名称</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("该控制设备所对应的继电器类型中文名称")]
        [Description("该控制设备所对应的继电器类型中文名称"), TypeConverter(typeof(ExpandableObjectConverter))]
        public String RelayTypeRemark
        {
            get { return RelayType != null ? RelayType.Remark : String.Empty; }
        }

        [NonSerialized] private ControlJobType _ControlJobType;

        /// <summary>该控制设备所对应的控制工作类型</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("该控制设备所对应的控制工作类型")]
        [Description("该控制设备所对应的控制工作类型")]
        public ControlJobType ControlJobType
        {
            get
            {
                if (_ControlJobType == null && !String.IsNullOrEmpty(ControlJobTypeId.ToString()) &&
                    !Dirtys.ContainsKey("ControlJobType"))
                {
                    _ControlJobType = ControlJobType.FindById(ControlJobTypeId);
                    Dirtys["ControlJobType"] = true;
                }
                return _ControlJobType;
            }
            set { _ControlJobType = value; }
        }

        /// <summary>该控制设备所对应的控制工作类型名称</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("该控制设备所对应的控制工作类型名称")]
        [Description("该控制设备所对应的控制工作类型名称"), TypeConverter(typeof(ExpandableObjectConverter))]
        public String ControlJobTypeName
        {
            get { return ControlJobType != null ? ControlJobType.Name : String.Empty; }
        }

        /// <summary>该控制设备所对应的控制工作类型名称</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("该控制设备所对应的控制工作类型名称")]
        [Description("该控制设备所对应的控制工作类型名称"), TypeConverter(typeof(ExpandableObjectConverter))]
        public String ControlJobTypeRemark
        {
            get { return ControlJobType != null ? ControlJobType.Remark : String.Empty; }
        }

        [NonSerialized] private ModularDevice _ModularDevice;

        /// <summary>该控制设备所对应的模块化设备</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("该控制设备所对应的模块化设备")]
        [Description("该控制设备所对应的模块化设备")]
        public ModularDevice ModularDevice
        {
            get
            {
                if (_ModularDevice == null && ModularDeviceID > 0 && !Dirtys.ContainsKey("ModularDevice"))
                {
                    _ModularDevice = ModularDevice.FindByID(ModularDeviceID);
                    Dirtys["ModularDevice"] = true;
                }
                return _ModularDevice;
            }
            set { _ModularDevice = value; }
        }

        /// <summary>该控制设备所对应的模块化设备名称</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("该控制设备所对应的模块化设备名称")]
        [Description("该控制设备所对应的模块化设备名称"), TypeConverter(typeof(ExpandableObjectConverter))]
        public String ModularDeviceName
        {
            get { return ModularDevice != null ? ModularDevice.Name : String.Empty; }
        }

        [NonSerialized] private EntityList<DeviceControlCommand> _DeviceControlCommands;

        /// <summary>该控制设备所拥有的控制指令集合</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("设备控制指令")]
        [Description("设备控制指令"), TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityList<DeviceControlCommand> DeviceControlCommands
        {
            get
            {
                if (_DeviceControlCommands == null && ID > 0 && !Dirtys.ContainsKey("DeviceControlCommands"))
                {
                    _DeviceControlCommands = DeviceControlCommand.FindAllByControlDeviceUnitID(ID);
                    Dirtys["DeviceControlCommands"] = true;
                }
                return _DeviceControlCommands;
            }
            set { _DeviceControlCommands = value; }
        }

        [NonSerialized] private EntityList<DeviceControlLog> _DeviceControlLogs;

        /// <summary>该控制设备所拥有的设备控制日志集合</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("设备控制记录")]
        [Description("设备控制记录"), TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityList<DeviceControlLog> DeviceControlLogs
        {
            get
            {
                if (_DeviceControlLogs == null && ID > 0 && !Dirtys.ContainsKey("DeviceControlLogs"))
                {
                    _DeviceControlLogs = DeviceControlLog.FindAllByControlDeviceUnitID(ID);
                    Dirtys["DeviceControlLogs"] = true;
                }
                return _DeviceControlLogs;
            }
            set { _DeviceControlLogs = value; }
        }

        [NonSerialized] private EntityList<FacilityControlDeviceUnit> _FacilityControlDeviceUnits;

        /// <summary>该控制设备所拥有的设施控制设备集合</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("该控制设备所拥有的设施控制设备集合")]
        [Description("该控制设备所拥有的设施控制设备集合"), TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityList<FacilityControlDeviceUnit> FacilityControlDeviceUnits
        {
            get
            {
                if (_FacilityControlDeviceUnits == null && !Dirtys.ContainsKey("FacilityControlDeviceUnits"))
                {
                    _FacilityControlDeviceUnits = FacilityControlDeviceUnit.FindAllByControlDeviceUnitGroupNum(GroupNum);
                    Dirtys["FacilityControlDeviceUnits"] = true;
                }
                return _FacilityControlDeviceUnits;
            }
            set { _FacilityControlDeviceUnits = value; }
        }





        private string _ModularDevices;
        [Category("关联选项"), DisplayName("模块化设备")]
        [Description("模块化设备"), TypeConverter(typeof(ModularConverter))]
        public string ModularDevices
        {
            get
            {
                return _ModularDevices;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _ModularDevices = value; }
        }

        private string _DeviceTypes;
        [Category("关联选项"), DisplayName("设备类型")]
        [Description("设备类型"), TypeConverter(typeof(DeviceTypeConverter))]
        public string DeviceTypes
        {
            get
            {
                return _DeviceTypes;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _DeviceTypes = value; }
        }


        private string _ControlJobTypes;
        [Category("关联选项"), DisplayName("控制工作类型")]
        [Description("控制工作类型"), TypeConverter(typeof(ControlJobTypeConverter))]
        public string ControlJobTypes
        {
            get
            {
                return _ControlJobTypes;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _ControlJobTypes = value; }
        }

        private string _RelayTypes;
        [Category("关联选项"), DisplayName("继电器类型")]
        [Description("继电器类型"), TypeConverter(typeof(RelayTypeConverter))]
        public string RelayTypes
        {
            get
            {
                return _RelayTypes;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _RelayTypes = value; }
        }
        #endregion 扩展属性

        #region 扩展查询

        /// <summary>根据设备类型查找</summary>
        /// <param name="devicetypeserialnum">设备类型</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByDeviceTypeSerialnum(String devicetypeserialnum)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.DeviceTypeSerialnum, devicetypeserialnum);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.DeviceTypeSerialnum, devicetypeserialnum);
        }

        /// <summary>根据模块化设备查找</summary>
        /// <param name="modulardeviceid">模块化设备</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByModularDeviceID(Int32 modulardeviceid)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.ModularDeviceID, modulardeviceid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.ModularDeviceID, modulardeviceid);
        }

        /// <summary>根据ID查找</summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindByID(Int32 id)
        {
            if (Meta.Count >= 1000)
                return Find(__.ID, id);
            else // 实体缓存
                return Meta.Cache.Entities.Find(__.ID, id);
            // 单对象缓存
            //return Meta.SingleCache[id];
        }

        // <summary>根据ID查找</summary>
        /// <param name="groupNum">ID</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindByGroupNum(Int32 groupNum)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.GroupNum, groupNum);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.GroupNum, groupNum);
            // 单对象缓存
            //return Meta.SingleCache[id];
        }


        /// <summary>根据继电器类型查找</summary>
        /// <param name="id">继电器类型</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByRelayTypeId(Int32 id)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.RelayTypeId, id);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.RelayTypeId, id);
        }

        #endregion 扩展查询

        #region 业务

        //public static String GetCode1(int facilityId)
        //{
        //    var fcd = DB.FacilityControlDeviceUnit.FindByID(facilityId);
        //    var list = FindAll(_, facilityId);
        //    if (list.Count > 0)
        //    {
        //        var f = list[0];
        //        return f.Code1 + "G" + (Convert.ToInt32(f.Code1.Replace(f.Code1 + "G", "")) + 1).ToString().PadLeft(3, '0');
        //    }
        //    return farm.Code1 + "G" + 1.ToString().PadLeft(3, '0');
        //}

        #endregion 业务
    }
}