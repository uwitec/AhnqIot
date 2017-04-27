#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.API
// FILENAME   ： IFacilityApi.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-30 19:48
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Api.Protocal.Meta;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ControlDataRequest;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest;
using SmartIot.Tool.API.Transport;
using System.Collections.Generic;
using SmartIot.Api.Protocal.Meta.Request.DataContent;
using SmartIot.Api.Protocal.Meta.Model;
using SmartIot.Tool.API.Core;

namespace SmartIot.Tool.API.Common
{
    public interface IFacilityApi
    {
        /// <summary>
        /// 获取设施下所有设备
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="facilitySerialnum">设施编码</param>
        /// <returns></returns>
        dynamic GetFacilityDevices(AwEntity entity, IApiTransport transport, string facilitySerialnum);

        /// <summary>
        /// 查询设施信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="facilityCode"></param>
        /// <returns></returns>
        XResponseMessage QueryFacility(AwEntity entity, IApiTransport transport, string facilityCode);

        /// <summary>
        /// 更新设施
        /// </summary>
        /// <param name="transport"></param>
        /// <param name="updates"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateFacility(AwEntity entity, IApiTransport transport, FacilityModel updates);

        /// <summary>
        /// 添加设施
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="addDatas"></param>
        /// <returns></returns>
        bool AddFacility(AwEntity entity, IApiTransport transport, FacilityModel addDatas);

        /// <summary>
        /// 获取控制指令
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="facilitySerialnum"></param>
        /// <returns></returns>
        IEnumerable<ControlCmd> GetControlCommand(AwEntity entity, IApiTransport transport, string facilitySerialnum);

        /// <summary>
        /// 上传控制结果
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        dynamic UploadControlResult(AwEntity entity, IApiTransport transport, ControlResult result);
    }
}