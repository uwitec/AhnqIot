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
    /// <summary>模块化设备</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class ModularDevice : ModularDevice<ModularDevice>
    {
    }

    /// <summary>模块化设备</summary>
    public partial class ModularDevice<TEntity> : LogEntity<TEntity> where TEntity : ModularDevice<TEntity>, new()
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

        static ModularDevice()
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

        //    var entity = new ModularDevice();
        //    entity.Name = "abc";
        //    entity.Address = "abc";
        //    entity.ProtocalTypeID = 0;
        //    entity.CommunicateDeviceID = 0;
        //    entity.OnlineStatus = true;
        //    entity.Exception = "abc";
        //    entity.Remark = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof(TEntity).Name, Meta.Table.DataTable.DisplayName);
        //}

        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            if (ControlDeviceUnits != null) ControlDeviceUnits.Delete();
            if (SensorDeviceUnits != null) SensorDeviceUnits.Delete();

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

        [NonSerialized] private EntityList<ControlDeviceUnit> _ControlDeviceUnits;

        /// <summary>该模块化设备所拥有的控制设备集合</summary>
        [XmlIgnore]
        [Category("扩展属性"), TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityList<ControlDeviceUnit> ControlDeviceUnits
        {
            get
            {
                if (_ControlDeviceUnits == null && ID > 0 && !Dirtys.ContainsKey("ControlDeviceUnits"))
                {
                    _ControlDeviceUnits = ControlDeviceUnit.FindAllByModularDeviceID(ID);
                    Dirtys["ControlDeviceUnits"] = true;
                }
                return _ControlDeviceUnits;
            }
            set { _ControlDeviceUnits = value; }
        }

        [NonSerialized] private CommunicateDevice _CommunicateDevice;

        /// <summary>该模块化设备所对应的通讯设备</summary>
        [XmlIgnore]
        [Category("关联选项")]
        public CommunicateDevice CommunicateDevice
        {
            get
            {
                if (_CommunicateDevice == null && CommunicateDeviceID > 0 && !Dirtys.ContainsKey("CommunicateDevice"))
                {
                    _CommunicateDevice = CommunicateDevice.FindByID(CommunicateDeviceID);
                    Dirtys["CommunicateDevice"] = true;
                }
                return _CommunicateDevice;
            }
            set { _CommunicateDevice = value; }
        }

        /// <summary>该模块化设备所对应的通讯设备名称</summary>
        [XmlIgnore]
        [Category("扩展属性"), TypeConverter(typeof(ExpandableObjectConverter))]
        public String CommunicateDeviceName
        {
            get { return CommunicateDevice != null ? CommunicateDevice.Name : String.Empty; }
        }

        [NonSerialized] private ProtocalType _ProtocalType;

        /// <summary>该模块化设备所对应的数据处理协议类型</summary>
        [XmlIgnore]
        [Category("关联选项")]
        public ProtocalType ProtocalType
        {
            get
            {
                if (_ProtocalType == null && ProtocalTypeID > 0 && !Dirtys.ContainsKey("ProtocalType"))
                {
                    _ProtocalType = ProtocalType.FindByID(ProtocalTypeID);
                    Dirtys["ProtocalType"] = true;
                }
                return _ProtocalType;
            }
            set { _ProtocalType = value; }
        }

        /// <summary>该模块化设备所对应的数据处理协议类型名称</summary>
        [XmlIgnore]
        [Category("扩展属性"), TypeConverter(typeof(ExpandableObjectConverter))]
        public String ProtocalTypeName
        {
            get { return ProtocalType != null ? ProtocalType.Name : String.Empty; }
        }

        [NonSerialized] private EntityList<SensorDeviceUnit> _SensorDeviceUnits;

        /// <summary>该模块化设备所拥有的传感器设备集合</summary>
        [XmlIgnore]
        [Category("扩展属性"), TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityList<SensorDeviceUnit> SensorDeviceUnits
        {
            get
            {
                if (_SensorDeviceUnits == null && ID > 0 && !Dirtys.ContainsKey("SensorDeviceUnits"))
                {
                    _SensorDeviceUnits = SensorDeviceUnit.FindAllByModularDeviceID(ID);
                    Dirtys["SensorDeviceUnits"] = true;
                }
                return _SensorDeviceUnits;
            }
            set { _SensorDeviceUnits = value; }
        }



        private string _ProtocalTypes;
        [Category("关联选项"), DisplayName("协议类型")]
        [Description("协议类型"), TypeConverter(typeof(ProtocalTypeConverter))]
        public string ProtocalTypes
        {
            get
            {
                return _ProtocalTypes;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _ProtocalTypes = value; }
        }

        private string _CommunicateDevices;
        [Category("关联选项"), DisplayName("通讯设备")]
        [Description("通讯设备"), TypeConverter(typeof(CommunicateDeviceConverter))]
        public string CommunicateDevices
        {
            get
            {
                return _CommunicateDevices;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _CommunicateDevices = value; }
        }

        #endregion 扩展属性

        #region 扩展查询

        /// <summary>根据名称查找</summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByName(String name)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.Name, name);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.Name, name);
        }

        /// <summary>根据通讯设备查找</summary>
        /// <param name="communicatedeviceid">通讯设备</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByCommunicateDeviceID(Int32 communicatedeviceid)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.CommunicateDeviceID, communicatedeviceid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.CommunicateDeviceID, communicatedeviceid);
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

        /// <summary>根据协议查找</summary>
        /// <param name="protocaltypeid">协议</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByProtocalTypeID(Int32 protocaltypeid)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.ProtocalTypeID, protocaltypeid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.ProtocalTypeID, protocaltypeid);
        }

        #endregion 扩展查询
    }
}