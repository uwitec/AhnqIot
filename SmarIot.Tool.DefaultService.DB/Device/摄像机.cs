using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>摄像机</summary>
    [Serializable]
    [DataObject]
    [Description("摄像机")]
    [BindIndex("PK__Facility__3214EC279E14A2E8", true, "ID")]
    [BindRelation("ID", true, "FacilityCamera", "CameraID")]
    [BindTable("Camera", Description = "摄像机", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class Camera<TEntity> : ICamera
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
                    case __.UserID:
                        return _UserID;
                    case __.UserPwd:
                        return _UserPwd;
                    case __.CameraHost:
                        return _CameraHost;
                    case __.CameraHttpPort:
                        return _CameraHttpPort;
                    case __.CameraDataPort:
                        return _CameraDataPort;
                    case __.CameraRTSPPort:
                        return _CameraRTSPPort;
                    case __.Channel:
                        return _Channel;
                    case __.StreamMedia:
                        return _StreamMedia;
                    case __.Company:
                        return _Company;
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
                    case __.UserID:
                        _UserID = Convert.ToString(value);
                        break;
                    case __.UserPwd:
                        _UserPwd = Convert.ToString(value);
                        break;
                    case __.CameraHost:
                        _CameraHost = Convert.ToString(value);
                        break;
                    case __.CameraHttpPort:
                        _CameraHttpPort = Convert.ToInt32(value);
                        break;
                    case __.CameraDataPort:
                        _CameraDataPort = Convert.ToInt32(value);
                        break;
                    case __.CameraRTSPPort:
                        _CameraRTSPPort = Convert.ToInt32(value);
                        break;
                    case __.Channel:
                        _Channel = Convert.ToInt32(value);
                        break;
                    case __.StreamMedia:
                        _StreamMedia = Convert.ToString(value);
                        break;
                    case __.Company:
                        _Company = Convert.ToString(value);
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
        [ReadOnly(true)]
        [Category("基本属性")]
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

        private String _UserID;

        /// <summary>登录用户名</summary>
        [DisplayName("登录用户名")]
        [Description("登录用户名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "UserID", "登录用户名", "admin", "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String UserID
        {
            get { return _UserID; }
            set
            {
                if (OnPropertyChanging(__.UserID, value))
                {
                    _UserID = value;
                    OnPropertyChanged(__.UserID);
                }
            }
        }

        private String _UserPwd;

        /// <summary>登录密码</summary>
        [DisplayName("登录密码")]
        [Description("登录密码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "UserPwd", "登录密码", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String UserPwd
        {
            get { return _UserPwd; }
            set
            {
                if (OnPropertyChanging(__.UserPwd, value))
                {
                    _UserPwd = value;
                    OnPropertyChanged(__.UserPwd);
                }
            }
        }

        private String _CameraHost;

        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "CameraHost", "地址", "192.168.1.64", "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String CameraHost
        {
            get { return _CameraHost; }
            set
            {
                if (OnPropertyChanging(__.CameraHost, value))
                {
                    _CameraHost = value;
                    OnPropertyChanged(__.CameraHost);
                }
            }
        }

        private Int32 _CameraHttpPort;

        /// <summary>web端口号</summary>
        [DisplayName("web端口号")]
        [Description("web端口号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "CameraHttpPort", "web端口号", "80", "int", 10, 0, false)]
        [Category("基本属性")]
        public virtual Int32 CameraHttpPort
        {
            get { return _CameraHttpPort; }
            set
            {
                if (OnPropertyChanging(__.CameraHttpPort, value))
                {
                    _CameraHttpPort = value;
                    OnPropertyChanged(__.CameraHttpPort);
                }
            }
        }

        private Int32 _CameraDataPort;

        /// <summary>数据端口号</summary>
        [DisplayName("数据端口号")]
        [Description("数据端口号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "CameraDataPort", "数据端口号", "8000", "int", 10, 0, false)]
        [Category("基本属性")]
        public virtual Int32 CameraDataPort
        {
            get { return _CameraDataPort; }
            set
            {
                if (OnPropertyChanging(__.CameraDataPort, value))
                {
                    _CameraDataPort = value;
                    OnPropertyChanged(__.CameraDataPort);
                }
            }
        }

        private Int32 _CameraRTSPPort;

        /// <summary>数据端口号</summary>
        [DisplayName("数据端口号")]
        [Description("数据端口号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(8, "CameraRTSPPort", "数据端口号", "554", "int", 10, 0, false)]
        [Category("基本属性")]
        public virtual Int32 CameraRTSPPort
        {
            get { return _CameraRTSPPort; }
            set
            {
                if (OnPropertyChanging(__.CameraRTSPPort, value))
                {
                    _CameraRTSPPort = value;
                    OnPropertyChanged(__.CameraRTSPPort);
                }
            }
        }

        private Int32 _Channel;

        /// <summary>通道</summary>
        [DisplayName("通道")]
        [Description("通道")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(9, "Channel", "通道", "1", "int", 10, 0, false)]
        [Category("基本属性")]
        public virtual Int32 Channel
        {
            get { return _Channel; }
            set
            {
                if (OnPropertyChanging(__.Channel, value))
                {
                    _Channel = value;
                    OnPropertyChanged(__.Channel);
                }
            }
        }

        private String _StreamMedia;

        /// <summary>流媒体地址</summary>
        [DisplayName("流媒体地址")]
        [Description("流媒体地址")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(10, "StreamMedia", "流媒体地址", null, "nvarchar(500)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String StreamMedia
        {
            get { return _StreamMedia; }
            set
            {
                if (OnPropertyChanging(__.StreamMedia, value))
                {
                    _StreamMedia = value;
                    OnPropertyChanged(__.StreamMedia);
                }
            }
        }

        private String _Company;

        /// <summary>厂家</summary>
        [DisplayName("厂家")]
        [Description("厂家")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(11, "Company", "厂家", "海康威视", "nvarchar(500)", 0, 0, true)]
        [Category("基本属性")]
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

        private Boolean _OnlineStatus;

        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(12, "OnlineStatus", "状态", null, "bit", 0, 0, false)]
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
        [BindColumn(13, "Exception", "异常", null, "nvarchar(50)", 0, 0, true)]
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
        [DataObjectField(false, false, true, 500)]
        [BindColumn(14, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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

        /// <summary>取得摄像机字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>登录用户名</summary>
            public static readonly Field UserID = FindByName(__.UserID);

            ///<summary>登录密码</summary>
            public static readonly Field UserPwd = FindByName(__.UserPwd);

            ///<summary>地址</summary>
            public static readonly Field CameraHost = FindByName(__.CameraHost);

            ///<summary>web端口号</summary>
            public static readonly Field CameraHttpPort = FindByName(__.CameraHttpPort);

            ///<summary>数据端口号</summary>
            public static readonly Field CameraDataPort = FindByName(__.CameraDataPort);

            ///<summary>数据端口号</summary>
            public static readonly Field CameraRTSPPort = FindByName(__.CameraRTSPPort);

            ///<summary>通道</summary>
            public static readonly Field Channel = FindByName(__.Channel);

            ///<summary>流媒体地址</summary>
            public static readonly Field StreamMedia = FindByName(__.StreamMedia);

            ///<summary>厂家</summary>
            public static readonly Field Company = FindByName(__.Company);

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

        /// <summary>取得摄像机字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>登录用户名</summary>
            public const String UserID = "UserID";

            ///<summary>登录密码</summary>
            public const String UserPwd = "UserPwd";

            ///<summary>地址</summary>
            public const String CameraHost = "CameraHost";

            ///<summary>web端口号</summary>
            public const String CameraHttpPort = "CameraHttpPort";

            ///<summary>数据端口号</summary>
            public const String CameraDataPort = "CameraDataPort";

            ///<summary>数据端口号</summary>
            public const String CameraRTSPPort = "CameraRTSPPort";

            ///<summary>通道</summary>
            public const String Channel = "Channel";

            ///<summary>流媒体地址</summary>
            public const String StreamMedia = "StreamMedia";

            ///<summary>厂家</summary>
            public const String Company = "Company";

            ///<summary>状态</summary>
            public const String OnlineStatus = "OnlineStatus";

            ///<summary>异常</summary>
            public const String Exception = "Exception";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>摄像机接口</summary>
    public partial interface ICamera
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

        /// <summary>登录用户名</summary>
        String UserID { get; set; }

        /// <summary>登录密码</summary>
        String UserPwd { get; set; }

        /// <summary>地址</summary>
        String CameraHost { get; set; }

        /// <summary>web端口号</summary>
        Int32 CameraHttpPort { get; set; }

        /// <summary>数据端口号</summary>
        Int32 CameraDataPort { get; set; }

        /// <summary>数据端口号</summary>
        Int32 CameraRTSPPort { get; set; }

        /// <summary>通道</summary>
        Int32 Channel { get; set; }

        /// <summary>流媒体地址</summary>
        String StreamMedia { get; set; }

        /// <summary>厂家</summary>
        String Company { get; set; }

        /// <summary>状态</summary>
        Boolean OnlineStatus { get; set; }

        /// <summary>异常</summary>
        String Exception { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}