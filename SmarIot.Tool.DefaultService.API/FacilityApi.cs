#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ：SmartIot.Tool.API
// FILENAME   ： ITypes.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-30 19:11
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta;
using SmartIot.Api.Protocal.Meta.Request.DataContent;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ControlDataRequest;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest;
using SmartIot.Api.Protocal.Meta.Request.DataContent.QueryDataRequest;
using SmartIot.Tool.API.Common;
using SmartIot.Tool.API.Core;
using SmartIot.Tool.API.Transport;
using NewLife.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SmartIot.Api.Protocal.Formatter;
using SmartIot.Api.Protocal.Meta.Model;

namespace SmartIot.Tool.DefaultService.API
{
    public class FacilityApi : ApiBase, IFacilityApi
    {
        /// <summary>
        /// 获取所有设施类型
        /// </summary>
        /// <param name="entity"></param>
        /// 
        /// <param name="transport"></param>
        /// <returns></returns>
        /// <summary>
        /// 获取设施下所有设备
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="facilitySerialnum"></param>
        /// <returns></returns>
        public dynamic GetFacilityDevices(AwEntity entity, IApiTransport transport, string facilitySerialnum)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (facilitySerialnum.IsNullOrWhiteSpace()) throw new ArgumentNullException(nameof(facilitySerialnum));
            Guard(entity);

            entity.Description = "获取设施下所有设备";
            entity.DataBlockObject.DataContentRequest.QueryDataBlock = new QueryDataBlock()
            {
                Facility = new QueryFacilityDevices() {Facility = facilitySerialnum}
            };
            var sw = new Stopwatch();
            sw.Start();
            var response = transport.Process(entity);
            sw.Stop();
            var time = sw.ElapsedMilliseconds;
            if (response.Success != ErrorType.NoError) return null;
            if (response.Data != null && response.Data.QueryFacilityDevices != null)
                return response.Data.QueryFacilityDevices;
            return null;
        }

        /// <summary>
        /// 查询设施信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="facilityCode"></param>
        /// <returns></returns>
        public XResponseMessage QueryFacility(AwEntity entity, IApiTransport transport, string facilityCode)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (facilityCode == null) throw new ArgumentNullException(nameof(facilityCode));
            Guard(entity);

            entity.Description = "查询设施信息";
            entity.DataBlockObject.DataContentRequest.QueryDataBlock = new QueryDataBlock()
            {
                FacilityCode = facilityCode
            };

            var response = transport.Process(entity);
            return response;
        }

        /// <summary>
        /// 更新设施信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="updates"></param>
        /// <returns></returns>
        public bool UpdateFacility(AwEntity entity, IApiTransport transport, FacilityModel updates)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (updates == null) throw new ArgumentNullException(nameof(updates));
            Guard(entity);

            entity.Description = "更新设施信息";
            entity.DataBlockObject.DataContentRequest.ManageDataBlock = new ManageDataBlock()
            {
                FacilityUpdate = updates
            };

            var response = transport.Process(entity);
            return response.Success == ErrorType.NoError;
        }

        /// <summary>
        /// 添加设施信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="addData"></param>
        /// <returns></returns>
        public bool AddFacility(AwEntity entity, IApiTransport transport, FacilityModel addData)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (addData == null) throw new ArgumentNullException(nameof(addData));
            Guard(entity);
            entity.Description = "添加设施信息";
            entity.DataBlockObject.DataContentRequest.ManageDataBlock = new ManageDataBlock()
            {
                FacilityAdd = addData
            };

            var response = transport.Process(entity);
            return response.Success == ErrorType.NoError;
        }


        /// <summary>
        /// 获取控制指令
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="facilitySerialnum"></param>
        /// <returns></returns>
        public IEnumerable<ControlCmd> GetControlCommand(AwEntity entity, IApiTransport transport,
            string facilitySerialnum)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (facilitySerialnum.IsNullOrWhiteSpace()) throw new ArgumentNullException(nameof(facilitySerialnum));
            Guard(entity);

            entity.Description = "获取控制设备指令";
            entity.DataBlockObject.DataContentRequest.ControlDataBlock = new ControlDataBlock()
            {
                ControlQueries = new[]
                {
                    new ControlQuery()
                    {
                        FacilityCode = facilitySerialnum,
                        Time = DateTime.Now
                    }
                }.ToList()
            };
            ; //使用ControlData基础数据块

            var response = transport.Process(entity);
            if (response.Success == ErrorType.NoError && response.Data != null)
            {
                string str = response.Data.ToString();
                var cmd =
                    ObjectContainer.Current.Resolve<FormatterBase>(DataProtocalType.Json.ToString())
                        .Deserialize<IEnumerable<ControlCmd>>(str);
                return cmd;
            }
            else
            {
                return Enumerable.Empty<ControlCmd>();
            }
        }

        /// <summary>
        /// 上传控制指令
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="facilitySerialnum"></param>
        /// <returns></returns>
        public dynamic UploadControlResult(AwEntity entity, IApiTransport transport, ControlResult controlResult)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            //if (controlResult.FacilityCode.IsNullOrWhiteSpace()) throw new ArgumentNullException("facilitySerialnum");
            Guard(entity);

            entity.Description = "上传控制指令";
            entity.DataBlockObject.DataContentRequest.ControlDataBlock = new ControlDataBlock()
            {
                ControlResults = new[]
                {
                    new ControlResult()
                    {
                        Serialnum = controlResult.Serialnum,
                        Result = controlResult.Result,
                        Time = controlResult.Time
                    }
                }.ToList()
            };

            var response = transport.Process(entity);
            //if (response.Success == ErrorType.NoError)
            //{
            //    if (response.Data != null && response.Data != null)
            //        return response.Data;
            //}
            //return null;

            return response.Success == ErrorType.NoError;
        }
    }
}