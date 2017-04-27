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
    /// <summary>NewClassByContent</summary>
    /// <remarks></remarks>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_NewClassByContent", true, "ID")]
    [BindTable("NewClassByContent", Description = "", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class NewClassByContent : INewClassByContent
    {
        #region 属性
        
        private Int32 _ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private Guid _ContentGUID;
        /// <summary>内容编码</summary>
        [DisplayName("内容编码")]
        [Description("内容编码")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn(2, "ContentGUID", "内容编码", null, "uniqueidentifier", 0, 0, false)]
        public virtual Guid ContentGUID
        {
            get { return _ContentGUID; }
            set { if (OnPropertyChanging(__.ContentGUID, value)) { _ContentGUID = value; OnPropertyChanged(__.ContentGUID); } }
        }

        private Guid _NewsClass;
        /// <summary>类型</summary>
        [DisplayName("类型")]
        [Description("类型")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn(3, "NewsClass", "类型", null, "uniqueidentifier", 0, 0, false)]
        public virtual Guid NewsClass
        {
            get { return _NewsClass; }
            set { if (OnPropertyChanging(__.NewsClass, value)) { _NewsClass = value; OnPropertyChanged(__.NewsClass); } }
        }

        private String _Title;
        /// <summary>标题</summary>
        [DisplayName("标题")]
        [Description("标题")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(4, "Title", "标题", null, "varchar(100)", 0, 0, false, Master=true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging(__.Title, value)) { _Title = value; OnPropertyChanged(__.Title); } }
        }

        private String _Title1;
        /// <summary>标题1</summary>
        [DisplayName("标题1")]
        [Description("标题1")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "Title1", "标题1", null, "varchar(50)", 0, 0, false)]
        public virtual String Title1
        {
            get { return _Title1; }
            set { if (OnPropertyChanging(__.Title1, value)) { _Title1 = value; OnPropertyChanged(__.Title1); } }
        }

        private Int32 _Click;
        /// <summary>点击数</summary>
        [DisplayName("点击数")]
        [Description("点击数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "Click", "点击数", null, "int", 10, 0, false)]
        public virtual Int32 Click
        {
            get { return _Click; }
            set { if (OnPropertyChanging(__.Click, value)) { _Click = value; OnPropertyChanged(__.Click); } }
        }

        private DateTime _DateTime;
        /// <summary>时间</summary>
        [DisplayName("时间")]
        [Description("时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(7, "DateTime", "时间", null, "datetime", 3, 0, false)]
        public virtual DateTime DateTime
        {
            get { return _DateTime; }
            set { if (OnPropertyChanging(__.DateTime, value)) { _DateTime = value; OnPropertyChanged(__.DateTime); } }
        }

        private Int32 _BeNew;
        /// <summary>1:new;2:import</summary>
        [DisplayName("1:new;2:import")]
        [Description("1:new;2:import")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "BeNew", "1:new;2:import", null, "int", 10, 0, false)]
        public virtual Int32 BeNew
        {
            get { return _BeNew; }
            set { if (OnPropertyChanging(__.BeNew, value)) { _BeNew = value; OnPropertyChanged(__.BeNew); } }
        }

        private Int32 _Enable;
        /// <summary></summary>
        [DisplayName("Enable")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(9, "Enable", "", null, "int", 10, 0, false)]
        public virtual Int32 Enable
        {
            get { return _Enable; }
            set { if (OnPropertyChanging(__.Enable, value)) { _Enable = value; OnPropertyChanged(__.Enable); } }
        }

        private Int32 _Serial;
        /// <summary></summary>
        [DisplayName("Serial")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(10, "Serial", "", null, "int", 10, 0, false)]
        public virtual Int32 Serial
        {
            get { return _Serial; }
            set { if (OnPropertyChanging(__.Serial, value)) { _Serial = value; OnPropertyChanged(__.Serial); } }
        }

        private Int32 _BeOnly;
        /// <summary>0:ahnw;1:ahsp;2:two</summary>
        [DisplayName("0:ahnw;1:ahsp;2:two")]
        [Description("0:ahnw;1:ahsp;2:two")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "BeOnly", "0:ahnw;1:ahsp;2:two", null, "int", 10, 0, false)]
        public virtual Int32 BeOnly
        {
            get { return _BeOnly; }
            set { if (OnPropertyChanging(__.BeOnly, value)) { _BeOnly = value; OnPropertyChanged(__.BeOnly); } }
        }

        private Int32 _AnswerNum;
        /// <summary>回复数</summary>
        [DisplayName("回复数")]
        [Description("回复数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(12, "AnswerNum", "回复数", null, "int", 10, 0, false)]
        public virtual Int32 AnswerNum
        {
            get { return _AnswerNum; }
            set { if (OnPropertyChanging(__.AnswerNum, value)) { _AnswerNum = value; OnPropertyChanged(__.AnswerNum); } }
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
                    case __.ID : return _ID;
                    case __.ContentGUID : return _ContentGUID;
                    case __.NewsClass : return _NewsClass;
                    case __.Title : return _Title;
                    case __.Title1 : return _Title1;
                    case __.Click : return _Click;
                    case __.DateTime : return _DateTime;
                    case __.BeNew : return _BeNew;
                    case __.Enable : return _Enable;
                    case __.Serial : return _Serial;
                    case __.BeOnly : return _BeOnly;
                    case __.AnswerNum : return _AnswerNum;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.ContentGUID : _ContentGUID = (Guid)value; break;
                    case __.NewsClass : _NewsClass = (Guid)value; break;
                    case __.Title : _Title = Convert.ToString(value); break;
                    case __.Title1 : _Title1 = Convert.ToString(value); break;
                    case __.Click : _Click = Convert.ToInt32(value); break;
                    case __.DateTime : _DateTime = Convert.ToDateTime(value); break;
                    case __.BeNew : _BeNew = Convert.ToInt32(value); break;
                    case __.Enable : _Enable = Convert.ToInt32(value); break;
                    case __.Serial : _Serial = Convert.ToInt32(value); break;
                    case __.BeOnly : _BeOnly = Convert.ToInt32(value); break;
                    case __.AnswerNum : _AnswerNum = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得NewClassByContent字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>内容编码</summary>
            public static readonly Field ContentGUID = FindByName(__.ContentGUID);

            ///<summary>类型</summary>
            public static readonly Field NewsClass = FindByName(__.NewsClass);

            ///<summary>标题</summary>
            public static readonly Field Title = FindByName(__.Title);

            ///<summary>标题1</summary>
            public static readonly Field Title1 = FindByName(__.Title1);

            ///<summary>点击数</summary>
            public static readonly Field Click = FindByName(__.Click);

            ///<summary>时间</summary>
            public static readonly Field DateTime = FindByName(__.DateTime);

            ///<summary>1:new;2:import</summary>
            public static readonly Field BeNew = FindByName(__.BeNew);

            ///<summary></summary>
            public static readonly Field Enable = FindByName(__.Enable);

            ///<summary></summary>
            public static readonly Field Serial = FindByName(__.Serial);

            ///<summary>0:ahnw;1:ahsp;2:two</summary>
            public static readonly Field BeOnly = FindByName(__.BeOnly);

            ///<summary>回复数</summary>
            public static readonly Field AnswerNum = FindByName(__.AnswerNum);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得NewClassByContent字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary>内容编码</summary>
            public const String ContentGUID = "ContentGUID";

            ///<summary>类型</summary>
            public const String NewsClass = "NewsClass";

            ///<summary>标题</summary>
            public const String Title = "Title";

            ///<summary>标题1</summary>
            public const String Title1 = "Title1";

            ///<summary>点击数</summary>
            public const String Click = "Click";

            ///<summary>时间</summary>
            public const String DateTime = "DateTime";

            ///<summary>1:new;2:import</summary>
            public const String BeNew = "BeNew";

            ///<summary></summary>
            public const String Enable = "Enable";

            ///<summary></summary>
            public const String Serial = "Serial";

            ///<summary>0:ahnw;1:ahsp;2:two</summary>
            public const String BeOnly = "BeOnly";

            ///<summary>回复数</summary>
            public const String AnswerNum = "AnswerNum";

        }
        
        #endregion
    }

    /// <summary>NewClassByContent接口</summary>
    /// <remarks></remarks>
    public partial interface INewClassByContent
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary>内容编码</summary>
        Guid ContentGUID { get; set; }

        /// <summary>类型</summary>
        Guid NewsClass { get; set; }

        /// <summary>标题</summary>
        String Title { get; set; }

        /// <summary>标题1</summary>
        String Title1 { get; set; }

        /// <summary>点击数</summary>
        Int32 Click { get; set; }

        /// <summary>时间</summary>
        DateTime DateTime { get; set; }

        /// <summary>1:new;2:import</summary>
        Int32 BeNew { get; set; }

        /// <summary></summary>
        Int32 Enable { get; set; }

        /// <summary></summary>
        Int32 Serial { get; set; }

        /// <summary>0:ahnw;1:ahsp;2:two</summary>
        Int32 BeOnly { get; set; }

        /// <summary>回复数</summary>
        Int32 AnswerNum { get; set; }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        
        #endregion
    }
}