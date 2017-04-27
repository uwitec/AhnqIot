using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>设施摄像机</summary>
    [Serializable]
    [DataObject]
    [Description("设施摄像机")]
    [BindIndex("PK_FacilityCamera", true, "ID")]
    [BindIndex("IX_FacilityCamera_CameraID", false, "CameraID")]
    [BindIndex("IX_FacilityCamera_FacilityID", false, "FacilityID")]
    [BindRelation("ID", true, "CameraPresetPoint", "FacilityCameraID")]
    [BindRelation("CameraID", false, "Camera", "ID")]
    [BindRelation("FacilityID", false, "Facility", "ID")]
    [BindTable("FacilityCamera", Description = "设施摄像机", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class FacilityCamera<TEntity> : IFacilityCamera
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
                    case __.FacilityID:
                        return _FacilityID;
                    case __.CameraID:
                        return _CameraID;
                    case __.CreateTime:
                        return _CreateTime;
                    case __.UpdateTime:
                        return _UpdateTime;
                    case __.Upload:
                        return _Upload;
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
                    case __.Code1:
                        _Code1 = Convert.ToString(value);
                        break;
                    case __.Code2:
                        _Code2 = Convert.ToString(value);
                        break;
                    case __.Code3:
                        _Code3 = Convert.ToString(value);
                        break;
                    case __.FacilityID:
                        _FacilityID = Convert.ToInt32(value);
                        break;
                    case __.CameraID:
                        _CameraID = Convert.ToInt32(value);
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

        private Int32 _FacilityID;

        /// <summary></summary>
        [DisplayName("FacilityID")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "FacilityID", "", null, "int", 10, 0, false)]
        public virtual Int32 FacilityID
        {
            get { return _FacilityID; }
            set
            {
                if (OnPropertyChanging(__.FacilityID, value))
                {
                    _FacilityID = value;
                    OnPropertyChanged(__.FacilityID);
                }
            }
        }

        private Int32 _CameraID;

        /// <summary></summary>
        [DisplayName("CameraID")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "CameraID", "", null, "int", 10, 0, false)]
        public virtual Int32 CameraID
        {
            get { return _CameraID; }
            set
            {
                if (OnPropertyChanging(__.CameraID, value))
                {
                    _CameraID = value;
                    OnPropertyChanged(__.CameraID);
                }
            }
        }

        private DateTime _CreateTime;

        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(7, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(8, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
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

        private Boolean _Upload;

        /// <summary>是否上传</summary>
        [DisplayName("是否上传")]
        [Description("是否上传")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(9, "Upload", "是否上传", "0", "bit", 0, 0, false)]
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
        [BindColumn(10, "Version", "版本", "0", "int", 10, 0, false)]
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

        private String _Remark;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(11, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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

        /// <summary>取得设施摄像机字段信息的快捷方式</summary>
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

            ///<summary></summary>
            public static readonly Field FacilityID = FindByName(__.FacilityID);

            ///<summary></summary>
            public static readonly Field CameraID = FindByName(__.CameraID);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            ///<summary>是否上传</summary>
            public static readonly Field Upload = FindByName(__.Upload);

            ///<summary>版本</summary>
            public static readonly Field Version = FindByName(__.Version);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得设施摄像机字段名称的快捷方式</summary>
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

            ///<summary></summary>
            public const String FacilityID = "FacilityID";

            ///<summary></summary>
            public const String CameraID = "CameraID";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            ///<summary>是否上传</summary>
            public const String Upload = "Upload";

            ///<summary>版本</summary>
            public const String Version = "Version";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>设施摄像机接口</summary>
    public partial interface IFacilityCamera
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

        /// <summary></summary>
        Int32 FacilityID { get; set; }

        /// <summary></summary>
        Int32 CameraID { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>是否上传</summary>
        Boolean Upload { get; set; }

        /// <summary>版本</summary>
        Int32 Version { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}