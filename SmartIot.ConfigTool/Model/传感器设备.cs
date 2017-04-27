using SmartIot.Tool.DefaultService.DB.Common;
using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.ConfigTool.Model
{
    public  class SensorDeviceUnitDto
    {

        /// <summary>ID</summary>
        [DisplayName("ID")]
        [Description("ID")]
        [Category("基本属性"), ReadOnly(true)]
        public  Int32 ID { get; set; }
        


        /// <summary>设备名称</summary>
        [DisplayName("设备名称")]
        [Description("设备名称")]
        [Category("基本属性")]
        public  String Name { get; set; }
   

        /// <summary>模块化设备编号</summary>
        [DisplayName("模块化设备编号")]
        [Description("模块化设备编号")]
        [Category("关联选项")]
        [ReadOnly(true)]
        public  Int32 ModularDeviceID { get; set; }
        


        /// <summary>传感器编号</summary>
        [DisplayName("传感器编号")]
        [Description("传感器编号")]
        [Category("关联选项")]
        [ReadOnly(true)]
        public  Int32 SensorId { get; set; }


        /// <summary>功能码</summary>
        [DisplayName("功能码")]
        [Description("功能码")]
        [Category("基本属性")]
        public  Int32 Function { get; set; }



        /// <summary>寄存器地址(十进制)</summary>
        [DisplayName("寄存器地址十进制")]
        [Description("寄存器地址(十进制)")]
        [Category("基本属性")]
        public  Int32 RegisterAddress { get; set; }

        /// <summary>寄存器长度</summary>
        [DisplayName("寄存器长度")]
        [Description("寄存器长度")]
        [Category("基本属性")]
        public  Int32 RegisterSize { get; set; }


        /// <summary>原始值</summary>
        [DisplayName("原始值")]
        [Description("原始值")]
        [Category("基本属性")]
        public  Int32 OriginalValue { get; set; }


        /// <summary>处理值</summary>
        [DisplayName("处理值")]
        [Description("处理值")]
        [Category("基本属性")]
        public  Decimal ProcessedValue { get; set; }

 

        /// <summary>显示值</summary>
        [DisplayName("显示值")]
        [Description("显示值")]
        [Category("基本属性")]
        public  String ShowValue { get; set; }


        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [Category("基本属性")]
        [ReadOnly(true)]
        public  DateTime UpdateTime { get; set; }


        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [Category("基本属性")]
        public  String Location { get; set; }

  
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

        private string _Sensors;
        [Category("关联选项"), DisplayName("传感器")]
        [Description("传感器"), TypeConverter(typeof(SensorConverter))]
        public string Sensors
        {
            get
            {
                return _Sensors;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _Sensors = value; }
        }



    }

}