using SmartIot.Tool.DefaultService.DB.Common;
using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.ConfigTool.Model
{
    public class FacilityDto
    {



        private Int32 _ID;

        /// <summary>ID</summary>
        [DisplayName("ID")]
        [Description("ID")]
        [Category("基本属性"), ReadOnly(true)]
        public  Int32 ID{get;set;}



        /// <summary>编码1</summary>
        [DisplayName("编码1")]
        [Description("编码1")]
        [Category("基本属性")]
        [ReadOnly(true)]
        public  String Code1{get;set;}

        /// <summary>编码2</summary>
        [DisplayName("编码2")]
        [Description("编码2")]
      
        [Category("基本属性")]
        [ReadOnly(true)]
        public  String Code2{get;set;}

        /// <summary>编码3</summary>
        [DisplayName("编码3")]
        [Description("编码3")]
        [Category("基本属性")]
        [ReadOnly(true)]
        public  String Code3{get;set;}

        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [Category("基本属性")]
        public  String Name{get;set;}

        /// <summary>基地ID</summary>
        [DisplayName("基地ID")]
        [Description("基地ID")]
        [Category("关联选项")]
        [ReadOnly(true)]
        public  Int32 FarmID{get;set;}
        /// <summary>设施类型编码</summary>
        [DisplayName("设施类型编码")]
        [Description("设施类型编码")]
        [Category("关联选项")]
        [ReadOnly(true)]
        public  String FacilityTypeSerialnum{get;set;}

        /// <summary>形象图片</summary>
        [DisplayName("形象图片")]
        [Description("形象图片")]
        [Category("基本属性")]
        public  String PhotoUrl{get;set;}

        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [Category("基本属性")]
        public  String Address{get;set;}

        /// <summary>联系人</summary>
        [DisplayName("联系人")]
        [Description("联系人")]
        [Category("基本属性")]
        public  String ContactMan{get;set;}

        /// <summary>联系电话</summary>
        [DisplayName("联系电话")]
        [Description("联系电话")]
        [Category("基本属性")]
        public  String ContactPhone{get;set;}

        /// <summary>手机</summary>
        [DisplayName("手机")]
        [Description("手机")]
        [Category("基本属性")]
        public  String ContactMobile{get;set;}

        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [Category("基本属性")]
        public  Boolean Status{get;set;}

        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [Category("基本属性")]
        [ReadOnly(true)]
        public  DateTime CreateTime{get;set;}

        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [Category("基本属性")]
        [ReadOnly(true)]
        public  DateTime UpdateTime{get;set;}

        /// <summary>设施介绍</summary>
        [DisplayName("设施介绍")]
        [Description("设施介绍")]
        [Category("基本属性")]
        public  String Introduce{get;set;}

        /// <summary>版本</summary>
        [DisplayName("版本")]
        [Description("版本")]
        [Category("基本属性")]
        public  Int32 Version{get;set;}

        /// <summary>是否上传</summary>
        [DisplayName("是否上传")]
        [Description("是否上传")]
        [Category("基本属性")]
        public  Boolean Upload{get;set;}

        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [Category("基本属性")]
        public  String Remark{get;set;}

        private string _Farms;
        [Category("关联选项"), DisplayName("所属基地")]
        [Description("所属基地"), TypeConverter(typeof(FarmConverter))]
        public string Farms
        {
            get
            {
                return _Farms;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _Farms = value; }
        }

        private string _FacilityTypes;
        [Category("关联选项"), DisplayName("设施类型")]
        [Description("设施类型"), TypeConverter(typeof(FacilityTypeConverter))]
        public string FacilityTypes
        {
            get
            {
                return _FacilityTypes;
                //return ModularDevice != null ? ModularDevice.Name : String.Empty; 
            }
            set { _FacilityTypes = value; }
        }
    }


}