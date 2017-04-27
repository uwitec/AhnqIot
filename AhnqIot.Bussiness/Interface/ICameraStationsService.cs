using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
 public  interface ICameraStationsService:IService<CameraStationsDto>
 {
        /// <summary>
        /// 获取所有的实景检测点
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CameraStationsDto>> GetAllAsny();
 }
}
