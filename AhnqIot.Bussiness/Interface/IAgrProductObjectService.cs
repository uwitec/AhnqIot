using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Bussiness.Interface
{
  public  interface IAgrProductObjectService : IService<AgrProductObjectDto>
    {
        Task<IEnumerable<AgrProductObjectDto>> GetAllAsync();
        //Task<AgrProductObjectDto>
    }
}
