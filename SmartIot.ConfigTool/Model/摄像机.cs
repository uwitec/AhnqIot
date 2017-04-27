using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.ConfigTool.Model
{
    public   class CameraDto
    {

        /// <summary>ID</summary>
        [DisplayName("ID")]
        [Description("ID")]
        [ReadOnly(true)]
        [Category("基本属性")]
        public  Int32 ID{get;set;}

        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [Category("基本属性")]
        public  String Name{get;set;}
        /// <summary>登录用户名</summary>
        [DisplayName("登录用户名")]
        [Description("登录用户名")]
        [Category("基本属性")]
        public  String UserID{get;set;}

        /// <summary>登录密码</summary>
        [DisplayName("登录密码")]
        [Description("登录密码")]
        [Category("基本属性")]
        public  String UserPwd{get;set;}

        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [Category("基本属性")]
        public  String CameraHost{get;set;}

        /// <summary>web端口号</summary>
        [DisplayName("web端口号")]
        [Description("web端口号")]
        [Category("基本属性")]
        public  Int32 CameraHttpPort{get;set;}

        /// <summary>数据端口号</summary>
        [DisplayName("数据端口号")]
        [Description("数据端口号")]
        [Category("基本属性")]
        public  Int32 CameraDataPort{get;set;}

        /// <summary>数据端口号</summary>
        [DisplayName("数据端口号")]
        [Description("数据端口号")]
        [Category("基本属性")]
        public  Int32 CameraRTSPPort{get;set;}

        /// <summary>通道</summary>
        [DisplayName("通道")]
        [Description("通道")]
        [Category("基本属性")]
        public  Int32 Channel{get;set;}

        /// <summary>流媒体地址</summary>
        [DisplayName("流媒体地址")]
        [Description("流媒体地址")]
        [Category("基本属性")]
        public  String StreamMedia{get;set;}
        /// <summary>厂家</summary>
        [DisplayName("厂家")]
        [Description("厂家")]
        [Category("基本属性")]
        public  String Company{get;set;}

        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [Category("基本属性")]
        public  Boolean OnlineStatus{get;set;}

        /// <summary>异常</summary>
        [DisplayName("异常")]
        [Description("异常")]
        [Category("基本属性")]
        public  String Exception{get;set;}

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [Category("基本属性")]
        public  String Remark { get; set; }

    }


}