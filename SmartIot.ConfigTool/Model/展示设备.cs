using SmartIot.Tool.DefaultService.DB.Common;
using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.ConfigTool.Model
{
    public   class ShowDeviceDto
    {

        /// <summary>ID</summary>
        [DisplayName("ID")]
        [Description("ID")]
        [Category("基本属性")]
        public  Int32 ID{get;set;}

        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [Category("基本属性")]
        public  String Name{get;set;}

        /// <summary>展示设备类型</summary>
        [DisplayName("展示设备类型")]
        [Description("展示设备类型")]
        [Category("关联选项")]
        [ReadOnly(true)]
        public  Int32 ShowDeviceTypeID{get;set;}

        /// <summary>通讯设备</summary>
        [DisplayName("通讯设备")]
        [Description("通讯设备")]
        [Category("关联选项")]
        [ReadOnly(true)]
        public  Int32 CommunicateDeviceID{get;set;}

        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [Category("基本属性")]

        public  String Address{get;set;}

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [Category("基本属性")]

        public  String Remark { get; set; }
        private string _ShowDeviceTypes;
        [Category("关联选项"), DisplayName("展示设备类型")]
        [Description("展示设备类型"), TypeConverter(typeof(ShowDeviceTypeConverter))]
        public string ShowDeviceTypes
        {
            get
            {
                return _ShowDeviceTypes;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _ShowDeviceTypes = value; }
        }

        private string _CommunicateDevices;
        [Category("关联选项"), DisplayName("通讯设备")]
        [Description("通讯设备"), TypeConverter(typeof(CommunicateDeviceConverter))]
        public string CommunicateDevices
        {
            get
            {
                return _CommunicateDevices;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _CommunicateDevices = value; }
        }
    }

  
}