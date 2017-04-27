using SmartIot.Api.Protocal.Meta;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest;
using SmartIot.Tool.API.Transport;
using System.Collections.Generic;
using SmartIot.Api.Protocal.Meta.Request.DataContent;

namespace SmartIot.Tool.API.Control
{
    public interface IControlAPI
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
        /// 更新设施
        /// </summary>
        /// <param name="transport"></param>
        /// <param name="updates"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateFacility(AwEntity entity, IApiTransport transport, List<FacilityUpdateData> updates);

        /// <summary>
        /// 添加设施信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="addDatas"></param>
        /// <returns></returns>
        bool AddFacility(AwEntity entity, IApiTransport transport, List<FacilityAddData> addDatas);

        /// <summary>
        /// 上传采集、控制、摄像机设备数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="collectData"></param>
        /// <returns></returns>
        bool UploadDeviceData(AwEntity entity, IApiTransport transport, CollectDataBlock collectData);
    }
}