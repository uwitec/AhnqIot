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
    /// <summary>Map</summary>
    /// <remarks></remarks>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindTable("CHANNEL_MAP", Description = "", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class CHANNEL_MAP : ICHANNEL_MAP
    {
        #region 属性
        
        private Decimal _CHANNEL_ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(1, "CHANNEL_ID", "", null, "decimal", 10, 0, false)]
        public virtual Decimal CHANNEL_ID
        {
            get { return _CHANNEL_ID; }
            set { if (OnPropertyChanging(__.CHANNEL_ID, value)) { _CHANNEL_ID = value; OnPropertyChanged(__.CHANNEL_ID); } }
        }

        private Decimal _CONTENT_ID;
        /// <summary></summary>
        [DisplayName("ID1")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "CONTENT_ID", "", null, "decimal", 10, 0, false)]
        public virtual Decimal CONTENT_ID
        {
            get { return _CONTENT_ID; }
            set { if (OnPropertyChanging(__.CONTENT_ID, value)) { _CONTENT_ID = value; OnPropertyChanged(__.CONTENT_ID); } }
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
                    case __.CHANNEL_ID : return _CHANNEL_ID;
                    case __.CONTENT_ID : return _CONTENT_ID;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.CHANNEL_ID : _CHANNEL_ID = Convert.ToDecimal(value); break;
                    case __.CONTENT_ID : _CONTENT_ID = Convert.ToDecimal(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得Map字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field CHANNEL_ID = FindByName(__.CHANNEL_ID);

            ///<summary></summary>
            public static readonly Field CONTENT_ID = FindByName(__.CONTENT_ID);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得Map字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String CHANNEL_ID = "CHANNEL_ID";

            ///<summary></summary>
            public const String CONTENT_ID = "CONTENT_ID";

        }
        
        #endregion
    }

    /// <summary>Map接口</summary>
    /// <remarks></remarks>
    public partial interface ICHANNEL_MAP
    {
        #region 属性
        /// <summary></summary>
        Decimal CHANNEL_ID { get; set; }

        /// <summary></summary>
        Decimal CONTENT_ID { get; set; }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        
        #endregion
    }
}