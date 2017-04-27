//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Web
//  FILENAME   ： UserLoginModel.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 13:45
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System.ComponentModel.DataAnnotations;

namespace AhnqIot.Web.Areas.apiV1.Models
{
    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class UserLoginModel
    {
        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        public string LoginName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        public string Password { get; set; } 
    }
}