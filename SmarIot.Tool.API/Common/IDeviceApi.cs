#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.API
// FILENAME   ： IFacilityApi.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-30 19:48
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Api.Protocal.Meta;
using SmartIot.Api.Protocal.Meta.Model;
using SmartIot.Api.Protocal.Meta.Request.DataContent;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;
using SmartIot.Tool.API.Core;
using SmartIot.Tool.API.Transport;
using System.Collections.Generic;

namespace SmartIot.Tool.API.Common
{
    public interface IDeviceApi
    {
        /// <summary>
        /// 获取所有设备类型
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <returns></returns>
        IEnumerable<DeviceTypeModel> GetDeviceTypes(AwEntity entity, IApiTransport transport);

        /// <summary>
        /// 查询设备（采集、控制）信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="deviceCode"></param>
        /// <returns></returns>
        XResponseMessage QueryDevice(AwEntity entity, IApiTransport transport, string deviceCode);

        ///// <summary>
        ///// 更新设备（采集、控制、音视频设备）信息
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <param name="transport"></param>
        ///// <param name="devices"></param>
        ///// <param name="cameras"></param>
        ///// <returns></returns>
        //bool UpdateDevice(AwEntity entity, IApiTransport transport, List<DeviceModel> devices, List<MediaData> cameras);

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <returns></returns>
        bool DeleteDevice(AwEntity entity, IApiTransport transport);

        /// <summary>
        /// 更新设备（采集、控制、音视频设备）信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="updateDevice"></param>
        /// <returns></returns>
        bool UpdateDevice(AwEntity entity, IApiTransport transport, DeviceModel updateDevice);

        /// <summary>
        /// 添加设备（采集、控制）信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="addDevice"></param>
        /// <returns></returns>
        bool AddDevice(AwEntity entity, IApiTransport transport, DeviceModel addDevice);

        /// <summary>
        /// 更新设备（多媒体设备）信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="updateDevice"></param>
        /// <returns></returns>
        bool UpdateMedia(AwEntity entity, IApiTransport transport, MediaData updateDevice);

        /// <summary>
        /// 添加设备（多媒体设备）信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="addDevice"></param>
        /// <returns></returns>
        bool AddMedia(AwEntity entity, IApiTransport transport, MediaData addDevice);

        /// <summary>
        /// 上传采集、控制、摄像机设备数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="collectData"></param>
        /// <returns></returns>
        bool UploadDeviceData(AwEntity entity, IApiTransport transport, CollectDataBlock collectData);

        /// <summary>
        /// 查询视频设备信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="mediaCode"></param>
        /// <returns></returns>
        XResponseMessage QueryMedia(AwEntity entity, IApiTransport transport, string mediaCode);
    }
}