using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>通讯设备</summary>
    [Serializable]
    [DataObject]
    [Description("通讯设备")]
    [BindIndex("IX_CommunicateDevice_CommunicateDeviceTypeID", false, "CommunicateDeviceTypeID")]
    [BindIndex("PK__CommunicateDevice", true, "ID")]
    [BindRelation("CommunicateDeviceTypeID", false, "CommunicateDeviceType", "ID")]
    [BindRelation("ID", true, "ModularDevice", "CommunicateDeviceID")]
    [BindRelation("ID", true, "ShowDevice", "CommunicateDeviceID")]
    [BindTable("CommunicateDevice", Description = "通讯设备", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class CommunicateDevice<TEntity> : ICommunicateDevice
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
                    case __.CommunicateDeviceTypeID:
                        return _CommunicateDeviceTypeID;
                    case __.Args1:
                        return _Args1;
                    case __.Args2:
                        return _Args2;
                    case __.Args3:
                        return _Args3;
                    case __.Args4:
                        return _Args4;
                    case __.Args5:
                        return _Args5;
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
                    case __.CommunicateDeviceTypeID:
                        _CommunicateDeviceTypeID = Convert.ToInt32(value);
                        break;
                    case __.Args1:
                        _Args1 = Convert.ToString(value);
                        break;
                    case __.Args2:
                        _Args2 = Convert.ToString(value);
                        break;
                    case __.Args3:
                        _Args3 = Convert.ToString(value);
                        break;
                    case __.Args4:
                        _Args4 = Convert.ToString(value);
                        break;
                    case __.Args5:
                        _Args5 = Convert.ToString(value);
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

        private Int32 _CommunicateDeviceTypeID;

        /// <summary>通讯设备类型</summary>
        [DisplayName("通讯设备类型")]
        [Description("通讯设备类型")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "CommunicateDeviceTypeID", "通讯设备类型", null, "int", 10, 0, false)]
        [Category("关联选项")]
        public virtual Int32 CommunicateDeviceTypeID
        {
            get { return _CommunicateDeviceTypeID; }
            set
            {
                if (OnPropertyChanging(__.CommunicateDeviceTypeID, value))
                {
                    _CommunicateDeviceTypeID = value;
                    OnPropertyChanged(__.CommunicateDeviceTypeID);
                }
            }
        }

        private String _Args1;

        /// <summary>参数1</summary>
        [DisplayName("参数1")]
        [Description("参数1")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Args1", "参数1", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Args1
        {
            get { return _Args1; }
            set
            {
                if (OnPropertyChanging(__.Args1, value))
                {
                    _Args1 = value;
                    OnPropertyChanged(__.Args1);
                }
            }
        }

        private String _Args2;

        /// <summary>参数2</summary>
        [DisplayName("参数2")]
        [Description("参数2")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "Args2", "参数2", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Args2
        {
            get { return _Args2; }
            set
            {
                if (OnPropertyChanging(__.Args2, value))
                {
                    _Args2 = value;
                    OnPropertyChanged(__.Args2);
                }
            }
        }

        private String _Args3;

        /// <summary>参数3</summary>
        [DisplayName("参数3")]
        [Description("参数3")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "Args3", "参数3", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Args3
        {
            get { return _Args3; }
            set
            {
                if (OnPropertyChanging(__.Args3, value))
                {
                    _Args3 = value;
                    OnPropertyChanged(__.Args3);
                }
            }
        }

        private String _Args4;

        /// <summary>参数4</summary>
        [DisplayName("参数4")]
        [Description("参数4")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "Args4", "参数4", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Args4
        {
            get { return _Args4; }
            set
            {
                if (OnPropertyChanging(__.Args4, value))
                {
                    _Args4 = value;
                    OnPropertyChanged(__.Args4);
                }
            }
        }

        private String _Args5;

        /// <summary>参数5</summary>
        [DisplayName("参数5")]
        [Description("参数5")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "Args5", "参数5", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Args5
        {
            get { return _Args5; }
            set
            {
                if (OnPropertyChanging(__.Args5, value))
                {
                    _Args5 = value;
                    OnPropertyChanged(__.Args5);
                }
            }
        }

        private Boolean _OnlineStatus;

        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(9, "OnlineStatus", "状态", null, "bit", 0, 0, false)]
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
        [BindColumn(10, "Exception", "异常", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(11, "Remark", "备注", null, "nvarchar(1000)", 0, 0, true)]
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

        /// <summary>取得通讯设备字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>通讯设备类型</summary>
            public static readonly Field CommunicateDeviceTypeID = FindByName(__.CommunicateDeviceTypeID);

            ///<summary>参数1</summary>
            public static readonly Field Args1 = FindByName(__.Args1);

            ///<summary>参数2</summary>
            public static readonly Field Args2 = FindByName(__.Args2);

            ///<summary>参数3</summary>
            public static readonly Field Args3 = FindByName(__.Args3);

            ///<summary>参数4</summary>
            public static readonly Field Args4 = FindByName(__.Args4);

            ///<summary>参数5</summary>
            public static readonly Field Args5 = FindByName(__.Args5);

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

        /// <summary>取得通讯设备字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>通讯设备类型</summary>
            public const String CommunicateDeviceTypeID = "CommunicateDeviceTypeID";

            ///<summary>参数1</summary>
            public const String Args1 = "Args1";

            ///<summary>参数2</summary>
            public const String Args2 = "Args2";

            ///<summary>参数3</summary>
            public const String Args3 = "Args3";

            ///<summary>参数4</summary>
            public const String Args4 = "Args4";

            ///<summary>参数5</summary>
            public const String Args5 = "Args5";

            ///<summary>状态</summary>
            public const String OnlineStatus = "OnlineStatus";

            ///<summary>异常</summary>
            public const String Exception = "Exception";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>通讯设备接口</summary>
    public partial interface ICommunicateDevice
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

        /// <summary>通讯设备类型</summary>
        Int32 CommunicateDeviceTypeID { get; set; }

        /// <summary>参数1</summary>
        String Args1 { get; set; }

        /// <summary>参数2</summary>
        String Args2 { get; set; }

        /// <summary>参数3</summary>
        String Args3 { get; set; }

        /// <summary>参数4</summary>
        String Args4 { get; set; }

        /// <summary>参数5</summary>
        String Args5 { get; set; }

        /// <summary>状态</summary>
        Boolean OnlineStatus { get; set; }

        /// <summary>异常</summary>
        String Exception { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}