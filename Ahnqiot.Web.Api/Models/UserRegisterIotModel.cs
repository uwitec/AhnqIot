//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Web
//  FILENAME   ： UserRegisterIotModel.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 14:59
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

namespace Ahnqiot.Web.Api.Models
{
    public class UserRegisterIotModel : UserRegisterBaseModel
    {
        public string CompanyName { get; set; }

        public string Location { get; set; }
    }
}