using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
  public  interface IAgrProductObjectGrowthInfoService:IService<AgrProductObjectGrowthInfoDto>
    {
        /// <summary>
        /// 根据农作物产品编码获取农作物产品的生长信息
        /// </summary>
        /// <param name="agrProductObjectSerialnum">农作物产品编码</param>
        /// <returns></returns>
        Task<AgrProductObjectGrowthInfoDto> GetAgrProductObjectGrowthInfoByAgrProductObjectSerialnum(string agrProductObjectSerialnum);
    }
}
