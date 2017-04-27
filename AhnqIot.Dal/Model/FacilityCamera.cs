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
    /// <summary>设施摄像机</summary>
    [Serializable]
    [DataObject]
    [Description("设施摄像机")]
    [BindIndex("Index_FacilitySerialnum", false, "FacilitySerialnum")]
    [BindIndex("PK__Facility__E3E7488DB904E455", true, "Serialnum")]
    [BindRelation("FacilitySerialnum", false, "Facility", "Serialnum")]
    [BindRelation("Serialnum", true, "FacilityCameraPresetPoint", "FacilityCameraSerialnum")]
    [BindRelation("Serialnum", true, "FacilityCameraRunLog", "FacilityCameraSerialnum")]
    [BindTable("FacilityCamera", Description = "设施摄像机", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class FacilityCamera : IFacilityCamera
    {
        #region 属性
        
        private String _Serialnum;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(1, "Serialnum", "编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Serialnum
        {
            get { return _Serialnum; }
            set { if (OnPropertyChanging(__.Serialnum, value)) { _Serialnum = value; OnPropertyChanged(__.Serialnum); } }
        }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(2, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateTime
        {
            get { return _CreateTime; }
            set { if (OnPropertyChanging(__.CreateTime, value)) { _CreateTime = value; OnPropertyChanged(__.CreateTime); } }
        }

        private String _CreateSysUserSerialnum;
        /// <summary>创建用户</summary>
        [DisplayName("创建用户")]
        [Description("创建用户")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "CreateSysUserSerialnum", "创建用户", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateSysUserSerialnum
        {
            get { return _CreateSysUserSerialnum; }
            set { if (OnPropertyChanging(__.CreateSysUserSerialnum, value)) { _CreateSysUserSerialnum = value; OnPropertyChanged(__.CreateSysUserSerialnum); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(4, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging(__.UpdateTime, value)) { _UpdateTime = value; OnPropertyChanged(__.UpdateTime); } }
        }

        private String _UpdateSysUserSerialnum;
        /// <summary>更新用户</summary>
        [DisplayName("更新用户")]
        [Description("更新用户")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "UpdateSysUserSerialnum", "更新用户", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UpdateSysUserSerialnum
        {
            get { return _UpdateSysUserSerialnum; }
            set { if (OnPropertyChanging(__.UpdateSysUserSerialnum, value)) { _UpdateSysUserSerialnum = value; OnPropertyChanged(__.UpdateSysUserSerialnum); } }
        }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "Name", "名称", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private String _FacilitySerialnum;
        /// <summary>设施编码</summary>
        [DisplayName("设施编码")]
        [Description("设施编码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "FacilitySerialnum", "设施编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FacilitySerialnum
        {
            get { return _FacilitySerialnum; }
            set { if (OnPropertyChanging(__.FacilitySerialnum, value)) { _FacilitySerialnum = value; OnPropertyChanged(__.FacilitySerialnum); } }
        }

        private String _UserID;
        /// <summary>登录用户名</summary>
        [DisplayName("登录用户名")]
        [Description("登录用户名")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(8, "UserID", "登录用户名", "admin", "nvarchar(50)", 0, 0, true)]
        public virtual String UserID
        {
            get { return _UserID; }
            set { if (OnPropertyChanging(__.UserID, value)) { _UserID = value; OnPropertyChanged(__.UserID); } }
        }

        private String _UserPwd;
        /// <summary>登录密码</summary>
        [DisplayName("登录密码")]
        [Description("登录密码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "UserPwd", "登录密码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserPwd
        {
            get { return _UserPwd; }
            set { if (OnPropertyChanging(__.UserPwd, value)) { _UserPwd = value; OnPropertyChanged(__.UserPwd); } }
        }

        private String _IP;
        /// <summary>IP地址</summary>
        [DisplayName("IP地址")]
        [Description("IP地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "IP", "IP地址", null, "nvarchar(50)", 0, 0, true)]
        public virtual String IP
        {
            get { return _IP; }
            set { if (OnPropertyChanging(__.IP, value)) { _IP = value; OnPropertyChanged(__.IP); } }
        }

        private Int32 _HttpPort;
        /// <summary>web端口号</summary>
        [DisplayName("web端口号")]
        [Description("web端口号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "HttpPort", "web端口号", "80", "int", 10, 0, false)]
        public virtual Int32 HttpPort
        {
            get { return _HttpPort; }
            set { if (OnPropertyChanging(__.HttpPort, value)) { _HttpPort = value; OnPropertyChanged(__.HttpPort); } }
        }

        private Int32 _DataPort;
        /// <summary>数据端口号</summary>
        [DisplayName("数据端口号")]
        [Description("数据端口号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(12, "DataPort", "数据端口号", "8000", "int", 10, 0, false)]
        public virtual Int32 DataPort
        {
            get { return _DataPort; }
            set { if (OnPropertyChanging(__.DataPort, value)) { _DataPort = value; OnPropertyChanged(__.DataPort); } }
        }

        private Int32 _RtspPort;
        /// <summary>RTSP 端口</summary>
        [DisplayName("RTSP端口")]
        [Description("RTSP 端口")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(13, "RtspPort", "RTSP 端口", "554", "int", 10, 0, false)]
        public virtual Int32 RtspPort
        {
            get { return _RtspPort; }
            set { if (OnPropertyChanging(__.RtspPort, value)) { _RtspPort = value; OnPropertyChanged(__.RtspPort); } }
        }

        private Int32 _Channel;
        /// <summary>通道</summary>
        [DisplayName("通道")]
        [Description("通道")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(14, "Channel", "通道", "1", "int", 10, 0, false)]
        public virtual Int32 Channel
        {
            get { return _Channel; }
            set { if (OnPropertyChanging(__.Channel, value)) { _Channel = value; OnPropertyChanged(__.Channel); } }
        }

        private Boolean _Status;
        /// <summary>启用</summary>
        [DisplayName("启用")]
        [Description("启用")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(15, "Status", "启用", null, "bit", 0, 0, false)]
        public virtual Boolean Status
        {
            get { return _Status; }
            set { if (OnPropertyChanging(__.Status, value)) { _Status = value; OnPropertyChanged(__.Status); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(16, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(17, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private String _Location;
        /// <summary>安装位置</summary>
        [DisplayName("安装位置")]
        [Description("安装位置")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(18, "Location", "安装位置", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Location
        {
            get { return _Location; }
            set { if (OnPropertyChanging(__.Location, value)) { _Location = value; OnPropertyChanged(__.Location); } }
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
                    case __.Serialnum : return _Serialnum;
                    case __.CreateTime : return _CreateTime;
                    case __.CreateSysUserSerialnum : return _CreateSysUserSerialnum;
                    case __.UpdateTime : return _UpdateTime;
                    case __.UpdateSysUserSerialnum : return _UpdateSysUserSerialnum;
                    case __.Name : return _Name;
                    case __.FacilitySerialnum : return _FacilitySerialnum;
                    case __.UserID : return _UserID;
                    case __.UserPwd : return _UserPwd;
                    case __.IP : return _IP;
                    case __.HttpPort : return _HttpPort;
                    case __.DataPort : return _DataPort;
                    case __.RtspPort : return _RtspPort;
                    case __.Channel : return _Channel;
                    case __.Status : return _Status;
                    case __.Remark : return _Remark;
                    case __.Sort : return _Sort;
                    case __.Location : return _Location;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Serialnum : _Serialnum = Convert.ToString(value); break;
                    case __.CreateTime : _CreateTime = Convert.ToDateTime(value); break;
                    case __.CreateSysUserSerialnum : _CreateSysUserSerialnum = Convert.ToString(value); break;
                    case __.UpdateTime : _UpdateTime = Convert.ToDateTime(value); break;
                    case __.UpdateSysUserSerialnum : _UpdateSysUserSerialnum = Convert.ToString(value); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.FacilitySerialnum : _FacilitySerialnum = Convert.ToString(value); break;
                    case __.UserID : _UserID = Convert.ToString(value); break;
                    case __.UserPwd : _UserPwd = Convert.ToString(value); break;
                    case __.IP : _IP = Convert.ToString(value); break;
                    case __.HttpPort : _HttpPort = Convert.ToInt32(value); break;
                    case __.DataPort : _DataPort = Convert.ToInt32(value); break;
                    case __.RtspPort : _RtspPort = Convert.ToInt32(value); break;
                    case __.Channel : _Channel = Convert.ToInt32(value); break;
                    case __.Status : _Status = Convert.ToBoolean(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Location : _Location = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得设施摄像机字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>编码</summary>
            public static readonly Field Serialnum = FindByName(__.Serialnum);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>创建用户</summary>
            public static readonly Field CreateSysUserSerialnum = FindByName(__.CreateSysUserSerialnum);

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            ///<summary>更新用户</summary>
            public static readonly Field UpdateSysUserSerialnum = FindByName(__.UpdateSysUserSerialnum);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>设施编码</summary>
            public static readonly Field FacilitySerialnum = FindByName(__.FacilitySerialnum);

            ///<summary>登录用户名</summary>
            public static readonly Field UserID = FindByName(__.UserID);

            ///<summary>登录密码</summary>
            public static readonly Field UserPwd = FindByName(__.UserPwd);

            ///<summary>IP地址</summary>
            public static readonly Field IP = FindByName(__.IP);

            ///<summary>web端口号</summary>
            public static readonly Field HttpPort = FindByName(__.HttpPort);

            ///<summary>数据端口号</summary>
            public static readonly Field DataPort = FindByName(__.DataPort);

            ///<summary>RTSP 端口</summary>
            public static readonly Field RtspPort = FindByName(__.RtspPort);

            ///<summary>通道</summary>
            public static readonly Field Channel = FindByName(__.Channel);

            ///<summary>启用</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>安装位置</summary>
            public static readonly Field Location = FindByName(__.Location);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得设施摄像机字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编码</summary>
            public const String Serialnum = "Serialnum";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>创建用户</summary>
            public const String CreateSysUserSerialnum = "CreateSysUserSerialnum";

            ///<summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            ///<summary>更新用户</summary>
            public const String UpdateSysUserSerialnum = "UpdateSysUserSerialnum";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>设施编码</summary>
            public const String FacilitySerialnum = "FacilitySerialnum";

            ///<summary>登录用户名</summary>
            public const String UserID = "UserID";

            ///<summary>登录密码</summary>
            public const String UserPwd = "UserPwd";

            ///<summary>IP地址</summary>
            public const String IP = "IP";

            ///<summary>web端口号</summary>
            public const String HttpPort = "HttpPort";

            ///<summary>数据端口号</summary>
            public const String DataPort = "DataPort";

            ///<summary>RTSP 端口</summary>
            public const String RtspPort = "RtspPort";

            ///<summary>通道</summary>
            public const String Channel = "Channel";

            ///<summary>启用</summary>
            public const String Status = "Status";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>安装位置</summary>
            public const String Location = "Location";

        }
        
        #endregion
    }

    /// <summary>设施摄像机接口</summary>
    public partial interface IFacilityCamera
    {
        #region 属性
        /// <summary>编码</summary>
        String Serialnum { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>创建用户</summary>
        String CreateSysUserSerialnum { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>更新用户</summary>
        String UpdateSysUserSerialnum { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>设施编码</summary>
        String FacilitySerialnum { get; set; }

        /// <summary>登录用户名</summary>
        String UserID { get; set; }

        /// <summary>登录密码</summary>
        String UserPwd { get; set; }

        /// <summary>IP地址</summary>
        String IP { get; set; }

        /// <summary>web端口号</summary>
        Int32 HttpPort { get; set; }

        /// <summary>数据端口号</summary>
        Int32 DataPort { get; set; }

        /// <summary>RTSP 端口</summary>
        Int32 RtspPort { get; set; }

        /// <summary>通道</summary>
        Int32 Channel { get; set; }

        /// <summary>启用</summary>
        Boolean Status { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>安装位置</summary>
        String Location { get; set; }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        
        #endregion
    }
}