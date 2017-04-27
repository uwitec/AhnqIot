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
   public class AWProductService : ServiceBase<AWProduct, AWProductDto>, IAWProductService
    {
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
      public async  Task<IEnumerable<AWProductDto>> GetAllAsync()
        {
            return GetDtoModels(await Repository.GetAllAsync());
        }
        /// <summary>
        /// 根据类型获取
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AWProductDto>> GetByTypeAsync(string typeId)
        {
            return GetDtoModels(await Repository.GetManyAsync(aw=>aw.AWProductTypeSerialnum.Equals(typeId)));
        }
        /// <summary>
        /// 根据时间段获取
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        public async Task<IEnumerable<AWProductDto>> GetByTimeAsync(string id, int year, int month)
        {
            return GetDtoModels(await Repository.GetManyAsync(aw => aw.Serialnum.Equals(id)&&aw.UpdateTime.Year.Equals(year)&&aw.UpdateTime.Month.Equals(month)));
        }
        /// <summary>
        /// 根据编码获取
        /// </summary>
        /// <param name="id">编码</param>
        /// <returns></returns>
        public async Task<AWProductDto> GetByIdAsync(string id)
        {
            return GetDtoModel(await Repository.GetByIdAsync(id));
        }
    }
}
