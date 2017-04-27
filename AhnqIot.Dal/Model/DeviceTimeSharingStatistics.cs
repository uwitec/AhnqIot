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
    /// <summary>企业分时统计数据</summary>
    [Serializable]
    [DataObject]
    [Description("企业分时统计数据")]
    [BindIndex("Index_DSAndCreateTime", false, "DeviceSerialnum,CreateTime")]
    [BindIndex("IX_CompanyTimeSharingStatistics_DeviceSerialnum", false, "DeviceSerialnum")]
    [BindIndex("PK__CompanyT__E3E7488D3F4BD157", true, "Serialnum")]
    [BindRelation("DeviceSerialnum", false, "Device", "Serialnum")]
    [BindTable("DeviceTimeSharingStatistics", Description = "企业分时统计数据", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class DeviceTimeSharingStatistics : IDeviceTimeSharingStatistics
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

        private String _DeviceSerialnum;
        /// <summary>设施编码</summary>
        [DisplayName("设施编码")]
        [Description("设施编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "DeviceSerialnum", "设施编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DeviceSerialnum
        {
            get { return _DeviceSerialnum; }
            set { if (OnPropertyChanging(__.DeviceSerialnum, value)) { _DeviceSerialnum = value; OnPropertyChanged(__.DeviceSerialnum); } }
        }

        private Int32 _TimeSharing;
        /// <summary>分时时段</summary>
        [DisplayName("分时时段")]
        [Description("分时时段")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "TimeSharing", "分时时段", null, "int", 10, 0, false)]
        public virtual Int32 TimeSharing
        {
            get { return _TimeSharing; }
            set { if (OnPropertyChanging(__.TimeSharing, value)) { _TimeSharing = value; OnPropertyChanged(__.TimeSharing); } }
        }

        private Decimal _AvgValue;
        /// <summary>平均</summary>
        [DisplayName("平均")]
        [Description("平均")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(8, "AvgValue", "平均", null, "decimal", 18, 1, false)]
        public virtual Decimal AvgValue
        {
            get { return _AvgValue; }
            set { if (OnPropertyChanging(__.AvgValue, value)) { _AvgValue = value; OnPropertyChanged(__.AvgValue); } }
        }

        private Decimal _StartValue;
        /// <summary>开始值</summary>
        [DisplayName("开始值")]
        [Description("开始值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(9, "StartValue", "开始值", null, "decimal", 18, 1, false)]
        public virtual Decimal StartValue
        {
            get { return _StartValue; }
            set { if (OnPropertyChanging(__.StartValue, value)) { _StartValue = value; OnPropertyChanged(__.StartValue); } }
        }

        private Decimal _EndValue;
        /// <summary>结束值</summary>
        [DisplayName("结束值")]
        [Description("结束值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(10, "EndValue", "结束值", null, "decimal", 18, 1, false)]
        public virtual Decimal EndValue
        {
            get { return _EndValue; }
            set { if (OnPropertyChanging(__.EndValue, value)) { _EndValue = value; OnPropertyChanged(__.EndValue); } }
        }

        private Decimal _MaxValue;
        /// <summary>最大值</summary>
        [DisplayName("最大值")]
        [Description("最大值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(11, "MaxValue", "最大值", null, "decimal", 18, 1, false)]
        public virtual Decimal MaxValue
        {
            get { return _MaxValue; }
            set { if (OnPropertyChanging(__.MaxValue, value)) { _MaxValue = value; OnPropertyChanged(__.MaxValue); } }
        }

        private Decimal _MinValue;
        /// <summary>最小值</summary>
        [DisplayName("最小值")]
        [Description("最小值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(12, "MinValue", "最小值", null, "decimal", 18, 1, false)]
        public virtual Decimal MinValue
        {
            get { return _MinValue; }
            set { if (OnPropertyChanging(__.MinValue, value)) { _MinValue = value; OnPropertyChanged(__.MinValue); } }
        }

        private Int32 _Count;
        /// <summary>样本数量</summary>
        [DisplayName("样本数量")]
        [Description("样本数量")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(13, "Count", "样本数量", null, "int", 10, 0, false)]
        public virtual Int32 Count
        {
            get { return _Count; }
            set { if (OnPropertyChanging(__.Count, value)) { _Count = value; OnPropertyChanged(__.Count); } }
        }

        private Decimal _Max;
        /// <summary>上限</summary>
        [DisplayName("上限")]
        [Description("上限")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(14, "Max", "上限", null, "decimal", 18, 1, false)]
        public virtual Decimal Max
        {
            get { return _Max; }
            set { if (OnPropertyChanging(__.Max, value)) { _Max = value; OnPropertyChanged(__.Max); } }
        }

        private Decimal _Min;
        /// <summary>下限</summary>
        [DisplayName("下限")]
        [Description("下限")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(15, "Min", "下限", null, "decimal", 18, 1, false)]
        public virtual Decimal Min
        {
            get { return _Min; }
            set { if (OnPropertyChanging(__.Min, value)) { _Min = value; OnPropertyChanged(__.Min); } }
        }

        private Int32 _ExceptionCount;
        /// <summary>异常次数</summary>
        [DisplayName("异常次数")]
        [Description("异常次数")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(16, "ExceptionCount", "异常次数", null, "int", 10, 0, false)]
        public virtual Int32 ExceptionCount
        {
            get { return _ExceptionCount; }
            set { if (OnPropertyChanging(__.ExceptionCount, value)) { _ExceptionCount = value; OnPropertyChanged(__.ExceptionCount); } }
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
                    case __.DeviceSerialnum : return _DeviceSerialnum;
                    case __.TimeSharing : return _TimeSharing;
                    case __.AvgValue : return _AvgValue;
                    case __.StartValue : return _StartValue;
                    case __.EndValue : return _EndValue;
                    case __.MaxValue : return _MaxValue;
                    case __.MinValue : return _MinValue;
                    case __.Count : return _Count;
                    case __.Max : return _Max;
                    case __.Min : return _Min;
                    case __.ExceptionCount : return _ExceptionCount;
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
                    case __.DeviceSerialnum : _DeviceSerialnum = Convert.ToString(value); break;
                    case __.TimeSharing : _TimeSharing = Convert.ToInt32(value); break;
                    case __.AvgValue : _AvgValue = Convert.ToDecimal(value); break;
                    case __.StartValue : _StartValue = Convert.ToDecimal(value); break;
                    case __.EndValue : _EndValue = Convert.ToDecimal(value); break;
                    case __.MaxValue : _MaxValue = Convert.ToDecimal(value); break;
                    case __.MinValue : _MinValue = Convert.ToDecimal(value); break;
                    case __.Count : _Count = Convert.ToInt32(value); break;
                    case __.Max : _Max = Convert.ToDecimal(value); break;
                    case __.Min : _Min = Convert.ToDecimal(value); break;
                    case __.ExceptionCount : _ExceptionCount = Convert.ToInt32(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得企业分时统计数据字段信息的快捷方式</summary>
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

            ///<summary>设施编码</summary>
            public static readonly Field DeviceSerialnum = FindByName(__.DeviceSerialnum);

            ///<summary>分时时段</summary>
            public static readonly Field TimeSharing = FindByName(__.TimeSharing);

            ///<summary>平均</summary>
            public static readonly Field AvgValue = FindByName(__.AvgValue);

            ///<summary>开始值</summary>
            public static readonly Field StartValue = FindByName(__.StartValue);

            ///<summary>结束值</summary>
            public static readonly Field EndValue = FindByName(__.EndValue);

            ///<summary>最大值</summary>
            public static readonly Field MaxValue = FindByName(__.MaxValue);

            ///<summary>最小值</summary>
            public static readonly Field MinValue = FindByName(__.MinValue);

            ///<summary>样本数量</summary>
            public static readonly Field Count = FindByName(__.Count);

            ///<summary>上限</summary>
            public static readonly Field Max = FindByName(__.Max);

            ///<summary>下限</summary>
            public static readonly Field Min = FindByName(__.Min);

            ///<summary>异常次数</summary>
            public static readonly Field ExceptionCount = FindByName(__.ExceptionCount);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得企业分时统计数据字段名称的快捷方式</summary>
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

            ///<summary>设施编码</summary>
            public const String DeviceSerialnum = "DeviceSerialnum";

            ///<summary>分时时段</summary>
            public const String TimeSharing = "TimeSharing";

            ///<summary>平均</summary>
            public const String AvgValue = "AvgValue";

            ///<summary>开始值</summary>
            public const String StartValue = "StartValue";

            ///<summary>结束值</summary>
            public const String EndValue = "EndValue";

            ///<summary>最大值</summary>
            public const String MaxValue = "MaxValue";

            ///<summary>最小值</summary>
            public const String MinValue = "MinValue";

            ///<summary>样本数量</summary>
            public const String Count = "Count";

            ///<summary>上限</summary>
            public const String Max = "Max";

            ///<summary>下限</summary>
            public const String Min = "Min";

            ///<summary>异常次数</summary>
            public const String ExceptionCount = "ExceptionCount";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>企业分时统计数据接口</summary>
    public partial interface IDeviceTimeSharingStatistics
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

        /// <summary>设施编码</summary>
        String DeviceSerialnum { get; set; }

        /// <summary>分时时段</summary>
        Int32 TimeSharing { get; set; }

        /// <summary>平均</summary>
        Decimal AvgValue { get; set; }

        /// <summary>开始值</summary>
        Decimal StartValue { get; set; }

        /// <summary>结束值</summary>
        Decimal EndValue { get; set; }

        /// <summary>最大值</summary>
        Decimal MaxValue { get; set; }

        /// <summary>最小值</summary>
        Decimal MinValue { get; set; }

        /// <summary>样本数量</summary>
        Int32 Count { get; set; }

        /// <summary>上限</summary>
        Decimal Max { get; set; }

        /// <summary>下限</summary>
        Decimal Min { get; set; }

        /// <summary>异常次数</summary>
        Int32 ExceptionCount { get; set; }

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