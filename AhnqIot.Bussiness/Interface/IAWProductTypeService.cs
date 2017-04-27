using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Bussiness.Interface
{
  public  interface IAWProductTypeService:IService<AWProductTypeDto>
    {
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AWProductTypeDto>> GetAllAsync();
    }
}
