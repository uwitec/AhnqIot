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
    /// <summary>农田小气候仪设备</summary>
    [Serializable]
    [DataObject]
    [Description("农田小气候仪设备")]
    [BindIndex("IX_WeatherDevice_WeatherDeviceTypeSerialnum", false, "WeatherDeviceTypeSerialnum")]
    [BindIndex("IX_WeatherDevice_WeatherStationSerialnum", false, "WeatherStationSerialnum")]
    [BindIndex("PK__WeatherD__E3E7488D5D4DABD6", true, "Serialnum")]
    [BindRelation("WeatherDeviceTypeSerialnum", false, "WeatherDeviceType", "Serialnum")]
    [BindRelation("WeatherStationSerialnum", false, "WeatherStation", "Serialnum")]
    [BindRelation("Serialnum", true, "WeatherStationOnlineStatistics", "WeatherDeviceSerialnum")]
    [BindTable("WeatherDevice", Description = "农田小气候仪设备", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class WeatherDevice : IWeatherDevice
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

        private String _WeatherStationSerialnum;
        /// <summary>农田小气候仪</summary>
        [DisplayName("农田小气候仪")]
        [Description("农田小气候仪")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "WeatherStationSerialnum", "农田小气候仪", null, "nvarchar(50)", 0, 0, true)]
        public virtual String WeatherStationSerialnum
        {
            get { return _WeatherStationSerialnum; }
            set { if (OnPropertyChanging(__.WeatherStationSerialnum, value)) { _WeatherStationSerialnum = value; OnPropertyChanged(__.WeatherStationSerialnum); } }
        }

        private String _WeatherDeviceTypeSerialnum;
        /// <summary>设备类型</summary>
        [DisplayName("设备类型")]
        [Description("设备类型")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(8, "WeatherDeviceTypeSerialnum", "设备类型", null, "nvarchar(50)", 0, 0, true)]
        public virtual String WeatherDeviceTypeSerialnum
        {
            get { return _WeatherDeviceTypeSerialnum; }
            set { if (OnPropertyChanging(__.WeatherDeviceTypeSerialnum, value)) { _WeatherDeviceTypeSerialnum = value; OnPropertyChanged(__.WeatherDeviceTypeSerialnum); } }
        }

        private Decimal _Value;
        /// <summary>数值</summary>
        [DisplayName("数值")]
        [Description("数值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(9, "Value", "数值", null, "decimal", 18, 1, false)]
        public virtual Decimal Value
        {
            get { return _Value; }
            set { if (OnPropertyChanging(__.Value, value)) { _Value = value; OnPropertyChanged(__.Value); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(10, "Sort", "排序", null, "int", 10, 0, false)]
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
        [BindColumn(11, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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
                    case __.WeatherStationSerialnum : return _WeatherStationSerialnum;
                    case __.WeatherDeviceTypeSerialnum : return _WeatherDeviceTypeSerialnum;
                    case __.Value : return _Value;
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
                    case __.WeatherStationSerialnum : _WeatherStationSerialnum = Convert.ToString(value); break;
                    case __.WeatherDeviceTypeSerialnum : _WeatherDeviceTypeSerialnum = Convert.ToString(value); break;
                    case __.Value : _Value = Convert.ToDecimal(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得农田小气候仪设备字段信息的快捷方式</summary>
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

            ///<summary>农田小气候仪</summary>
            public static readonly Field WeatherStationSerialnum = FindByName(__.WeatherStationSerialnum);

            ///<summary>设备类型</summary>
            public static readonly Field WeatherDeviceTypeSerialnum = FindByName(__.WeatherDeviceTypeSerialnum);

            ///<summary>数值</summary>
            public static readonly Field Value = FindByName(__.Value);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得农田小气候仪设备字段名称的快捷方式</summary>
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

            ///<summary>农田小气候仪</summary>
            public const String WeatherStationSerialnum = "WeatherStationSerialnum";

            ///<summary>设备类型</summary>
            public const String WeatherDeviceTypeSerialnum = "WeatherDeviceTypeSerialnum";

            ///<summary>数值</summary>
            public const String Value = "Value";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>农田小气候仪设备接口</summary>
    public partial interface IWeatherDevice
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

        /// <summary>农田小气候仪</summary>
        String WeatherStationSerialnum { get; set; }

        /// <summary>设备类型</summary>
        String WeatherDeviceTypeSerialnum { get; set; }

        /// <summary>数值</summary>
        Decimal Value { get; set; }

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