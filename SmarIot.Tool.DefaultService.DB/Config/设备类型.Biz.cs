/*
 * XCoder v6.5.5660.22154
 * 作者：soft-cq/CQ-PC
 * 时间：2015-08-02 20:28:32
 * 版权：版权所有 (C) 新生命开发团队 2002~2015
*/

using NewLife.Common;
using NewLife.Data;
using NewLife.Log;
using System;
using System.ComponentModel;
using System.Xml.Serialization;
using SmartIot.Tool.DefaultService.DB;
using XCode;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>设备类型</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class DeviceType : DeviceType<DeviceType>
    {
    }

    /// <summary>设备类型</summary>
    public partial class DeviceType<TEntity> : LogEntity<TEntity> where TEntity : DeviceType<TEntity>, new()
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

        static DeviceType()
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

            if (isNew && !Dirtys[__.CreateTime]) CreateTime = DateTime.Now;
            if (!Dirtys[__.UpdateTime]) UpdateTime = DateTime.Now;
        }

        /// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void InitData()
        {
            base.InitData();

            // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
            // Meta.Count是快速取得表记录数
            if (Meta.Count > 0) return;

            // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
            if (XTrace.Debug)
                XTrace.WriteLine("开始初始化{0}[{1}]数据……", typeof (TEntity).Name, Meta.Table.DataTable.DisplayName);

            AddEntity("collect", "采集", "", "采集设备类型");
            //设施类
            AddEntity("collect-facility", "采集-设施类", "collect", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("空气温度"), "空气温度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("空气相对湿度"), "空气相对湿度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("光照度"), "光照度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("光辐射"), "光辐射", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("光照时数"), "光照时数", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("一氧化碳"), "一氧化碳", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("二氧化碳"), "二氧化碳", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("氨气"), "氨气", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("硫化氢"), "硫化氢", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("土壤温度"), "土壤温度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("土壤湿度"), "土壤湿度", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("土壤电导率"), "土壤电导率", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("设施类备用1"), "设施类备用1", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("设施类备用2"), "设施类备用2", "collect-facility", "设施类");
            AddEntity("collect-facility-" + PinYin.Get("设施类备用3"), "设施类备用3", "collect-facility", "设施类");
            //气象站
            AddEntity("collect-weather", "采集-气象站", "collect", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("温度"), "温度", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("湿度"), "湿度", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("光照"), "光照", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("风速"), "风速", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("风向"), "风向", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("雨雪感知"), "雨雪感知", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("降雨量"), "降雨量", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("大气压强"), "大气压强", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("气象站备用1"), "气象站备用1", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("气象站备用2"), "气象站备用2", "collect-weather", "气象站");
            AddEntity("collect-weather-" + PinYin.Get("气象站备用3"), "气象站备用3", "collect-weather", "气象站");
            //水产类
            AddEntity("collect-aquatic", "采集-水产类", "collect", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("溶解氧"), "溶解氧", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("PH"), "PH", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("氨氮"), "氨氮", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("严硝酸盐"), "严硝酸盐", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("水温"), "水温", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("水位"), "水位", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("重金属"), "重金属", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("亚硝酸盐"), "亚硝酸盐", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("水产类备用1"), "水产类备用1", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("水产类备用2"), "水产类备用2", "collect-aquatic", "水产类");
            AddEntity("collect-aquatic-" + PinYin.Get("水产类备用3"), "水产类备用3", "collect-aquatic", "水产类");

            AddEntity("control", "控制", "", "控制设备类型");
            //设施
            AddEntity("control-facility", "控制-设施类", "control", "设施类");
            AddEntity("control-facility-" + PinYin.Get("风机"), "风机", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("循环风机"), "循环风机", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("湿帘"), "湿帘", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("内保温"), "内保温", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("外遮阳"), "外遮阳", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("侧窗"), "侧窗", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("天窗"), "天窗", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("加热空调"), "加热空调", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("降温空调"), "降温空调", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("喷灌"), "喷灌", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("滴灌"), "滴灌", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("设施类备用1"), "设施类备用1", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("设施类备用2"), "设施类备用2", "control-facility", "设施类");
            AddEntity("control-facility-" + PinYin.Get("设施类备用3"), "设施类备用3", "control-facility", "设施类");
            //水产
            AddEntity("control-aquatic", "控制-水产类", "control", "水产类");
            AddEntity("control-aquatic-" + PinYin.Get("增氧设备"), "增氧设备", "control-aquatic", "水产类");
            AddEntity("control-aquatic-" + PinYin.Get("投料机"), "投料机", "control-aquatic", "水产类");
            AddEntity("control-aquatic-" + PinYin.Get("水产类备用1"), "水产类备用1", "control-aquatic", "水产类");
            AddEntity("control-aquatic-" + PinYin.Get("水产类备用2"), "水产类备用2", "control-aquatic", "水产类");
            AddEntity("control-aquatic-" + PinYin.Get("水产类备用3"), "水产类备用3", "control-aquatic", "水产类");

            if (XTrace.Debug)
                XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof (TEntity).Name, Meta.Table.DataTable.DisplayName);
        }

        private void AddEntity(string serialnum, string name, string parent, string description)
        {
            var entity = new DeviceType();
            entity.Serialnum = serialnum;
            entity.Name = name;
            entity.ParentSerialnum = parent;
            entity.PhotoUrl = "DeviceType/" + PinYin.GetFirst(name) + ".png";
            entity.Introduce = description;
            entity.CreateTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;
            entity.Remark = "systype";
            entity.Insert();
        }

        protected override int OnUpdate()
        {
            // 如果Remark为systype，则无法修改
            if (this.Remark == "systype")
            {
                return 0;
            }

            return base.OnUpdate();
        }

        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            if (ControlDeviceUnits != null) ControlDeviceUnits.Delete();
            if (Sensors != null) Sensors.Delete();

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

        /// <summary>该设备类型所拥有的控制设备集合</summary>
        [XmlIgnore]
        public EntityList<ControlDeviceUnit> ControlDeviceUnits
        {
            get
            {
                if (_ControlDeviceUnits == null && !String.IsNullOrEmpty(Serialnum) &&
                    !Dirtys.ContainsKey("ControlDeviceUnits"))
                {
                    _ControlDeviceUnits = ControlDeviceUnit.FindAllByDeviceTypeSerialnum(Serialnum);
                    Dirtys["ControlDeviceUnits"] = true;
                }
                return _ControlDeviceUnits;
            }
            set { _ControlDeviceUnits = value; }
        }

        [NonSerialized] private EntityList<Sensor> _Sensors;

        /// <summary>该设备类型所拥有的传感器集合</summary>
        [XmlIgnore]
        public EntityList<Sensor> Sensors
        {
            get
            {
                if (_Sensors == null && !String.IsNullOrEmpty(Serialnum) && !Dirtys.ContainsKey("Sensors"))
                {
                    _Sensors = Sensor.FindAllByDeviceTypeSerialnum(Serialnum);
                    Dirtys["Sensors"] = true;
                }
                return _Sensors;
            }
            set { _Sensors = value; }
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

        /// <summary>根据编码查找</summary>
        /// <param name="serialnum">编码</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindBySerialnum(String serialnum)
        {
            if (Meta.Count >= 1000)
                return Find(__.Serialnum, serialnum);
            else // 实体缓存
                return Meta.Cache.Entities.Find(__.Serialnum, serialnum);
            // 单对象缓存
            //return Meta.SingleCache[serialnum];
        }

        #endregion 扩展查询
    }
}