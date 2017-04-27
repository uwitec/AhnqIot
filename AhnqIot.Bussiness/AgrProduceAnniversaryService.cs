using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Hxj.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Bussiness
{
  public  class AgrProduceAnniversaryService :ServiceBase<AhnqIot.Hxj.DbModel.AgrProduceAnniversaryService, AgrProduceAnniversaryServiceDto>,IAgrProduceAnniversaryService
    {
        /// <summary>
        /// 添加周年服务方案
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
     public async   Task<bool> AddAsny(AgrProduceAnniversaryServiceDto dto)
        {
            Repository.Add(GetDbModel(dto));
            return await Repository.CommitAsync() > 0;
        }
        /// <summary>
        /// 根据编码获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
      public async  Task<AgrProduceAnniversaryServiceDto> GetByIdAsny(string id)
        {
            return
               GetDtoModel(
                   await Repository.GetByIdAsync(id));
        }
    }
}
