using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
 public   interface IAgrDiagnosticInfoService: IService<AgrDiagnosticInfoDto>
    {
        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <param name="dto">诊断信息实体</param>
        /// <returns></returns>
        Task<bool> AddAgrDiagnosticInfoAsny(AgrDiagnosticInfoDto dto);
    }
}
