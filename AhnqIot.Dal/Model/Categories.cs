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
    /// <summary>Categories</summary>
    /// <remarks></remarks>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_dbo.Categories", true, "CategoryID")]
    [BindTable("Categories", Description = "", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class Categories : ICategories
    {
        #region 属性
        
        private Int32 _CategoryID;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "CategoryID", "", null, "int", 10, 0, false)]
        public virtual Int32 CategoryID
        {
            get { return _CategoryID; }
            set { if (OnPropertyChanging(__.CategoryID, value)) { _CategoryID = value; OnPropertyChanged(__.CategoryID); } }
        }

        private String _CategoryName;
        /// <summary></summary>
        [DisplayName("CategoryName")]
        [Description("")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(2, "CategoryName", "", null, "nvarchar(MAX)", 0, 0, true)]
        public virtual String CategoryName
        {
            get { return _CategoryName; }
            set { if (OnPropertyChanging(__.CategoryName, value)) { _CategoryName = value; OnPropertyChanged(__.CategoryName); } }
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
                    case __.CategoryID : return _CategoryID;
                    case __.CategoryName : return _CategoryName;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.CategoryID : _CategoryID = Convert.ToInt32(value); break;
                    case __.CategoryName : _CategoryName = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得Categories字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field CategoryID = FindByName(__.CategoryID);

            ///<summary></summary>
            public static readonly Field CategoryName = FindByName(__.CategoryName);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得Categories字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String CategoryID = "CategoryID";

            ///<summary></summary>
            public const String CategoryName = "CategoryName";

        }
        
        #endregion
    }

    /// <summary>Categories接口</summary>
    /// <remarks></remarks>
    public partial interface ICategories
    {
        #region 属性
        /// <summary></summary>
        Int32 CategoryID { get; set; }

        /// <summary></summary>
        String CategoryName { get; set; }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        
        #endregion
    }
}