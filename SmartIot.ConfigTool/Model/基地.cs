using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace SmartIot.ConfigTool.Model
{

    public class FarmDto
    {

        /// <summary>ID</summary>
        [DisplayName("ID")]
        [Description("ID")]
        [ReadOnly(true)]
        [Category("基本属性")]
        public  Int32 ID{ get; set; }


        /// <summary>编码1</summary>
        [DisplayName("编码1")]
        [Description("编码1")]
        [Category("基本属性")]
        public  String Code1 { get; set; }


        /// <summary>编码2</summary>
        [DisplayName("编码2")]
        [Description("编码2")]
        [Category("基本属性")]
        public  String Code2 { get; set; }


        /// <summary>编码3</summary>
        [DisplayName("编码3")]
        [Description("编码3")]
        [Category("基本属性")]
        public  String Code3 { get; set; }


        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [Category("基本属性")]
        public  String Name { get; set; }

        [Category("基本属性")]
        /// <summary>企业</summary>
        [DisplayName("企业")]
        [Description("企业")]
        public  String CompanySerialnum { get; set; }


        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [Category("基本属性")]
        public  String Address { get; set; }

        /// <summary>形象图片</summary>
        [DisplayName("形象图片")]
        [Description("形象图片")]
        [Category("基本属性")]
        public  String PhotoUrl { get; set; }

        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [Category("基本属性")]
        public  String Lotitude { get; set; }

        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [Category("基本属性")]
        public  String Latitude { get; set; }


        /// <summary>面积</summary>
        [DisplayName("面积")]
        [Description("面积")]
        [Category("基本属性")]
        public  Int32 Area { get; set; }

        /// <summary>联系人</summary>
        [DisplayName("联系人")]
        [Description("联系人")]

        [Category("基本属性")]
        public  String ContactMan { get; set; }
        /// <summary>联系电话</summary>
        [DisplayName("联系电话")]
        [Description("联系电话")]
        [Category("基本属性")]
        public  String ContactPhone { get; set; }

        /// <summary>手机</summary>
        [DisplayName("手机")]
        [Description("手机")]
        [Category("基本属性")]
        public  String ContactMobile { get; set; }

        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [Category("基本属性")]
        public  Boolean Status { get; set; }

        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [Category("基本属性")]
        [ReadOnly(true)]
        public  DateTime CreateTime { get; set; }

        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [Category("基本属性")]
        [ReadOnly(true)]
        public  DateTime UpdateTime { get; set; }

        /// <summary>数据接口访问KEY</summary>
        [DisplayName("数据接口访问KEY")]
        [Description("数据接口访问KEY")]
        [Category("基本属性")]
        public  String APIKey { get; set; }

        /// <summary>是否上传</summary>
        [DisplayName("是否上传")]
        [Description("是否上传")]
        [Category("基本属性")]
        public  Boolean Upload { get; set; }

        /// <summary>版本</summary>
        [DisplayName("版本")]
        [Description("版本")]
        [Category("基本属性")]
        public  Int32 Version { get; set; }

        /// <summary>基地介绍</summary>
        [DisplayName("基地介绍")]
        [Description("基地介绍")]
        [Category("基本属性")]

        public  String Introduce { get; set; }

        /// <summary>备注</summary>
        [DisplayName("基地密码")]
        [Description("基地密码")]

        [Category("基本属性")]
        public  String Remark { get; set; }



    }
}