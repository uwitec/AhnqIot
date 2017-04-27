using SmartIot.Tool.DefaultService.DB.Common;
using System;
using System.ComponentModel;

namespace SmartIot.ConfigTool.Model
{
	public class   CommunicateDeviceDto
    {
        /// <summary>ID</summary>
        [DisplayName("ID")]
        [Description("ID")]
        [Category("基本属性"),ReadOnly(true)]
        public  Int32 ID{get;set;}

        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [Category("基本属性")]
        public  String Name{get;set;}

        /// <summary>通讯设备类型</summary>
        [DisplayName("通讯设备类型")]
        [Description("通讯设备类型")]
        [Category("关联选项")]
        public  Int32 CommunicateDeviceTypeID{get;set;}

        /// <summary>参数1</summary>
        [DisplayName("参数1")]
        [Description("参数1")]
        [Category("基本属性")]
        public  String Args1{get;set;}

        /// <summary>参数2</summary>
        [DisplayName("参数2")]
        [Description("参数2")]
        [Category("基本属性")]
        public  String Args2{get;set;}

        /// <summary>参数3</summary>
        [DisplayName("参数3")]
        [Description("参数3")]
        [Category("基本属性")]
        public  String Args3{get;set;}

        /// <summary>参数4</summary>
        [DisplayName("参数4")]
        [Description("参数4")]
        [Category("基本属性")]
        public  String Args4{get;set;}

        /// <summary>参数5</summary>
        [DisplayName("参数5")]
        [Description("参数5")]
        [Category("基本属性")]
        public  String Args5{get;set;}

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
        private string _CommunicateDeviceTypes;
        [Category("关联选项"), DisplayName("通讯设备类型")]
        [Description("通讯设备类型"), TypeConverter(typeof(CommunicateDeviceTypeConverter))]
        public string CommunicateDeviceTypes
        {
            get
            {
                return _CommunicateDeviceTypes;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _CommunicateDeviceTypes = value; }
        }
    }

 
}