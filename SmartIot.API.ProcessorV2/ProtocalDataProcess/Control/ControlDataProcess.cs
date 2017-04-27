using AhnqIot.Infrastructure.DI;
using Autofac;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Request.DataContent;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Control.InnerProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Control
{
    public class ControlDataProcess
    {
        public ControlDataProcess()
        {
        }

        public async Task<XResponseMessage> ProcessAsync(ControlDataBlock controlDataBlock)
        {
            if (controlDataBlock == null) return null;

            if (controlDataBlock.ControlQueries != null)
            {
                try
                {
                    var result =
                        await
                            AhnqIotContainer.Container.Resolve<ControlQueryProcess>()
                                .ProcessAsync(controlDataBlock.ControlQueries);
                    return ResultHelper.CreateMessage("查询控制指令", obj: result);
                }
                catch (AggregateException ex)
                {
                    return ResultHelper.CreateExceptionMessage(ex, "查询控制指令失败", ErrorType.InternalError);
                }
            }
            if (controlDataBlock.ControlResults == null) return null;
            {
                try
                {
                    var result =
                        await
                            AhnqIotContainer.Container.Resolve<ControlResultProcess>()
                                .ProcessAsync(controlDataBlock.ControlResults);
                    return ResultHelper.CreateMessage("上传控制指令", obj: result);
                }
                catch (AggregateException ex)
                {
                    return ResultHelper.CreateExceptionMessage(ex, "上传控制指令失败", ErrorType.InternalError);
                }
            }
        }
    }
}