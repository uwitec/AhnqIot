/*
 * XCoder v6.5.5847.16174
 * 作者：soft-cq/CQ-PC
 * 时间：2016-01-04 14:00:47
 * 版权：版权所有 (C) 安徽斯玛特物联网科技有限公司 2011~2016
 * http://www.smartah.cc
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using NewLife.Log;
using NewLife.Web;
using NewLife.Data;
using XCode;
using XCode.Configuration;
using XCode.Membership;

namespace AhnqIot.Dal
{
    /// <summary>企业设备</summary>
    public partial class Device : Entity<Device>
    {
        #region 对象操作
        
            

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
            // 货币保留6位小数
            if (Dirtys[__.ProcessedValue]) ProcessedValue = Math.Round(ProcessedValue, 6);
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
        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}[{1}]数据……", typeof(Device).Name, Meta.Table.DataTable.DisplayName);

        //    var entity = new Device();
        //    entity.Serialnum = "abc";
        //    entity.CreateTime = DateTime.Now;
        //    entity.CreateSysUserSerialnum = "abc";
        //    entity.UpdateTime = DateTime.Now;
        //    entity.UpdateSysUserSerialnum = "abc";
        //    entity.Name = "abc";
        //    entity.FacilitySerialnum = "abc";
        //    entity.DeviceTypeSerialnum = "abc";
        //    entity.PhotoUrl = "abc";
        //    entity.OnlineStatus = true;
        //    entity.IsException = true;
        //    entity.ProcessedValue = 0;
        //    entity.ShowValue = "abc";
        //    entity.Unit = "abc";
        //    entity.Location = "abc";
        //    entity.Status = 0;
        //    entity.Sort = 0;
        //    entity.Remark = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof(Device).Name, Meta.Table.DataTable.DisplayName);
        //}

        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            if (DeviceControlCommands != null) DeviceControlCommands.Delete();
            if (DeviceControlLogs != null) DeviceControlLogs.Delete();
            if (DeviceDataExceptionLogs != null) DeviceDataExceptionLogs.Delete();
            if (DeviceDataInfos != null) DeviceDataInfos.Delete();
            if (DeviceExceptionSets != null) DeviceExceptionSets.Delete();
            if (DeviceRunLogs != null) DeviceRunLogs.Delete();
            if (DeviceRunningStatisticss != null) DeviceRunningStatisticss.Delete();
            if (DeviceTimeSharingStatisticss != null) DeviceTimeSharingStatisticss.Delete();
            if (ExceptionSmss != null) ExceptionSmss.Delete();

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

            
        #endregion

        #region 扩展属性
        
        [NonSerialized]
        private DeviceType _DeviceType;
        /// <summary>该企业设备所对应的设备类型</summary>
        [XmlIgnore]
        public DeviceType DeviceType
        {
            get
            {
                if (_DeviceType == null && !String.IsNullOrEmpty(DeviceTypeSerialnum) && !Dirtys.ContainsKey("DeviceType"))
                {
                    _DeviceType = DeviceType.FindBySerialnum(DeviceTypeSerialnum);
                    Dirtys["DeviceType"] = true;
                }
                return _DeviceType;
            }
            set { _DeviceType = value; }
        }

        /// <summary>该企业设备所对应的设备类型名称</summary>
        [XmlIgnore]
        public String DeviceTypeName { get { return DeviceType != null ? DeviceType.Name : String.Empty; } }

        [NonSerialized]
        private Facility _Facility;
        /// <summary>该企业设备所对应的基地设施</summary>
        [XmlIgnore]
        public Facility Facility
        {
            get
            {
                if (_Facility == null && !String.IsNullOrEmpty(FacilitySerialnum) && !Dirtys.ContainsKey("Facility"))
                {
                    _Facility = Facility.FindBySerialnum(FacilitySerialnum);
                    Dirtys["Facility"] = true;
                }
                return _Facility;
            }
            set { _Facility = value; }
        }

        /// <summary>该企业设备所对应的基地设施名称</summary>
        [XmlIgnore]
        public String FacilityName { get { return Facility != null ? Facility.Name : String.Empty; } }

        [NonSerialized]
        private EntityList<DeviceControlCommand> _DeviceControlCommands;
        /// <summary>该企业设备所拥有的企业设备控制指令集合</summary>
        [XmlIgnore]
        public EntityList<DeviceControlCommand> DeviceControlCommands
        {
            get
            {
                if (_DeviceControlCommands == null && !String.IsNullOrEmpty(Serialnum) && !Dirtys.ContainsKey("DeviceControlCommands"))
                {
                    _DeviceControlCommands = DeviceControlCommand.FindAllByDeviceSerialnum(Serialnum);
                    Dirtys["DeviceControlCommands"] = true;
                }
                return _DeviceControlCommands;
            }
            set { _DeviceControlCommands = value; }
        }

        [NonSerialized]
        private EntityList<DeviceControlLog> _DeviceControlLogs;
        /// <summary>该企业设备所拥有的企业设备控制日志集合</summary>
        [XmlIgnore]
        public EntityList<DeviceControlLog> DeviceControlLogs
        {
            get
            {
                if (_DeviceControlLogs == null && !String.IsNullOrEmpty(Serialnum) && !Dirtys.ContainsKey("DeviceControlLogs"))
                {
                    _DeviceControlLogs = DeviceControlLog.FindAllByDeviceSerialnum(Serialnum);
                    Dirtys["DeviceControlLogs"] = true;
                }
                return _DeviceControlLogs;
            }
            set { _DeviceControlLogs = value; }
        }

        [NonSerialized]
        private EntityList<DeviceDataExceptionLog> _DeviceDataExceptionLogs;
        /// <summary>该企业设备所拥有的企业设备数据异常记录集合</summary>
        [XmlIgnore]
        public EntityList<DeviceDataExceptionLog> DeviceDataExceptionLogs
        {
            get
            {
                if (_DeviceDataExceptionLogs == null && !String.IsNullOrEmpty(Serialnum) && !Dirtys.ContainsKey("DeviceDataExceptionLogs"))
                {
                    _DeviceDataExceptionLogs = DeviceDataExceptionLog.FindAllByDeviceSerialnum(Serialnum);
                    Dirtys["DeviceDataExceptionLogs"] = true;
                }
                return _DeviceDataExceptionLogs;
            }
            set { _DeviceDataExceptionLogs = value; }
        }

        [NonSerialized]
        private EntityList<DeviceDataInfo> _DeviceDataInfos;
        /// <summary>该企业设备所拥有的企业设备数据记录集合</summary>
        [XmlIgnore]
        public EntityList<DeviceDataInfo> DeviceDataInfos
        {
            get
            {
                if (_DeviceDataInfos == null && !String.IsNullOrEmpty(Serialnum) && !Dirtys.ContainsKey("DeviceDataInfos"))
                {
                    _DeviceDataInfos = DeviceDataInfo.FindAllByDeviceSerialnum(Serialnum);
                    Dirtys["DeviceDataInfos"] = true;
                }
                return _DeviceDataInfos;
            }
            set { _DeviceDataInfos = value; }
        }

        [NonSerialized]
        private EntityList<DeviceExceptionSet> _DeviceExceptionSets;
        /// <summary>该企业设备所拥有的设备参数异常区间集合</summary>
        [XmlIgnore]
        public EntityList<DeviceExceptionSet> DeviceExceptionSets
        {
            get
            {
                if (_DeviceExceptionSets == null && !String.IsNullOrEmpty(Serialnum) && !Dirtys.ContainsKey("DeviceExceptionSets"))
                {
                    _DeviceExceptionSets = DeviceExceptionSet.FindAllByDeviceSerialnum(Serialnum);
                    Dirtys["DeviceExceptionSets"] = true;
                }
                return _DeviceExceptionSets;
            }
            set { _DeviceExceptionSets = value; }
        }

        [NonSerialized]
        private EntityList<DeviceRunLog> _DeviceRunLogs;
        /// <summary>该企业设备所拥有的企业设备运行记录集合</summary>
        [XmlIgnore]
        public EntityList<DeviceRunLog> DeviceRunLogs
        {
            get
            {
                if (_DeviceRunLogs == null && !String.IsNullOrEmpty(Serialnum) && !Dirtys.ContainsKey("DeviceRunLogs"))
                {
                    _DeviceRunLogs = DeviceRunLog.FindAllByDeviceSerialnum(Serialnum);
                    Dirtys["DeviceRunLogs"] = true;
                }
                return _DeviceRunLogs;
            }
            set { _DeviceRunLogs = value; }
        }

        [NonSerialized]
        private EntityList<DeviceRunningStatistics> _DeviceRunningStatisticss;
        /// <summary>该企业设备所拥有的企业设备运行统计集合</summary>
        [XmlIgnore]
        public EntityList<DeviceRunningStatistics> DeviceRunningStatisticss
        {
            get
            {
                if (_DeviceRunningStatisticss == null && !String.IsNullOrEmpty(Serialnum) && !Dirtys.ContainsKey("DeviceRunningStatisticss"))
                {
                    _DeviceRunningStatisticss = DeviceRunningStatistics.FindAllByDeviceSerialnum(Serialnum);
                    Dirtys["DeviceRunningStatisticss"] = true;
                }
                return _DeviceRunningStatisticss;
            }
            set { _DeviceRunningStatisticss = value; }
        }

        [NonSerialized]
        private EntityList<DeviceTimeSharingStatistics> _DeviceTimeSharingStatisticss;
        /// <summary>该企业设备所拥有的企业分时统计数据集合</summary>
        [XmlIgnore]
        public EntityList<DeviceTimeSharingStatistics> DeviceTimeSharingStatisticss
        {
            get
            {
                if (_DeviceTimeSharingStatisticss == null && !String.IsNullOrEmpty(Serialnum) && !Dirtys.ContainsKey("DeviceTimeSharingStatisticss"))
                {
                    _DeviceTimeSharingStatisticss = DeviceTimeSharingStatistics.FindAllByDeviceSerialnum(Serialnum);
                    Dirtys["DeviceTimeSharingStatisticss"] = true;
                }
                return _DeviceTimeSharingStatisticss;
            }
            set { _DeviceTimeSharingStatisticss = value; }
        }

        [NonSerialized]
        private EntityList<ExceptionSms> _ExceptionSmss;
        /// <summary>该企业设备所拥有的企业异常短信集合</summary>
        [XmlIgnore]
        public EntityList<ExceptionSms> ExceptionSmss
        {
            get
            {
                if (_ExceptionSmss == null && !String.IsNullOrEmpty(Serialnum) && !Dirtys.ContainsKey("ExceptionSmss"))
                {
                    _ExceptionSmss = ExceptionSms.FindAllByDeviceSerialnum(Serialnum);
                    Dirtys["ExceptionSmss"] = true;
                }
                return _ExceptionSmss;
            }
            set { _ExceptionSmss = value; }
        }

            
        #endregion

        #region 扩展查询
        
            
        /// <summary>根据设施编码查找</summary>
        /// <param name="facilityserialnum">设施编码</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<Device> FindAllByFacilitySerialnum(String facilityserialnum)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.FacilitySerialnum, facilityserialnum);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.FacilitySerialnum, facilityserialnum);
        }

        /// <summary>根据设备类型查找</summary>
        /// <param name="devicetypeserialnum">设备类型</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<Device> FindAllByDeviceTypeSerialnum(String devicetypeserialnum)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.DeviceTypeSerialnum, devicetypeserialnum);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.DeviceTypeSerialnum, devicetypeserialnum);
        }

        /// <summary>根据显示值查找</summary>
        /// <param name="showvalue">显示值</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<Device> FindAllByShowValue(String showvalue)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.ShowValue, showvalue);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.ShowValue, showvalue);
        }

        /// <summary>根据编码查找</summary>
        /// <param name="serialnum">编码</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Device FindBySerialnum(String serialnum)
        {
            if (Meta.Count >= 1000)
                return Find(__.Serialnum, serialnum);
            else // 实体缓存
                return Meta.Cache.Entities.Find(__.Serialnum, serialnum);
            // 单对象缓存
            //return Meta.SingleCache[serialnum];
        }

            
        #endregion

        #region 高级查询
        
        // 以下为自定义高级查询的例子
        /// <summary>查询满足条件的记录集，分页、排序</summary>
        /// <param name="userid">用户编号</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="key">关键字</param>
        /// <param name="param">分页排序参数，同时返回满足条件的总记录数</param>
        /// <returns>实体集</returns>
        public static EntityList<Device> Search(Int32 userid, DateTime start, DateTime end, String key, PageParameter param)
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
        
        #endregion
    }
}