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
    /// <summary>作物周年服务方案</summary>
    [Serializable]
    [DataObject]
    [Description("作物周年服务方案")]
    [BindIndex("PK__AgrProdu__E3E7488DA69CAB52", true, "Serialnum")]
    [BindIndex("IX_AgrProduceAnniversaryService_AgrProductObjectSerialnum", false, "AgrProductObjectSerialnum")]
    [BindIndex("IX_AgrProduceAnniversaryService_SysAreaSerialnum", false, "SysAreaSerialnum")]
    [BindRelation("AgrProductObjectSerialnum", false, "AgrProductObject", "Serialnum")]
    [BindRelation("SysAreaSerialnum", false, "SysArea", "Serialnum")]
    [BindTable("AgrProduceAnniversaryService", Description = "作物周年服务方案", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class AgrProduceAnniversaryService : IAgrProduceAnniversaryService
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

        private String _SysAreaSerialnum;
        /// <summary>区域编码</summary>
        [DisplayName("区域编码")]
        [Description("区域编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "SysAreaSerialnum", "区域编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysAreaSerialnum
        {
            get { return _SysAreaSerialnum; }
            set { if (OnPropertyChanging(__.SysAreaSerialnum, value)) { _SysAreaSerialnum = value; OnPropertyChanged(__.SysAreaSerialnum); } }
        }

        private String _AgrProductObjectSerialnum;
        /// <summary>品种编码</summary>
        [DisplayName("品种编码")]
        [Description("品种编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "AgrProductObjectSerialnum", "品种编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AgrProductObjectSerialnum
        {
            get { return _AgrProductObjectSerialnum; }
            set { if (OnPropertyChanging(__.AgrProductObjectSerialnum, value)) { _AgrProductObjectSerialnum = value; OnPropertyChanged(__.AgrProductObjectSerialnum); } }
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

        private String _MainDevelopmentalStage;
        /// <summary>主要作物发育期</summary>
        [DisplayName("主要作物发育期")]
        [Description("主要作物发育期")]
        [DataObjectField(false, false, false, 100)]
        [BindColumn(10, "MainDevelopmentalStage", "主要作物发育期", null, "nvarchar(100)", 0, 0, true)]
        public virtual String MainDevelopmentalStage
        {
            get { return _MainDevelopmentalStage; }
            set { if (OnPropertyChanging(__.MainDevelopmentalStage, value)) { _MainDevelopmentalStage = value; OnPropertyChanged(__.MainDevelopmentalStage); } }
        }

        private String _PossibleDisasters;
        /// <summary>可能出现的灾害</summary>
        [DisplayName("可能出现的灾害")]
        [Description("可能出现的灾害")]
        [DataObjectField(false, false, false, 200)]
        [BindColumn(11, "PossibleDisasters", "可能出现的灾害", null, "nvarchar(200)", 0, 0, true)]
        public virtual String PossibleDisasters
        {
            get { return _PossibleDisasters; }
            set { if (OnPropertyChanging(__.PossibleDisasters, value)) { _PossibleDisasters = value; OnPropertyChanged(__.PossibleDisasters); } }
        }

        private String _ServiceFocus;
        /// <summary>服务重点</summary>
        [DisplayName("服务重点")]
        [Description("服务重点")]
        [DataObjectField(false, false, false, 500)]
        [BindColumn(12, "ServiceFocus", "服务重点", null, "nvarchar(500)", 0, 0, true)]
        public virtual String ServiceFocus
        {
            get { return _ServiceFocus; }
            set { if (OnPropertyChanging(__.ServiceFocus, value)) { _ServiceFocus = value; OnPropertyChanged(__.ServiceFocus); } }
        }

        private String _ServiceContent;
        /// <summary>服务内容</summary>
        [DisplayName("服务内容")]
        [Description("服务内容")]
        [DataObjectField(false, false, false, 500)]
        [BindColumn(13, "ServiceContent", "服务内容", null, "nvarchar(500)", 0, 0, true)]
        public virtual String ServiceContent
        {
            get { return _ServiceContent; }
            set { if (OnPropertyChanging(__.ServiceContent, value)) { _ServiceContent = value; OnPropertyChanged(__.ServiceContent); } }
        }

        private String _TakeMeasures;
        /// <summary>相应对策</summary>
        [DisplayName("相应对策")]
        [Description("相应对策")]
        [DataObjectField(false, false, false, 1073741823)]
        [BindColumn(14, "TakeMeasures", "相应对策", null, "ntext", 0, 0, true)]
        public virtual String TakeMeasures
        {
            get { return _TakeMeasures; }
            set { if (OnPropertyChanging(__.TakeMeasures, value)) { _TakeMeasures = value; OnPropertyChanged(__.TakeMeasures); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(15, "Sort", "排序", null, "int", 10, 0, false)]
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
        [BindColumn(16, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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
                    case __.SysAreaSerialnum : return _SysAreaSerialnum;
                    case __.AgrProductObjectSerialnum : return _AgrProductObjectSerialnum;
                    case __.Month : return _Month;
                    case __.Ten : return _Ten;
                    case __.MainDevelopmentalStage : return _MainDevelopmentalStage;
                    case __.PossibleDisasters : return _PossibleDisasters;
                    case __.ServiceFocus : return _ServiceFocus;
                    case __.ServiceContent : return _ServiceContent;
                    case __.TakeMeasures : return _TakeMeasures;
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
                    case __.SysAreaSerialnum : _SysAreaSerialnum = Convert.ToString(value); break;
                    case __.AgrProductObjectSerialnum : _AgrProductObjectSerialnum = Convert.ToString(value); break;
                    case __.Month : _Month = Convert.ToInt32(value); break;
                    case __.Ten : _Ten = Convert.ToString(value); break;
                    case __.MainDevelopmentalStage : _MainDevelopmentalStage = Convert.ToString(value); break;
                    case __.PossibleDisasters : _PossibleDisasters = Convert.ToString(value); break;
                    case __.ServiceFocus : _ServiceFocus = Convert.ToString(value); break;
                    case __.ServiceContent : _ServiceContent = Convert.ToString(value); break;
                    case __.TakeMeasures : _TakeMeasures = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得作物周年服务方案字段信息的快捷方式</summary>
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

            ///<summary>区域编码</summary>
            public static readonly Field SysAreaSerialnum = FindByName(__.SysAreaSerialnum);

            ///<summary>品种编码</summary>
            public static readonly Field AgrProductObjectSerialnum = FindByName(__.AgrProductObjectSerialnum);

            ///<summary>月</summary>
            public static readonly Field Month = FindByName(__.Month);

            ///<summary>旬号。上旬、中旬、下旬</summary>
            public static readonly Field Ten = FindByName(__.Ten);

            ///<summary>主要作物发育期</summary>
            public static readonly Field MainDevelopmentalStage = FindByName(__.MainDevelopmentalStage);

            ///<summary>可能出现的灾害</summary>
            public static readonly Field PossibleDisasters = FindByName(__.PossibleDisasters);

            ///<summary>服务重点</summary>
            public static readonly Field ServiceFocus = FindByName(__.ServiceFocus);

            ///<summary>服务内容</summary>
            public static readonly Field ServiceContent = FindByName(__.ServiceContent);

            ///<summary>相应对策</summary>
            public static readonly Field TakeMeasures = FindByName(__.TakeMeasures);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得作物周年服务方案字段名称的快捷方式</summary>
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

            ///<summary>区域编码</summary>
            public const String SysAreaSerialnum = "SysAreaSerialnum";

            ///<summary>品种编码</summary>
            public const String AgrProductObjectSerialnum = "AgrProductObjectSerialnum";

            ///<summary>月</summary>
            public const String Month = "Month";

            ///<summary>旬号。上旬、中旬、下旬</summary>
            public const String Ten = "Ten";

            ///<summary>主要作物发育期</summary>
            public const String MainDevelopmentalStage = "MainDevelopmentalStage";

            ///<summary>可能出现的灾害</summary>
            public const String PossibleDisasters = "PossibleDisasters";

            ///<summary>服务重点</summary>
            public const String ServiceFocus = "ServiceFocus";

            ///<summary>服务内容</summary>
            public const String ServiceContent = "ServiceContent";

            ///<summary>相应对策</summary>
            public const String TakeMeasures = "TakeMeasures";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>作物周年服务方案接口</summary>
    public partial interface IAgrProduceAnniversaryService
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

        /// <summary>区域编码</summary>
        String SysAreaSerialnum { get; set; }

        /// <summary>品种编码</summary>
        String AgrProductObjectSerialnum { get; set; }

        /// <summary>月</summary>
        Int32 Month { get; set; }

        /// <summary>旬号。上旬、中旬、下旬</summary>
        String Ten { get; set; }

        /// <summary>主要作物发育期</summary>
        String MainDevelopmentalStage { get; set; }

        /// <summary>可能出现的灾害</summary>
        String PossibleDisasters { get; set; }

        /// <summary>服务重点</summary>
        String ServiceFocus { get; set; }

        /// <summary>服务内容</summary>
        String ServiceContent { get; set; }

        /// <summary>相应对策</summary>
        String TakeMeasures { get; set; }

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