using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.ConfigTool.Model
{

    public class FacilitySensorDeviceUnitDto
    {



        /// <summary>ID</summary>
        [DisplayName("ID")]
        [Description("ID")]

        [ReadOnly(true)]
        public  Int32 ID { get; set; }


        /// <summary>设备名称</summary>
        [DisplayName("设备名称")]
        [Description("设备名称")]
        public  String Name { get; set; }

        /// <summary>编码1</summary>
        [DisplayName("编码1")]
        [Description("编码1")]
        [ReadOnly(true)]
        public  String Code1 { get; set; }

        /// <summary>编码2</summary>
        [DisplayName("编码2")]
        [Description("编码2")]
        [ReadOnly(true)]
        public  String Code2 { get; set; }

        /// <summary>编码3</summary>
        [DisplayName("编码3")]
        [Description("编码3")]
        [ReadOnly(true)]
        public  String Code3 { get; set; }

        /// <summary>设施</summary>
        [DisplayName("设施")]
        [Description("设施")]
        public  Int32 FacilityID { get; set; }

        /// <summary>传感器设备</summary>
        [DisplayName("传感器设备")]
        [Description("传感器设备")]
        public  Int32 SensorDeviceUnitID { get; set; }

        /// <summary>是否上传</summary>
        [DisplayName("是否上传")]
        [Description("是否上传")]
        public  Boolean Upload { get; set; }

        /// <summary>版本</summary>
        [DisplayName("版本")]
        [Description("版本")]
        public  Int32 Version { get; set; }

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        public  String Remark { get; set; }
    }
}