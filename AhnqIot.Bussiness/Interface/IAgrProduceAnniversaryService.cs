using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Bussiness.Interface
{
    public interface IAgrProduceAnniversaryService : IService<AgrProduceAnniversaryServiceDto>
    {
        /// <summary>
        /// 添加周年服务方案
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> AddAsny(AgrProduceAnniversaryServiceDto dto);
        /// <summary>
        /// 根据编码获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AgrProduceAnniversaryServiceDto> GetByIdAsny(string id);
    }
}
