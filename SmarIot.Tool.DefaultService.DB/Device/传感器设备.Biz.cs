/*
 * XCoder v6.5.5660.22154
 * 作者：soft-cq/CQ-PC
 * 时间：2015-08-02 20:28:32
 * 版权：版权所有 (C) 新生命开发团队 2002~2015
*/

using NewLife.Data;
using System;
using System.ComponentModel;
using System.Xml.Serialization;
using SmartIot.Tool.DefaultService.DB;
using XCode;
using SmartIot.Tool.DefaultService.DB.Common;
using System.Collections.Generic;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>传感器设备</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class SensorDeviceUnit : SensorDeviceUnit<SensorDeviceUnit>
    {
    }

    /// <summary>传感器设备</summary>
    public partial class SensorDeviceUnit<TEntity> : LogEntity<TEntity> where TEntity : SensorDeviceUnit<TEntity>, new()
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

        static SensorDeviceUnit()
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

            // 货币保留6位小数
            if (Dirtys[__.ProcessedValue]) ProcessedValue = Math.Round(ProcessedValue, 6);
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

        //    var entity = new SensorDeviceUnit();
        //    entity.Name = "abc";
        //    entity.ModularDeviceID = 0;
        //    entity.SensorId = 0;
        //    entity.Function = 0;
        //    entity.RegisterAddress = 0;
        //    entity.RegisterSize = 0;
        //    entity.OriginalValue = 0;
        //    entity.ProcessedValue = 0;
        //    entity.ShowValue = "abc";
        //    entity.UpdateTime = DateTime.Now;
        //    entity.Remark = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof(TEntity).Name, Meta.Table.DataTable.DisplayName);
        //}

        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            if (DeviceDatas != null) DeviceDatas.Delete();
            if (DeviceDataExceptionLogs != null) DeviceDataExceptionLogs.Delete();
            if (FacilitySensorDeviceUnits != null) FacilitySensorDeviceUnits.Delete();
            if (ShowDatas != null) ShowDatas.Delete();
            if (TimeSharingStatisticss != null) TimeSharingStatisticss.Delete();

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

        [NonSerialized] private EntityList<DeviceData> _DeviceDatas;

        /// <summary>该传感器设备所拥有的设备数据记录集合</summary>
        [XmlIgnore]
        [Category("扩展属性"), TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("设备数据")]
        [DisplayName("设备数据")]
        public EntityList<DeviceData> DeviceDatas
        {
            get
            {
                if (_DeviceDatas == null && ID > 0 && !Dirtys.ContainsKey("DeviceDatas"))
                {
                    _DeviceDatas = DeviceData.FindAllBySensorDeviceUnitID(ID);
                    Dirtys["DeviceDatas"] = true;
                }
                return _DeviceDatas;
            }
            set { _DeviceDatas = value; }
        }

        [NonSerialized] private EntityList<DeviceDataExceptionLog> _DeviceDataExceptionLogs;

        /// <summary>该传感器设备所拥有的设备数据异常记录集合</summary>
        [XmlIgnore]
        [Category("扩展属性"), TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("设备异常记录")]
        [DisplayName("设备异常记录")]
        public EntityList<DeviceDataExceptionLog> DeviceDataExceptionLogs
        {
            get
            {
                if (_DeviceDataExceptionLogs == null && ID > 0 && !Dirtys.ContainsKey("DeviceDataExceptionLogs"))
                {
                    _DeviceDataExceptionLogs = DeviceDataExceptionLog.FindAllBySensorDeviceUnitID(ID);
                    Dirtys["DeviceDataExceptionLogs"] = true;
                }
                return _DeviceDataExceptionLogs;
            }
            set { _DeviceDataExceptionLogs = value; }
        }

        [NonSerialized] private EntityList<FacilitySensorDeviceUnit> _FacilitySensorDeviceUnits;

        /// <summary>该传感器设备所拥有的设施传感器设备集合</summary>
        [XmlIgnore]
        [Category("扩展属性"), TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("设备所拥有的设施传感器集合")]
        [DisplayName("设备所拥有的设施传感器集合")]
        public EntityList<FacilitySensorDeviceUnit> FacilitySensorDeviceUnits
        {
            get
            {
                if (_FacilitySensorDeviceUnits == null && ID > 0 && !Dirtys.ContainsKey("FacilitySensorDeviceUnits"))
                {
                    _FacilitySensorDeviceUnits = FacilitySensorDeviceUnit.FindAllBySensorDeviceUnitID(ID);
                    Dirtys["FacilitySensorDeviceUnits"] = true;
                }
                return _FacilitySensorDeviceUnits;
            }
            set { _FacilitySensorDeviceUnits = value; }
        }

        [NonSerialized] private ModularDevice _ModularDevice;

        /// <summary>该传感器设备所对应的模块化设备</summary>
        [XmlIgnore]
        [Description("模块化设备")]
        [DisplayName("模块化设备")]
        [Category("扩展属性")]
        //[ReadOnly(true), TypeConverter(typeof(ExpandableObjectConverter))]
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

        /// <summary>该传感器设备所对应的模块化设备名称</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [Description("模块化设备名称")]
        [DisplayName("模块化设备名称")]
        //[ReadOnlyAttribute(false)]

        public String ModularDeviceName
        {
            get { return ModularDevice != null ? ModularDevice.Name : String.Empty; }
        }

        [NonSerialized]
        private Sensor _Sensor;

        /// <summary>该传感器设备所对应的传感器</summary>
        [XmlIgnore]
        [Description("传感器")]
        [DisplayName("传感器")]
        [Category("扩展属性")]
        public Sensor Sensor
        {
            get
            {
                if (_Sensor == null && SensorId > 0 && !Dirtys.ContainsKey("Sensor"))
                {
                    _Sensor = Sensor.FindByID(SensorId);
                    Dirtys["Sensor"] = true;
                }
                return _Sensor;
            }
            set { _Sensor = value; }
        }

        /// <summary>该传感器设备所对应的传感器传感器名称</summary>
        [XmlIgnore]
        [Description("传感器名称")]
        [DisplayName("传感器名称")]
        [Category("扩展属性")]
        public String SensorName
        {
            get { return Sensor != null ? Sensor.Name : String.Empty; }
        }

        [NonSerialized] private EntityList<ShowData> _ShowDatas;

        /// <summary>该传感器设备所拥有的显示数据集合</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("显示数据")]
        [Description("显示数据"), TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityList<ShowData> ShowDatas
        {
            get
            {
                if (_ShowDatas == null && ID > 0 && !Dirtys.ContainsKey("ShowDatas"))
                {
                    _ShowDatas = ShowData.FindAllBySensorDeviceUnitID(ID);
                    Dirtys["ShowDatas"] = true;
                }
                return _ShowDatas;
            }
            set { _ShowDatas = value; }
        }

        [NonSerialized] private EntityList<TimeSharingStatistics> _TimeSharingStatisticss;

        /// <summary>该传感器设备所拥有的分时统计数据集合</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        [DisplayName("分时统计数据")]
        [Description("分时统计数据"), TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityList<TimeSharingStatistics> TimeSharingStatisticss
        {
            get
            {
                if (_TimeSharingStatisticss == null && ID > 0 && !Dirtys.ContainsKey("TimeSharingStatisticss"))
                {
                    _TimeSharingStatisticss = TimeSharingStatistics.FindAllBySensorDeviceUnitID(ID);
                    Dirtys["TimeSharingStatisticss"] = true;
                }
                return _TimeSharingStatisticss;
            }
            set { _TimeSharingStatisticss = value; }
        }





        private string _ModularDevices;
        [Category("关联选项"),DisplayName("模块化设备")]
        [Description("模块化设备"),TypeConverter(typeof(ModularConverter))]
        public string ModularDevices
        {
            get {
                return _ModularDevices;
                    //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _ModularDevices = value; }
        }

        private string _Sensors;
        [Category("关联选项"), DisplayName("传感器")]
        [Description("传感器"), TypeConverter(typeof(SensorConverter))]
        public string Sensors
        {
            get
            {
                return _Sensors;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _Sensors = value; }
        }

        #endregion 扩展属性

        #region 扩展查询

        /// <summary>根据变送器编号查找</summary>
        /// <param name="modulardeviceid">变送器编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByModularDeviceID(Int32 modulardeviceid)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.ModularDeviceID, modulardeviceid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.ModularDeviceID, modulardeviceid);
        }

        /// <summary>根据传感器编号查找</summary>
        /// <param name="sensorid">传感器编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllBySensorId(Int32 sensorid)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.SensorId, sensorid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.SensorId, sensorid);
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

        #endregion 扩展查询
    }
}