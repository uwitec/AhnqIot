#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： ISysAreaService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-14 0:46
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Threading.Tasks;
using AhnqIot.Dto;
using System.Collections;
using System.Collections.Generic;
using AhnqIot.Bussiness.Core;

#endregion

namespace AhnqIot.Bussiness.Interface
{
    public interface ISysAreaService : IService<SysAreaDto>
    {
    }
}