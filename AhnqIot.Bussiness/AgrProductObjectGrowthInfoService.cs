using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Hxj.Repository.AhnqIot;
using AutoMapper;

namespace AhnqIot.Bussiness
{
    public class AgrProductObjectGrowthInfoService :ServiceBase<AgrProductObjectGrowthInfo,AgrProductObjectGrowthInfoDto> ,IAgrProductObjectGrowthInfoService
    {
        //private readonly IAhnqIotRepository<AgrProductObjectGrowthInfo> _agrProductObjectGrowthInfoRep;

        public AgrProductObjectGrowthInfoService(IAhnqIotRepository<AgrProductObjectGrowthInfo> agrProductObjectGrowthInfoRep)
        {
            //_agrProductObjectGrowthInfoRep = agrProductObjectGrowthInfoRep;
        }

        /// <summary>
        /// 根据农作物产品编码获取农作物产品的生长信息
        /// </summary>
        /// <param name="agrProductObjectSerialnum">农作物产品编码</param>
        /// <returns></returns>
        public async Task<AgrProductObjectGrowthInfoDto> GetAgrProductObjectGrowthInfoByAgrProductObjectSerialnum(string agrProductObjectSerialnum)
        {
            return GetDtoModel(await Repository.GetAsync(agi => agi.AgrProductObjectSerialnum.Equals(agrProductObjectSerialnum)));
        }
    }
}
