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
    /// <summary>基地关联气象站</summary>
    [Serializable]
    [DataObject]
    [Description("基地关联气象站")]
    [BindIndex("IX_RelationWeatherStation_SysDepartmentSerialnum", false, "SysDepartmentSerialnum")]
    [BindIndex("PK__Relation__E3E7488D7AA4C791", true, "Serialnum")]
    [BindRelation("SysDepartmentSerialnum", false, "SysDepartment", "Serialnum")]
    [BindRelation("Serialnum", true, "AreaStationDataInfo", "AreaStationSerialnum")]
    [BindRelation("Serialnum", true, "Farm", "AreaStationSerialnum")]
    [BindTable("AreaStation", Description = "基地关联气象站", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class AreaStation : IAreaStation
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

        private String _SysDepartmentSerialnum;
        /// <summary>机构</summary>
        [DisplayName("机构")]
        [Description("机构")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "SysDepartmentSerialnum", "机构", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysDepartmentSerialnum
        {
            get { return _SysDepartmentSerialnum; }
            set { if (OnPropertyChanging(__.SysDepartmentSerialnum, value)) { _SysDepartmentSerialnum = value; OnPropertyChanged(__.SysDepartmentSerialnum); } }
        }

        private String _StationCode;
        /// <summary>台站号</summary>
        [DisplayName("台站号")]
        [Description("台站号")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "StationCode", "台站号", null, "nvarchar(50)", 0, 0, true)]
        public virtual String StationCode
        {
            get { return _StationCode; }
            set { if (OnPropertyChanging(__.StationCode, value)) { _StationCode = value; OnPropertyChanged(__.StationCode); } }
        }

        private Decimal _Temprature;
        /// <summary>温度</summary>
        [DisplayName("温度")]
        [Description("温度")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(8, "Temprature", "温度", null, "decimal", 18, 1, false)]
        public virtual Decimal Temprature
        {
            get { return _Temprature; }
            set { if (OnPropertyChanging(__.Temprature, value)) { _Temprature = value; OnPropertyChanged(__.Temprature); } }
        }

        private Decimal _Humidity;
        /// <summary>湿度</summary>
        [DisplayName("湿度")]
        [Description("湿度")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(9, "Humidity", "湿度", null, "decimal", 18, 0, false)]
        public virtual Decimal Humidity
        {
            get { return _Humidity; }
            set { if (OnPropertyChanging(__.Humidity, value)) { _Humidity = value; OnPropertyChanged(__.Humidity); } }
        }

        private Decimal _Rainfall;
        /// <summary>降雨量</summary>
        [DisplayName("降雨量")]
        [Description("降雨量")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(10, "Rainfall", "降雨量", null, "decimal", 18, 1, false)]
        public virtual Decimal Rainfall
        {
            get { return _Rainfall; }
            set { if (OnPropertyChanging(__.Rainfall, value)) { _Rainfall = value; OnPropertyChanged(__.Rainfall); } }
        }

        private Decimal _WindSpeed;
        /// <summary>风速</summary>
        [DisplayName("风速")]
        [Description("风速")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(11, "WindSpeed", "风速", null, "decimal", 18, 1, false)]
        public virtual Decimal WindSpeed
        {
            get { return _WindSpeed; }
            set { if (OnPropertyChanging(__.WindSpeed, value)) { _WindSpeed = value; OnPropertyChanged(__.WindSpeed); } }
        }

        private Int32 _WindDirection;
        /// <summary>风向</summary>
        [DisplayName("风向")]
        [Description("风向")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(12, "WindDirection", "风向", null, "int", 10, 0, false)]
        public virtual Int32 WindDirection
        {
            get { return _WindDirection; }
            set { if (OnPropertyChanging(__.WindDirection, value)) { _WindDirection = value; OnPropertyChanged(__.WindDirection); } }
        }

        private Decimal _Atmosphere;
        /// <summary>大气压</summary>
        [DisplayName("大气压")]
        [Description("大气压")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(13, "Atmosphere", "大气压", null, "decimal", 18, 1, false)]
        public virtual Decimal Atmosphere
        {
            get { return _Atmosphere; }
            set { if (OnPropertyChanging(__.Atmosphere, value)) { _Atmosphere = value; OnPropertyChanged(__.Atmosphere); } }
        }

        private String _Addr;
        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(14, "Addr", "地址", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Addr
        {
            get { return _Addr; }
            set { if (OnPropertyChanging(__.Addr, value)) { _Addr = value; OnPropertyChanged(__.Addr); } }
        }

        private String _Lontitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "Lontitude", "经度", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Lontitude
        {
            get { return _Lontitude; }
            set { if (OnPropertyChanging(__.Lontitude, value)) { _Lontitude = value; OnPropertyChanged(__.Lontitude); } }
        }

        private String _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(16, "Latitude", "纬度", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Latitude
        {
            get { return _Latitude; }
            set { if (OnPropertyChanging(__.Latitude, value)) { _Latitude = value; OnPropertyChanged(__.Latitude); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(17, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(18, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
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
                    case __.SysDepartmentSerialnum : return _SysDepartmentSerialnum;
                    case __.StationCode : return _StationCode;
                    case __.Temprature : return _Temprature;
                    case __.Humidity : return _Humidity;
                    case __.Rainfall : return _Rainfall;
                    case __.WindSpeed : return _WindSpeed;
                    case __.WindDirection : return _WindDirection;
                    case __.Atmosphere : return _Atmosphere;
                    case __.Addr : return _Addr;
                    case __.Lontitude : return _Lontitude;
                    case __.Latitude : return _Latitude;
                    case __.Remark : return _Remark;
                    case __.Sort : return _Sort;
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
                    case __.SysDepartmentSerialnum : _SysDepartmentSerialnum = Convert.ToString(value); break;
                    case __.StationCode : _StationCode = Convert.ToString(value); break;
                    case __.Temprature : _Temprature = Convert.ToDecimal(value); break;
                    case __.Humidity : _Humidity = Convert.ToDecimal(value); break;
                    case __.Rainfall : _Rainfall = Convert.ToDecimal(value); break;
                    case __.WindSpeed : _WindSpeed = Convert.ToDecimal(value); break;
                    case __.WindDirection : _WindDirection = Convert.ToInt32(value); break;
                    case __.Atmosphere : _Atmosphere = Convert.ToDecimal(value); break;
                    case __.Addr : _Addr = Convert.ToString(value); break;
                    case __.Lontitude : _Lontitude = Convert.ToString(value); break;
                    case __.Latitude : _Latitude = Convert.ToString(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得基地关联气象站字段信息的快捷方式</summary>
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

            ///<summary>机构</summary>
            public static readonly Field SysDepartmentSerialnum = FindByName(__.SysDepartmentSerialnum);

            ///<summary>台站号</summary>
            public static readonly Field StationCode = FindByName(__.StationCode);

            ///<summary>温度</summary>
            public static readonly Field Temprature = FindByName(__.Temprature);

            ///<summary>湿度</summary>
            public static readonly Field Humidity = FindByName(__.Humidity);

            ///<summary>降雨量</summary>
            public static readonly Field Rainfall = FindByName(__.Rainfall);

            ///<summary>风速</summary>
            public static readonly Field WindSpeed = FindByName(__.WindSpeed);

            ///<summary>风向</summary>
            public static readonly Field WindDirection = FindByName(__.WindDirection);

            ///<summary>大气压</summary>
            public static readonly Field Atmosphere = FindByName(__.Atmosphere);

            ///<summary>地址</summary>
            public static readonly Field Addr = FindByName(__.Addr);

            ///<summary>经度</summary>
            public static readonly Field Lontitude = FindByName(__.Lontitude);

            ///<summary>纬度</summary>
            public static readonly Field Latitude = FindByName(__.Latitude);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得基地关联气象站字段名称的快捷方式</summary>
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

            ///<summary>机构</summary>
            public const String SysDepartmentSerialnum = "SysDepartmentSerialnum";

            ///<summary>台站号</summary>
            public const String StationCode = "StationCode";

            ///<summary>温度</summary>
            public const String Temprature = "Temprature";

            ///<summary>湿度</summary>
            public const String Humidity = "Humidity";

            ///<summary>降雨量</summary>
            public const String Rainfall = "Rainfall";

            ///<summary>风速</summary>
            public const String WindSpeed = "WindSpeed";

            ///<summary>风向</summary>
            public const String WindDirection = "WindDirection";

            ///<summary>大气压</summary>
            public const String Atmosphere = "Atmosphere";

            ///<summary>地址</summary>
            public const String Addr = "Addr";

            ///<summary>经度</summary>
            public const String Lontitude = "Lontitude";

            ///<summary>纬度</summary>
            public const String Latitude = "Latitude";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

        }
        
        #endregion
    }

    /// <summary>基地关联气象站接口</summary>
    public partial interface IAreaStation
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

        /// <summary>机构</summary>
        String SysDepartmentSerialnum { get; set; }

        /// <summary>台站号</summary>
        String StationCode { get; set; }

        /// <summary>温度</summary>
        Decimal Temprature { get; set; }

        /// <summary>湿度</summary>
        Decimal Humidity { get; set; }

        /// <summary>降雨量</summary>
        Decimal Rainfall { get; set; }

        /// <summary>风速</summary>
        Decimal WindSpeed { get; set; }

        /// <summary>风向</summary>
        Int32 WindDirection { get; set; }

        /// <summary>大气压</summary>
        Decimal Atmosphere { get; set; }

        /// <summary>地址</summary>
        String Addr { get; set; }

        /// <summary>经度</summary>
        String Lontitude { get; set; }

        /// <summary>纬度</summary>
        String Latitude { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        
        #endregion
    }
}