using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Bussiness.Interface
{
   public interface IAWProductService : IService<AWProductDto>
    {
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AWProductDto>> GetAllAsync();
        /// <summary>
        /// 根据类型获取
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        Task<IEnumerable<AWProductDto>> GetByTypeAsync(string typeId);
        /// <summary>
        /// 根据时间段获取
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        Task<IEnumerable<AWProductDto>> GetByTimeAsync(string id,int year,int month);
        /// <summary>
        /// 根据编码获取
        /// </summary>
        /// <param name="id">编码</param>
        /// <returns></returns>
        Task<AWProductDto> GetByIdAsync(string id);
    }
}
