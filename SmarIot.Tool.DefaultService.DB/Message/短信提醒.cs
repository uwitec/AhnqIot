using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>短信提醒</summary>
    [Serializable]
    [DataObject]
    [Description("短信提醒")]
    [BindIndex("PK__SMS__3214EC2762161060", true, "ID")]
    [BindTable("SMS", Description = "短信提醒", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class SMS<TEntity> : ISMS
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
                    case __.Mobile:
                        return _Mobile;
                    case __.Message:
                        return _Message;
                    case __.CreateTime:
                        return _CreateTime;
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
                    case __.Mobile:
                        _Mobile = Convert.ToString(value);
                        break;
                    case __.Message:
                        _Message = Convert.ToString(value);
                        break;
                    case __.CreateTime:
                        _CreateTime = Convert.ToDateTime(value);
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

        private String _Mobile;

        /// <summary>手机号码</summary>
        [DisplayName("手机号码")]
        [Description("手机号码")]
        [DataObjectField(false, false, false, 11)]
        [BindColumn(2, "Mobile", "手机号码", null, "nvarchar(11)", 0, 0, true)]
        public virtual String Mobile
        {
            get { return _Mobile; }
            set
            {
                if (OnPropertyChanging(__.Mobile, value))
                {
                    _Mobile = value;
                    OnPropertyChanged(__.Mobile);
                }
            }
        }

        private String _Message;

        /// <summary>短消息内容</summary>
        [DisplayName("短消息内容")]
        [Description("短消息内容")]
        [DataObjectField(false, false, false, 500)]
        [BindColumn(3, "Message", "短消息内容", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Message
        {
            get { return _Message; }
            set
            {
                if (OnPropertyChanging(__.Message, value))
                {
                    _Message = value;
                    OnPropertyChanged(__.Message);
                }
            }
        }

        private DateTime _CreateTime;

        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(4, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
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

        #endregion 属性

        #region 字段名

        /// <summary>取得短信提醒字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>手机号码</summary>
            public static readonly Field Mobile = FindByName(__.Mobile);

            ///<summary>短消息内容</summary>
            public static readonly Field Message = FindByName(__.Message);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得短信提醒字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>手机号码</summary>
            public const String Mobile = "Mobile";

            ///<summary>短消息内容</summary>
            public const String Message = "Message";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";
        }

        #endregion 字段名
    }

    /// <summary>短信提醒接口</summary>
    public partial interface ISMS
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

        /// <summary>手机号码</summary>
        String Mobile { get; set; }

        /// <summary>短消息内容</summary>
        String Message { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        #endregion 属性
    }
}