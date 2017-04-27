using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
   public interface ICameraStationPicsService : IService<CameraStationPicsDto>
    {
        /// <summary>
        /// 添加实景监测点图片
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> AddAsny(CameraStationPicsDto dto);
    }
}
