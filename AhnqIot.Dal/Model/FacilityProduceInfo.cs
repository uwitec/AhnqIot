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
    /// <summary>设施种植养殖信息</summary>
    [Serializable]
    [DataObject]
    [Description("设施种植养殖信息")]
    [BindIndex("IX_FacilityProduceInfo_AgrProductObjectSerialnum", false, "AgrProductObjectSerialnum")]
    [BindIndex("IX_FacilityProduceInfo_FacilitySerialnum", false, "FacilitySerialnum")]
    [BindIndex("PK__Facility__E3E7488D24B541D0", true, "Serialnum")]
    [BindRelation("AgrProductObjectSerialnum", false, "AgrProductObject", "Serialnum")]
    [BindRelation("FacilitySerialnum", false, "Facility", "Serialnum")]
    [BindTable("FacilityProduceInfo", Description = "设施种植养殖信息", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class FacilityProduceInfo : IFacilityProduceInfo
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

        private String _FacilitySerialnum;
        /// <summary>设施编码</summary>
        [DisplayName("设施编码")]
        [Description("设施编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "FacilitySerialnum", "设施编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FacilitySerialnum
        {
            get { return _FacilitySerialnum; }
            set { if (OnPropertyChanging(__.FacilitySerialnum, value)) { _FacilitySerialnum = value; OnPropertyChanged(__.FacilitySerialnum); } }
        }

        private String _AgrProductObjectSerialnum;
        /// <summary>品种</summary>
        [DisplayName("品种")]
        [Description("品种")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(8, "AgrProductObjectSerialnum", "品种", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AgrProductObjectSerialnum
        {
            get { return _AgrProductObjectSerialnum; }
            set { if (OnPropertyChanging(__.AgrProductObjectSerialnum, value)) { _AgrProductObjectSerialnum = value; OnPropertyChanged(__.AgrProductObjectSerialnum); } }
        }

        private String _Description;
        /// <summary>说明</summary>
        [DisplayName("说明")]
        [Description("说明")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(9, "Description", "说明", null, "ntext", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging(__.Description, value)) { _Description = value; OnPropertyChanged(__.Description); } }
        }

        private Boolean _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(10, "Status", "状态", null, "bit", 0, 0, false)]
        public virtual Boolean Status
        {
            get { return _Status; }
            set { if (OnPropertyChanging(__.Status, value)) { _Status = value; OnPropertyChanged(__.Status); } }
        }

        private DateTime _StartTime;
        /// <summary>种植开始时间</summary>
        [DisplayName("种植开始时间")]
        [Description("种植开始时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(11, "StartTime", "种植开始时间", null, "datetime", 3, 0, false)]
        public virtual DateTime StartTime
        {
            get { return _StartTime; }
            set { if (OnPropertyChanging(__.StartTime, value)) { _StartTime = value; OnPropertyChanged(__.StartTime); } }
        }

        private DateTime _EndTime;
        /// <summary>种植结束时间</summary>
        [DisplayName("种植结束时间")]
        [Description("种植结束时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(12, "EndTime", "种植结束时间", null, "datetime", 3, 0, false)]
        public virtual DateTime EndTime
        {
            get { return _EndTime; }
            set { if (OnPropertyChanging(__.EndTime, value)) { _EndTime = value; OnPropertyChanged(__.EndTime); } }
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
                    case __.Name : return _Name;
                    case __.FacilitySerialnum : return _FacilitySerialnum;
                    case __.AgrProductObjectSerialnum : return _AgrProductObjectSerialnum;
                    case __.Description : return _Description;
                    case __.Status : return _Status;
                    case __.StartTime : return _StartTime;
                    case __.EndTime : return _EndTime;
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
                    case __.FacilitySerialnum : _FacilitySerialnum = Convert.ToString(value); break;
                    case __.AgrProductObjectSerialnum : _AgrProductObjectSerialnum = Convert.ToString(value); break;
                    case __.Description : _Description = Convert.ToString(value); break;
                    case __.Status : _Status = Convert.ToBoolean(value); break;
                    case __.StartTime : _StartTime = Convert.ToDateTime(value); break;
                    case __.EndTime : _EndTime = Convert.ToDateTime(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得设施种植养殖信息字段信息的快捷方式</summary>
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

            ///<summary>设施编码</summary>
            public static readonly Field FacilitySerialnum = FindByName(__.FacilitySerialnum);

            ///<summary>品种</summary>
            public static readonly Field AgrProductObjectSerialnum = FindByName(__.AgrProductObjectSerialnum);

            ///<summary>说明</summary>
            public static readonly Field Description = FindByName(__.Description);

            ///<summary>状态</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>种植开始时间</summary>
            public static readonly Field StartTime = FindByName(__.StartTime);

            ///<summary>种植结束时间</summary>
            public static readonly Field EndTime = FindByName(__.EndTime);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得设施种植养殖信息字段名称的快捷方式</summary>
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

            ///<summary>设施编码</summary>
            public const String FacilitySerialnum = "FacilitySerialnum";

            ///<summary>品种</summary>
            public const String AgrProductObjectSerialnum = "AgrProductObjectSerialnum";

            ///<summary>说明</summary>
            public const String Description = "Description";

            ///<summary>状态</summary>
            public const String Status = "Status";

            ///<summary>种植开始时间</summary>
            public const String StartTime = "StartTime";

            ///<summary>种植结束时间</summary>
            public const String EndTime = "EndTime";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>设施种植养殖信息接口</summary>
    public partial interface IFacilityProduceInfo
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

        /// <summary>设施编码</summary>
        String FacilitySerialnum { get; set; }

        /// <summary>品种</summary>
        String AgrProductObjectSerialnum { get; set; }

        /// <summary>说明</summary>
        String Description { get; set; }

        /// <summary>状态</summary>
        Boolean Status { get; set; }

        /// <summary>种植开始时间</summary>
        DateTime StartTime { get; set; }

        /// <summary>种植结束时间</summary>
        DateTime EndTime { get; set; }

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