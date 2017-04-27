#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.API
// FILENAME   ： IFarmApi.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-30 19:47
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Api.Protocal.Meta;
using SmartIot.Api.Protocal.Meta.Model;
using SmartIot.Api.Protocal.Meta.Request.DataContent.RuntimeDataRequest;
using SmartIot.Tool.API.Transport;
using System.Collections.Generic;

namespace SmartIot.Tool.API.Common
{
    public interface IFarmApi
    {
        /// <summary>
        /// 获取基地所有设施
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <returns></returns>
        IEnumerable<FacilityModel> GetFacilities(AwEntity entity, IApiTransport transport);

        bool UploadFarmStatus(AwEntity entity, IApiTransport transport, FarmStatus fs);
    }
}