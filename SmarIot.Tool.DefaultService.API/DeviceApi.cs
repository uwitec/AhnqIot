using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta;
using SmartIot.Api.Protocal.Meta.Model;
using SmartIot.Api.Protocal.Meta.Request.DataContent;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest;
using SmartIot.Tool.API.Common;
using SmartIot.Tool.API.Core;
using SmartIot.Tool.API.Transport;
using NewLife.Log;
using NewLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using SmartIot.Api.Protocal.Formatter;

namespace SmartIot.Tool.DefaultService.API
{
    public class DeviceApi : ApiBase, IDeviceApi
    {
        /// <summary>
        /// 获取所有设备类型
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <returns></returns>
        public IEnumerable<DeviceTypeModel> GetDeviceTypes(AwEntity entity, IApiTransport transport)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            Guard(entity);

            entity.Description = "获取所有设施类型";
            entity.DataBlockObject.DataContentRequest.QueryDataBlock = new QueryDataBlock()
            {
                DeviceType = true
            };

            var response = transport.Process(entity);
            if (response.Success != ErrorType.NoError) return new List<DeviceTypeModel>();
            if (response.Data == null || response.Data.QueryDeviceType == null) return new List<DeviceTypeModel>();
            try
            {
                string str = response.Data.QueryDeviceType.ToString();
                var ie =
                    ObjectContainer.Current.Resolve<FormatterBase>(DataProtocalType.Json.ToString())
                        .Deserialize<IEnumerable<DeviceTypeModel>>(str);
                return ie;
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }
            return new List<DeviceTypeModel>();
        }

        /// <summary>
        /// 查询设备（采集、控制）信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="deviceCode"></param>
        /// <returns></returns>
        public XResponseMessage QueryDevice(AwEntity entity, IApiTransport transport, string deviceCode)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (deviceCode == null) throw new ArgumentNullException(nameof(deviceCode));
            Guard(entity);

            entity.Description = "查询设备信息";
            entity.DataBlockObject.DataContentRequest.QueryDataBlock = new QueryDataBlock()
            {
                DeviceCode = deviceCode
            };

            var response = transport.Process(entity);
            return response;
        }

        //public bool UploadDeviceData(AwEntity entity, IApiTransport transport, List<DeviceModel> devices)
        //{
        //    if (transport == null) throw new ArgumentNullException("transport");
        //    Guard(entity);
        //    if (devices == null || !devices.Any()) return false;

        //    entity.Description = "上传设备数据";
        //    var sds = devices.Select(dev => new SensorData
        //    {
        //        //FacilityCode = dev.FacilitySerialnum,
        //        DeviceCode = dev.Serialnum,
        //        //DeviceType = dev.DeviceTypeSerialnum,
        //        Value = dev.ProcessedValue,
        //        ShowValue = dev.ShowValue,
        //        //Unit = dev.Unit,
        //        Time = dev.UpdateTime
        //    });
        //    entity.DataBlockObject.DataContentRequest.CollectDataBlock = new CollectDataBlock
        //    {
        //        SensorDatas = sds.ToList()
        //    };

        //    var response = transport.Process(entity);
        //    return response.Success == ErrorType.NoError;
        //}

        /// <summary>
        /// 上传采集、控制、摄像机设备数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="collectData"></param>
        /// <returns></returns>
        public bool UploadDeviceData(AwEntity entity, IApiTransport transport, CollectDataBlock collectData)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (collectData == null) throw new ArgumentNullException(nameof(collectData));
            Guard(entity);

            entity.Description = "上传设备数据";
            entity.DataBlockObject.DataContentRequest.CollectDataBlock = new CollectDataBlock()
            {
                SensorDatas = collectData.SensorDatas,
                MediaDatas = collectData.MediaDatas
            };
            var response = transport.Process(entity);
            return response.Success == ErrorType.NoError;
        }

        /// <summary>
        /// 更新设备（采集、控制）信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="updateDevice"></param>
        /// <returns></returns>
        public bool UpdateDevice(AwEntity entity, IApiTransport transport, DeviceModel updateDevice)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (updateDevice == null) throw new ArgumentNullException(nameof(updateDevice));
            Guard(entity);

            entity.Description = "更新设备信息";
            entity.DataBlockObject.DataContentRequest.ManageDataBlock = new ManageDataBlock()
            {
                DeviceUpdate = updateDevice
            };

            var response = transport.Process(entity);
            return response.Success == ErrorType.NoError;
        }

        /// <summary>
        /// 添加设备（采集、控制）信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="addDevice"></param>
        /// <returns></returns>
        public bool AddDevice(AwEntity entity, IApiTransport transport, DeviceModel addDevice)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (addDevice == null) throw new ArgumentNullException(nameof(addDevice));
            Guard(entity);

            entity.Description = "添加设备信息";
            entity.DataBlockObject.DataContentRequest.ManageDataBlock = new ManageDataBlock()
            {
                DeviceAdd = addDevice
            };

            var response = transport.Process(entity);
            return response.Success == ErrorType.NoError;
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <returns></returns>
        public bool DeleteDevice(AwEntity entity, IApiTransport transport)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            Guard(entity);

            throw new NotImplementedException("DeleteDevice");
        }

        /// <summary>
        /// 更新设备（多媒体设备）信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="updateDevice"></param>
        /// <returns></returns>
        public bool UpdateMedia(AwEntity entity, IApiTransport transport, MediaData updateDevice)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (updateDevice == null) throw new ArgumentNullException(nameof(updateDevice));
            Guard(entity);

            entity.Description = "更新多媒体设备信息";
            entity.DataBlockObject.DataContentRequest.ManageDataBlock = new ManageDataBlock()
            {
                MediaUpdate = updateDevice
            };

            var response = transport.Process(entity);
            return response.Success == ErrorType.NoError;
        }

        /// <summary>
        /// 添加设备（多媒体设备）信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="addDevice"></param>
        /// <returns></returns>
        public bool AddMedia(AwEntity entity, IApiTransport transport, MediaData addDevice)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (addDevice == null) throw new ArgumentNullException(nameof(addDevice));
            Guard(entity);

            entity.Description = "添加多媒体设备信息";
            entity.DataBlockObject.DataContentRequest.ManageDataBlock = new ManageDataBlock()
            {
                MediaAdd = addDevice
            };

            var response = transport.Process(entity);
            return response.Success == ErrorType.NoError;
        }

        /// <summary>
        /// 查询视频设备信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <param name="mediaCode"></param>
        /// <returns></returns>
        public XResponseMessage QueryMedia(AwEntity entity, IApiTransport transport, string mediaCode)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (mediaCode == null) throw new ArgumentNullException(nameof(mediaCode));
            Guard(entity);

            entity.Description = "查询视频设备信息";
            entity.DataBlockObject.DataContentRequest.QueryDataBlock = new QueryDataBlock()
            {
                MediaCode = mediaCode
            };

            var response = transport.Process(entity);
            return response;
        }
    }
}