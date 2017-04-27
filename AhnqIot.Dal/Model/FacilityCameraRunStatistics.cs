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
    /// <summary>基地摄像机运行统计</summary>
    [Serializable]
    [DataObject]
    [Description("基地摄像机运行统计")]
    [BindIndex("IX_FarmCameraRunStatistics_FarmSerialnum", false, "FacilitySerialnum")]
    [BindIndex("PK__FarmCame__E3E7488D5DC0190F", true, "Serialnum")]
    [BindRelation("FacilitySerialnum", false, "Facility", "Serialnum")]
    [BindTable("FacilityCameraRunStatistics", Description = "基地摄像机运行统计", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class FacilityCameraRunStatistics : IFacilityCameraRunStatistics
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

        private String _FacilitySerialnum;
        /// <summary>基地编码</summary>
        [DisplayName("基地编码")]
        [Description("基地编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "FacilitySerialnum", "基地编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FacilitySerialnum
        {
            get { return _FacilitySerialnum; }
            set { if (OnPropertyChanging(__.FacilitySerialnum, value)) { _FacilitySerialnum = value; OnPropertyChanged(__.FacilitySerialnum); } }
        }

        private Int32 _Year;
        /// <summary>年</summary>
        [DisplayName("年")]
        [Description("年")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "Year", "年", null, "int", 10, 0, false)]
        public virtual Int32 Year
        {
            get { return _Year; }
            set { if (OnPropertyChanging(__.Year, value)) { _Year = value; OnPropertyChanged(__.Year); } }
        }

        private Int32 _Month;
        /// <summary>月</summary>
        [DisplayName("月")]
        [Description("月")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(8, "Month", "月", null, "int", 10, 0, false)]
        public virtual Int32 Month
        {
            get { return _Month; }
            set { if (OnPropertyChanging(__.Month, value)) { _Month = value; OnPropertyChanged(__.Month); } }
        }

        private Int32 _Day;
        /// <summary>天</summary>
        [DisplayName("天")]
        [Description("天")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(9, "Day", "天", null, "int", 10, 0, false)]
        public virtual Int32 Day
        {
            get { return _Day; }
            set { if (OnPropertyChanging(__.Day, value)) { _Day = value; OnPropertyChanged(__.Day); } }
        }

        private Int32 _OnlineCount;
        /// <summary>在线次数</summary>
        [DisplayName("在线次数")]
        [Description("在线次数")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(10, "OnlineCount", "在线次数", null, "int", 10, 0, false)]
        public virtual Int32 OnlineCount
        {
            get { return _OnlineCount; }
            set { if (OnPropertyChanging(__.OnlineCount, value)) { _OnlineCount = value; OnPropertyChanged(__.OnlineCount); } }
        }

        private Int32 _AllCount;
        /// <summary>总次数</summary>
        [DisplayName("总次数")]
        [Description("总次数")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "AllCount", "总次数", null, "int", 10, 0, false)]
        public virtual Int32 AllCount
        {
            get { return _AllCount; }
            set { if (OnPropertyChanging(__.AllCount, value)) { _AllCount = value; OnPropertyChanged(__.AllCount); } }
        }

        private Decimal _OnlinePercent;
        /// <summary>在线率</summary>
        [DisplayName("在线率")]
        [Description("在线率")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(12, "OnlinePercent", "在线率", null, "decimal", 18, 1, false)]
        public virtual Decimal OnlinePercent
        {
            get { return _OnlinePercent; }
            set { if (OnPropertyChanging(__.OnlinePercent, value)) { _OnlinePercent = value; OnPropertyChanged(__.OnlinePercent); } }
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
                    case __.FacilitySerialnum : return _FacilitySerialnum;
                    case __.Year : return _Year;
                    case __.Month : return _Month;
                    case __.Day : return _Day;
                    case __.OnlineCount : return _OnlineCount;
                    case __.AllCount : return _AllCount;
                    case __.OnlinePercent : return _OnlinePercent;
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
                    case __.FacilitySerialnum : _FacilitySerialnum = Convert.ToString(value); break;
                    case __.Year : _Year = Convert.ToInt32(value); break;
                    case __.Month : _Month = Convert.ToInt32(value); break;
                    case __.Day : _Day = Convert.ToInt32(value); break;
                    case __.OnlineCount : _OnlineCount = Convert.ToInt32(value); break;
                    case __.AllCount : _AllCount = Convert.ToInt32(value); break;
                    case __.OnlinePercent : _OnlinePercent = Convert.ToDecimal(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得基地摄像机运行统计字段信息的快捷方式</summary>
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

            ///<summary>基地编码</summary>
            public static readonly Field FacilitySerialnum = FindByName(__.FacilitySerialnum);

            ///<summary>年</summary>
            public static readonly Field Year = FindByName(__.Year);

            ///<summary>月</summary>
            public static readonly Field Month = FindByName(__.Month);

            ///<summary>天</summary>
            public static readonly Field Day = FindByName(__.Day);

            ///<summary>在线次数</summary>
            public static readonly Field OnlineCount = FindByName(__.OnlineCount);

            ///<summary>总次数</summary>
            public static readonly Field AllCount = FindByName(__.AllCount);

            ///<summary>在线率</summary>
            public static readonly Field OnlinePercent = FindByName(__.OnlinePercent);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得基地摄像机运行统计字段名称的快捷方式</summary>
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

            ///<summary>基地编码</summary>
            public const String FacilitySerialnum = "FacilitySerialnum";

            ///<summary>年</summary>
            public const String Year = "Year";

            ///<summary>月</summary>
            public const String Month = "Month";

            ///<summary>天</summary>
            public const String Day = "Day";

            ///<summary>在线次数</summary>
            public const String OnlineCount = "OnlineCount";

            ///<summary>总次数</summary>
            public const String AllCount = "AllCount";

            ///<summary>在线率</summary>
            public const String OnlinePercent = "OnlinePercent";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>基地摄像机运行统计接口</summary>
    public partial interface IFacilityCameraRunStatistics
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

        /// <summary>基地编码</summary>
        String FacilitySerialnum { get; set; }

        /// <summary>年</summary>
        Int32 Year { get; set; }

        /// <summary>月</summary>
        Int32 Month { get; set; }

        /// <summary>天</summary>
        Int32 Day { get; set; }

        /// <summary>在线次数</summary>
        Int32 OnlineCount { get; set; }

        /// <summary>总次数</summary>
        Int32 AllCount { get; set; }

        /// <summary>在线率</summary>
        Decimal OnlinePercent { get; set; }

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