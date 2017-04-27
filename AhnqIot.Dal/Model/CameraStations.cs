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
    /// <summary>实景监测点</summary>
    [Serializable]
    [DataObject]
    [Description("实景监测点")]
    [BindIndex("IX_CameraStations_SysDepartmentSerialnum", false, "SysDepartmentSerialnum")]
    [BindIndex("PK__CameraSt__E3E7488D9EA292ED", true, "Serialnum")]
    [BindRelation("Serialnum", true, "CameraStationOnlineStatistics", "CameraStationsSerialnum")]
    [BindRelation("Serialnum", true, "CameraStationPresetPoint", "CameraStationsSerialnum")]
    [BindRelation("Serialnum", true, "CameraStationRunLog", "CameraStationsSerialnum")]
    [BindRelation("SysDepartmentSerialnum", false, "SysDepartment", "Serialnum")]
    [BindTable("CameraStations", Description = "实景监测点", ConnName = "ConnName", DbType = DatabaseType.SqlServer)]
    public partial class CameraStations : ICameraStations
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
        /// <summary>实景监测点</summary>
        [DisplayName("实景监测点")]
        [Description("实景监测点")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(6, "Name", "实景监测点", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private String _SysDepartmentSerialnum;
        /// <summary>机构</summary>
        [DisplayName("机构")]
        [Description("机构")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "SysDepartmentSerialnum", "机构", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SysDepartmentSerialnum
        {
            get { return _SysDepartmentSerialnum; }
            set { if (OnPropertyChanging(__.SysDepartmentSerialnum, value)) { _SysDepartmentSerialnum = value; OnPropertyChanged(__.SysDepartmentSerialnum); } }
        }

        private String _Location;
        /// <summary>安装位置</summary>
        [DisplayName("安装位置")]
        [Description("安装位置")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(8, "Location", "安装位置", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Location
        {
            get { return _Location; }
            set { if (OnPropertyChanging(__.Location, value)) { _Location = value; OnPropertyChanged(__.Location); } }
        }

        private String _Lotitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "Lotitude", "经度", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Lotitude
        {
            get { return _Lotitude; }
            set { if (OnPropertyChanging(__.Lotitude, value)) { _Lotitude = value; OnPropertyChanged(__.Lotitude); } }
        }

        private String _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "Latitude", "纬度", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Latitude
        {
            get { return _Latitude; }
            set { if (OnPropertyChanging(__.Latitude, value)) { _Latitude = value; OnPropertyChanged(__.Latitude); } }
        }

        private DateTime _SetupTime;
        /// <summary>安装时间</summary>
        [DisplayName("安装时间")]
        [Description("安装时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(11, "SetupTime", "安装时间", null, "datetime", 3, 0, false)]
        public virtual DateTime SetupTime
        {
            get { return _SetupTime; }
            set { if (OnPropertyChanging(__.SetupTime, value)) { _SetupTime = value; OnPropertyChanged(__.SetupTime); } }
        }

        private String _UserID;
        /// <summary>登录用户名</summary>
        [DisplayName("登录用户名")]
        [Description("登录用户名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "UserID", "登录用户名", "admin", "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(13, "UserPwd", "登录密码", "admin", "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(14, "IP", "IP地址", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(15, "HttpPort", "web端口号", "80", "int", 10, 0, false)]
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
        [BindColumn(16, "DataPort", "数据端口号", "8000", "int", 10, 0, false)]
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
        [BindColumn(17, "RtspPort", "RTSP 端口", "554", "int", 10, 0, false)]
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
        [BindColumn(18, "Channel", "通道", "1", "int", 10, 0, false)]
        public virtual Int32 Channel
        {
            get { return _Channel; }
            set { if (OnPropertyChanging(__.Channel, value)) { _Channel = value; OnPropertyChanged(__.Channel); } }
        }

        private String _StreamMedia;
        /// <summary>流媒体地址</summary>
        [DisplayName("流媒体地址")]
        [Description("流媒体地址")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(19, "StreamMedia", "流媒体地址", null, "nvarchar(500)", 0, 0, true)]
        public virtual String StreamMedia
        {
            get { return _StreamMedia; }
            set { if (OnPropertyChanging(__.StreamMedia, value)) { _StreamMedia = value; OnPropertyChanged(__.StreamMedia); } }
        }

        private String _Introduce;
        /// <summary>介绍</summary>
        [DisplayName("介绍")]
        [Description("介绍")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(20, "Introduce", "介绍", null, "ntext", 0, 0, true)]
        public virtual String Introduce
        {
            get { return _Introduce; }
            set { if (OnPropertyChanging(__.Introduce, value)) { _Introduce = value; OnPropertyChanged(__.Introduce); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(21, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(22, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } }
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
                    case __.SysDepartmentSerialnum : return _SysDepartmentSerialnum;
                    case __.Location : return _Location;
                    case __.Lotitude : return _Lotitude;
                    case __.Latitude : return _Latitude;
                    case __.SetupTime : return _SetupTime;
                    case __.UserID : return _UserID;
                    case __.UserPwd : return _UserPwd;
                    case __.IP : return _IP;
                    case __.HttpPort : return _HttpPort;
                    case __.DataPort : return _DataPort;
                    case __.RtspPort : return _RtspPort;
                    case __.Channel : return _Channel;
                    case __.StreamMedia : return _StreamMedia;
                    case __.Introduce : return _Introduce;
                    case __.Sort : return _Sort;
                    case __.Remark : return _Remark;
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
                    case __.SysDepartmentSerialnum : _SysDepartmentSerialnum = Convert.ToString(value); break;
                    case __.Location : _Location = Convert.ToString(value); break;
                    case __.Lotitude : _Lotitude = Convert.ToString(value); break;
                    case __.Latitude : _Latitude = Convert.ToString(value); break;
                    case __.SetupTime : _SetupTime = Convert.ToDateTime(value); break;
                    case __.UserID : _UserID = Convert.ToString(value); break;
                    case __.UserPwd : _UserPwd = Convert.ToString(value); break;
                    case __.IP : _IP = Convert.ToString(value); break;
                    case __.HttpPort : _HttpPort = Convert.ToInt32(value); break;
                    case __.DataPort : _DataPort = Convert.ToInt32(value); break;
                    case __.RtspPort : _RtspPort = Convert.ToInt32(value); break;
                    case __.Channel : _Channel = Convert.ToInt32(value); break;
                    case __.StreamMedia : _StreamMedia = Convert.ToString(value); break;
                    case __.Introduce : _Introduce = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        
        #endregion

        #region 字段名
        
        /// <summary>取得实景监测点字段信息的快捷方式</summary>
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

            ///<summary>实景监测点</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>机构</summary>
            public static readonly Field SysDepartmentSerialnum = FindByName(__.SysDepartmentSerialnum);

            ///<summary>安装位置</summary>
            public static readonly Field Location = FindByName(__.Location);

            ///<summary>经度</summary>
            public static readonly Field Lotitude = FindByName(__.Lotitude);

            ///<summary>纬度</summary>
            public static readonly Field Latitude = FindByName(__.Latitude);

            ///<summary>安装时间</summary>
            public static readonly Field SetupTime = FindByName(__.SetupTime);

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

            ///<summary>流媒体地址</summary>
            public static readonly Field StreamMedia = FindByName(__.StreamMedia);

            ///<summary>介绍</summary>
            public static readonly Field Introduce = FindByName(__.Introduce);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得实景监测点字段名称的快捷方式</summary>
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

            ///<summary>实景监测点</summary>
            public const String Name = "Name";

            ///<summary>机构</summary>
            public const String SysDepartmentSerialnum = "SysDepartmentSerialnum";

            ///<summary>安装位置</summary>
            public const String Location = "Location";

            ///<summary>经度</summary>
            public const String Lotitude = "Lotitude";

            ///<summary>纬度</summary>
            public const String Latitude = "Latitude";

            ///<summary>安装时间</summary>
            public const String SetupTime = "SetupTime";

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

            ///<summary>流媒体地址</summary>
            public const String StreamMedia = "StreamMedia";

            ///<summary>介绍</summary>
            public const String Introduce = "Introduce";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        
        #endregion
    }

    /// <summary>实景监测点接口</summary>
    public partial interface ICameraStations
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

        /// <summary>实景监测点</summary>
        String Name { get; set; }

        /// <summary>机构</summary>
        String SysDepartmentSerialnum { get; set; }

        /// <summary>安装位置</summary>
        String Location { get; set; }

        /// <summary>经度</summary>
        String Lotitude { get; set; }

        /// <summary>纬度</summary>
        String Latitude { get; set; }

        /// <summary>安装时间</summary>
        DateTime SetupTime { get; set; }

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

        /// <summary>流媒体地址</summary>
        String StreamMedia { get; set; }

        /// <summary>介绍</summary>
        String Introduce { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        #endregion

        #region 获取/设置 字段值
        
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        
        #endregion
    }
}