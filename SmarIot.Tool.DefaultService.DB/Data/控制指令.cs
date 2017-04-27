using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.Tool.DefaultService.DB
{
    /// <summary>控制指令</summary>
    [Serializable]
    [DataObject]
    [Description("控制指令")]
    [BindIndex("Index_ControlDeviceUnitGroupNum", false, "ControlDeviceUnitGroupNum")]
    [BindIndex("PK__DeviceCo__3214EC2786562325", true, "ID")]
    [BindRelation("ControlDeviceUnitGroupNum", false, "FacilityControlDeviceUnit", "ControlDeviceUnitGroupNum")]
    [BindRelation("ID", true, "DeviceControlLog", "DeviceControlCommandID")]
    [BindTable("DeviceControlCommand", Description = "控制指令", ConnName = "SmartIot-Scada-data",
        DbType = DatabaseType.SqlServer)]
    public abstract partial class DeviceControlCommand<TEntity> : IDeviceControlCommand
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
                    case __.ControlDeviceUnitGroupNum:
                        return _ControlDeviceUnitGroupNum;
                    case __.Command:
                        return _Command;
                    case __.ControlContinueTime:
                        return _ControlContinueTime;
                    case __.Status:
                        return _Status;
                    case __.CreateTime:
                        return _CreateTime;
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
                    case __.ControlDeviceUnitGroupNum:
                        _ControlDeviceUnitGroupNum = Convert.ToInt32(value);
                        break;
                    case __.Command:
                        _Command = Convert.ToString(value);
                        break;
                    case __.ControlContinueTime:
                        _ControlContinueTime = Convert.ToInt32(value);
                        break;
                    case __.Status:
                        _Status = Convert.ToInt32(value);
                        break;
                    case __.CreateTime:
                        _CreateTime = Convert.ToDateTime(value);
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

        private Int32 _ControlDeviceUnitGroupNum;

        /// <summary>控制设备组名</summary>
        [DisplayName("控制设备组名")]
        [Description("控制设备组名")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "ControlDeviceUnitGroupNum", "控制设备组名", null, "int", 10, 0, false)]
        public virtual Int32 ControlDeviceUnitGroupNum
        {
            get { return _ControlDeviceUnitGroupNum; }
            set
            {
                if (OnPropertyChanging(__.ControlDeviceUnitGroupNum, value))
                {
                    _ControlDeviceUnitGroupNum = value;
                    OnPropertyChanged(__.ControlDeviceUnitGroupNum);
                }
            }
        }

        private String _Command;

        /// <summary>指令内容</summary>
        [DisplayName("指令内容")]
        [Description("指令内容")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(6, "Command", "指令内容", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Command
        {
            get { return _Command; }
            set
            {
                if (OnPropertyChanging(__.Command, value))
                {
                    _Command = value;
                    OnPropertyChanged(__.Command);
                }
            }
        }

        private Int32 _ControlContinueTime;

        /// <summary>控制指令执行的时间长度，单位秒，0为不自动结束控制。</summary>
        [DisplayName("控制指令执行的时间长度，单位秒，0为不自动结束控制")]
        [Description("控制指令执行的时间长度，单位秒，0为不自动结束控制。")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "ControlContinueTime", "控制指令执行的时间长度，单位秒，0为不自动结束控制。", null, "int", 10, 0, false)]
        public virtual Int32 ControlContinueTime
        {
            get { return _ControlContinueTime; }
            set
            {
                if (OnPropertyChanging(__.ControlContinueTime, value))
                {
                    _ControlContinueTime = value;
                    OnPropertyChanged(__.ControlContinueTime);
                }
            }
        }

        private Int32 _Status;

        /// <summary>0为未执行，1为正在执行，2执行成功，4为执行失败，8为指令过期。</summary>
        [DisplayName("0为未执行，1为正在执行，2执行成功，4为执行失败，8为指令过期")]
        [Description("0为未执行，1为正在执行，2执行成功，4为执行失败，8为指令过期。")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(8, "Status", "0为未执行，1为正在执行，2执行成功，4为执行失败，8为指令过期。", null, "int", 10, 0, false)]
        public virtual Int32 Status
        {
            get { return _Status; }
            set
            {
                if (OnPropertyChanging(__.Status, value))
                {
                    _Status = value;
                    OnPropertyChanged(__.Status);
                }
            }
        }

        private DateTime _CreateTime;

        /// <summary>指令生成时间</summary>
        [DisplayName("指令生成时间")]
        [Description("指令生成时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(9, "CreateTime", "指令生成时间", null, "datetime", 3, 0, false)]
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

        private String _Remark;

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(10, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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

        /// <summary>取得控制指令字段信息的快捷方式</summary>
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

            ///<summary>控制设备组名</summary>
            public static readonly Field ControlDeviceUnitGroupNum = FindByName(__.ControlDeviceUnitGroupNum);

            ///<summary>指令内容</summary>
            public static readonly Field Command = FindByName(__.Command);

            ///<summary>控制指令执行的时间长度，单位秒，0为不自动结束控制。</summary>
            public static readonly Field ControlContinueTime = FindByName(__.ControlContinueTime);

            ///<summary>0为未执行，1为正在执行，2执行成功，4为执行失败，8为指令过期。</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>指令生成时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            private static Field FindByName(String name)
            {
                return Meta.Table.FindByName(name);
            }
        }

        /// <summary>取得控制指令字段名称的快捷方式</summary>
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

            ///<summary>控制设备组名</summary>
            public const String ControlDeviceUnitGroupNum = "_ControlDeviceUnitGroupNum";

            ///<summary>指令内容</summary>
            public const String Command = "Command";

            ///<summary>控制指令执行的时间长度，单位秒，0为不自动结束控制。</summary>
            public const String ControlContinueTime = "ControlContinueTime";

            ///<summary>0为未执行，1为正在执行，2执行成功，4为执行失败，8为指令过期。</summary>
            public const String Status = "Status";

            ///<summary>指令生成时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>备注</summary>
            public const String Remark = "Remark";
        }

        #endregion 字段名
    }

    /// <summary>控制指令接口</summary>
    public partial interface IDeviceControlCommand
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

        /// <summary>控制设备组名</summary>
        Int32 ControlDeviceUnitGroupNum { get; set; }

        /// <summary>指令内容</summary>
        String Command { get; set; }

        /// <summary>控制指令执行的时间长度，单位秒，0为不自动结束控制。</summary>
        Int32 ControlContinueTime { get; set; }

        /// <summary>0为未执行，1为正在执行，2执行成功，4为执行失败，8为指令过期。</summary>
        Int32 Status { get; set; }

        /// <summary>指令生成时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion 属性
    }
}