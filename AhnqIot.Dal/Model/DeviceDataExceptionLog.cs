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
    /// <summary>企业设备数据异常记录</summary>
    [Serializable]
    [DataObject]
    [Description("企业设备数据异常记录")]
    [BindIndex("Index_DeviceSerialnum", false, "DeviceSerialnum,CreateTime")]
    [BindIndex("IX_DeviceDataExceptionLog_DeviceSerialnum", false, "DeviceSerialnum")]
    [BindIndex("PK__DeviceDa__E3E7488D6F951036", true, "Serialnum")]
    [BindRelation("DeviceSerialnum", false, "Device", "Serialnum")]
    [BindTable("DeviceDataExceptionLog", Description = "企业设备数据异常记录", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class DeviceDataExceptionLog : IDeviceDataExceptionLog
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
        /// <summary>设备编码</summary>
        [DisplayName("设备编码")]
        [Description("设备编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "DeviceSerialnum", "设备编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DeviceSerialnum
        {
            get { return _DeviceSerialnum; }
            set { if (OnPropertyChanging(__.DeviceSerialnum, value)) { _DeviceSerialnum = value; OnPropertyChanged(__.DeviceSerialnum); } }
        }

        private Decimal _Value;
        /// <summary>设备值</summary>
        [DisplayName("设备值")]
        [Description("设备值")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(7, "Value", "设备值", null, "decimal", 18, 1, false)]
        public virtual Decimal Value
        {
            get { return _Value; }
            set { if (OnPropertyChanging(__.Value, value)) { _Value = value; OnPropertyChanged(__.Value); } }
        }

        private Int32 _Status;
        /// <summary>异常类型（1：偏大，-1：偏小）</summary>
        [DisplayName("异常类型1：偏大，-1：偏小")]
        [Description("异常类型（1：偏大，-1：偏小）")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(8, "Status", "异常类型（1：偏大，-1：偏小）", null, "int", 10, 0, false)]
        public virtual Int32 Status
        {
            get { return _Status; }
            set { if (OnPropertyChanging(__.Status, value)) { _Status = value; OnPropertyChanged(__.Status); } }
        }

        private Decimal _Max;
        /// <summary>上限</summary>
        [DisplayName("上限")]
        [Description("上限")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(9, "Max", "上限", null, "decimal", 18, 1, false)]
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
        [BindColumn(10, "Min", "下限", null, "decimal", 18, 1, false)]
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
        [BindColumn(11, "Sort", "排序", null, "int", 10, 0, false)]
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
        [BindColumn(12, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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
                    case __.Value : return _Value;
                    case __.Status : return _Status;
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
                    case __.Value : _Value = Convert.ToDecimal(value); break;
                    case __.Status : _Status = Convert.ToInt32(value); break;
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
        
        /// <summary>取得企业设备数据异常记录字段信息的快捷方式</summary>
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

            ///<summary>设备编码</summary>
            public static readonly Field DeviceSerialnum = FindByName(__.DeviceSerialnum);

            ///<summary>设备值</summary>
            public static readonly Field Value = FindByName(__.Value);

            ///<summary>异常类型（1：偏大，-1：偏小）</summary>
            public static readonly Field Status = FindByName(__.Status);

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

        /// <summary>取得企业设备数据异常记录字段名称的快捷方式</summary>
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

            ///<summary>设备编码</summary>
            public const String DeviceSerialnum = "DeviceSerialnum";

            ///<summary>设备值</summary>
            public const String Value = "Value";

            ///<summary>异常类型（1：偏大，-1：偏小）</summary>
            public const String Status = "Status";

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

    /// <summary>企业设备数据异常记录接口</summary>
    public partial interface IDeviceDataExceptionLog
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

        /// <summary>设备编码</summary>
        String DeviceSerialnum { get; set; }

        /// <summary>设备值</summary>
        Decimal Value { get; set; }

        /// <summary>异常类型（1：偏大，-1：偏小）</summary>
        Int32 Status { get; set; }

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