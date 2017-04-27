#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： ManageDataProcess.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-29 21:55
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System;
using System.Threading.Tasks;
using AhnqIot.Infrastructure.DI;
using Autofac;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Request.DataContent;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Manage.InnerProcess;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Manage
{
    public class ManageDataProcess
    {
        public ManageDataProcess()
        {
        }

        public async Task<XResponseMessage> ProcessAsync(ManageDataBlock manageDataBlock)
        {
            if (manageDataBlock == null) return null;

            if (manageDataBlock.FacilityAdd != null)
            {
                try
                {
                    return
                        await
                            AhnqIotContainer.Container.Resolve<FacilityAddProcess>()
                                .ProcessAsync(manageDataBlock.FacilityAdd);
                }
                catch (AggregateException ex)
                {
                    return ResultHelper.CreateExceptionMessage(ex, "添加设施失败", ErrorType.InternalError);
                }
            }

            if (manageDataBlock.FacilityUpdate != null)
            {
                try
                {
                    return
                        await
                            AhnqIotContainer.Container.Resolve<FacilityUpdateProcess>()
                                .ProcessAsync(manageDataBlock.FacilityUpdate);
                }
                catch (AggregateException ex)
                {
                    return ResultHelper.CreateExceptionMessage(ex, "更新设施失败", ErrorType.InternalError);
                }
            }
            if (manageDataBlock.DeviceAdd != null)
            {
                try
                {
                    return
                        await
                            AhnqIotContainer.Container.Resolve<DeviceAddProcess>()
                                .ProcessAsync(manageDataBlock.DeviceAdd);
                }
                catch (AggregateException ex)
                {
                    return ResultHelper.CreateExceptionMessage(ex, "添加设备失败", ErrorType.InternalError);
                }
            }

            if (manageDataBlock.DeviceUpdate != null)
            {
                try
                {
                    return
                        await
                            AhnqIotContainer.Container.Resolve<DeviceUpdateProcess>()
                                .ProcessAsync(manageDataBlock.DeviceUpdate);
                }
                catch (AggregateException ex)
                {
                    return ResultHelper.CreateExceptionMessage(ex, "更新设备失败", ErrorType.InternalError);
                }
            }
            if (manageDataBlock.MediaAdd != null)
            {
                try
                {
                    return
                        await
                            AhnqIotContainer.Container.Resolve<MediaAddProcess>().ProcessAsync(manageDataBlock.MediaAdd);
                }
                catch (AggregateException ex)
                {
                    return ResultHelper.CreateExceptionMessage(ex, "添加视频设备失败", ErrorType.InternalError);
                }
            }

            if (manageDataBlock.MediaUpdate != null)
            {
                try
                {
                    return
                        await
                            AhnqIotContainer.Container.Resolve<MediaUpdateProcess>()
                                .ProcessAsync(manageDataBlock.MediaUpdate);
                }
                catch (AggregateException ex)
                {
                    return ResultHelper.CreateExceptionMessage(ex, "更新视频设备失败", ErrorType.InternalError);
                }
            }

            //旧版本
            await
                AhnqIotContainer.Container.Resolve<FacilityAddProcess>().ProcessAsync(manageDataBlock.FacilityAddDatas);
            await
                AhnqIotContainer.Container.Resolve<FacilityUpdateProcess>()
                    .ProcessAsync(manageDataBlock.FacilityUpdateDatas);

            return null;
        }
    }
}