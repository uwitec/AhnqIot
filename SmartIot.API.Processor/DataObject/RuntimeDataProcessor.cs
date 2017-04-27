#region Code File Comment

// SOLUTION   ： SmartIot - DeviceCode
// PROJECT    ： SmartIot.API.Processor
// FILENAME   ： RuntimeDataProcessor.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-28 23:08
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using SmartIot.Api.Protocal.Meta.Request.DataContent.RuntimeDataRequest;
using SmartIot.API.Processor.DataObject.CoreProcessor;

#endregion

namespace SmartIot.API.Processor.DataObject
{
    public class RuntimeDataProcessor
    {
        /// <summary>
        ///     处理示范点状态上传数据
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static XResponseMessage ProcessUploadFarmStatus(FarmStatus status)
        {
            if (status == null) throw new ArgumentNullException("status");

            return FarmStatusProcessor.Process(status);
        }
    }
}