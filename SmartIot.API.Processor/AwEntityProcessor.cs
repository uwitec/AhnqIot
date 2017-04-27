#region Code File Comment

// SOLUTION   ： SmartIot - DeviceCode
// PROJECT    ： SmartIot.API.Processor
// FILENAME   ： AwEntityProcessor.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-01 19:51
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta;
using SmartIot.API.Processor.DataObject;
using System.Threading.Tasks;

#endregion

namespace SmartIot.API.Processor
{
    public class AwEntityProcessor
    {
        public static async Task<XResponseMessage> Process(AwEntity awEntity)
        {
            if (awEntity.Version == 2013)
            {
                //数据校验
                var authorize = ProcessValidation(awEntity.ValidationBlock);
                if (authorize)
                {
                    if (awEntity.DataBlockObject == null)
                    {
                        return ResultHelper.CreateMessage("数据块对象错误", ErrorType.NotSupportedProtocalType);
                    }
                    else
                    {
                        var dataContent = awEntity.DataBlockObject.DataContentRequest;
                        if (dataContent == null)
                        {
                            return ResultHelper.CreateMessage("数据内容错误", ErrorType.NotSupportedProtocalType);
                        }
                        else
                        {
                            #region 处理一般数据

                            var commonData = dataContent.CommonDataBlock;
                            if (commonData != null)
                            {
                                try
                                {
                                    var result = DataObjectProcessor.ProcessCommonData(commonData);
                                    //if (result != null && result.Success != ErrorType.NoError)
                                    //    return result;
                                    return result;
                                }
                                catch (Exception ex)
                                {
                                    ServiceLogger.Current.WriteException(ex);
                                    return ResultHelper.CreateExceptionMessage(ex);
                                }
                            }

                            #endregion

                            #region 处理采集数据

                            var collectData = dataContent.CollectDataBlock;
                            if (collectData != null)
                            {
                                try
                                {
                                    var result = DataObjectProcessor.ProcessCollectData(collectData);
                                    if (result != null && result.Success != ErrorType.NoError)
                                        return result;
                                }
                                catch (Exception ex)
                                {
                                    ServiceLogger.Current.WriteException(ex);
                                    return ResultHelper.CreateExceptionMessage(ex);
                                }
                            }

                            #endregion

                            #region 处理控制数据

                            var controlData = dataContent.ControlDataBlock;
                            if (controlData != null)
                            {
                                try
                                {
                                    var result = DataObjectProcessor.ProcessControlData(controlData);
                                    if (result != null && result.Success == ErrorType.NoError)
                                        return result;
                                }
                                catch (Exception ex)
                                {
                                    ServiceLogger.Current.WriteException(ex);
                                    return ResultHelper.CreateExceptionMessage(ex);
                                }
                            }

                            #endregion

                            #region 处理查询数据

                            var queryData = dataContent.QueryDataBlock;
                            if (queryData != null)
                            {
                                try
                                {
                                    var result = await DataObjectProcessor.ProcessQueryData(queryData);
                                    //if (result != null && result.Success != ErrorType.NoError)
                                    //    return result;
                                    return result;
                                }
                                catch (Exception ex)
                                {
                                    ServiceLogger.Current.WriteException(ex);
                                    return ResultHelper.CreateExceptionMessage(ex);
                                }
                            }

                            #endregion

                            #region 处理管理数据

                            var manageData = dataContent.ManageDataBlock;
                            if (manageData != null)
                            {
                                try
                                {
                                    var result =await DataObjectProcessor.ProcessManageData(manageData);
                                    //if (result != null && result.Success != ErrorType.NoError)
                                    //    return result;
                                    return result;
                                }
                                catch (Exception ex)
                                {
                                    ServiceLogger.Current.WriteException(ex);
                                    return ResultHelper.CreateExceptionMessage(ex);
                                }
                            }

                            #endregion

                            #region 处理运行数据

                            var runtimeData = dataContent.RuntimeDataBlock;
                            if (runtimeData != null)
                            {
                                try
                                {
                                    var result = DataObjectProcessor.ProcessRuntimeData(runtimeData);
                                    //if (result != null && result.Success != ErrorType.NoError)
                                    //    return result;
                                    return result;
                                }
                                catch (Exception ex)
                                {
                                    ServiceLogger.Current.WriteException(ex);
                                    return ResultHelper.CreateExceptionMessage(ex);
                                }
                            }

                            #endregion
                        }
                    }
                    return ResultHelper.CreateMessage("无需要处理数据", ErrorType.NoError);
                }
                else
                {
                    return ResultHelper.CreateMessage("权限验证失败", ErrorType.AuthorizeFailed);
                }
            }
            else
            {
                //协议版本错误
                return ResultHelper.CreateMessage("协议版本错误", ErrorType.VersionError);
            }
        }

        /// <summary>
        ///     数据验证处理
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool ProcessValidation(ValidationBlock v)
        {
            return true;
        }
    }
}