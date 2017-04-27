/*
 * XCoder v6.5.5660.22154
 * 作者：soft-cq/CQ-PC
 * 时间：2015-08-02 20:28:32
 * 版权：版权所有 (C) 新生命开发团队 2002~2015
*/

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using NewLife.Common;
using NewLife.Data;
using NewLife.Log;
using XCode;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>传感器</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class Sensor : Sensor<Sensor>
    {
    }

    /// <summary>传感器</summary>
    public partial class Sensor<TEntity> : LogEntity<TEntity> where TEntity : Sensor<TEntity>, new()
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

        #region 业务

        /// <summary>
        /// 添加传感器
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="devicetype"></param>
        /// <param name="unit"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="experienceMax"></param>
        /// <param name="experienceMin"></param>
        /// <param name="valueComputeString"></param>
        /// <param name="showComputeString"></param>
        /// <param name="company"></param>
        /// <param name="accuracy"></param>
        private static void AddSensor(string code, string name, string devicetype, string unit,
            decimal max, decimal min, decimal? experienceMax, decimal? experienceMin,
            string valueComputeString, string showComputeString = "",
            string company = "SmartIot", int accuracy = 0)
        {
            var entity = new Sensor
            {
                Code = code,
                DeviceTypeSerialnum = devicetype,
                Name = name,
                MaxValue = max,
                MinValue = min,
                ExperienceMax = experienceMax ?? 0,
                ExperienceMin = experienceMin ?? 0,
                Unit = unit,
                Company = company,
                Accuracy = accuracy,
                ValueComputeString = valueComputeString,
                ShowComputeString = showComputeString,
                Memo = ""
            };
            entity.Insert();
        }

        #endregion 业务

        #region 对象操作

        static Sensor()
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
            AddEntity("collect-facility-" + PinYin.Get("空气温度"), "collect-facility-" + PinYin.Get("空气温度"), "空气温度", 80,
                -20, 40, -10, "℃", "", 1, "x * 0.1", "x * 0.1 - 20", "");
            AddEntity("collect-facility-" + PinYin.Get("空气相对湿度"), "collect-facility-" + PinYin.Get("空气相对湿度"), "空气相对湿度",
                100, 0, 100, 0, "%", "", 0, "x * 0.1", "x * 0.1", "");
            AddEntity("collect-facility-" + PinYin.Get("光照度"), "collect-facility-" + PinYin.Get("光照度"), "光照度", 200000, 0,
                200000, 0, "LUX", "", 0, "x * 1", "x * 20", "");
            AddEntity("collect-facility-" + PinYin.Get("土壤湿度"), "collect-facility-" + PinYin.Get("土壤湿度"), "土壤湿度", 100, 0,
                80, 0, "%", "", 1, "x * 0.1", "x * 0.1", "");
            AddEntity("collect-facility-" + PinYin.Get("土壤湿度-模拟量"), "collect-facility-" + PinYin.Get("土壤湿度-模拟量"), "土壤湿度",
                100, 0, 80, 0, "%", "", 2, "x * 0.01", "x * 0.01", "");
            AddEntity("collect-facility-" + PinYin.Get("土壤温度"), "collect-facility-" + PinYin.Get("土壤温度"), "土壤温度", 100,
                -50, 50, -5, "℃", "", 3, "x * 0.015-50", "x * 0.015 - 50", "");

            AddEntity("collect-facility-" + PinYin.Get("水温"), "collect-aquatic-" + PinYin.Get("水温"), "水温", 80, -20, 40,
                0, "", "", 2, "x * 0.01-20", "x * 0.01-20", "");
            AddEntity("collect-facility-" + PinYin.Get("水位	"), "collect-aquatic-" + PinYin.Get("水位"), "水位	", 500, 0, 100,
                50, "mg/l", "", 2, "x *0.05", "x *0.05", "");
            AddEntity("collect-facility-" + PinYin.Get("PH"), "collect-aquatic-" + PinYin.Get("PH"), "PH", 14, 0, 9, 6,
                "", "", 4, "x * 0.0014", "x * 0.0014", "");
            AddEntity("collect-facility-" + PinYin.Get("溶解氧	"), "collect-aquatic-" + PinYin.Get("溶解氧	"), "溶解氧	", 20, 0,
                8, 2, "mg/l", "", 3, "x *0.002", "x *0.002", "");
            AddEntity("collect-facility-" + PinYin.Get("氨气"), "collect-facility-" + PinYin.Get("氨气"), "氨气", 20, 0, 3, 1,
                "mg/l", "", 3, "x * 0.002", "x *0.002", "");
            AddEntity("collect-facility-" + PinYin.Get("硫化氢"), "collect-facility-" + PinYin.Get("硫化氢"), "硫化氢", 20, 0, 3,
                0, "mg/L", "", 3, "x * 0.002", "x * 0.002", "");
            AddEntity("collect-facility-" + PinYin.Get("一氧化碳"), "collect-facility-" + PinYin.Get("一氧化碳"), "一氧化碳", 20, 0,
                1, 0, "ppm", "", 3, "x * 0.002", "x * 0.002", "");
            AddEntity("collect-facility-" + PinYin.Get("二氧化碳"), "collect-facility-" + PinYin.Get("二氧化碳"), "二氧化碳", 2000,
                0, 950, 200, "ppm", "", 0, "x * 1", "x * 1", "");
            AddEntity("collect-facility-" + PinYin.Get("日照时数"), "collect-facility-" + PinYin.Get("日照时数"), "日照时数", 24, 0,
                24, 0, "h", "", 0, "x * 0.1", "x *0.1", "");
            AddEntity("collect-facility-" + PinYin.Get("电导率"), "collect-facility-" + PinYin.Get("电导率"), "电导率", 20, 0, 5,
                4, "", "", 0, "x * 1", "x * 1", "");
            AddEntity("collect-facility-" + PinYin.Get("气象站温度"), "collect-weather-" + PinYin.Get("室外气象站温度"), "室外气象站温度",
                80, -20, 50, -10, "℃", "", 2, "x * 0.01 - 20", "x * 0.01 - 20", "");
            AddEntity("collect-facility-" + PinYin.Get("气象站湿度"), "collect-weather-" + PinYin.Get("气象站湿度"), "气象站湿度", 100,
                0, 100, 0, "%", "", 2, "x * 0.01", "x * 0.01", "");
            AddEntity("collect-facility-" + PinYin.Get("气象站光照"), "collect-weather-" + PinYin.Get("气象站光照"), "气象站光照",
                200000, 0, 200000, 0, "LUX", "", 0, "x * 20", "x * 20", "");
            AddEntity("collect-facility-" + PinYin.Get("气象站降雨量"), "collect-weather-" + PinYin.Get("气象站降雨量"), "气象站降雨量",
                100, 0, 10, 0, "mm/h", "", 2, "x * 0.01", "x * 0.01", "");
            AddEntity("collect-facility-" + PinYin.Get("气象站风速"), "collect-weather-" + PinYin.Get("气象站风速"), "气象站风速", 30,
                0, 30, 0, "m/s", "", 3, "x * 0.003", "x * 0.003", "");
            AddEntity("collect-facility-" + PinYin.Get("气象站风向"), "collect-weather-" + PinYin.Get("气象站风向"), "气象站风向", 16,
                0, 16, 0, "", "", 0, "Math.Log(x, 2)", "Math.Log(x, 2)", "");
            AddEntity("collect-facility-" + PinYin.Get("气象站雨雪"), "collect-weather-" + PinYin.Get("气象站雨雪"), "气象站雨雪", 1, 0,
                1, 0, "", "", 0, "x", "x", "");
            AddEntity("collect-facility-" + PinYin.Get("气象站气压"), "collect-weather-" + PinYin.Get("气象站气压"), "气象站气压", 1050,
                0, 1050, 0, "hPa", "", 0, "x", "x", "");
            AddEntity("collect-facility-" + PinYin.Get("继电器"), "collect-facility-" + PinYin.Get("继电器"), "继电器", 0, 0, 0,
                0, "", "", 0, "x * 1", "x * 1", "");
            AddEntity("collect-facility-" + PinYin.Get("光合作用有效辐射"), "collect-facility-" + PinYin.Get("光合作用有效辐射"),
                "光合作用有效辐射", 2000, 0, 2000, 0, "W/m2", "", 0, "x * 1", "x * 1", "");
            AddEntity("collect-facility-" + PinYin.Get("蒸发"), "collect-facility-" + PinYin.Get("蒸发"), "蒸发", 1000, 0,
                1000, 0, "mm", "", 1, "x * 0.1", "x * 0.1", "");
            if (XTrace.Debug)
                XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof (TEntity).Name, Meta.Table.DataTable.DisplayName);
        }

        private void AddEntity(string code, string deviceTypeSerialnum, string name, int maxValue, int minValue,
            int experienceMax, int experienceMin, string unit, string company, int accuracy, string valueComputeString,
            string showComputeString, string memo)
        {
            var entity = new Sensor();
            entity.Code = code;
            entity.DeviceTypeSerialnum = deviceTypeSerialnum;
            entity.Name = name;
            entity.MaxValue = maxValue;
            entity.MinValue = minValue;
            entity.ExperienceMax = experienceMax;
            entity.ExperienceMin = experienceMin;
            entity.Unit = unit;
            entity.Company = company;
            entity.Accuracy = accuracy;
            entity.ValueComputeString = valueComputeString;
            entity.ShowComputeString = showComputeString;
            entity.Memo = memo;
            entity.Insert();
        }

        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
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

        [NonSerialized] private DeviceType _DeviceType;

        /// <summary>该传感器所对应的设备类型</summary>
        [XmlIgnore]
        [Description("设备类型"), TypeConverter(typeof(ExpandableObjectConverter))]
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

        /// <summary>该传感器所对应的设备类型名称</summary>
        [XmlIgnore]
        public String DeviceTypeName
        {
            get { return DeviceType != null ? DeviceType.Name : String.Empty; }
        }

        [NonSerialized] private EntityList<SensorDeviceUnit> _SensorDeviceUnits;

        /// <summary>该传感器所拥有的传感器设备集合</summary>
        [XmlIgnore]
        public EntityList<SensorDeviceUnit> SensorDeviceUnits
        {
            get
            {
                if (_SensorDeviceUnits == null && ID > 0 && !Dirtys.ContainsKey("SensorDeviceUnits"))
                {
                    _SensorDeviceUnits = SensorDeviceUnit.FindAllBySensorId(ID);
                    Dirtys["SensorDeviceUnits"] = true;
                }
                return _SensorDeviceUnits;
            }
            set { _SensorDeviceUnits = value; }
        }

        #endregion 扩展属性

        #region 扩展查询

        /// <summary>根据编码查找</summary>
        /// <param name="code">编码</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByCode(String code)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.Code, code);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.Code, code);
        }

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

        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
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