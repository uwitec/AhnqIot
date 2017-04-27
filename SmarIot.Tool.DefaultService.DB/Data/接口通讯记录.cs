using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>接口通讯记录</summary>
    [Serializable]
    [DataObject]
    [Description("接口通讯记录")]
    [BindIndex("Index_ApiAccessLogCreateTime", false, "CreateTime")]
    [BindIndex("Index_ApiAccessLogApiName", false, "ApiName")]
    [BindIndex("PK__ApiAccessLog_", true, "ID")]
    [BindTable("ApiAccessLog", Description = "接口通讯记录", ConnName = "SmartIot-Scada-Log", DbType = DatabaseType.SqlServer)
    ]
    public abstract partial class ApiAccessLog<TEntity> : IApiAccessLog
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
                    case __.ApiName:
                        return _ApiName;
                    case __.CreateTime:
                        return _CreateTime;
                    case __.Result:
                        return _Result;
                    case __.CostTime:
                        return _CostTime;
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
                    case __.ApiName:
                        _ApiName = Convert.ToString(value);
                        break;
                    case __.CreateTime:
                        _CreateTime = Convert.ToDateTime(value);
                        break;
                    case __.Result:
                        _Result = Convert.ToBoolean(value);
                        break;
                    case __.CostTime:
                        _CostTime = Convert.ToInt32(value);
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

        private String _ApiName;

        /// <summary>接口名称</summary>
        [DisplayName("接口名称")]
        [Description("接口名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "ApiName", "接口名称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ApiName
        {
            get { return _ApiName; }
            set
            {
                if (OnPropertyChanging(__.ApiName, value))
                {
                    _ApiName = value;
                    OnPropertyChanged(__.ApiName);
                }
            }
        }

        private DateTime _CreateTime;

        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(3, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
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

        private Boolean _Result;

        /// <summary>访问结果</summary>
        [DisplayName("访问结果")]
        [Description("访问结果")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(4, "Result", "访问结果", "0", "bit", 0, 0, false)]
        public virtual Boolean Result
        {
            get { return _Result; }
            set
            {
                if (OnPropertyChanging(__.Result, value))
                {
                    _Result = value;
                    OnPropertyChanged(__.Result);
                }
            }
        }

        private Int32 _CostTime;

        /// <summary>耗时(秒)</summary>
        [DisplayName("耗时秒")]
        [Description("耗时(秒)")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "CostTime", "耗时(秒)", null, "int", 10, 0, false)]
        public virtual Int32 CostTime
        {
            get { return _CostTime; }
            set
            {
                if (OnPropertyChanging(__.CostTime, value))
                {
                    _CostTime = value;
                    OnPropertyChanged(__.CostTime);
                }
            }
        }

        private String _Remark;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(6, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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

        /// <summary>取得接口通讯记录字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>接口名称</summary>
            public static readonly Field ApiName = FindByName(__.ApiName);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>访问结果</summary>
            public static readonly Field Result = FindByName(__.Result);

            ///<summary>耗时(秒)</summary>
            public static readonly Field CostTime = FindByName(__.CostTime);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得接口通讯记录字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>接口名称</summary>
            public const String ApiName = "ApiName";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>访问结果</summary>
            public const String Result = "Result";

            ///<summary>耗时(秒)</summary>
            public const String CostTime = "CostTime";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>接口通讯记录接口</summary>
    public partial interface IApiAccessLog
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

        /// <summary>接口名称</summary>
        String ApiName { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>访问结果</summary>
        Boolean Result { get; set; }

        /// <summary>耗时(秒)</summary>
        Int32 CostTime { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}