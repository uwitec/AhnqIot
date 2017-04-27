using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Hxj.Repository.AhnqIot;
using Autofac;
using AutoMapper;

namespace AhnqIot.Bussiness
{
    public class FacilityCameraRunLogService :ServiceBase<FacilityCameraRunLog,FacilityCameraRunLogDto>, IFacilityCameraRunLogService
    {
        //private readonly IAhnqIotRepository<FacilityCameraRunLog> _facilityCameraRunLogRep;

        public FacilityCameraRunLogService(IAhnqIotRepository<FacilityCameraRunLog> deviceRunLogRep)
        {
            //_deviceRunLogRep = deviceRunLogRep;
            //_facilityCameraRunLogRep = AhnqIotContainer.Container.Resolve<IAhnqIotRepository<FacilityCameraRunLog>>();
        }

        /// <summary>
        /// 添加设施视频运行日志
        /// </summary>
        /// <param name="dto">  运行日志实体</param>
        /// <returns></returns>
        public async Task<bool> AddRunLogAsny(FacilityCameraRunLogDto dto)
        {
            var facilityCameraRunLog = GetDbModel(dto);
            Repository.Add(facilityCameraRunLog);
            return await Repository.CommitAsync() > 0;
        }
        /// <summary>
        /// 添加设施视频运行日志
        /// </summary>
        /// <param name="dto">  运行日志实体</param>
        /// <returns></returns>
        public bool AddRunLog(FacilityCameraRunLogDto dto)
        {
            var facilityCameraRunLog = GetDbModel(dto);
            Repository.Add(facilityCameraRunLog);
            return Repository.Commit() > 0;
        }
        /// <summary>
        /// 处理设施视频运行日志(此方法能自动分析日志类型)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> ProcessRunLogAsync(FacilityCameraRunLogDto dto)
        {
            dto.Status = true;
            if (DateTime.Now.Subtract(dto.UpdateTime).TotalMinutes > 10)
            {
                dto.Status = false;
            }
            return await AddRunLogAsny(dto);
        }
    }
}
