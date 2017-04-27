using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Hxj.Repository.AhnqIot;
using AutoMapper;
namespace AhnqIot.Bussiness
{
    public class AgrDiagnosticInfoService : ServiceBase<AgrDiagnosticInfo, AgrDiagnosticInfoDto>, IAgrDiagnosticInfoService
    {
        //private readonly IAhnqIotRepository<AgrDiagnosticInfo> _agrDiagnosticInfoRep;

        public AgrDiagnosticInfoService(IAhnqIotRepository<AgrDiagnosticInfo> agrDiagnosticInfoRep)
        {
            //_agrDiagnosticInfoRep = agrDiagnosticInfoRep;
        }
        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <param name="dto">诊断信息实体</param>
        /// <returns></returns>
        public async Task<bool> AddAgrDiagnosticInfoAsny(AgrDiagnosticInfoDto dto)
        {
            var agrDiagnosticInfo =GetDbModel(dto);
            Repository.Add(agrDiagnosticInfo);
            return await Repository.CommitAsync() > 0;
        }
    }
}
