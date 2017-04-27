using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>显示数据</summary>
    [Serializable]
    [DataObject]
    [Description("显示数据")]
    [BindIndex("Index_ShowDataSensorDeviceUnitID", false, "SensorDeviceUnitID")]
    [BindIndex("Index_ShowDataShowDeviceID", false, "ShowDeviceID")]
    [BindIndex("PK__ShowData__3214EC275454FE04", true, "ID")]
    [BindRelation("SensorDeviceUnitID", false, "SensorDeviceUnit", "ID")]
    [BindRelation("ShowDeviceID", false, "ShowDevice", "ID")]
    [BindTable("ShowData", Description = "显示数据", ConnName = "SmartIot-Scada", DbType = DatabaseType.SqlServer)]
    public abstract partial class ShowData<TEntity> : IShowData
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
                    case __.SensorDeviceUnitID:
                        return _SensorDeviceUnitID;
                    case __.ShowDeviceID:
                        return _ShowDeviceID;
                    case __.Position:
                        return _Position;
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
                    case __.SensorDeviceUnitID:
                        _SensorDeviceUnitID = Convert.ToInt32(value);
                        break;
                    case __.ShowDeviceID:
                        _ShowDeviceID = Convert.ToInt32(value);
                        break;
                    case __.Position:
                        _Position = Convert.ToInt32(value);
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

        private Int32 _SensorDeviceUnitID;

        /// <summary>传感器设备</summary>
        [DisplayName("传感器设备")]
        [Description("传感器设备")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "SensorDeviceUnitID", "传感器设备", null, "int", 10, 0, false)]
        public virtual Int32 SensorDeviceUnitID
        {
            get { return _SensorDeviceUnitID; }
            set
            {
                if (OnPropertyChanging(__.SensorDeviceUnitID, value))
                {
                    _SensorDeviceUnitID = value;
                    OnPropertyChanged(__.SensorDeviceUnitID);
                }
            }
        }

        private Int32 _ShowDeviceID;

        /// <summary>展示设备</summary>
        [DisplayName("展示设备")]
        [Description("展示设备")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "ShowDeviceID", "展示设备", null, "int", 10, 0, false)]
        public virtual Int32 ShowDeviceID
        {
            get { return _ShowDeviceID; }
            set
            {
                if (OnPropertyChanging(__.ShowDeviceID, value))
                {
                    _ShowDeviceID = value;
                    OnPropertyChanged(__.ShowDeviceID);
                }
            }
        }

        private Int32 _Position;

        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(4, "Position", "位置", null, "int", 10, 0, false)]
        public virtual Int32 Position
        {
            get { return _Position; }
            set
            {
                if (OnPropertyChanging(__.Position, value))
                {
                    _Position = value;
                    OnPropertyChanged(__.Position);
                }
            }
        }

        private String _Remark;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 1000)]
        [BindColumn(5, "Remark", "备注", null, "nvarchar(1000)", 0, 0, true)]
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

        /// <summary>取得显示数据字段信息的快捷方式</summary>
        partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>传感器设备</summary>
            public static readonly Field SensorDeviceUnitID = FindByName(__.SensorDeviceUnitID);

            ///<summary>展示设备</summary>
            public static readonly Field ShowDeviceID = FindByName(__.ShowDeviceID);

            ///<summary>位置</summary>
            public static readonly Field Position = FindByName(__.Position);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得显示数据字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>传感器设备</summary>
            public const String SensorDeviceUnitID = "SensorDeviceUnitID";

            ///<summary>展示设备</summary>
            public const String ShowDeviceID = "ShowDeviceID";

            ///<summary>位置</summary>
            public const String Position = "Position";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>显示数据接口</summary>
    public partial interface IShowData
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

        /// <summary>传感器设备</summary>
        Int32 SensorDeviceUnitID { get; set; }

        /// <summary>展示设备</summary>
        Int32 ShowDeviceID { get; set; }

        /// <summary>位置</summary>
        Int32 Position { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}