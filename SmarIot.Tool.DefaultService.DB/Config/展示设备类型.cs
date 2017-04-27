using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>展示设备类型</summary>
    [Serializable]
    [DataObject]
    [Description("展示设备类型")]
    [BindIndex("PK__ShowDevi__3214EC276E7289B8", true, "ID")]
    [BindRelation("ID", true, "ShowDevice", "ShowDeviceTypeID")]
    [BindTable("ShowDeviceType", Description = "展示设备类型", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class ShowDeviceType<TEntity> : IShowDeviceType
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
                    case __.ID:
                        return _ID;
                    case __.Name:
                        return _Name;
                    case __.Company:
                        return _Company;
                    case __.Version:
                        return _Version;
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
                    case __.ID:
                        _ID = Convert.ToInt32(value);
                        break;
                    case __.Name:
                        _Name = Convert.ToString(value);
                        break;
                    case __.Company:
                        _Company = Convert.ToString(value);
                        break;
                    case __.Version:
                        _Version = Convert.ToString(value);
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

        private Int32 _ID;

        /// <summary>ID</summary>
        [DisplayName("ID")]
        [Description("ID")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "ID", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set
            {
                if (OnPropertyChanging(__.ID, value))
                {
                    _ID = value;
                    OnPropertyChanged(__.ID);
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

        private String _Company;

        /// <summary>厂家</summary>
        [DisplayName("厂家")]
        [Description("厂家")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(3, "Company", "厂家", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Company
        {
            get { return _Company; }
            set
            {
                if (OnPropertyChanging(__.Company, value))
                {
                    _Company = value;
                    OnPropertyChanged(__.Company);
                }
            }
        }

        private String _Version;

        /// <summary>版本号</summary>
        [DisplayName("版本号")]
        [Description("版本号")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(4, "Version", "版本号", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Version
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

        private String _Remark;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 1000)]
        [BindColumn(5, "Remark", "备注", null, "nvarchar(1000)", 0, 0, true)]
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

        /// <summary>取得展示设备类型字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>厂家</summary>
            public static readonly Field Company = FindByName(__.Company);

            ///<summary>版本号</summary>
            public static readonly Field Version = FindByName(__.Version);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得展示设备类型字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>厂家</summary>
            public const String Company = "Company";

            ///<summary>版本号</summary>
            public const String Version = "Version";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>展示设备类型接口</summary>
    public partial interface IShowDeviceType
    {
        #region 获取/设置 字段值

        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }

        #endregion 获取/设置 字段值

        #region 属性

        /// <summary>ID</summary>
        Int32 ID { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>厂家</summary>
        String Company { get; set; }

        /// <summary>版本号</summary>
        String Version { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}