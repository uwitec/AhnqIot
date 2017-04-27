using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>展示设备</summary>
    [Serializable]
    [DataObject]
    [Description("展示设备")]
    [BindIndex("Index_ShowDeviceCommunicateDeviceID", false, "CommunicateDeviceID")]
    [BindIndex("Index_ShowDeviceShowDeviceTypeID", false, "ShowDeviceTypeID")]
    [BindIndex("PK__ShowDevi__3214EC2738312937", true, "ID")]
    [BindRelation("ID", true, "ShowData", "ShowDeviceID")]
    [BindRelation("CommunicateDeviceID", false, "CommunicateDevice", "ID")]
    [BindRelation("ShowDeviceTypeID", false, "ShowDeviceType", "ID")]
    [BindTable("ShowDevice", Description = "展示设备", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class ShowDevice<TEntity> : IShowDevice
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
                    case __.ShowDeviceTypeID:
                        return _ShowDeviceTypeID;
                    case __.CommunicateDeviceID:
                        return _CommunicateDeviceID;
                    case __.Address:
                        return _Address;
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
                    case __.ShowDeviceTypeID:
                        _ShowDeviceTypeID = Convert.ToInt32(value);
                        break;
                    case __.CommunicateDeviceID:
                        _CommunicateDeviceID = Convert.ToInt32(value);
                        break;
                    case __.Address:
                        _Address = Convert.ToString(value);
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
        [DataObjectField(false, false, false, 500)]
        [BindColumn(2, "Name", "名称", null, "nvarchar(500)", 0, 0, true, Master = true)]
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

        private Int32 _ShowDeviceTypeID;

        /// <summary>展示设备类型</summary>
        [DisplayName("展示设备类型")]
        [Description("展示设备类型")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "ShowDeviceTypeID", "展示设备类型", null, "int", 10, 0, false)]
        [Category("关联选项")]
        [ReadOnly(true)]
        public virtual Int32 ShowDeviceTypeID
        {
            get { return _ShowDeviceTypeID; }
            set
            {
                if (OnPropertyChanging(__.ShowDeviceTypeID, value))
                {
                    _ShowDeviceTypeID = value;
                    OnPropertyChanged(__.ShowDeviceTypeID);
                }
            }
        }

        private Int32 _CommunicateDeviceID;

        /// <summary>通讯设备</summary>
        [DisplayName("通讯设备")]
        [Description("通讯设备")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(4, "CommunicateDeviceID", "通讯设备", null, "int", 10, 0, false)]
        [Category("关联选项")]
        [ReadOnly(true)]
        public virtual Int32 CommunicateDeviceID
        {
            get { return _CommunicateDeviceID; }
            set
            {
                if (OnPropertyChanging(__.CommunicateDeviceID, value))
                {
                    _CommunicateDeviceID = value;
                    OnPropertyChanged(__.CommunicateDeviceID);
                }
            }
        }

        private String _Address;

        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(5, "Address", "地址", null, "nvarchar(500)", 0, 0, true)]
        [Category("基本属性")]

        public virtual String Address
        {
            get { return _Address; }
            set
            {
                if (OnPropertyChanging(__.Remark, value))
                {
                    _Address = value;
                    OnPropertyChanged(__.Address);
                }
            }
        }

        private String _Remark;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(5, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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

        /// <summary>取得展示设备字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>展示设备类型</summary>
            public static readonly Field ShowDeviceTypeID = FindByName(__.ShowDeviceTypeID);

            ///<summary>通讯设备</summary>
            public static readonly Field CommunicateDeviceID = FindByName(__.CommunicateDeviceID);

            ///<summary>地址</summary>
            public static readonly Field Address = FindByName(__.Address);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得展示设备字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>展示设备类型</summary>
            public const String ShowDeviceTypeID = "ShowDeviceTypeID";

            ///<summary>通讯设备</summary>
            public const String CommunicateDeviceID = "CommunicateDeviceID";

            ///<summary>地址</summary>
            public const String Address = "Address";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>展示设备接口</summary>
    public partial interface IShowDevice
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

        /// <summary>展示设备类型</summary>
        Int32 ShowDeviceTypeID { get; set; }

        /// <summary>通讯设备</summary>
        Int32 CommunicateDeviceID { get; set; }

        /// <summary>地址</summary>
        String Address { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}