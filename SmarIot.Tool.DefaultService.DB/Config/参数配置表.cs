using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>参数配置表</summary>
    [Serializable]
    [DataObject]
    [Description("参数配置表")]
    [BindIndex("Index_ParmeterConfigName", false, "Name")]
    [BindIndex("Index_ParmeterConfigType", false, "Type")]
    [BindIndex("PK__Parmeter__3214EC27FEF0B029", true, "ID")]
    [BindTable("ParmeterConfig", Description = "参数配置表", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class ParmeterConfig<TEntity> : IParmeterConfig
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
                    case __.Type:
                        return _Type;
                    case __.Name:
                        return _Name;
                    case __.Value:
                        return _Value;
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
                    case __.Type:
                        _Type = Convert.ToString(value);
                        break;
                    case __.Name:
                        _Name = Convert.ToString(value);
                        break;
                    case __.Value:
                        _Value = Convert.ToString(value);
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

        private String _Type;

        /// <summary>类型</summary>
        [DisplayName("类型")]
        [Description("类型")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "Type", "类型", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Type
        {
            get { return _Type; }
            set
            {
                if (OnPropertyChanging(__.Type, value))
                {
                    _Type = value;
                    OnPropertyChanged(__.Type);
                }
            }
        }

        private String _Name;

        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "Name", "名称", null, "nvarchar(50)", 0, 0, true, Master = true)]
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

        private String _Value;

        /// <summary>参数值</summary>
        [DisplayName("参数值")]
        [Description("参数值")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(4, "Value", "参数值", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Value
        {
            get { return _Value; }
            set
            {
                if (OnPropertyChanging(__.Value, value))
                {
                    _Value = value;
                    OnPropertyChanged(__.Value);
                }
            }
        }

        private String _Remark;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 2000)]
        [BindColumn(5, "Remark", "备注", null, "nvarchar(2000)", 0, 0, true)]
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

        /// <summary>取得参数配置表字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>类型</summary>
            public static readonly Field Type = FindByName(__.Type);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>参数值</summary>
            public static readonly Field Value = FindByName(__.Value);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得参数配置表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>类型</summary>
            public const String Type = "Type";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>参数值</summary>
            public const String Value = "Value";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>参数配置表接口</summary>
    public partial interface IParmeterConfig
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

        /// <summary>类型</summary>
        String Type { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>参数值</summary>
        String Value { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}