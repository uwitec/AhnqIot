#region Code File Comment

// SOLUTION   ： SmartIot - DeviceCode
// PROJECT    ： SmartIot.API.Processor
// FILENAME   ： DataObjectProcessor.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-01 22:25
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Request.DataContent;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

#endregion using namespace

namespace SmartIot.API.Processor.DataObject
{
    public class DataObjectProcessor
    {
        /// <summary>
        /// 处理采集数据块
        /// </summary>
        /// <param name="collectDataBlock"></param>
        public static XResponseMessage ProcessCollectData(CollectDataBlock collectDataBlock)
        {
            if (collectDataBlock == null) throw new ArgumentNullException("collectDataBlock");

            if (collectDataBlock.SensorDatas != null && collectDataBlock.SensorDatas.Any())
            {
                var result = CollectDataProcessor.ProcessSensorData(collectDataBlock.SensorDatas);
                if (result != null && result.Success != ErrorType.NoError)
                    return result;
            }
            if (collectDataBlock.MediaDatas != null && collectDataBlock.MediaDatas.Any())
            {
                var result = CollectDataProcessor.ProcessMediaData(collectDataBlock.MediaDatas);
                if (result != null && result.Success != ErrorType.NoError)
                    return result;
            }
            if (collectDataBlock.PictureDatas != null && collectDataBlock.PictureDatas.Any())
            {
                var result = CollectDataProcessor.ProcessPictureData(collectDataBlock.PictureDatas);
                if (result != null && result.Success != ErrorType.NoError)
                    return result;
            }
            //return null;
            return ResultHelper.CreateMessage("", ErrorType.NoError);
        }

        /// <summary>
        ///     处理控制数据块
        /// </summary>
        /// <param name="controlDataBlock"></param>
        public static XResponseMessage ProcessControlData(ControlDataBlock controlDataBlock)
        {
            if (controlDataBlock == null) throw new ArgumentNullException("controlDataBlock");
            //todo 此处处理设备控制指令有重复，需要再仔细考虑
            if (controlDataBlock.ControlCmds != null && controlDataBlock.ControlCmds.Any())
            {
                var result = ControlDataProcessor.ProcessControlQueries(controlDataBlock.ControlQueries);
                if (result != null && result.Success != ErrorType.NoError)
                    return result;
            }
            if (controlDataBlock.ControlQueries != null && controlDataBlock.ControlQueries.Any())
            {
                var result = ControlDataProcessor.ProcessControlQueries(controlDataBlock.ControlQueries);
                if (result != null && result.Success == ErrorType.NoError)
                    return result;
            }
            if (controlDataBlock.ControlResults != null && controlDataBlock.ControlResults.Any())
            {
                var result = ControlDataProcessor.ProcessControlResults(controlDataBlock.ControlResults);
                if (result != null && result.Success == ErrorType.NoError)
                    return result;
            }
            //return null;
            return ResultHelper.CreateMessage("", ErrorType.NoError);
        }

        /// <summary>
        ///     处理普通数据
        /// </summary>
        /// <param name="commonDataBlock"></param>
        public static XResponseMessage ProcessCommonData(CommonDataBlock commonDataBlock)
        {
            if (commonDataBlock == null) throw new ArgumentNullException("commonDataBlock");

            dynamic data = new ExpandoObject();
            var message = "";

            var result2 = new XResponseMessage()
            {
                Success = ErrorType.NoError,
                Message = message,
                Data = data,
            };
            return result2;
        }

        /// <summary>
        ///     处理查询数据
        /// </summary>
        /// <param name="queryDataBlock"></param>
        public static async Task<XResponseMessage> ProcessQueryData(QueryDataBlock queryDataBlock)
        {
            if (queryDataBlock == null) throw new ArgumentNullException("queryDataBlock");

            dynamic data = new ExpandoObject();
            var message = "";
            XResponseMessage xResponseMessage = new XResponseMessage { Message = message, Success = ErrorType.NoContent, IsTrue = false, Data = data };

            //获取设施类型
            xResponseMessage = (XResponseMessage)await ProcessQueryFacilityType(queryDataBlock, data);
            if (xResponseMessage.IsTrue)
            {
                message = xResponseMessage.Message;
                return xResponseMessage;
            }

            //获取设备类型
            xResponseMessage = (XResponseMessage)await ProcessQueryDeviceType(queryDataBlock, data);
            if (xResponseMessage.IsTrue)
            {
                message = xResponseMessage.Message;
                return xResponseMessage;
            }

            //查询基地下所有设施
            xResponseMessage = (XResponseMessage)await ProcessQueryFacilitys(queryDataBlock, data);
            if (xResponseMessage.IsTrue)
            {
                message = xResponseMessage.Message;
                return xResponseMessage;
            }

            //获取设施下所有设备，包含采集设备、控制设备、音视频设备
            xResponseMessage = (XResponseMessage)await ProcessQueryFacilityDevices(queryDataBlock, data);
            if (xResponseMessage.IsTrue)
            {
                message = xResponseMessage.Message;
                return xResponseMessage;
            }

            var result2 = new XResponseMessage()
            {
                Success = ErrorType.NoError,
                Message = message,
                Data = data,
            };
            return result2;
        }

        /// <summary>
        ///     处理管理数据
        /// </summary>
        /// <param name="manageDataBlock"></param>
        public static async Task<XResponseMessage> ProcessManageData(ManageDataBlock manageDataBlock)
        {
            if (manageDataBlock == null) throw new ArgumentNullException("manageDataBlock");

            dynamic data = new ExpandoObject();
            var message = "";
            XResponseMessage xResponseMessage = new XResponseMessage { IsTrue = false, Success = ErrorType.NoContent, Data = data, Message = message };

            //添加设施、（传感器、音视频）设备
            xResponseMessage = (XResponseMessage)await ProcessFacilityAddDatas(manageDataBlock, data);
            if (xResponseMessage.IsTrue)
            {
                message = xResponseMessage.Message;
                return xResponseMessage;
            }

            //更新设施数据
            xResponseMessage = (XResponseMessage)await ProcessFacilityUpdateDatas(manageDataBlock, data);
            if (xResponseMessage.IsTrue)
            {
                message = xResponseMessage.Message;
                return xResponseMessage;
            }
            //更新设备（采集、控制设备，音视频设备）数据
            xResponseMessage = (XResponseMessage)await ProcessDeviceUpdateData(manageDataBlock, data);
            if (xResponseMessage.IsTrue)
            {
                message = xResponseMessage.Message;
                return xResponseMessage;
            }

            var result2 = new XResponseMessage()
            {
                Success = ErrorType.NoError,
                Message = message,
                Data = data,
            };
            return result2;
        }

        /// <summary>
        ///     处理运行数据
        /// </summary>
        /// <param name="runtimeDataBlock"></param>
        public static XResponseMessage ProcessRuntimeData(RuntimeDataBlock runtimeDataBlock)
        {
            if (runtimeDataBlock == null) throw new ArgumentNullException("runtimeDataBlock");

            dynamic data = new ExpandoObject();
            var message = "";
            XResponseMessage xResponseMessage;
            //上传示范点状态
            if (ProcessUploadFarmStatus(runtimeDataBlock, data, ref message, out xResponseMessage)) return xResponseMessage;
            var result2 = new XResponseMessage()
            {
                Success = ErrorType.NoError,
                Message = message,
                Data = data,
            };
            return result2;
        }

        #region RuntimeDataBlock

        /// <summary>
        /// 处理上传基地状态
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="xResponseMessage"></param>
        /// <returns></returns>
        private static bool ProcessUploadFarmStatus(RuntimeDataBlock cd, dynamic data, ref string message,
            out XResponseMessage xResponseMessage)
        {
            if (cd.UploadFarmStatus != null)
            {
                var result = RuntimeDataProcessor.ProcessUploadFarmStatus(cd.UploadFarmStatus);
                if (result != null && result.Success != ErrorType.NoError)
                {
                    xResponseMessage = result;
                    return true;
                }

                if (result != null)
                {
                    if (!result.Message.IsNullOrWhiteSpace())
                        message += result.Message + " ";
                    if (result.Data != null)
                    {
                        data.UploadFarmStatus = result.Data;
                    }
                }
            }
            xResponseMessage = null;
            return false;
        }

        #endregion RuntimeDataBlock

        #region ManageDataBlock

        /// <summary>
        /// 处理设备数据更新
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static async Task<XResponseMessage> ProcessDeviceUpdateData(ManageDataBlock cd, dynamic data)
        {
            XResponseMessage xResponseMessage = new XResponseMessage();
            if (cd.DeviceUpdateData != null)
            {
                var result = await ManageDataProcessor.ProcessDeviceUpdate(cd.DeviceUpdateData);
                if (result != null && result.Success != ErrorType.NoError)
                {
                    xResponseMessage = result;
                    xResponseMessage.IsTrue = true;
                }

                if (result != null)
                {
                    if (!result.Message.IsNullOrWhiteSpace())
                        xResponseMessage.Message += result.Message + " ";
                    if (result.Data != null)
                    {
                        data.DeviceUpdateData = result.Data;
                    }
                }
            }
            xResponseMessage.IsTrue = false;
            return xResponseMessage;
        }

        /// <summary>
        /// 处理设施更新数据
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static async Task<XResponseMessage> ProcessFacilityUpdateDatas(ManageDataBlock cd, dynamic data)
        {
            XResponseMessage xResponseMessage = new XResponseMessage();
            if (cd.FacilityUpdateDatas != null)
            {
                var result = await ManageDataProcessor.ProcessFacilityUpdate(cd.FacilityUpdateDatas);
                if (result != null && result.Success != ErrorType.NoError)
                {
                    xResponseMessage = result;
                    xResponseMessage.IsTrue = true;
                }

                if (result != null)
                {
                    if (!result.Message.IsNullOrWhiteSpace())
                        xResponseMessage.Message += result.Message + " ";
                    if (result.Data != null)
                    {
                        data.FacilityUpdateDatas = result.Data;
                    }
                }
            }
            xResponseMessage.IsTrue = false;
            return xResponseMessage;
        }

        /// <summary>
        /// 处理设施添加数据
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="xResponseMessage"></param>
        /// <returns></returns>
        private static async Task<XResponseMessage> ProcessFacilityAddDatas(ManageDataBlock cd, dynamic data)

        {
            XResponseMessage xResponseMessage = new XResponseMessage();
            if (cd.FacilityAddDatas != null && cd.FacilityAddDatas.Any())
            {
                var result = await ManageDataProcessor.ProcessFacilityAddData(cd.FacilityAddDatas);
                if (result != null && result.Success != ErrorType.NoError)
                {
                    xResponseMessage = result;
                    xResponseMessage.IsTrue = true;
                }

                if (result != null)
                {
                    if (!result.Message.IsNullOrWhiteSpace())
                        xResponseMessage.Message += result.Message + " ";
                    if (result.Data != null)
                    {
                        data.FacilityAddDatas = result.Data;
                    }
                }
            }
            xResponseMessage.IsTrue = false;
            return xResponseMessage;
        }

        #endregion ManageDataBlock

        #region QueryDataBlock

        /// <summary>
        /// 处理设施设备查询
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="xResponseMessage"></param>
        /// <returns></returns>
        private static async Task<XResponseMessage> ProcessQueryFacilityDevices(QueryDataBlock cd, dynamic data)
        {
            XResponseMessage xResponseMessage = null;
            if (cd.Facility != null)
            {
                var facility = cd.Facility.Facility;

                var result = await QueryDataProcessor.ProcessGetFacilityDevices(facility);
                if (result != null && result.Success != ErrorType.NoError)
                {
                    xResponseMessage = result;
                    xResponseMessage.IsTrue = true;
                }

                if (result != null)
                {
                    if (!result.Message.IsNullOrWhiteSpace())
                        xResponseMessage.Message += result.Message + " ";
                    if (result.Data != null)
                    {
                        data.QueryFacilityDevices = result.Data;
                    }
                }
            }
            xResponseMessage.IsTrue = false;
            return xResponseMessage;
        }

        private static async Task<XResponseMessage> ProcessQueryFacilitys(QueryDataBlock cd, dynamic data)
        {
            XResponseMessage xResponseMessage = null;
            if (cd.FarmCode != null)
            {
                var farm = cd.FarmCode.Farm;

                var result = await QueryDataProcessor.ProcessGetFacilities(farm);
                if (result != null && result.Success != ErrorType.NoError)
                {
                    xResponseMessage = result;
                    xResponseMessage.IsTrue = true;
                }

                if (result != null)
                {
                    if (!result.Message.IsNullOrWhiteSpace())
                        xResponseMessage.Message += result.Message + " ";
                    if (result.Data != null)
                    {
                        data.QueryFacilitys = result.Data;
                    }
                }
            }
            xResponseMessage.IsTrue = false;
            return xResponseMessage;
        }

        private static async Task<XResponseMessage> ProcessQueryDeviceType(QueryDataBlock cd, dynamic data)
        {
            XResponseMessage xResponseMessage = null;
            if (cd.DeviceType)
            {
                var result = await QueryDataProcessor.ProcessDeviceTypeGet();
                if (result != null && result.Success != ErrorType.NoError)
                {
                    xResponseMessage = result;
                    xResponseMessage.IsTrue = true;
                }

                if (result != null)
                {
                    if (!result.Message.IsNullOrWhiteSpace())
                        xResponseMessage.Message += result.Message + " ";
                    if (result.Data != null)
                    {
                        data.QueryDeviceType = result.Data;
                    }
                }
            }
            xResponseMessage.IsTrue = false;
            return xResponseMessage;
        }

        private static async Task<XResponseMessage> ProcessQueryFacilityType(QueryDataBlock queryDataBlock, dynamic data)
        {
            XResponseMessage xResponseMessage = null;
            if (queryDataBlock.FacilityType)
            {
                var result = await QueryDataProcessor.ProcessFacilityTypeGet();
                if (result != null && result.Success != ErrorType.NoError)
                {
                    xResponseMessage = result;
                    xResponseMessage.IsTrue = true;
                }

                if (result != null)
                {
                    if (!result.Message.IsNullOrWhiteSpace())
                        xResponseMessage.Message += result.Message + " ";
                    if (result.Data != null)
                    {
                        data.QueryFacilityType = result.Data;
                    }
                }
            }
            xResponseMessage.IsTrue = false;
            return xResponseMessage;
        }

        #endregion QueryDataBlock
    }
}