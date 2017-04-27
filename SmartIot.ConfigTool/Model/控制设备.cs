using SmartIot.Tool.DefaultService.DB.Common;
using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.ConfigTool.Model
{

    public  class ControlDeviceUnitDto
    {



        /// <summary>ID</summary>
        [DisplayName("ID")]
        [Description("ID")]
        [Category("基本属性")]
        [ReadOnly(true)]
        public  Int32 ID{get;set;}

        /// <summary>设备名称</summary>
        [DisplayName("设备名称")]
        [Description("设备名称,请以{设备名称}+‘-’+{控制工作内容}’的格式填写！")]
        [Category("基本属性")]
        public  String Name{get;set;}

        /// <summary>模块化设备</summary>
        [DisplayName("模块化设备ID")]
        [Description("模块化设备ID")]
        [Category("关联选项")]
        [ReadOnly(true)]
        public  Int32 ModularDeviceID{get;set;}

        /// <summary>设备类型</summary>
        [DisplayName("设备类型ID")]
        [Description("设备类型ID")]
        [Category("关联选项")]
        [ReadOnly(true)]
        public  String DeviceTypeSerialnum{get;set;}

        /// <summary>功能码</summary>
        [DisplayName("功能码")]
        [Description("功能码")]
        [Category("基本属性")]
        public  Int32 Function{get;set;}


        private Int32 _RegisterAddress1;

        /// <summary>寄存器地址(十进制)</summary>
        [DisplayName("寄存器地址十进制")]
        [Description("寄存器地址(十进制)")]
        [Category("基本属性")]
        public  Int32 RegisterAddress1{get;set;}

        /// <summary>控制设备组号(十进制)</summary>
        [DisplayName("控制设备组号十进制")]
        [Description("控制设备组号(十进制)")]
        [Category("基本属性")]
        public  Int32 GroupNum{get;set;}

        /// <summary>继电器类型</summary>
        [DisplayName("继电器类型ID")]
        [Description("继电器类型ID")]
        [Category("关联选项")]
        [ReadOnly(true)]
        public  Int32 RelayTypeId{get;set;}

   
        /// <summary>原始值</summary>
        [DisplayName("原始值")]
        [Description("原始值")]
        [Category("基本属性")]
        public  Int32 OriginalValue{get;set;}

        /// <summary>设备状态</summary>
        [DisplayName("设备状态")]
        [Description("设备状态")]
        [Category("基本属性")]
        public  String ProcessedValue{get;set;}

        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [Category("基本属性")]
        public  DateTime UpdateTime{get;set;}

        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [Category("基本属性")]
        public  String Location{get;set;}

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [Category("基本属性")]
        public  String Remark{get;set;}

        /// <summary>工作</summary>
        [DisplayName("控制工作类型ID")]
        [Description("控制工作类型ID")]
        [Category("关联选项")]
        [ReadOnly(true)]
        public  Int32 ControlJobTypeId { get; set; }
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