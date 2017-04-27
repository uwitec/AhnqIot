/*
 * XCoder v6.5.5847.16174
 * 作者：soft-cq/CQ-PC
 * 时间：2016-01-04 13:59:42
 * 版权：版权所有 (C) 安徽斯玛特物联网科技有限公司 2011~2016
 * http://www.smartah.cc
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace AhnqIot.Dal
{
    /// <summary>企业设备</summary>
    [Serializable]
    [DataObject]
    [Description("企业设备")]
    [BindIndex("Index_FacilitySerialnum", false, "FacilitySerialnum")]
    [BindIndex("IX_Device_DeviceTypeSerialnum", false, "DeviceTypeSerialnum")]
    [BindIndex("IX_Device_ShowValue", false, "ShowValue")]
    [BindIndex("PK__Device__E3E7488D7CDEC0D4", true, "Serialnum")]
    [BindRelation("DeviceTypeSerialnum", false, "DeviceType", "Serialnum")]
    [BindRelation("FacilitySerialnum", false, "Facility", "Serialnum")]
    [BindRelation("Serialnum", true, "DeviceControlCommand", "DeviceSerialnum")]
    [BindRelation("Serialnum", true, "DeviceControlLog", "DeviceSerialnum")]
    [BindRelation("ShowValue", false, "DeviceControlLog", "DeviceShowValue")]
    [BindRelation("Serialnum", true, "DeviceDataExceptionLog", "DeviceSerialnum")]
    [BindRelation("Serialnum", true, "DeviceDataInfo", "DeviceSerialnum")]
    [BindRelation("Serialnum", true, "DeviceExceptionSet", "DeviceSerialnum")]
    [BindRelation("Serialnum", true, "DeviceRunLog", "DeviceSerialnum")]
    [BindRelation("Serialnum", true, "DeviceRunningStatistics", "DeviceSerialnum")]
    [BindRelation("Serialnum", true, "DeviceTimeSharingStatistics", "DeviceSerialnum")]
    [BindRelation("Serialnum", true, "ExceptionSms", "DeviceSerialnum")]
    [BindTable("Device", Description = "企业设备", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class Device : IDevice
    {
        #region 属性
        
        private String _Serialnum;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(1, "Serialnum", "编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Serialnum
        {
            get { return _Serialnum; }
            set { if (OnPropertyChanging(__.Serialnum, value)) { _Serialnum = value; OnPropertyChanged(__.Serialnum); } }
        }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(2, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateTime
        {
            get { return _CreateTime; }
            set { if (OnPropertyChanging(__.CreateTime, value)) { _CreateTime = value; OnPropertyChanged(__.CreateTime); } }
        }

        private String _CreateSysUserSerialnum;
        /// <summary>创建用户</summary>
        [DisplayName("创建用户")]
        [Description("创建用户")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "CreateSysUserSerialnum", "创建用户", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateSysUserSerialnum
        {
            get { return _CreateSysUserSerialnum; }
            set { if (OnPropertyChanging(__.CreateSysUserSerialnum, value)) { _CreateSysUserSerialnum = value; OnPropertyChanged(__.CreateSysUserSerialnum); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(4, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging(__.UpdateTime, value)) { _UpdateTime = value; OnPropertyChanged(__.UpdateTime); } }
        }

        private String _UpdateSysUserSerialnum;
        /// <summary>更新用户</summary>
        [DisplayName("更新用户")]
        [Description("更新用户")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "UpdateSysUserSerialnum", "更新用户", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UpdateSysUserSerialnum
        {
            get { return _UpdateSysUserSerialnum; }
            set { if (OnPropertyChanging(__.UpdateSysUserSerialnum, value)) { _UpdateSysUserSerialnum = value; OnPropertyChanged(__.UpdateSysUserSerialnum); } }
        }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "Name", "名称", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private String _FacilitySerialnum;
        /// <summary>设施编码</summary>
        [DisplayName("设施编码")]
        [Description("设施编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "FacilitySerialnum", "设施编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FacilitySerialnum
        {
            get { return _FacilitySerialnum; }
            set { if (OnPropertyChanging(__.FacilitySerialnum, value)) { _FacilitySerialnum = value; OnPropertyChanged(__.FacilitySerialnum); } }
        }

        private String _DeviceTypeSerialnum;
        /// <summary>设备类型</summary>
        [DisplayName("设备类型")]
        [Description("设备类型")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "DeviceTypeSerialnum", "设备类型", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DeviceTypeSerialnum
        {
            get { return _DeviceTypeSerialnum; }
            set { if (OnPropertyChanging(__.DeviceTypeSerialnum, value)) { _DeviceTypeSerialnum = value; OnPropertyChanged(__.DeviceTypeSerialnum); } }
        }

        private String _PhotoUrl;
        /// <summary>形象图片</summary>
        [DisplayName("形象图片")]
        [Description("形象图片")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(9, "PhotoUrl", "形象图片", null, "nvarchar(500)", 0, 0, true)]
        public virtual String PhotoUrl
        {
            get { return _PhotoUrl; }
            set { if (OnPropertyChanging(__.PhotoUrl, value)) { _PhotoUrl = value; OnPropertyChanged(__.PhotoUrl); } }
        }

        private Boolean _OnlineStatus;
        /// <summary>在线状态</summary>
        [DisplayName("在线状态")]
        [Description("在线状态")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(10, "OnlineStatus", "在线状态", null, "bit", 0, 0, false)]
        public virtual Boolean OnlineStatus
        {
            get { return _OnlineStatus; }
            set { if (OnPropertyChanging(__.OnlineStatus, value)) { _OnlineStatus = value; OnPropertyChanged(__.OnlineStatus); } }
        }

        private Boolean _IsException;
        /// <summary>是否数据异常</summary>
        [DisplayName("是否数据异常")]
        [Description("是否数据异常")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(11, "IsException", "是否数据异常", null, "bit", 0, 0, false)]
        public virtual Boolean IsException
        {
            get { return _IsException; }
            set { if (OnPropertyChanging(__.IsException, value)) { _IsException = value; OnPropertyChanged(__.IsException); } }
        }

        private Decimal _ProcessedValue;
        /// <summary>处理值</summary>
        [DisplayName("处理值")]
        [Description("处理值")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(12, "ProcessedValue", "处理值", null, "decimal", 18, 1, false)]
        public virtual Decimal ProcessedValue
        {
            get { return _ProcessedValue; }
            set { if (OnPropertyChanging(__.ProcessedValue, value)) { _ProcessedValue = value; OnPropertyChanged(__.ProcessedValue); } }
        }

        private String _ShowValue;
        /// <summary>显示值</summary>
        [DisplayName("显示值")]
        [Description("显示值")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(13, "ShowValue", "显示值", null, "nvarchar(500)", 0, 0, true)]
        public virtual String ShowValue
        {
            get { return _ShowValue; }
            set { if (OnPropertyChanging(__.ShowValue, value)) { _ShowValue = value; OnPropertyChanged(__.ShowValue); } }
        }

        private String _Unit;
        /// <summary>单位</summary>
        [DisplayName("单位")]
        [Description("单位")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "Unit", "单位", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Unit
        {
            get { return _Unit; }
            set { if (OnPropertyChanging(__.Unit, value)) { _Unit = value; OnPropertyChanged(__.Unit); } }
        }

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(15, "Location", "位置", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Location
        {
            get { return _Location; }
            set { if (OnPropertyChanging(__.Location, value)) { _Location = value; OnPropertyChanged(__.Location); } }
        }

        private Int32 _Status;
        /// <summary>数据状态 -1 删除 0 禁用 1 正常</summary>
        [DisplayName("数据状态-1删除0禁用1正常")]
        [Description("数据状态 -1 删除 0 禁用 1 正常")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(16, "Status", "数据状态 -1 删除 0 禁用 1 正常", null, "int", 10, 0, false)]
        public virtual Int32 Status
        {
            get { return _Status; }
            set { if (OnPropertyChanging(__.Status, value)) { _Status = value; OnPropertyChanged(__.Status); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(17, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(18, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } }
        }

        #endregion

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
                    case __.Serialnum : return _Serialnum;
                    case __.CreateTime : return _CreateTime;
                    case __.CreateSysUserSerialnum : return _CreateSysUserSerialnum;
                    case __.UpdateTime : return _UpdateTime;
                    case __.UpdateSysUserSerialnum : return _UpdateSysUserSerialnum;
                    case __.Name : return _Name;
                    case __.FacilitySerialnum : return _FacilitySerialnum;
                    case __.DeviceTypeSerialnum : return _DeviceTypeSerialnum;
                    case __.PhotoUrl : return _PhotoUrl;
                    case __.OnlineStatus : return _OnlineStatus;
                    case __.IsException : return _IsException;
                    case __.ProcessedValue : return _ProcessedValue;
                    case __.ShowValue : return _ShowValue;
                    case __.Unit : return _Unit;
                    case __.Location : return _Location;
                    case __.Status : return _Status;
                    case __.Sort : return _Sort;
                    case __.Remark : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Serialnum : _Serialnum = Convert.ToString(value); break;
                    case __.CreateTime : _CreateTime = Convert.ToDateTime(value); break;
                    case __.CreateSysUserSerialnum : _CreateSysUserSerialnum = Convert.ToString(value); break;
                    case __.UpdateTime : _UpdateTime = Convert.ToDateTime(value); break;
                    case __.UpdateSysUserSerialnum : _UpdateSysUserSerialnum = Convert.ToString(value); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.FacilitySerialnum : _FacilitySerialnum = Convert.ToString(value); break;
                    case __.DeviceTypeSerialnum : _DeviceTypeSerialnum = Convert.ToString(value); break;
                    case __.PhotoUrl : _PhotoUrl = Convert.ToString(value); break;
                    case __.OnlineStatus : _OnlineStatus = Convert.ToBoolean(value); break;
                    case __.IsException : _IsException = Convert.ToBoolean(value); break;
                    case __.ProcessedValue : _ProcessedValue = Convert.ToDecimal(value); break;
                    case __.ShowValue : _ShowValue = Convert.ToString(value); break;
                    case __.Unit : _Unit = Convert.ToString(value); break;
                    case __.Location : _Location = Convert.ToString(value); break;
                    case __.Status : _Status = Convert.ToInt32(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得企业设备字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>编码</summary>
            public static readonly Field Serialnum = FindByName(__.Serialnum);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>创建用户</summary>
            public static readonly Field CreateSysUserSerialnum = FindByName(__.CreateSysUserSerialnum);

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            ///<summary>更新用户</summary>
            public static readonly Field UpdateSysUserSerialnum = FindByName(__.UpdateSysUserSerialnum);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>设施编码</summary>
            public static readonly Field FacilitySerialnum = FindByName(__.FacilitySerialnum);

            ///<summary>设备类型</summary>
            public static readonly Field DeviceTypeSerialnum = FindByName(__.DeviceTypeSerialnum);

            ///<summary>形象图片</summary>
            public static readonly Field PhotoUrl = FindByName(__.PhotoUrl);

            ///<summary>在线状态</summary>
            public static readonly Field OnlineStatus = FindByName(__.OnlineStatus);

            ///<summary>是否数据异常</summary>
            public static readonly Field IsException = FindByName(__.IsException);

            ///<summary>处理值</summary>
            public static readonly Field ProcessedValue = FindByName(__.ProcessedValue);

            ///<summary>显示值</summary>
            public static readonly Field ShowValue = FindByName(__.ShowValue);

            ///<summary>单位</summary>
            public static readonly Field Unit = FindByName(__.Unit);

            ///<summary>位置</summary>
            public static readonly Field Location = FindByName(__.Location);

            ///<summary>数据状态 -1 删除 0 禁用 1 正常</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得企业设备字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编码</summary>
            public const String Serialnum = "Serialnum";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>创建用户</summary>
            public const String CreateSysUserSerialnum = "CreateSysUserSerialnum";

            ///<summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            ///<summary>更新用户</summary>
            public const String UpdateSysUserSerialnum = "UpdateSysUserSerialnum";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>设施编码</summary>
            public const String FacilitySerialnum = "FacilitySerialnum";

            ///<summary>设备类型</summary>
            public const String DeviceTypeSerialnum = "DeviceTypeSerialnum";

            ///<summary>形象图片</summary>
            public const String PhotoUrl = "PhotoUrl";

            ///<summary>在线状态</summary>
            public const String OnlineStatus = "OnlineStatus";

            ///<summary>是否数据异常</summary>
            public const String IsException = "IsException";

            ///<summary>处理值</summary>
            public const String ProcessedValue = "ProcessedValue";

            ///<summary>显示值</summary>
            public const String ShowValue = "ShowValue";

            ///<summary>单位</summary>
            public const String Unit = "Unit";

            ///<summary>位置</summary>
            public const String Location = "Location";

            ///<summary>数据状态 -1 删除 0 禁用 1 正常</summary>
            public const String Status = "Status";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>企业设备接口</summary>
    public partial interface IDevice
    {
        #region 属性
        /// <summary>编码</summary>
        String Serialnum { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>创建用户</summary>
        String CreateSysUserSerialnum { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>更新用户</summary>
        String UpdateSysUserSerialnum { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>设施编码</summary>
        String FacilitySerialnum { get; set; }

        /// <summary>设备类型</summary>
        String DeviceTypeSerialnum { get; set; }

        /// <summary>形象图片</summary>
        String PhotoUrl { get; set; }

        /// <summary>在线状态</summary>
        Boolean OnlineStatus { get; set; }

        /// <summary>是否数据异常</summary>
        Boolean IsException { get; set; }

        /// <summary>处理值</summary>
        Decimal ProcessedValue { get; set; }

        /// <summary>显示值</summary>
        String ShowValue { get; set; }

        /// <summary>单位</summary>
        String Unit { get; set; }

        /// <summary>位置</summary>
        String Location { get; set; }

        /// <summary>数据状态 -1 删除 0 禁用 1 正常</summary>
        Int32 Status { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        
        #endregion
    }
}