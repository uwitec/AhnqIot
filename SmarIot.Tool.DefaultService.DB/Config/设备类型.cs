using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>设备类型</summary>
    [Serializable]
    [DataObject]
    [Description("设备类型")]
    [BindIndex("Index_DeviceTypeName", false, "Name")]
    [BindIndex("PK__DeviceTy__E3E7488D9DACADC2", true, "Serialnum")]
    [BindRelation("Serialnum", true, "ControlDeviceUnit", "DeviceTypeSerialnum")]
    [BindRelation("Serialnum", true, "Sensor", "DeviceTypeSerialnum")]
    [BindTable("DeviceType", Description = "设备类型", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class DeviceType<TEntity> : IDeviceType
    {
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
                    case __.Serialnum:
                        return _Serialnum;
                    case __.Name:
                        return _Name;
                    case __.ParentSerialnum:
                        return _ParentSerialnum;
                    case __.PhotoUrl:
                        return _PhotoUrl;
                    case __.CreateTime:
                        return _CreateTime;
                    case __.UpdateTime:
                        return _UpdateTime;
                    case __.Upload:
                        return _Upload;
                    case __.Version:
                        return _Version;
                    case __.Introduce:
                        return _Introduce;
                    case __.Remark:
                        return _Remark;
                    default:
                        return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Serialnum:
                        _Serialnum = Convert.ToString(value);
                        break;
                    case __.Name:
                        _Name = Convert.ToString(value);
                        break;
                    case __.ParentSerialnum:
                        _ParentSerialnum = Convert.ToString(value);
                        break;
                    case __.PhotoUrl:
                        _PhotoUrl = Convert.ToString(value);
                        break;
                    case __.CreateTime:
                        _CreateTime = Convert.ToDateTime(value);
                        break;
                    case __.UpdateTime:
                        _UpdateTime = Convert.ToDateTime(value);
                        break;
                    case __.Upload:
                        _Upload = Convert.ToBoolean(value);
                        break;
                    case __.Version:
                        _Version = Convert.ToInt32(value);
                        break;
                    case __.Introduce:
                        _Introduce = Convert.ToString(value);
                        break;
                    case __.Remark:
                        _Remark = Convert.ToString(value);
                        break;
                    default:
                        base[name] = value;
                        break;
                }
            }
        }

        #endregion 获取/设置 字段值

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
            set
            {
                if (OnPropertyChanging(__.Serialnum, value))
                {
                    _Serialnum = value;
                    OnPropertyChanged(__.Serialnum);
                }
            }
        }

        private String _Name;

        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "Name", "名称", null, "nvarchar(50)", 0, 0, true, Master = true)]
        public virtual String Name
        {
            get { return _Name; }
            set
            {
                if (OnPropertyChanging(__.Name, value))
                {
                    _Name = value;
                    OnPropertyChanged(__.Name);
                }
            }
        }

        private String _ParentSerialnum;

        /// <summary>上级类型编码</summary>
        [DisplayName("上级类型编码")]
        [Description("上级类型编码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "ParentSerialnum", "上级类型编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ParentSerialnum
        {
            get { return _ParentSerialnum; }
            set
            {
                if (OnPropertyChanging(__.ParentSerialnum, value))
                {
                    _ParentSerialnum = value;
                    OnPropertyChanged(__.ParentSerialnum);
                }
            }
        }

        private String _PhotoUrl;

        /// <summary>形象图片</summary>
        [DisplayName("形象图片")]
        [Description("形象图片")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(4, "PhotoUrl", "形象图片", null, "nvarchar(500)", 0, 0, true)]
        public virtual String PhotoUrl
        {
            get { return _PhotoUrl; }
            set
            {
                if (OnPropertyChanging(__.PhotoUrl, value))
                {
                    _PhotoUrl = value;
                    OnPropertyChanged(__.PhotoUrl);
                }
            }
        }

        private DateTime _CreateTime;

        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(5, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateTime
        {
            get { return _CreateTime; }
            set
            {
                if (OnPropertyChanging(__.CreateTime, value))
                {
                    _CreateTime = value;
                    OnPropertyChanged(__.CreateTime);
                }
            }
        }

        private DateTime _UpdateTime;

        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(6, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set
            {
                if (OnPropertyChanging(__.UpdateTime, value))
                {
                    _UpdateTime = value;
                    OnPropertyChanged(__.UpdateTime);
                }
            }
        }

        private Boolean _Upload;

        /// <summary>是否上传</summary>
        [DisplayName("是否上传")]
        [Description("是否上传")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(7, "Upload", "是否上传", "0", "bit", 0, 0, false)]
        public virtual Boolean Upload
        {
            get { return _Upload; }
            set
            {
                if (OnPropertyChanging(__.Upload, value))
                {
                    _Upload = value;
                    OnPropertyChanged(__.Upload);
                }
            }
        }

        private Int32 _Version;

        /// <summary>版本</summary>
        [DisplayName("版本")]
        [Description("版本")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(8, "Version", "版本", "0", "int", 10, 0, false)]
        public virtual Int32 Version
        {
            get { return _Version; }
            set
            {
                if (OnPropertyChanging(__.Version, value))
                {
                    _Version = value;
                    OnPropertyChanged(__.Version);
                }
            }
        }

        private String _Introduce;

        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(9, "Introduce", "描述", null, "ntext", 0, 0, true)]
        public virtual String Introduce
        {
            get { return _Introduce; }
            set
            {
                if (OnPropertyChanging(__.Introduce, value))
                {
                    _Introduce = value;
                    OnPropertyChanged(__.Introduce);
                }
            }
        }

        private String _Remark;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(10, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Remark
        {
            get { return _Remark; }
            set
            {
                if (OnPropertyChanging(__.Remark, value))
                {
                    _Remark = value;
                    OnPropertyChanged(__.Remark);
                }
            }
        }

        #endregion 属性

        #region 字段名

        /// <summary>取得设备类型字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>编码</summary>
            public static readonly Field Serialnum = FindByName(__.Serialnum);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>上级类型编码</summary>
            public static readonly Field ParentSerialnum = FindByName(__.ParentSerialnum);

            ///<summary>形象图片</summary>
            public static readonly Field PhotoUrl = FindByName(__.PhotoUrl);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            ///<summary>是否上传</summary>
            public static readonly Field Upload = FindByName(__.Upload);

            ///<summary>版本</summary>
            public static readonly Field Version = FindByName(__.Version);

            ///<summary>描述</summary>
            public static readonly Field Introduce = FindByName(__.Introduce);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得设备类型字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编码</summary>
            public const String Serialnum = "Serialnum";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>上级类型编码</summary>
            public const String ParentSerialnum = "ParentSerialnum";

            ///<summary>形象图片</summary>
            public const String PhotoUrl = "PhotoUrl";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            ///<summary>是否上传</summary>
            public const String Upload = "Upload";

            ///<summary>版本</summary>
            public const String Version = "Version";

            ///<summary>描述</summary>
            public const String Introduce = "Introduce";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>设备类型接口</summary>
    public partial interface IDeviceType
    {
        #region 获取/设置 字段值

        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }

        #endregion 获取/设置 字段值

        #region 属性

        /// <summary>编码</summary>
        String Serialnum { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>上级类型编码</summary>
        String ParentSerialnum { get; set; }

        /// <summary>形象图片</summary>
        String PhotoUrl { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>是否上传</summary>
        Boolean Upload { get; set; }

        /// <summary>版本</summary>
        Int32 Version { get; set; }

        /// <summary>描述</summary>
        String Introduce { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}