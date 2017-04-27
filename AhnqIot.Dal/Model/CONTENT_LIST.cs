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
    /// <summary>List</summary>
    /// <remarks></remarks>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK__CONTENT___3214EC2766BE7745", true, "ID")]
    [BindTable("CONTENT_LIST", Description = "", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class CONTENT_LIST : ICONTENT_LIST
    {
        #region 属性
        
        private Decimal _ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn(1, "ID", "", null, "decimal", 10, 0, false)]
        public virtual Decimal ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private String _TITLE;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(2, "TITLE", "", null, "nvarchar(200)", 0, 0, true, Master=true)]
        public virtual String TITLE
        {
            get { return _TITLE; }
            set { if (OnPropertyChanging(__.TITLE, value)) { _TITLE = value; OnPropertyChanged(__.TITLE); } }
        }

        private String _LONGTITLE;
        /// <summary></summary>
        [DisplayName("Longtitle")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(3, "LONGTITLE", "", null, "nvarchar(500)", 0, 0, true)]
        public virtual String LONGTITLE
        {
            get { return _LONGTITLE; }
            set { if (OnPropertyChanging(__.LONGTITLE, value)) { _LONGTITLE = value; OnPropertyChanged(__.LONGTITLE); } }
        }

        private Decimal _INFOTYPE;
        /// <summary></summary>
        [DisplayName("Infotype")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "INFOTYPE", "", null, "decimal", 10, 0, false)]
        public virtual Decimal INFOTYPE
        {
            get { return _INFOTYPE; }
            set { if (OnPropertyChanging(__.INFOTYPE, value)) { _INFOTYPE = value; OnPropertyChanged(__.INFOTYPE); } }
        }

        private Decimal _ORDERID;
        /// <summary></summary>
        [DisplayName("Orderid")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "ORDERID", "", null, "decimal", 10, 0, false)]
        public virtual Decimal ORDERID
        {
            get { return _ORDERID; }
            set { if (OnPropertyChanging(__.ORDERID, value)) { _ORDERID = value; OnPropertyChanged(__.ORDERID); } }
        }

        private String _INFOSOURCE;
        /// <summary></summary>
        [DisplayName("Infosource")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "INFOSOURCE", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String INFOSOURCE
        {
            get { return _INFOSOURCE; }
            set { if (OnPropertyChanging(__.INFOSOURCE, value)) { _INFOSOURCE = value; OnPropertyChanged(__.INFOSOURCE); } }
        }

        private String _KEYWORD;
        /// <summary></summary>
        [DisplayName("Keyword")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(7, "KEYWORD", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String KEYWORD
        {
            get { return _KEYWORD; }
            set { if (OnPropertyChanging(__.KEYWORD, value)) { _KEYWORD = value; OnPropertyChanged(__.KEYWORD); } }
        }

        private DateTime _TIME_PUBLISH;
        /// <summary></summary>
        [DisplayName("Publish")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(8, "TIME_PUBLISH", "", null, "datetime", 3, 0, false)]
        public virtual DateTime TIME_PUBLISH
        {
            get { return _TIME_PUBLISH; }
            set { if (OnPropertyChanging(__.TIME_PUBLISH, value)) { _TIME_PUBLISH = value; OnPropertyChanged(__.TIME_PUBLISH); } }
        }

        private DateTime _TIME_UNPUBLISH;
        /// <summary></summary>
        [DisplayName("Unpublish")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(9, "TIME_UNPUBLISH", "", null, "datetime", 3, 0, false)]
        public virtual DateTime TIME_UNPUBLISH
        {
            get { return _TIME_UNPUBLISH; }
            set { if (OnPropertyChanging(__.TIME_UNPUBLISH, value)) { _TIME_UNPUBLISH = value; OnPropertyChanged(__.TIME_UNPUBLISH); } }
        }

        private String _SUMMARY;
        /// <summary></summary>
        [DisplayName("Summary")]
        [Description("")]
        [DataObjectField(false, false, true, 800)]
        [BindColumn(10, "SUMMARY", "", null, "varchar(800)", 0, 0, false)]
        public virtual String SUMMARY
        {
            get { return _SUMMARY; }
            set { if (OnPropertyChanging(__.SUMMARY, value)) { _SUMMARY = value; OnPropertyChanged(__.SUMMARY); } }
        }

        private Boolean _PROP_TOP;
        /// <summary></summary>
        [DisplayName("Top")]
        [Description("")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(11, "PROP_TOP", "", null, "bit", 0, 0, false)]
        public virtual Boolean PROP_TOP
        {
            get { return _PROP_TOP; }
            set { if (OnPropertyChanging(__.PROP_TOP, value)) { _PROP_TOP = value; OnPropertyChanged(__.PROP_TOP); } }
        }

        private Boolean _PROP_PIC;
        /// <summary></summary>
        [DisplayName("Pic1")]
        [Description("")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(12, "PROP_PIC", "", null, "bit", 0, 0, false)]
        public virtual Boolean PROP_PIC
        {
            get { return _PROP_PIC; }
            set { if (OnPropertyChanging(__.PROP_PIC, value)) { _PROP_PIC = value; OnPropertyChanged(__.PROP_PIC); } }
        }

        private String _HTML_PATH;
        /// <summary></summary>
        [DisplayName("Path")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "HTML_PATH", "", null, "varchar(50)", 0, 0, false)]
        public virtual String HTML_PATH
        {
            get { return _HTML_PATH; }
            set { if (OnPropertyChanging(__.HTML_PATH, value)) { _HTML_PATH = value; OnPropertyChanged(__.HTML_PATH); } }
        }

        private String _URL_LINK;
        /// <summary></summary>
        [DisplayName("Link")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(14, "URL_LINK", "", null, "varchar(100)", 0, 0, false)]
        public virtual String URL_LINK
        {
            get { return _URL_LINK; }
            set { if (OnPropertyChanging(__.URL_LINK, value)) { _URL_LINK = value; OnPropertyChanged(__.URL_LINK); } }
        }

        private String _RELATION_ID;
        /// <summary></summary>
        [DisplayName("ID1")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(15, "RELATION_ID", "", null, "varchar(200)", 0, 0, false)]
        public virtual String RELATION_ID
        {
            get { return _RELATION_ID; }
            set { if (OnPropertyChanging(__.RELATION_ID, value)) { _RELATION_ID = value; OnPropertyChanged(__.RELATION_ID); } }
        }

        private String _HOT_ID;
        /// <summary></summary>
        [DisplayName("ID2")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(16, "HOT_ID", "", null, "varchar(200)", 0, 0, false)]
        public virtual String HOT_ID
        {
            get { return _HOT_ID; }
            set { if (OnPropertyChanging(__.HOT_ID, value)) { _HOT_ID = value; OnPropertyChanged(__.HOT_ID); } }
        }

        private String _TITLE_COLOR;
        /// <summary></summary>
        [DisplayName("Color")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(17, "TITLE_COLOR", "", null, "varchar(10)", 0, 0, false)]
        public virtual String TITLE_COLOR
        {
            get { return _TITLE_COLOR; }
            set { if (OnPropertyChanging(__.TITLE_COLOR, value)) { _TITLE_COLOR = value; OnPropertyChanged(__.TITLE_COLOR); } }
        }

        private Decimal _STATE;
        /// <summary></summary>
        [DisplayName("State")]
        [Description("")]
        [DataObjectField(false, false, true, 4)]
        [BindColumn(18, "STATE", "", null, "decimal", 4, 0, false)]
        public virtual Decimal STATE
        {
            get { return _STATE; }
            set { if (OnPropertyChanging(__.STATE, value)) { _STATE = value; OnPropertyChanged(__.STATE); } }
        }

        private Decimal _Click;
        /// <summary></summary>
        [DisplayName("Click")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(19, "Click", "", null, "decimal", 10, 0, false)]
        public virtual Decimal Click
        {
            get { return _Click; }
            set { if (OnPropertyChanging(__.Click, value)) { _Click = value; OnPropertyChanged(__.Click); } }
        }

        private String _PIC;
        /// <summary></summary>
        [DisplayName("Pic")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(20, "PIC", "", null, "varchar(200)", 0, 0, false)]
        public virtual String PIC
        {
            get { return _PIC; }
            set { if (OnPropertyChanging(__.PIC, value)) { _PIC = value; OnPropertyChanged(__.PIC); } }
        }

        private String _INFO_ID;
        /// <summary></summary>
        [DisplayName("ID3")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(21, "INFO_ID", "", null, "varchar(50)", 0, 0, false)]
        public virtual String INFO_ID
        {
            get { return _INFO_ID; }
            set { if (OnPropertyChanging(__.INFO_ID, value)) { _INFO_ID = value; OnPropertyChanged(__.INFO_ID); } }
        }

        private DateTime _TIME_LAST;
        /// <summary></summary>
        [DisplayName("Last")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(22, "TIME_LAST", "", null, "datetime", 3, 0, false)]
        public virtual DateTime TIME_LAST
        {
            get { return _TIME_LAST; }
            set { if (OnPropertyChanging(__.TIME_LAST, value)) { _TIME_LAST = value; OnPropertyChanged(__.TIME_LAST); } }
        }

        private Decimal _USER_ID;
        /// <summary></summary>
        [DisplayName("ID4")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(23, "USER_ID", "", null, "decimal", 10, 0, false)]
        public virtual Decimal USER_ID
        {
            get { return _USER_ID; }
            set { if (OnPropertyChanging(__.USER_ID, value)) { _USER_ID = value; OnPropertyChanged(__.USER_ID); } }
        }

        private String _USER_NAME;
        /// <summary></summary>
        [DisplayName("Name")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(24, "USER_NAME", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String USER_NAME
        {
            get { return _USER_NAME; }
            set { if (OnPropertyChanging(__.USER_NAME, value)) { _USER_NAME = value; OnPropertyChanged(__.USER_NAME); } }
        }

        private Decimal _USER_ID_PUB;
        /// <summary></summary>
        [DisplayName("ID_Pub")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(25, "USER_ID_PUB", "", null, "decimal", 10, 0, false)]
        public virtual Decimal USER_ID_PUB
        {
            get { return _USER_ID_PUB; }
            set { if (OnPropertyChanging(__.USER_ID_PUB, value)) { _USER_ID_PUB = value; OnPropertyChanged(__.USER_ID_PUB); } }
        }

        private String _USER_NAME_PUB;
        /// <summary></summary>
        [DisplayName("Name_Pub")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(26, "USER_NAME_PUB", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String USER_NAME_PUB
        {
            get { return _USER_NAME_PUB; }
            set { if (OnPropertyChanging(__.USER_NAME_PUB, value)) { _USER_NAME_PUB = value; OnPropertyChanged(__.USER_NAME_PUB); } }
        }

        private String _MP3;
        /// <summary></summary>
        [DisplayName("Mp3")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(27, "MP3", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String MP3
        {
            get { return _MP3; }
            set { if (OnPropertyChanging(__.MP3, value)) { _MP3 = value; OnPropertyChanged(__.MP3); } }
        }

        private Boolean _IPTV;
        /// <summary></summary>
        [DisplayName("Iptv")]
        [Description("")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(28, "IPTV", "", null, "bit", 0, 0, false)]
        public virtual Boolean IPTV
        {
            get { return _IPTV; }
            set { if (OnPropertyChanging(__.IPTV, value)) { _IPTV = value; OnPropertyChanged(__.IPTV); } }
        }

        private String _FLV;
        /// <summary></summary>
        [DisplayName("Flv")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(29, "FLV", "", null, "varchar(50)", 0, 0, false)]
        public virtual String FLV
        {
            get { return _FLV; }
            set { if (OnPropertyChanging(__.FLV, value)) { _FLV = value; OnPropertyChanged(__.FLV); } }
        }

        private Boolean _PROP_INDEX;
        /// <summary></summary>
        [DisplayName("Index")]
        [Description("")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(30, "PROP_INDEX", "", null, "bit", 0, 0, false)]
        public virtual Boolean PROP_INDEX
        {
            get { return _PROP_INDEX; }
            set { if (OnPropertyChanging(__.PROP_INDEX, value)) { _PROP_INDEX = value; OnPropertyChanged(__.PROP_INDEX); } }
        }

        private String _City;
        /// <summary></summary>
        [DisplayName("City")]
        [Description("")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn(31, "City", "", null, "varchar(8)", 0, 0, false)]
        public virtual String City
        {
            get { return _City; }
            set { if (OnPropertyChanging(__.City, value)) { _City = value; OnPropertyChanged(__.City); } }
        }

        private String _CustomType;
        /// <summary></summary>
        [DisplayName("CustomType")]
        [Description("")]
        [DataObjectField(false, false, true, 254)]
        [BindColumn(32, "CustomType", "", null, "varchar(254)", 0, 0, false)]
        public virtual String CustomType
        {
            get { return _CustomType; }
            set { if (OnPropertyChanging(__.CustomType, value)) { _CustomType = value; OnPropertyChanged(__.CustomType); } }
        }

        private String _FileUser;
        /// <summary></summary>
        [DisplayName("FileUser")]
        [Description("")]
        [DataObjectField(false, false, true, 54)]
        [BindColumn(33, "FileUser", "", null, "nvarchar(54)", 0, 0, true)]
        public virtual String FileUser
        {
            get { return _FileUser; }
            set { if (OnPropertyChanging(__.FileUser, value)) { _FileUser = value; OnPropertyChanged(__.FileUser); } }
        }

        private String _FileCode;
        /// <summary></summary>
        [DisplayName("FileCode")]
        [Description("")]
        [DataObjectField(false, false, true, 54)]
        [BindColumn(34, "FileCode", "", null, "nvarchar(54)", 0, 0, true)]
        public virtual String FileCode
        {
            get { return _FileCode; }
            set { if (OnPropertyChanging(__.FileCode, value)) { _FileCode = value; OnPropertyChanged(__.FileCode); } }
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
                    case __.TITLE : return _TITLE;
                    case __.LONGTITLE : return _LONGTITLE;
                    case __.INFOTYPE : return _INFOTYPE;
                    case __.ORDERID : return _ORDERID;
                    case __.INFOSOURCE : return _INFOSOURCE;
                    case __.KEYWORD : return _KEYWORD;
                    case __.TIME_PUBLISH : return _TIME_PUBLISH;
                    case __.TIME_UNPUBLISH : return _TIME_UNPUBLISH;
                    case __.SUMMARY : return _SUMMARY;
                    case __.PROP_TOP : return _PROP_TOP;
                    case __.PROP_PIC : return _PROP_PIC;
                    case __.HTML_PATH : return _HTML_PATH;
                    case __.URL_LINK : return _URL_LINK;
                    case __.RELATION_ID : return _RELATION_ID;
                    case __.HOT_ID : return _HOT_ID;
                    case __.TITLE_COLOR : return _TITLE_COLOR;
                    case __.STATE : return _STATE;
                    case __.Click : return _Click;
                    case __.PIC : return _PIC;
                    case __.INFO_ID : return _INFO_ID;
                    case __.TIME_LAST : return _TIME_LAST;
                    case __.USER_ID : return _USER_ID;
                    case __.USER_NAME : return _USER_NAME;
                    case __.USER_ID_PUB : return _USER_ID_PUB;
                    case __.USER_NAME_PUB : return _USER_NAME_PUB;
                    case __.MP3 : return _MP3;
                    case __.IPTV : return _IPTV;
                    case __.FLV : return _FLV;
                    case __.PROP_INDEX : return _PROP_INDEX;
                    case __.City : return _City;
                    case __.CustomType : return _CustomType;
                    case __.FileUser : return _FileUser;
                    case __.FileCode : return _FileCode;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToDecimal(value); break;
                    case __.TITLE : _TITLE = Convert.ToString(value); break;
                    case __.LONGTITLE : _LONGTITLE = Convert.ToString(value); break;
                    case __.INFOTYPE : _INFOTYPE = Convert.ToDecimal(value); break;
                    case __.ORDERID : _ORDERID = Convert.ToDecimal(value); break;
                    case __.INFOSOURCE : _INFOSOURCE = Convert.ToString(value); break;
                    case __.KEYWORD : _KEYWORD = Convert.ToString(value); break;
                    case __.TIME_PUBLISH : _TIME_PUBLISH = Convert.ToDateTime(value); break;
                    case __.TIME_UNPUBLISH : _TIME_UNPUBLISH = Convert.ToDateTime(value); break;
                    case __.SUMMARY : _SUMMARY = Convert.ToString(value); break;
                    case __.PROP_TOP : _PROP_TOP = Convert.ToBoolean(value); break;
                    case __.PROP_PIC : _PROP_PIC = Convert.ToBoolean(value); break;
                    case __.HTML_PATH : _HTML_PATH = Convert.ToString(value); break;
                    case __.URL_LINK : _URL_LINK = Convert.ToString(value); break;
                    case __.RELATION_ID : _RELATION_ID = Convert.ToString(value); break;
                    case __.HOT_ID : _HOT_ID = Convert.ToString(value); break;
                    case __.TITLE_COLOR : _TITLE_COLOR = Convert.ToString(value); break;
                    case __.STATE : _STATE = Convert.ToDecimal(value); break;
                    case __.Click : _Click = Convert.ToDecimal(value); break;
                    case __.PIC : _PIC = Convert.ToString(value); break;
                    case __.INFO_ID : _INFO_ID = Convert.ToString(value); break;
                    case __.TIME_LAST : _TIME_LAST = Convert.ToDateTime(value); break;
                    case __.USER_ID : _USER_ID = Convert.ToDecimal(value); break;
                    case __.USER_NAME : _USER_NAME = Convert.ToString(value); break;
                    case __.USER_ID_PUB : _USER_ID_PUB = Convert.ToDecimal(value); break;
                    case __.USER_NAME_PUB : _USER_NAME_PUB = Convert.ToString(value); break;
                    case __.MP3 : _MP3 = Convert.ToString(value); break;
                    case __.IPTV : _IPTV = Convert.ToBoolean(value); break;
                    case __.FLV : _FLV = Convert.ToString(value); break;
                    case __.PROP_INDEX : _PROP_INDEX = Convert.ToBoolean(value); break;
                    case __.City : _City = Convert.ToString(value); break;
                    case __.CustomType : _CustomType = Convert.ToString(value); break;
                    case __.FileUser : _FileUser = Convert.ToString(value); break;
                    case __.FileCode : _FileCode = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得List字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary></summary>
            public static readonly Field TITLE = FindByName(__.TITLE);

            ///<summary></summary>
            public static readonly Field LONGTITLE = FindByName(__.LONGTITLE);

            ///<summary></summary>
            public static readonly Field INFOTYPE = FindByName(__.INFOTYPE);

            ///<summary></summary>
            public static readonly Field ORDERID = FindByName(__.ORDERID);

            ///<summary></summary>
            public static readonly Field INFOSOURCE = FindByName(__.INFOSOURCE);

            ///<summary></summary>
            public static readonly Field KEYWORD = FindByName(__.KEYWORD);

            ///<summary></summary>
            public static readonly Field TIME_PUBLISH = FindByName(__.TIME_PUBLISH);

            ///<summary></summary>
            public static readonly Field TIME_UNPUBLISH = FindByName(__.TIME_UNPUBLISH);

            ///<summary></summary>
            public static readonly Field SUMMARY = FindByName(__.SUMMARY);

            ///<summary></summary>
            public static readonly Field PROP_TOP = FindByName(__.PROP_TOP);

            ///<summary></summary>
            public static readonly Field PROP_PIC = FindByName(__.PROP_PIC);

            ///<summary></summary>
            public static readonly Field HTML_PATH = FindByName(__.HTML_PATH);

            ///<summary></summary>
            public static readonly Field URL_LINK = FindByName(__.URL_LINK);

            ///<summary></summary>
            public static readonly Field RELATION_ID = FindByName(__.RELATION_ID);

            ///<summary></summary>
            public static readonly Field HOT_ID = FindByName(__.HOT_ID);

            ///<summary></summary>
            public static readonly Field TITLE_COLOR = FindByName(__.TITLE_COLOR);

            ///<summary></summary>
            public static readonly Field STATE = FindByName(__.STATE);

            ///<summary></summary>
            public static readonly Field Click = FindByName(__.Click);

            ///<summary></summary>
            public static readonly Field PIC = FindByName(__.PIC);

            ///<summary></summary>
            public static readonly Field INFO_ID = FindByName(__.INFO_ID);

            ///<summary></summary>
            public static readonly Field TIME_LAST = FindByName(__.TIME_LAST);

            ///<summary></summary>
            public static readonly Field USER_ID = FindByName(__.USER_ID);

            ///<summary></summary>
            public static readonly Field USER_NAME = FindByName(__.USER_NAME);

            ///<summary></summary>
            public static readonly Field USER_ID_PUB = FindByName(__.USER_ID_PUB);

            ///<summary></summary>
            public static readonly Field USER_NAME_PUB = FindByName(__.USER_NAME_PUB);

            ///<summary></summary>
            public static readonly Field MP3 = FindByName(__.MP3);

            ///<summary></summary>
            public static readonly Field IPTV = FindByName(__.IPTV);

            ///<summary></summary>
            public static readonly Field FLV = FindByName(__.FLV);

            ///<summary></summary>
            public static readonly Field PROP_INDEX = FindByName(__.PROP_INDEX);

            ///<summary></summary>
            public static readonly Field City = FindByName(__.City);

            ///<summary></summary>
            public static readonly Field CustomType = FindByName(__.CustomType);

            ///<summary></summary>
            public static readonly Field FileUser = FindByName(__.FileUser);

            ///<summary></summary>
            public static readonly Field FileCode = FindByName(__.FileCode);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得List字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary></summary>
            public const String TITLE = "TITLE";

            ///<summary></summary>
            public const String LONGTITLE = "LONGTITLE";

            ///<summary></summary>
            public const String INFOTYPE = "INFOTYPE";

            ///<summary></summary>
            public const String ORDERID = "ORDERID";

            ///<summary></summary>
            public const String INFOSOURCE = "INFOSOURCE";

            ///<summary></summary>
            public const String KEYWORD = "KEYWORD";

            ///<summary></summary>
            public const String TIME_PUBLISH = "TIME_PUBLISH";

            ///<summary></summary>
            public const String TIME_UNPUBLISH = "TIME_UNPUBLISH";

            ///<summary></summary>
            public const String SUMMARY = "SUMMARY";

            ///<summary></summary>
            public const String PROP_TOP = "PROP_TOP";

            ///<summary></summary>
            public const String PROP_PIC = "PROP_PIC";

            ///<summary></summary>
            public const String HTML_PATH = "HTML_PATH";

            ///<summary></summary>
            public const String URL_LINK = "URL_LINK";

            ///<summary></summary>
            public const String RELATION_ID = "RELATION_ID";

            ///<summary></summary>
            public const String HOT_ID = "HOT_ID";

            ///<summary></summary>
            public const String TITLE_COLOR = "TITLE_COLOR";

            ///<summary></summary>
            public const String STATE = "STATE";

            ///<summary></summary>
            public const String Click = "Click";

            ///<summary></summary>
            public const String PIC = "PIC";

            ///<summary></summary>
            public const String INFO_ID = "INFO_ID";

            ///<summary></summary>
            public const String TIME_LAST = "TIME_LAST";

            ///<summary></summary>
            public const String USER_ID = "USER_ID";

            ///<summary></summary>
            public const String USER_NAME = "USER_NAME";

            ///<summary></summary>
            public const String USER_ID_PUB = "USER_ID_PUB";

            ///<summary></summary>
            public const String USER_NAME_PUB = "USER_NAME_PUB";

            ///<summary></summary>
            public const String MP3 = "MP3";

            ///<summary></summary>
            public const String IPTV = "IPTV";

            ///<summary></summary>
            public const String FLV = "FLV";

            ///<summary></summary>
            public const String PROP_INDEX = "PROP_INDEX";

            ///<summary></summary>
            public const String City = "City";

            ///<summary></summary>
            public const String CustomType = "CustomType";

            ///<summary></summary>
            public const String FileUser = "FileUser";

            ///<summary></summary>
            public const String FileCode = "FileCode";

        }
        
        #endregion
    }

    /// <summary>List接口</summary>
    /// <remarks></remarks>
    public partial interface ICONTENT_LIST
    {
        #region 属性
        /// <summary></summary>
        Decimal ID { get; set; }

        /// <summary></summary>
        String TITLE { get; set; }

        /// <summary></summary>
        String LONGTITLE { get; set; }

        /// <summary></summary>
        Decimal INFOTYPE { get; set; }

        /// <summary></summary>
        Decimal ORDERID { get; set; }

        /// <summary></summary>
        String INFOSOURCE { get; set; }

        /// <summary></summary>
        String KEYWORD { get; set; }

        /// <summary></summary>
        DateTime TIME_PUBLISH { get; set; }

        /// <summary></summary>
        DateTime TIME_UNPUBLISH { get; set; }

        /// <summary></summary>
        String SUMMARY { get; set; }

        /// <summary></summary>
        Boolean PROP_TOP { get; set; }

        /// <summary></summary>
        Boolean PROP_PIC { get; set; }

        /// <summary></summary>
        String HTML_PATH { get; set; }

        /// <summary></summary>
        String URL_LINK { get; set; }

        /// <summary></summary>
        String RELATION_ID { get; set; }

        /// <summary></summary>
        String HOT_ID { get; set; }

        /// <summary></summary>
        String TITLE_COLOR { get; set; }

        /// <summary></summary>
        Decimal STATE { get; set; }

        /// <summary></summary>
        Decimal Click { get; set; }

        /// <summary></summary>
        String PIC { get; set; }

        /// <summary></summary>
        String INFO_ID { get; set; }

        /// <summary></summary>
        DateTime TIME_LAST { get; set; }

        /// <summary></summary>
        Decimal USER_ID { get; set; }

        /// <summary></summary>
        String USER_NAME { get; set; }

        /// <summary></summary>
        Decimal USER_ID_PUB { get; set; }

        /// <summary></summary>
        String USER_NAME_PUB { get; set; }

        /// <summary></summary>
        String MP3 { get; set; }

        /// <summary></summary>
        Boolean IPTV { get; set; }

        /// <summary></summary>
        String FLV { get; set; }

        /// <summary></summary>
        Boolean PROP_INDEX { get; set; }

        /// <summary></summary>
        String City { get; set; }

        /// <summary></summary>
        String CustomType { get; set; }

        /// <summary></summary>
        String FileUser { get; set; }

        /// <summary></summary>
        String FileCode { get; set; }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        
        #endregion
    }
}