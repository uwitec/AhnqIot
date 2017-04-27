using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
  public  interface ICompanyUserService:IService<CompanyUserDto>
  {
        /// <summary>
        /// 根据系统用户编码获取
        /// </summary>
        /// <param name="sysUserId">系统用户编码</param>
        /// <returns></returns>
        Task<CompanyUserDto> GetBySysUserIdAsync(string sysUserId);
  }
}
