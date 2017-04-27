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
    /// <summary>企业设备数据记录</summary>
    [Serializable]
    [DataObject]
    [Description("企业设备数据记录")]
    [BindIndex("Index_b", false, "DeviceSerialnum,CreateTime")]
    [BindIndex("IX_CompanyDataInfo_DeviceSerialnum", false, "DeviceSerialnum")]
    [BindIndex("PK__CompanyD__E3E7488D9075E711", true, "Serialnum")]
    [BindRelation("DeviceSerialnum", false, "Device", "Serialnum")]
    [BindTable("DeviceDataInfo", Description = "企业设备数据记录", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class DeviceDataInfo : IDeviceDataInfo
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

        private String _ShowValue;
        /// <summary>显示值</summary>
        [DisplayName("显示值")]
        [Description("显示值")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(7, "ShowValue", "显示值", null, "nvarchar(500)", 0, 0, true)]
        public virtual String ShowValue
        {
            get { return _ShowValue; }
            set { if (OnPropertyChanging(__.ShowValue, value)) { _ShowValue = value; OnPropertyChanged(__.ShowValue); } }
        }

        private Int32 _OriginalData;
        /// <summary>未处理值</summary>
        [DisplayName("未处理值")]
        [Description("未处理值")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(8, "OriginalData", "未处理值", null, "int", 10, 0, false)]
        public virtual Int32 OriginalData
        {
            get { return _OriginalData; }
            set { if (OnPropertyChanging(__.OriginalData, value)) { _OriginalData = value; OnPropertyChanged(__.OriginalData); } }
        }

        private Decimal _ProcessedValue;
        /// <summary>处理值</summary>
        [DisplayName("处理值")]
        [Description("处理值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(9, "ProcessedValue", "处理值", null, "decimal", 18, 1, false)]
        public virtual Decimal ProcessedValue
        {
            get { return _ProcessedValue; }
            set { if (OnPropertyChanging(__.ProcessedValue, value)) { _ProcessedValue = value; OnPropertyChanged(__.ProcessedValue); } }
        }

        private Boolean _IsException;
        /// <summary>是否异常</summary>
        [DisplayName("是否异常")]
        [Description("是否异常")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(10, "IsException", "是否异常", null, "bit", 0, 0, false)]
        public virtual Boolean IsException
        {
            get { return _IsException; }
            set { if (OnPropertyChanging(__.IsException, value)) { _IsException = value; OnPropertyChanged(__.IsException); } }
        }

        private Decimal _Max;
        /// <summary>上限</summary>
        [DisplayName("上限")]
        [Description("上限")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(11, "Max", "上限", null, "decimal", 18, 1, false)]
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
        [BindColumn(12, "Min", "下限", null, "decimal", 18, 1, false)]
        public virtual Decimal Min
        {
            get { return _Min; }
            set { if (OnPropertyChanging(__.Min, value)) { _Min = value; OnPropertyChanged(__.Min); } }
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
                    case __.DeviceSerialnum : return _DeviceSerialnum;
                    case __.ShowValue : return _ShowValue;
                    case __.OriginalData : return _OriginalData;
                    case __.ProcessedValue : return _ProcessedValue;
                    case __.IsException : return _IsException;
                    case __.Max : return _Max;
                    case __.Min : return _Min;
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
                    case __.ShowValue : _ShowValue = Convert.ToString(value); break;
                    case __.OriginalData : _OriginalData = Convert.ToInt32(value); break;
                    case __.ProcessedValue : _ProcessedValue = Convert.ToDecimal(value); break;
                    case __.IsException : _IsException = Convert.ToBoolean(value); break;
                    case __.Max : _Max = Convert.ToDecimal(value); break;
                    case __.Min : _Min = Convert.ToDecimal(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得企业设备数据记录字段信息的快捷方式</summary>
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

            ///<summary>显示值</summary>
            public static readonly Field ShowValue = FindByName(__.ShowValue);

            ///<summary>未处理值</summary>
            public static readonly Field OriginalData = FindByName(__.OriginalData);

            ///<summary>处理值</summary>
            public static readonly Field ProcessedValue = FindByName(__.ProcessedValue);

            ///<summary>是否异常</summary>
            public static readonly Field IsException = FindByName(__.IsException);

            ///<summary>上限</summary>
            public static readonly Field Max = FindByName(__.Max);

            ///<summary>下限</summary>
            public static readonly Field Min = FindByName(__.Min);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得企业设备数据记录字段名称的快捷方式</summary>
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

            ///<summary>显示值</summary>
            public const String ShowValue = "ShowValue";

            ///<summary>未处理值</summary>
            public const String OriginalData = "OriginalData";

            ///<summary>处理值</summary>
            public const String ProcessedValue = "ProcessedValue";

            ///<summary>是否异常</summary>
            public const String IsException = "IsException";

            ///<summary>上限</summary>
            public const String Max = "Max";

            ///<summary>下限</summary>
            public const String Min = "Min";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>企业设备数据记录接口</summary>
    public partial interface IDeviceDataInfo
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

        /// <summary>显示值</summary>
        String ShowValue { get; set; }

        /// <summary>未处理值</summary>
        Int32 OriginalData { get; set; }

        /// <summary>处理值</summary>
        Decimal ProcessedValue { get; set; }

        /// <summary>是否异常</summary>
        Boolean IsException { get; set; }

        /// <summary>上限</summary>
        Decimal Max { get; set; }

        /// <summary>下限</summary>
        Decimal Min { get; set; }

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