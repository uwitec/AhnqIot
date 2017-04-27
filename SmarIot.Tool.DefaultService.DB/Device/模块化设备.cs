using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>模块化设备</summary>
    [Serializable]
    [DataObject]
    [Description("模块化设备")]
    [BindIndex("Index_ModularDeviceName", false, "Name")]
    [BindIndex("IX_ModularDevice_CommunicateDeviceID", false, "CommunicateDeviceID")]
    [BindIndex("PK__ModularD__3214EC27D876B505", true, "ID")]
    [BindIndex("IX_ModularDevice_ProtocalTypeID", false, "ProtocalTypeID")]
    [BindRelation("ID", true, "ControlDeviceUnit", "ModularDeviceID")]
    [BindRelation("CommunicateDeviceID", false, "CommunicateDevice", "ID")]
    [BindRelation("ProtocalTypeID", false, "ProtocalType", "ID")]
    [BindRelation("ID", true, "SensorDeviceUnit", "ModularDeviceID")]
    [BindTable("ModularDevice", Description = "模块化设备", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class ModularDevice<TEntity> : IModularDevice
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
                    case __.Address:
                        return _Address;
                    case __.ProtocalTypeID:
                        return _ProtocalTypeID;
                    case __.CommunicateDeviceID:
                        return _CommunicateDeviceID;
                    case __.OnlineStatus:
                        return _OnlineStatus;
                    case __.Exception:
                        return _Exception;
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
                    case __.Address:
                        _Address = Convert.ToString(value);
                        break;
                    case __.ProtocalTypeID:
                        _ProtocalTypeID = Convert.ToInt32(value);
                        break;
                    case __.CommunicateDeviceID:
                        _CommunicateDeviceID = Convert.ToInt32(value);
                        break;
                    case __.OnlineStatus:
                        _OnlineStatus = Convert.ToBoolean(value);
                        break;
                    case __.Exception:
                        _Exception = Convert.ToString(value);
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
        [Category("基本属性"),ReadOnly(true)]
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
        [Category("基本属性")]
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

        private String _Address;

        /// <summary>设备地址</summary>
        [DisplayName("设备地址")]
        [Description("设备地址")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "Address", "设备地址", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Address
        {
            get { return _Address; }
            set
            {
                if (OnPropertyChanging(__.Address, value))
                {
                    _Address = value;
                    OnPropertyChanged(__.Address);
                }
            }
        }

        private Int32 _ProtocalTypeID;

        /// <summary>协议</summary>
        [DisplayName("协议")]
        [Description("协议")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(4, "ProtocalTypeID", "协议", null, "int", 10, 0, false)]
        [Category("基本属性"),ReadOnly(true)]
        public virtual Int32 ProtocalTypeID
        {
            get { return _ProtocalTypeID; }
            set
            {
                if (OnPropertyChanging(__.ProtocalTypeID, value))
                {
                    _ProtocalTypeID = value;
                    OnPropertyChanged(__.ProtocalTypeID);
                }
            }
        }

        private Int32 _CommunicateDeviceID;

        /// <summary>通讯设备</summary>
        [DisplayName("通讯设备")]
        [Description("通讯设备")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "CommunicateDeviceID", "通讯设备", null, "int", 10, 0, false)]
        [Category("基本属性"), ReadOnly(true)]
        public virtual Int32 CommunicateDeviceID
        {
            get { return _CommunicateDeviceID; }
            set
            {
                if (OnPropertyChanging(__.CommunicateDeviceID, value))
                {
                    _CommunicateDeviceID = value;
                    OnPropertyChanged(__.CommunicateDeviceID);
                }
            }
        }

        private Boolean _OnlineStatus;

        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(6, "OnlineStatus", "状态", null, "bit", 0, 0, false)]
        [Category("基本属性")]
        public virtual Boolean OnlineStatus
        {
            get { return _OnlineStatus; }
            set
            {
                if (OnPropertyChanging(__.OnlineStatus, value))
                {
                    _OnlineStatus = value;
                    OnPropertyChanged(__.OnlineStatus);
                }
            }
        }

        private String _Exception;

        /// <summary>异常</summary>
        [DisplayName("异常")]
        [Description("异常")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "Exception", "异常", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Exception
        {
            get { return _Exception; }
            set
            {
                if (OnPropertyChanging(__.Exception, value))
                {
                    _Exception = value;
                    OnPropertyChanged(__.Exception);
                }
            }
        }

        private String _Remark;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 1000)]
        [BindColumn(8, "Remark", "备注", null, "nvarchar(1000)", 0, 0, true)]
        [Category("基本属性")]
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

        /// <summary>取得模块化设备字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>设备地址</summary>
            public static readonly Field Address = FindByName(__.Address);

            ///<summary>协议</summary>
            public static readonly Field ProtocalTypeID = FindByName(__.ProtocalTypeID);

            ///<summary>通讯设备</summary>
            public static readonly Field CommunicateDeviceID = FindByName(__.CommunicateDeviceID);

            ///<summary>状态</summary>
            public static readonly Field OnlineStatus = FindByName(__.OnlineStatus);

            ///<summary>异常</summary>
            public static readonly Field Exception = FindByName(__.Exception);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得模块化设备字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>设备地址</summary>
            public const String Address = "Address";

            ///<summary>协议</summary>
            public const String ProtocalTypeID = "ProtocalTypeID";

            ///<summary>通讯设备</summary>
            public const String CommunicateDeviceID = "CommunicateDeviceID";

            ///<summary>状态</summary>
            public const String OnlineStatus = "OnlineStatus";

            ///<summary>异常</summary>
            public const String Exception = "Exception";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>模块化设备接口</summary>
    public partial interface IModularDevice
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

        /// <summary>设备地址</summary>
        String Address { get; set; }

        /// <summary>协议</summary>
        Int32 ProtocalTypeID { get; set; }

        /// <summary>通讯设备</summary>
        Int32 CommunicateDeviceID { get; set; }

        /// <summary>状态</summary>
        Boolean OnlineStatus { get; set; }

        /// <summary>异常</summary>
        String Exception { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}