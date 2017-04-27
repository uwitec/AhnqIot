using SmartIot.Tool.DefaultService.DB.Common;
using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.ConfigTool.Model
{
  
    public  class ModularDeviceDto
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

        /// <summary>设备地址</summary>
        [DisplayName("设备地址")]
        [Description("设备地址")]
        [Category("基本属性")]
        public  String Address{get;set;}

        /// <summary>协议</summary>
        [DisplayName("协议")]
        [Description("协议")]
        [Category("基本属性"),ReadOnly(true)]
        public  Int32 ProtocalTypeID{get;set;}

        /// <summary>通讯设备</summary>
        [DisplayName("通讯设备")]
        [Description("通讯设备")]
        [Category("基本属性"), ReadOnly(true)]
        public  Int32 CommunicateDeviceID{get;set;}


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
        private string _ModularDevices;
        [Category("关联选项"), DisplayName("模块化设备")]
        [Description("模块化设备"), TypeConverter(typeof(ModularConverter))]
        public string ModularDevices
        {
            get
            {
                return _ModularDevices;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _ModularDevices = value; }
        }

        private string _DeviceTypes;
        [Category("关联选项"), DisplayName("设备类型")]
        [Description("设备类型"), TypeConverter(typeof(DeviceTypeConverter))]
        public string DeviceTypes
        {
            get
            {
                return _DeviceTypes;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _DeviceTypes = value; }
        }


        private string _ControlJobTypes;
        [Category("关联选项"), DisplayName("控制工作类型")]
        [Description("控制工作类型"), TypeConverter(typeof(ControlJobTypeConverter))]
        public string ControlJobTypes
        {
            get
            {
                return _ControlJobTypes;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _ControlJobTypes = value; }
        }

        private string _RelayTypes;
        [Category("关联选项"), DisplayName("继电器类型")]
        [Description("继电器类型"), TypeConverter(typeof(RelayTypeConverter))]
        public string RelayTypes
        {
            get
            {
                return _RelayTypes;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _RelayTypes = value; }
        }

    }

  
}