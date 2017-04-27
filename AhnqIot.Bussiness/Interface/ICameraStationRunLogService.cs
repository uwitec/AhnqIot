using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
  public  interface ICameraStationRunLogService:IService<CameraStationRunLogDto>
  {
        /// <summary>
        /// 添加实景监测点运行记录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
      Task<bool> AddAsny(CameraStationRunLogDto dto);
  }
}
