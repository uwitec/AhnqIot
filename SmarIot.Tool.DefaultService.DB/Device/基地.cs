using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>基地</summary>
    [Serializable]
    [DataObject]
    [Description("基地")]
    [BindIndex("PK__Farm__3214EC27C24FB40E", true, "ID")]
    [BindRelation("ID", true, "Facility", "FarmID")]
    [BindTable("Farm", Description = "基地", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class Farm<TEntity> : IFarm
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
                    case __.Code1:
                        return _Code1;
                    case __.Code2:
                        return _Code2;
                    case __.Code3:
                        return _Code3;
                    case __.Name:
                        return _Name;
                    case __.CompanySerialnum:
                        return _CompanySerialnum;
                    case __.Address:
                        return _Address;
                    case __.PhotoUrl:
                        return _PhotoUrl;
                    case __.Lotitude:
                        return _Lotitude;
                    case __.Latitude:
                        return _Latitude;
                    case __.Area:
                        return _Area;
                    case __.ContactMan:
                        return _ContactMan;
                    case __.ContactPhone:
                        return _ContactPhone;
                    case __.ContactMobile:
                        return _ContactMobile;
                    case __.Status:
                        return _Status;
                    case __.CreateTime:
                        return _CreateTime;
                    case __.UpdateTime:
                        return _UpdateTime;
                    case __.APIKey:
                        return _APIKey;
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
                    case __.ID:
                        _ID = Convert.ToInt32(value);
                        break;
                    case __.Code1:
                        _Code1 = Convert.ToString(value);
                        break;
                    case __.Code2:
                        _Code2 = Convert.ToString(value);
                        break;
                    case __.Code3:
                        _Code3 = Convert.ToString(value);
                        break;
                    case __.Name:
                        _Name = Convert.ToString(value);
                        break;
                    case __.CompanySerialnum:
                        _CompanySerialnum = Convert.ToString(value);
                        break;
                    case __.Address:
                        _Address = Convert.ToString(value);
                        break;
                    case __.PhotoUrl:
                        _PhotoUrl = Convert.ToString(value);
                        break;
                    case __.Lotitude:
                        _Lotitude = Convert.ToString(value);
                        break;
                    case __.Latitude:
                        _Latitude = Convert.ToString(value);
                        break;
                    case __.Area:
                        _Area = Convert.ToInt32(value);
                        break;
                    case __.ContactMan:
                        _ContactMan = Convert.ToString(value);
                        break;
                    case __.ContactPhone:
                        _ContactPhone = Convert.ToString(value);
                        break;
                    case __.ContactMobile:
                        _ContactMobile = Convert.ToString(value);
                        break;
                    case __.Status:
                        _Status = Convert.ToBoolean(value);
                        break;
                    case __.CreateTime:
                        _CreateTime = Convert.ToDateTime(value);
                        break;
                    case __.UpdateTime:
                        _UpdateTime = Convert.ToDateTime(value);
                        break;
                    case __.APIKey:
                        _APIKey = Convert.ToString(value);
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

        private String _Code1;

        /// <summary>编码1</summary>
        [DisplayName("编码1")]
        [Description("编码1")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "Code1", "编码1", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Code1
        {
            get { return _Code1; }
            set
            {
                if (OnPropertyChanging(__.Code1, value))
                {
                    _Code1 = value;
                    OnPropertyChanged(__.Code1);
                }
            }
        }

        private String _Code2;

        /// <summary>编码2</summary>
        [DisplayName("编码2")]
        [Description("编码2")]
        [DataObjectField(false, false, true, 50)]
        [Category("基本属性")]
        [BindColumn(3, "Code2", "编码2", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code2
        {
            get { return _Code2; }
            set
            {
                if (OnPropertyChanging(__.Code2, value))
                {
                    _Code2 = value;
                    OnPropertyChanged(__.Code2);
                }
            }
        }

        private String _Code3;

        /// <summary>编码3</summary>
        [DisplayName("编码3")]
        [Description("编码3")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Code3", "编码3", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Code3
        {
            get { return _Code3; }
            set
            {
                if (OnPropertyChanging(__.Code3, value))
                {
                    _Code3 = value;
                    OnPropertyChanged(__.Code3);
                }
            }
        }

        private String _Name;

        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(5, "Name", "名称", null, "nvarchar(50)", 0, 0, true, Master = true)]
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

        private String _CompanySerialnum;
        [Category("基本属性")]

        /// <summary>企业</summary>
        [DisplayName("企业")]
        [Description("企业")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "CompanySerialnum", "企业", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CompanySerialnum
        {
            get { return _CompanySerialnum; }
            set
            {
                if (OnPropertyChanging(__.CompanySerialnum, value))
                {
                    _CompanySerialnum = value;
                    OnPropertyChanged(__.CompanySerialnum);
                }
            }
        }

        private String _Address;

        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(7, "Address", "地址", null, "nvarchar(500)", 0, 0, true)]
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

        private String _PhotoUrl;

        /// <summary>形象图片</summary>
        [DisplayName("形象图片")]
        [Description("形象图片")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(8, "PhotoUrl", "形象图片", null, "nvarchar(500)", 0, 0, true)]
        [Category("基本属性")]
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

        private String _Lotitude;

        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "Lotitude", "经度", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Lotitude
        {
            get { return _Lotitude; }
            set
            {
                if (OnPropertyChanging(__.Lotitude, value))
                {
                    _Lotitude = value;
                    OnPropertyChanged(__.Lotitude);
                }
            }
        }

        private String _Latitude;

        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "Latitude", "纬度", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String Latitude
        {
            get { return _Latitude; }
            set
            {
                if (OnPropertyChanging(__.Latitude, value))
                {
                    _Latitude = value;
                    OnPropertyChanged(__.Latitude);
                }
            }
        }

        private Int32 _Area;

        /// <summary>面积</summary>
        [DisplayName("面积")]
        [Description("面积")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "Area", "面积", "0", "int", 10, 0, false)]
        [Category("基本属性")]
        public virtual Int32 Area
        {
            get { return _Area; }
            set
            {
                if (OnPropertyChanging(__.Area, value))
                {
                    _Area = value;
                    OnPropertyChanged(__.Area);
                }
            }
        }

        private String _ContactMan;

        /// <summary>联系人</summary>
        [DisplayName("联系人")]
        [Description("联系人")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "ContactMan", "联系人", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String ContactMan
        {
            get { return _ContactMan; }
            set
            {
                if (OnPropertyChanging(__.ContactMan, value))
                {
                    _ContactMan = value;
                    OnPropertyChanged(__.ContactMan);
                }
            }
        }

        private String _ContactPhone;

        /// <summary>联系电话</summary>
        [DisplayName("联系电话")]
        [Description("联系电话")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "ContactPhone", "联系电话", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String ContactPhone
        {
            get { return _ContactPhone; }
            set
            {
                if (OnPropertyChanging(__.ContactPhone, value))
                {
                    _ContactPhone = value;
                    OnPropertyChanged(__.ContactPhone);
                }
            }
        }

        private String _ContactMobile;

        /// <summary>手机</summary>
        [DisplayName("手机")]
        [Description("手机")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "ContactMobile", "手机", null, "nvarchar(50)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String ContactMobile
        {
            get { return _ContactMobile; }
            set
            {
                if (OnPropertyChanging(__.ContactMobile, value))
                {
                    _ContactMobile = value;
                    OnPropertyChanged(__.ContactMobile);
                }
            }
        }

        private Boolean _Status;

        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(15, "Status", "状态", "0", "bit", 0, 0, false)]
        [Category("基本属性")]
        public virtual Boolean Status
        {
            get { return _Status; }
            set
            {
                if (OnPropertyChanging(__.Status, value))
                {
                    _Status = value;
                    OnPropertyChanged(__.Status);
                }
            }
        }

        private DateTime _CreateTime;

        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(16, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
        [Category("基本属性")]
        [ReadOnly(true)]
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
        [DataObjectField(false, false, false, 3)]
        [BindColumn(17, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
        [Category("基本属性")]
        [ReadOnly(true)]
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

        private String _APIKey;

        /// <summary>数据接口访问KEY</summary>
        [DisplayName("数据接口访问KEY")]
        [Description("数据接口访问KEY")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(18, "APIKey", "数据接口访问KEY", null, "nvarchar(500)", 0, 0, true)]
        [Category("基本属性")]
        public virtual String APIKey
        {
            get { return _APIKey; }
            set
            {
                if (OnPropertyChanging(__.APIKey, value))
                {
                    _APIKey = value;
                    OnPropertyChanged(__.APIKey);
                }
            }
        }

        private Boolean _Upload;

        /// <summary>是否上传</summary>
        [DisplayName("是否上传")]
        [Description("是否上传")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(19, "Upload", "是否上传", "0", "bit", 0, 0, false)]
        [Category("基本属性")]
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
        [BindColumn(20, "Version", "版本", "0", "int", 10, 0, false)]
        [Category("基本属性")]
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

        /// <summary>基地介绍</summary>
        [DisplayName("基地介绍")]
        [Description("基地介绍")]
        [DataObjectField(false, false, true, -1)]
        [Category("基本属性")]
        [BindColumn(21, "Introduce", "基地介绍", null, "ntext", 0, 0, true)]
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
        [DisplayName("基地密码")]
        [Description("基地密码")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(22, "Remark", "基地密码", null, "nvarchar(500)", 0, 0, true)]
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

        /// <summary>取得基地字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>编码1</summary>
            public static readonly Field Code1 = FindByName(__.Code1);

            ///<summary>编码2</summary>
            public static readonly Field Code2 = FindByName(__.Code2);

            ///<summary>编码3</summary>
            public static readonly Field Code3 = FindByName(__.Code3);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>企业</summary>
            public static readonly Field CompanySerialnum = FindByName(__.CompanySerialnum);

            ///<summary>地址</summary>
            public static readonly Field Address = FindByName(__.Address);

            ///<summary>形象图片</summary>
            public static readonly Field PhotoUrl = FindByName(__.PhotoUrl);

            ///<summary>经度</summary>
            public static readonly Field Lotitude = FindByName(__.Lotitude);

            ///<summary>纬度</summary>
            public static readonly Field Latitude = FindByName(__.Latitude);

            ///<summary>面积</summary>
            public static readonly Field Area = FindByName(__.Area);

            ///<summary>联系人</summary>
            public static readonly Field ContactMan = FindByName(__.ContactMan);

            ///<summary>联系电话</summary>
            public static readonly Field ContactPhone = FindByName(__.ContactPhone);

            ///<summary>手机</summary>
            public static readonly Field ContactMobile = FindByName(__.ContactMobile);

            ///<summary>状态</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            ///<summary>数据接口访问KEY</summary>
            public static readonly Field APIKey = FindByName(__.APIKey);

            ///<summary>是否上传</summary>
            public static readonly Field Upload = FindByName(__.Upload);

            ///<summary>版本</summary>
            public static readonly Field Version = FindByName(__.Version);

            ///<summary>基地介绍</summary>
            public static readonly Field Introduce = FindByName(__.Introduce);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得基地字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>编码1</summary>
            public const String Code1 = "Code1";

            ///<summary>编码2</summary>
            public const String Code2 = "Code2";

            ///<summary>编码3</summary>
            public const String Code3 = "Code3";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>企业</summary>
            public const String CompanySerialnum = "CompanySerialnum";

            ///<summary>地址</summary>
            public const String Address = "Address";

            ///<summary>形象图片</summary>
            public const String PhotoUrl = "PhotoUrl";

            ///<summary>经度</summary>
            public const String Lotitude = "Lotitude";

            ///<summary>纬度</summary>
            public const String Latitude = "Latitude";

            ///<summary>面积</summary>
            public const String Area = "Area";

            ///<summary>联系人</summary>
            public const String ContactMan = "ContactMan";

            ///<summary>联系电话</summary>
            public const String ContactPhone = "ContactPhone";

            ///<summary>手机</summary>
            public const String ContactMobile = "ContactMobile";

            ///<summary>状态</summary>
            public const String Status = "Status";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            ///<summary>数据接口访问KEY</summary>
            public const String APIKey = "APIKey";

            ///<summary>是否上传</summary>
            public const String Upload = "Upload";

            ///<summary>版本</summary>
            public const String Version = "Version";

            ///<summary>基地介绍</summary>
            public const String Introduce = "Introduce";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>基地接口</summary>
    public partial interface IFarm
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

        /// <summary>编码1</summary>
        String Code1 { get; set; }

        /// <summary>编码2</summary>
        String Code2 { get; set; }

        /// <summary>编码3</summary>
        String Code3 { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>企业</summary>
        String CompanySerialnum { get; set; }

        /// <summary>地址</summary>
        String Address { get; set; }

        /// <summary>形象图片</summary>
        String PhotoUrl { get; set; }

        /// <summary>经度</summary>
        String Lotitude { get; set; }

        /// <summary>纬度</summary>
        String Latitude { get; set; }

        /// <summary>面积</summary>
        Int32 Area { get; set; }

        /// <summary>联系人</summary>
        String ContactMan { get; set; }

        /// <summary>联系电话</summary>
        String ContactPhone { get; set; }

        /// <summary>手机</summary>
        String ContactMobile { get; set; }

        /// <summary>状态</summary>
        Boolean Status { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>数据接口访问KEY</summary>
        String APIKey { get; set; }

        /// <summary>是否上传</summary>
        Boolean Upload { get; set; }

        /// <summary>版本</summary>
        Int32 Version { get; set; }

        /// <summary>基地介绍</summary>
        String Introduce { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}