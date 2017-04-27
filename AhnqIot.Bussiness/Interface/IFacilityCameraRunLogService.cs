using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
    public interface IFacilityCameraRunLogService : IService<FacilityCameraRunLogDto>
    {

        /// <summary>
        /// 添加设施视频运行日志
        /// </summary>
        /// <param name="dto">视频运行日志实体</param>
        /// <returns></returns>
        Task<bool> AddRunLogAsny(FacilityCameraRunLogDto dto);
        /// <summary>
        /// 添加设施视频运行日志
        /// </summary>
        /// <param name="dto">视频运行日志实体</param>
        /// <returns></returns>
        bool AddRunLog(FacilityCameraRunLogDto dto);

        /// <summary>
        /// 处理设施视频运行记录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> ProcessRunLogAsync(FacilityCameraRunLogDto dto);
    }
}
