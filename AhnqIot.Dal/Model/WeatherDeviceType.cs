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
    /// <summary>气象设备类型</summary>
    [Serializable]
    [DataObject]
    [Description("气象设备类型")]
    [BindIndex("PK__WeatherD__E3E7488D148C5260", true, "Serialnum")]
    [BindRelation("Serialnum", true, "WeatherDevice", "WeatherDeviceTypeSerialnum")]
    [BindTable("WeatherDeviceType", Description = "气象设备类型", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class WeatherDeviceType : IWeatherDeviceType
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

        private String _ParentSerialnum;
        /// <summary>上级</summary>
        [DisplayName("上级")]
        [Description("上级")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "ParentSerialnum", "上级", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ParentSerialnum
        {
            get { return _ParentSerialnum; }
            set { if (OnPropertyChanging(__.ParentSerialnum, value)) { _ParentSerialnum = value; OnPropertyChanged(__.ParentSerialnum); } }
        }

        private String _Unit;
        /// <summary>单位</summary>
        [DisplayName("单位")]
        [Description("单位")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(8, "Unit", "单位", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Unit
        {
            get { return _Unit; }
            set { if (OnPropertyChanging(__.Unit, value)) { _Unit = value; OnPropertyChanged(__.Unit); } }
        }

        private String _Calc;
        /// <summary>计算公式</summary>
        [DisplayName("计算公式")]
        [Description("计算公式")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "Calc", "计算公式", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Calc
        {
            get { return _Calc; }
            set { if (OnPropertyChanging(__.Calc, value)) { _Calc = value; OnPropertyChanged(__.Calc); } }
        }

        private String _Introduce;
        /// <summary>说明</summary>
        [DisplayName("说明")]
        [Description("说明")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "Introduce", "说明", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(11, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(12, "Location", "位置", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Location
        {
            get { return _Location; }
            set { if (OnPropertyChanging(__.Location, value)) { _Location = value; OnPropertyChanged(__.Location); } }
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
                    case __.Name : return _Name;
                    case __.ParentSerialnum : return _ParentSerialnum;
                    case __.Unit : return _Unit;
                    case __.Calc : return _Calc;
                    case __.Introduce : return _Introduce;
                    case __.Sort : return _Sort;
                    case __.Location : return _Location;
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
                    case __.ParentSerialnum : _ParentSerialnum = Convert.ToString(value); break;
                    case __.Unit : _Unit = Convert.ToString(value); break;
                    case __.Calc : _Calc = Convert.ToString(value); break;
                    case __.Introduce : _Introduce = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Location : _Location = Convert.ToString(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得气象设备类型字段信息的快捷方式</summary>
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

            ///<summary>上级</summary>
            public static readonly Field ParentSerialnum = FindByName(__.ParentSerialnum);

            ///<summary>单位</summary>
            public static readonly Field Unit = FindByName(__.Unit);

            ///<summary>计算公式</summary>
            public static readonly Field Calc = FindByName(__.Calc);

            ///<summary>说明</summary>
            public static readonly Field Introduce = FindByName(__.Introduce);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>位置</summary>
            public static readonly Field Location = FindByName(__.Location);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得气象设备类型字段名称的快捷方式</summary>
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

            ///<summary>上级</summary>
            public const String ParentSerialnum = "ParentSerialnum";

            ///<summary>单位</summary>
            public const String Unit = "Unit";

            ///<summary>计算公式</summary>
            public const String Calc = "Calc";

            ///<summary>说明</summary>
            public const String Introduce = "Introduce";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>位置</summary>
            public const String Location = "Location";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>气象设备类型接口</summary>
    public partial interface IWeatherDeviceType
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

        /// <summary>上级</summary>
        String ParentSerialnum { get; set; }

        /// <summary>单位</summary>
        String Unit { get; set; }

        /// <summary>计算公式</summary>
        String Calc { get; set; }

        /// <summary>说明</summary>
        String Introduce { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>位置</summary>
        String Location { get; set; }

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