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
    /// <summary>农田小气候仪</summary>
    [Serializable]
    [DataObject]
    [Description("农田小气候仪")]
    [BindIndex("IX_WeatherStation_SysDepartmentSerialnum", false, "SysDepartmentSerialnum")]
    [BindIndex("PK__WeatherS__E3E7488DBD95E875", true, "Serialnum")]
    [BindRelation("Serialnum", true, "WeatherDevice", "WeatherStationSerialnum")]
    [BindRelation("SysDepartmentSerialnum", false, "SysDepartment", "Serialnum")]
    [BindTable("WeatherStation", Description = "农田小气候仪", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class WeatherStation : IWeatherStation
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
        /// <summary>机构编码</summary>
        [DisplayName("机构编码")]
        [Description("机构编码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "SysDepartmentSerialnum", "机构编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysDepartmentSerialnum
        {
            get { return _SysDepartmentSerialnum; }
            set { if (OnPropertyChanging(__.SysDepartmentSerialnum, value)) { _SysDepartmentSerialnum = value; OnPropertyChanged(__.SysDepartmentSerialnum); } }
        }

        private String _Location;
        /// <summary>安装位置</summary>
        [DisplayName("安装位置")]
        [Description("安装位置")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(7, "Location", "安装位置", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Location
        {
            get { return _Location; }
            set { if (OnPropertyChanging(__.Location, value)) { _Location = value; OnPropertyChanged(__.Location); } }
        }

        private String _Lotitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "Lotitude", "经度", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Lotitude
        {
            get { return _Lotitude; }
            set { if (OnPropertyChanging(__.Lotitude, value)) { _Lotitude = value; OnPropertyChanged(__.Lotitude); } }
        }

        private String _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "Latitude", "纬度", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Latitude
        {
            get { return _Latitude; }
            set { if (OnPropertyChanging(__.Latitude, value)) { _Latitude = value; OnPropertyChanged(__.Latitude); } }
        }

        private DateTime _SetupTime;
        /// <summary>安装时间</summary>
        [DisplayName("安装时间")]
        [Description("安装时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(10, "SetupTime", "安装时间", null, "datetime", 3, 0, false)]
        public virtual DateTime SetupTime
        {
            get { return _SetupTime; }
            set { if (OnPropertyChanging(__.SetupTime, value)) { _SetupTime = value; OnPropertyChanged(__.SetupTime); } }
        }

        private Int32 _UploadExperiod;
        /// <summary>数据上传频率（几分钟上传一次）</summary>
        [DisplayName("数据上传频率几分钟上传一次")]
        [Description("数据上传频率（几分钟上传一次）")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "UploadExperiod", "数据上传频率（几分钟上传一次）", null, "int", 10, 0, false)]
        public virtual Int32 UploadExperiod
        {
            get { return _UploadExperiod; }
            set { if (OnPropertyChanging(__.UploadExperiod, value)) { _UploadExperiod = value; OnPropertyChanged(__.UploadExperiod); } }
        }

        private String _Introduce;
        /// <summary>介绍</summary>
        [DisplayName("介绍")]
        [Description("介绍")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(12, "Introduce", "介绍", null, "ntext", 0, 0, true)]
        public virtual String Introduce
        {
            get { return _Introduce; }
            set { if (OnPropertyChanging(__.Introduce, value)) { _Introduce = value; OnPropertyChanged(__.Introduce); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(13, "Sort", "排序", null, "int", 10, 0, false)]
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
        [BindColumn(14, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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
                    case __.SysDepartmentSerialnum : return _SysDepartmentSerialnum;
                    case __.Location : return _Location;
                    case __.Lotitude : return _Lotitude;
                    case __.Latitude : return _Latitude;
                    case __.SetupTime : return _SetupTime;
                    case __.UploadExperiod : return _UploadExperiod;
                    case __.Introduce : return _Introduce;
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
                    case __.SysDepartmentSerialnum : _SysDepartmentSerialnum = Convert.ToString(value); break;
                    case __.Location : _Location = Convert.ToString(value); break;
                    case __.Lotitude : _Lotitude = Convert.ToString(value); break;
                    case __.Latitude : _Latitude = Convert.ToString(value); break;
                    case __.SetupTime : _SetupTime = Convert.ToDateTime(value); break;
                    case __.UploadExperiod : _UploadExperiod = Convert.ToInt32(value); break;
                    case __.Introduce : _Introduce = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得农田小气候仪字段信息的快捷方式</summary>
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

            ///<summary>机构编码</summary>
            public static readonly Field SysDepartmentSerialnum = FindByName(__.SysDepartmentSerialnum);

            ///<summary>安装位置</summary>
            public static readonly Field Location = FindByName(__.Location);

            ///<summary>经度</summary>
            public static readonly Field Lotitude = FindByName(__.Lotitude);

            ///<summary>纬度</summary>
            public static readonly Field Latitude = FindByName(__.Latitude);

            ///<summary>安装时间</summary>
            public static readonly Field SetupTime = FindByName(__.SetupTime);

            ///<summary>数据上传频率（几分钟上传一次）</summary>
            public static readonly Field UploadExperiod = FindByName(__.UploadExperiod);

            ///<summary>介绍</summary>
            public static readonly Field Introduce = FindByName(__.Introduce);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得农田小气候仪字段名称的快捷方式</summary>
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

            ///<summary>机构编码</summary>
            public const String SysDepartmentSerialnum = "SysDepartmentSerialnum";

            ///<summary>安装位置</summary>
            public const String Location = "Location";

            ///<summary>经度</summary>
            public const String Lotitude = "Lotitude";

            ///<summary>纬度</summary>
            public const String Latitude = "Latitude";

            ///<summary>安装时间</summary>
            public const String SetupTime = "SetupTime";

            ///<summary>数据上传频率（几分钟上传一次）</summary>
            public const String UploadExperiod = "UploadExperiod";

            ///<summary>介绍</summary>
            public const String Introduce = "Introduce";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>农田小气候仪接口</summary>
    public partial interface IWeatherStation
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

        /// <summary>机构编码</summary>
        String SysDepartmentSerialnum { get; set; }

        /// <summary>安装位置</summary>
        String Location { get; set; }

        /// <summary>经度</summary>
        String Lotitude { get; set; }

        /// <summary>纬度</summary>
        String Latitude { get; set; }

        /// <summary>安装时间</summary>
        DateTime SetupTime { get; set; }

        /// <summary>数据上传频率（几分钟上传一次）</summary>
        Int32 UploadExperiod { get; set; }

        /// <summary>介绍</summary>
        String Introduce { get; set; }

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