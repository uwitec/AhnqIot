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
using System.Linq;
using System.Xml.Serialization;
using XCode;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>基地设施</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class Facility : Facility<Facility>
    {
    }

    /// <summary>基地设施</summary>
    public partial class Facility<TEntity> : LogEntity<TEntity> where TEntity : Facility<TEntity>, new()
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

        static Facility()
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

        //    var entity = new Facility();
        //    entity.Code1 = "abc";
        //    entity.Code2 = "abc";
        //    entity.Code3 = "abc";
        //    entity.Name = "abc";
        //    entity.FarmID = 0;
        //    entity.FacilityTypeSerialnum = "abc";
        //    entity.PhotoUrl = "abc";
        //    entity.Address = "abc";
        //    entity.ContactMan = "abc";
        //    entity.ContactPhone = "abc";
        //    entity.ContactMobile = "abc";
        //    entity.Status = true;
        //    entity.CreateTime = DateTime.Now;
        //    entity.UpdateTime = DateTime.Now;
        //    entity.Introduce = "abc";
        //    entity.Version = 0;
        //    entity.Upload = true;
        //    entity.Remark = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof(TEntity).Name, Meta.Table.DataTable.DisplayName);
        //}

        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            if (FacilityCameras != null) FacilityCameras.Delete();
            if (FacilityControlDeviceUnits != null) FacilityControlDeviceUnits.Delete();
            if (FacilitySensorDeviceUnits != null) FacilitySensorDeviceUnits.Delete();

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

        [NonSerialized] private FacilityType _FacilityType;

        /// <summary>该基地设施所对应的设施类型</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        public FacilityType FacilityType
        {
            get
            {
                if (_FacilityType == null && !String.IsNullOrEmpty(FacilityTypeSerialnum) &&
                    !Dirtys.ContainsKey("FacilityType"))
                {
                    _FacilityType = FacilityType.FindBySerialnum(FacilityTypeSerialnum);
                    Dirtys["FacilityType"] = true;
                }
                return _FacilityType;
            }
            set { _FacilityType = value; }
        }

        /// <summary>该基地设施所对应的设施类型名称</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        public String FacilityTypeName
        {
            get { return FacilityType != null ? FacilityType.Name : String.Empty; }
        }

        [NonSerialized] private Farm _Farm;

        /// <summary>该基地设施所对应的基地</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        public Farm Farm
        {
            get
            {
                if (_Farm == null && FarmID > 0 && !Dirtys.ContainsKey("Farm"))
                {
                    _Farm = Farm.FindByID(FarmID);
                    Dirtys["Farm"] = true;
                }
                return _Farm;
            }
            set { _Farm = value; }
        }

        /// <summary>该基地设施所对应的基地名称</summary>
        [XmlIgnore]
        [Category("扩展属性")]
        public String FarmName
        {
            get { return Farm != null ? Farm.Name : String.Empty; }
        }

        [NonSerialized] private EntityList<FacilityCamera> _FacilityCameras;

        /// <summary>该基地设施所拥有的设施摄像机集合</summary>
        [XmlIgnore]
        [Category("扩展属性"), TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityList<FacilityCamera> FacilityCameras
        {
            get
            {
                if (_FacilityCameras == null && ID > 0 && !Dirtys.ContainsKey("FacilityCameras"))
                {
                    _FacilityCameras = FacilityCamera.FindAllByFacilityID(ID);
                    Dirtys["FacilityCameras"] = true;
                }
                return _FacilityCameras;
            }
            set { _FacilityCameras = value; }
        }

        [NonSerialized] private EntityList<FacilityControlDeviceUnit> _FacilityControlDeviceUnits;

        /// <summary>该基地设施所拥有的设施控制设备集合</summary>
        [XmlIgnore]
        [Category("扩展属性"), TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityList<FacilityControlDeviceUnit> FacilityControlDeviceUnits
        {
            get
            {
                if (_FacilityControlDeviceUnits==null && ID > 0 && !Dirtys.ContainsKey("FacilityControlDeviceUnits"))
                {
                    _FacilityControlDeviceUnits = FacilityControlDeviceUnit.FindAllByFacilityID(ID);
                    Dirtys["FacilityControlDeviceUnits"] = true;
                }
                return _FacilityControlDeviceUnits;
            }
            set { _FacilityControlDeviceUnits = value; }
        }

        [NonSerialized] private EntityList<FacilitySensorDeviceUnit> _FacilitySensorDeviceUnits;

        /// <summary>该基地设施所拥有的设施传感器设备集合</summary>
        [XmlIgnore]
        [Category("扩展属性"), TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityList<FacilitySensorDeviceUnit> FacilitySensorDeviceUnits
        {
            get
            {
                //if (_FacilitySensorDeviceUnits == null && ID > 0 && !Dirtys.ContainsKey("FacilitySensorDeviceUnits"))
                //{
                _FacilitySensorDeviceUnits = FacilitySensorDeviceUnit.FindAllByFacilityID(ID);
                //    Dirtys["FacilitySensorDeviceUnits"] = true;
                //}
                return _FacilitySensorDeviceUnits;
            }
            set { _FacilitySensorDeviceUnits = value; }
        }



        private string _Farms;
        [Category("关联选项"), DisplayName("所属基地")]
        [Description("所属基地"), TypeConverter(typeof(FarmConverter))]
        public string Farms
        {
            get
            {
                return _Farms;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _Farms = value; }
        }

        private string _FacilityTypes;
        [Category("关联选项"), DisplayName("设施类型")]
        [Description("设施类型"), TypeConverter(typeof(FacilityTypeConverter))]
        public string FacilityTypes
        {
            get
            {
                return _FacilityTypes;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _FacilityTypes = value; }
        }
        #endregion 扩展属性

        #region 扩展查询

        /// <summary>根据基地查找</summary>
        /// <param name="farmid">基地</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByFarmID(Int32 farmid)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.FarmID, farmid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.FarmID, farmid);
        }

        /// <summary>根据设施类型查找</summary>
        /// <param name="facilitytypeserialnum">设施类型</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByFacilityTypeSerialnum(String facilitytypeserialnum)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.FacilityTypeSerialnum, facilitytypeserialnum);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.FacilityTypeSerialnum, facilitytypeserialnum);
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

        #region 业务

        public String GetCode1()
        {
            //基地
            var farm = Farm.FindByID(FarmID);
            //所有基地下所有设施
            var list = farm.Facilitys.ToList().OrderByDescending(e => e.Code1);

            var isNew = this.ID < 1;
            if (isNew) //新增
            {
                if (list.Any())
                {
                    var f = list.ElementAt(0);
                    return farm.Code1 + "G" +
                           (Convert.ToInt32(f.Code1.Replace(f.Code1.Substring(0, farm.Code1.Length) + "G", "")) + 1)
                               .ToString().PadLeft(3, '0');
                }
            }
            else
            {
                if (list.Any())
                {
                    var f = list.ElementAt(0);
                    if (!f.Code1.IsNullOrWhiteSpace())
                    {
                        if ((Code1 + "").StartsWith(farm.Code1)) return Code1;

                        //更换基地编码
                        var newCode = f.Code1.Replace(f.Code1.Substring(0, farm.Code1.Length), farm.Code1);
                        if (Find(_.Code1, newCode) != null)
                        {
                            return farm.Code1 + "G" +
                                   (Convert.ToInt32(f.Code1.Replace(f.Code1.Substring(0, farm.Code1.Length) + "G", "")) +
                                    1)
                                       .ToString().PadLeft(3, '0');
                        }
                        return newCode;
                    }
                }
            }
            return farm.Code1 + "G" + 1.ToString().PadLeft(3, '0');
        }

        public static String GetCode2(int farmId)
        {
            var farm = Farm.FindByID(farmId);

            var list = FindAll(_.FarmID, farmId);
            if (list.Count > 0)
            {
                var f = list[0];
                if (!f._Code2.IsNullOrWhiteSpace())

                    return farm.Code2 + "G" +
                           (Convert.ToInt32(f.Code2.Replace(farm.Code2 + "G", "")) + 1).ToString().PadLeft(3, '0');
            }
            return farm.Code1 + "G" + 1.ToString().PadLeft(3, '0');
        }

        public static String GetCode3(int farmId)
        {
            var farm = Farm.FindByID(farmId);

            var list = FindAll(_.FarmID, farmId);
            if (list.Count > 0)
            {
                var f = list[0];
                if (!f._Code3.IsNullOrWhiteSpace())

                    return farm.Code3 + "G" +
                           (Convert.ToInt32(f.Code3.Replace(farm.Code3 + "G", "")) + 1).ToString().PadLeft(3, '0');
            }
            return farm.Code3 + "G" + 1.ToString().PadLeft(3, '0');
        }

        #endregion 业务
    }
}