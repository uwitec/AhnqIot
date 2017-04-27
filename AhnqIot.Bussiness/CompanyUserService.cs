using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Hxj.DbModel;

namespace AhnqIot.Bussiness
{
  public  class CompanyUserService:ServiceBase<CompanyUser,CompanyUserDto>, ICompanyUserService
    {
      /// <summary>
      /// 根据系统用户编码获取
      /// </summary>
      /// <param name="sysUserId">系统用户编码</param>
      /// <returns></returns>
      public async  Task<CompanyUserDto> GetBySysUserIdAsync(string sysUserId)
      {
          return  GetDtoModel(await Repository.GetAsync(c => c.SysUserSerialnum.Equals(sysUserId)));
      }
    }
}
