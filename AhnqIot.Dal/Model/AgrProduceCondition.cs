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
    /// <summary>农业气象指标库</summary>
    [Serializable]
    [DataObject]
    [Description("农业气象指标库")]
    [BindIndex("IX_AgrProduceCondition_AgrProductObjectSerialnum", false, "AgrProductObjectSerialnum")]
    [BindIndex("PK__AgrProdu__E3E7488D0451928C", true, "Serialnum")]
    [BindIndex("IX_AgrProduceCondition_SysAreaSerialnum", false, "SysAreaSerialnum")]
    [BindRelation("AgrProductObjectSerialnum", false, "AgrProductObject", "Serialnum")]
    [BindRelation("SysAreaSerialnum", false, "SysArea", "Serialnum")]
    [BindTable("AgrProduceCondition", Description = "农业气象指标库", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class AgrProduceCondition : IAgrProduceCondition
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

        private String _AgrProductObjectSerialnum;
        /// <summary>品种编码</summary>
        [DisplayName("品种编码")]
        [Description("品种编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "AgrProductObjectSerialnum", "品种编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AgrProductObjectSerialnum
        {
            get { return _AgrProductObjectSerialnum; }
            set { if (OnPropertyChanging(__.AgrProductObjectSerialnum, value)) { _AgrProductObjectSerialnum = value; OnPropertyChanged(__.AgrProductObjectSerialnum); } }
        }

        private String _SysAreaSerialnum;
        /// <summary>区域编码</summary>
        [DisplayName("区域编码")]
        [Description("区域编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "SysAreaSerialnum", "区域编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysAreaSerialnum
        {
            get { return _SysAreaSerialnum; }
            set { if (OnPropertyChanging(__.SysAreaSerialnum, value)) { _SysAreaSerialnum = value; OnPropertyChanged(__.SysAreaSerialnum); } }
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

        private String _Ten;
        /// <summary>旬号。上旬、中旬、下旬</summary>
        [DisplayName("旬号")]
        [Description("旬号。上旬、中旬、下旬")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(9, "Ten", "旬号。上旬、中旬、下旬", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Ten
        {
            get { return _Ten; }
            set { if (OnPropertyChanging(__.Ten, value)) { _Ten = value; OnPropertyChanged(__.Ten); } }
        }

        private String _DevelopmentalStage;
        /// <summary>发育期</summary>
        [DisplayName("发育期")]
        [Description("发育期")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(10, "DevelopmentalStage", "发育期", null, "nvarchar(100)", 0, 0, true)]
        public virtual String DevelopmentalStage
        {
            get { return _DevelopmentalStage; }
            set { if (OnPropertyChanging(__.DevelopmentalStage, value)) { _DevelopmentalStage = value; OnPropertyChanged(__.DevelopmentalStage); } }
        }

        private String _SuitableCondition;
        /// <summary>适宜条件</summary>
        [DisplayName("适宜条件")]
        [Description("适宜条件")]
        [DataObjectField(false, false, false, 1073741823)]
        [BindColumn(11, "SuitableCondition", "适宜条件", null, "ntext", 0, 0, true)]
        public virtual String SuitableCondition
        {
            get { return _SuitableCondition; }
            set { if (OnPropertyChanging(__.SuitableCondition, value)) { _SuitableCondition = value; OnPropertyChanged(__.SuitableCondition); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(12, "Sort", "排序", null, "int", 10, 0, false)]
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
        [BindColumn(13, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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
                    case __.AgrProductObjectSerialnum : return _AgrProductObjectSerialnum;
                    case __.SysAreaSerialnum : return _SysAreaSerialnum;
                    case __.Month : return _Month;
                    case __.Ten : return _Ten;
                    case __.DevelopmentalStage : return _DevelopmentalStage;
                    case __.SuitableCondition : return _SuitableCondition;
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
                    case __.AgrProductObjectSerialnum : _AgrProductObjectSerialnum = Convert.ToString(value); break;
                    case __.SysAreaSerialnum : _SysAreaSerialnum = Convert.ToString(value); break;
                    case __.Month : _Month = Convert.ToInt32(value); break;
                    case __.Ten : _Ten = Convert.ToString(value); break;
                    case __.DevelopmentalStage : _DevelopmentalStage = Convert.ToString(value); break;
                    case __.SuitableCondition : _SuitableCondition = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得农业气象指标库字段信息的快捷方式</summary>
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

            ///<summary>品种编码</summary>
            public static readonly Field AgrProductObjectSerialnum = FindByName(__.AgrProductObjectSerialnum);

            ///<summary>区域编码</summary>
            public static readonly Field SysAreaSerialnum = FindByName(__.SysAreaSerialnum);

            ///<summary>月</summary>
            public static readonly Field Month = FindByName(__.Month);

            ///<summary>旬号。上旬、中旬、下旬</summary>
            public static readonly Field Ten = FindByName(__.Ten);

            ///<summary>发育期</summary>
            public static readonly Field DevelopmentalStage = FindByName(__.DevelopmentalStage);

            ///<summary>适宜条件</summary>
            public static readonly Field SuitableCondition = FindByName(__.SuitableCondition);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得农业气象指标库字段名称的快捷方式</summary>
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

            ///<summary>品种编码</summary>
            public const String AgrProductObjectSerialnum = "AgrProductObjectSerialnum";

            ///<summary>区域编码</summary>
            public const String SysAreaSerialnum = "SysAreaSerialnum";

            ///<summary>月</summary>
            public const String Month = "Month";

            ///<summary>旬号。上旬、中旬、下旬</summary>
            public const String Ten = "Ten";

            ///<summary>发育期</summary>
            public const String DevelopmentalStage = "DevelopmentalStage";

            ///<summary>适宜条件</summary>
            public const String SuitableCondition = "SuitableCondition";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>农业气象指标库接口</summary>
    public partial interface IAgrProduceCondition
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

        /// <summary>品种编码</summary>
        String AgrProductObjectSerialnum { get; set; }

        /// <summary>区域编码</summary>
        String SysAreaSerialnum { get; set; }

        /// <summary>月</summary>
        Int32 Month { get; set; }

        /// <summary>旬号。上旬、中旬、下旬</summary>
        String Ten { get; set; }

        /// <summary>发育期</summary>
        String DevelopmentalStage { get; set; }

        /// <summary>适宜条件</summary>
        String SuitableCondition { get; set; }

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