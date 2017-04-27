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
    /// <summary>农业诊断模型</summary>
    [Serializable]
    [DataObject]
    [Description("农业诊断模型")]
    [BindIndex("IX_AgrDiagnosticModel_AgrProductObjectSerialnum", false, "AgrProductObjectGrowthInfoSerialnum")]
    [BindIndex("IX_AgrDiagnosticModel_DeviceTypeSerialnum", false, "DeviceTypeSerialnum")]
    [BindIndex("PK__AgrDiagn__E3E7488DDEFA49DB", true, "Serialnum")]
    [BindRelation("Serialnum", true, "AgrDiagnosticInfo", "AgrDiagnosticModelSerialnum")]
    [BindRelation("AgrProductObjectGrowthInfoSerialnum", false, "AgrProductObjectGrowthInfo", "Serialnum")]
    [BindRelation("DeviceTypeSerialnum", false, "DeviceType", "Serialnum")]
    [BindTable("AgrDiagnosticModel", Description = "农业诊断模型", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class AgrDiagnosticModel : IAgrDiagnosticModel
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
        /// <summary>等级</summary>
        [DisplayName("等级")]
        [Description("等级")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "Name", "等级", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private String _AgrProductObjectGrowthInfoSerialnum;
        /// <summary>品种生长周期</summary>
        [DisplayName("品种生长周期")]
        [Description("品种生长周期")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "AgrProductObjectGrowthInfoSerialnum", "品种生长周期", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AgrProductObjectGrowthInfoSerialnum
        {
            get { return _AgrProductObjectGrowthInfoSerialnum; }
            set { if (OnPropertyChanging(__.AgrProductObjectGrowthInfoSerialnum, value)) { _AgrProductObjectGrowthInfoSerialnum = value; OnPropertyChanged(__.AgrProductObjectGrowthInfoSerialnum); } }
        }

        private String _DeviceTypeSerialnum;
        /// <summary>参数类型</summary>
        [DisplayName("参数类型")]
        [Description("参数类型")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(8, "DeviceTypeSerialnum", "参数类型", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DeviceTypeSerialnum
        {
            get { return _DeviceTypeSerialnum; }
            set { if (OnPropertyChanging(__.DeviceTypeSerialnum, value)) { _DeviceTypeSerialnum = value; OnPropertyChanged(__.DeviceTypeSerialnum); } }
        }

        private Decimal _MaxValue;
        /// <summary>上限</summary>
        [DisplayName("上限")]
        [Description("上限")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(9, "MaxValue", "上限", null, "decimal", 18, 1, false)]
        public virtual Decimal MaxValue
        {
            get { return _MaxValue; }
            set { if (OnPropertyChanging(__.MaxValue, value)) { _MaxValue = value; OnPropertyChanged(__.MaxValue); } }
        }

        private Decimal _MinValue;
        /// <summary>下限</summary>
        [DisplayName("下限")]
        [Description("下限")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(10, "MinValue", "下限", null, "decimal", 18, 1, false)]
        public virtual Decimal MinValue
        {
            get { return _MinValue; }
            set { if (OnPropertyChanging(__.MinValue, value)) { _MinValue = value; OnPropertyChanged(__.MinValue); } }
        }

        private String _DisplayColor;
        /// <summary>显示颜色（16进制）</summary>
        [DisplayName("显示颜色16进制")]
        [Description("显示颜色（16进制）")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(11, "DisplayColor", "显示颜色（16进制）", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DisplayColor
        {
            get { return _DisplayColor; }
            set { if (OnPropertyChanging(__.DisplayColor, value)) { _DisplayColor = value; OnPropertyChanged(__.DisplayColor); } }
        }

        private String _Effect;
        /// <summary>影响</summary>
        [DisplayName("影响")]
        [Description("影响")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(12, "Effect", "影响", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Effect
        {
            get { return _Effect; }
            set { if (OnPropertyChanging(__.Effect, value)) { _Effect = value; OnPropertyChanged(__.Effect); } }
        }

        private String _Advise;
        /// <summary>建议</summary>
        [DisplayName("建议")]
        [Description("建议")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(13, "Advise", "建议", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Advise
        {
            get { return _Advise; }
            set { if (OnPropertyChanging(__.Advise, value)) { _Advise = value; OnPropertyChanged(__.Advise); } }
        }

        private Boolean _IsNotice;
        /// <summary>是否通知</summary>
        [DisplayName("是否通知")]
        [Description("是否通知")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(14, "IsNotice", "是否通知", null, "bit", 0, 0, false)]
        public virtual Boolean IsNotice
        {
            get { return _IsNotice; }
            set { if (OnPropertyChanging(__.IsNotice, value)) { _IsNotice = value; OnPropertyChanged(__.IsNotice); } }
        }

        private String _TipInfo;
        /// <summary>内容</summary>
        [DisplayName("内容")]
        [Description("内容")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(15, "TipInfo", "内容", null, "ntext", 0, 0, true)]
        public virtual String TipInfo
        {
            get { return _TipInfo; }
            set { if (OnPropertyChanging(__.TipInfo, value)) { _TipInfo = value; OnPropertyChanged(__.TipInfo); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(16, "Sort", "排序", null, "int", 10, 0, false)]
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
        [BindColumn(17, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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
                    case __.AgrProductObjectGrowthInfoSerialnum : return _AgrProductObjectGrowthInfoSerialnum;
                    case __.DeviceTypeSerialnum : return _DeviceTypeSerialnum;
                    case __.MaxValue : return _MaxValue;
                    case __.MinValue : return _MinValue;
                    case __.DisplayColor : return _DisplayColor;
                    case __.Effect : return _Effect;
                    case __.Advise : return _Advise;
                    case __.IsNotice : return _IsNotice;
                    case __.TipInfo : return _TipInfo;
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
                    case __.AgrProductObjectGrowthInfoSerialnum : _AgrProductObjectGrowthInfoSerialnum = Convert.ToString(value); break;
                    case __.DeviceTypeSerialnum : _DeviceTypeSerialnum = Convert.ToString(value); break;
                    case __.MaxValue : _MaxValue = Convert.ToDecimal(value); break;
                    case __.MinValue : _MinValue = Convert.ToDecimal(value); break;
                    case __.DisplayColor : _DisplayColor = Convert.ToString(value); break;
                    case __.Effect : _Effect = Convert.ToString(value); break;
                    case __.Advise : _Advise = Convert.ToString(value); break;
                    case __.IsNotice : _IsNotice = Convert.ToBoolean(value); break;
                    case __.TipInfo : _TipInfo = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得农业诊断模型字段信息的快捷方式</summary>
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

            ///<summary>等级</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>品种生长周期</summary>
            public static readonly Field AgrProductObjectGrowthInfoSerialnum = FindByName(__.AgrProductObjectGrowthInfoSerialnum);

            ///<summary>参数类型</summary>
            public static readonly Field DeviceTypeSerialnum = FindByName(__.DeviceTypeSerialnum);

            ///<summary>上限</summary>
            public static readonly Field MaxValue = FindByName(__.MaxValue);

            ///<summary>下限</summary>
            public static readonly Field MinValue = FindByName(__.MinValue);

            ///<summary>显示颜色（16进制）</summary>
            public static readonly Field DisplayColor = FindByName(__.DisplayColor);

            ///<summary>影响</summary>
            public static readonly Field Effect = FindByName(__.Effect);

            ///<summary>建议</summary>
            public static readonly Field Advise = FindByName(__.Advise);

            ///<summary>是否通知</summary>
            public static readonly Field IsNotice = FindByName(__.IsNotice);

            ///<summary>内容</summary>
            public static readonly Field TipInfo = FindByName(__.TipInfo);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得农业诊断模型字段名称的快捷方式</summary>
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

            ///<summary>等级</summary>
            public const String Name = "Name";

            ///<summary>品种生长周期</summary>
            public const String AgrProductObjectGrowthInfoSerialnum = "AgrProductObjectGrowthInfoSerialnum";

            ///<summary>参数类型</summary>
            public const String DeviceTypeSerialnum = "DeviceTypeSerialnum";

            ///<summary>上限</summary>
            public const String MaxValue = "MaxValue";

            ///<summary>下限</summary>
            public const String MinValue = "MinValue";

            ///<summary>显示颜色（16进制）</summary>
            public const String DisplayColor = "DisplayColor";

            ///<summary>影响</summary>
            public const String Effect = "Effect";

            ///<summary>建议</summary>
            public const String Advise = "Advise";

            ///<summary>是否通知</summary>
            public const String IsNotice = "IsNotice";

            ///<summary>内容</summary>
            public const String TipInfo = "TipInfo";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>农业诊断模型接口</summary>
    public partial interface IAgrDiagnosticModel
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

        /// <summary>等级</summary>
        String Name { get; set; }

        /// <summary>品种生长周期</summary>
        String AgrProductObjectGrowthInfoSerialnum { get; set; }

        /// <summary>参数类型</summary>
        String DeviceTypeSerialnum { get; set; }

        /// <summary>上限</summary>
        Decimal MaxValue { get; set; }

        /// <summary>下限</summary>
        Decimal MinValue { get; set; }

        /// <summary>显示颜色（16进制）</summary>
        String DisplayColor { get; set; }

        /// <summary>影响</summary>
        String Effect { get; set; }

        /// <summary>建议</summary>
        String Advise { get; set; }

        /// <summary>是否通知</summary>
        Boolean IsNotice { get; set; }

        /// <summary>内容</summary>
        String TipInfo { get; set; }

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