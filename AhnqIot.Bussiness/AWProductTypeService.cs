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
   public class AWProductTypeService: ServiceBase<AWProductType, AWProductTypeDto>,IAWProductTypeService
    {
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
      public async  Task<IEnumerable<AWProductTypeDto>> GetAllAsync()
        {
            return GetDtoModels(await Repository.GetAllAsync());
        }
    }
}
