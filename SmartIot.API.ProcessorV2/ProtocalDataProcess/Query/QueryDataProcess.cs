#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： QueryDataProcess.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-03 16:18
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using SmartIot.Api.Protocal.Meta.Request.DataContent;
using SmartIot.API.ProcessorV2.Core;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Query.InnerProcess;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Query
{
    public class QueryDataProcess
    {
        public QueryDataProcess()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="md"></param>
        /// <param name="id">原始数据包ID</param>
        /// <returns></returns>
        public async Task<XResponseMessage> ProcessAsync(QueryDataBlock md)
        {
            if (md == null) return null;
            if (md.FacilityType) //查询设施类型
            {
                try
                {
                    var result = await AhnqIotContainer.Container.Resolve<FacilityTypeProcess>().ProcessAsync();
                    return ResultHelper.CreateMessage("查询设施类型", obj: result);
                }
                catch (AggregateException ex)
                {
                    ex.InnerExceptions.ToList().ForEach(e =>
                    {
                        LogHelper.Error("查询设施类型出错：{0}", e.Message);
                        LogHelper.Fatal(e.ToString());
                    });
                    return ResultHelper.CreateExceptionMessage(ex, ex.Message);
                }
            }
            if (md.FarmCode != null && !md.FarmCode.Farm.IsNullOrWhiteSpace()) //查询基地下设施
            {
                try
                {
                    var result =
                        await AhnqIotContainer.Container.Resolve<QueryFacilitysProcess>().ProcessAsync(md.FarmCode.Farm);
                    return ResultHelper.CreateMessage("查询基地下设施", obj: result);
                }
                catch (AggregateException ex)
                {
                    ex.InnerExceptions.ToList().ForEach(e =>
                    {
                        LogHelper.Error("查询设施类型出错：{0}", e.Message);
                        LogHelper.Fatal(e.ToString());
                    });
                    return ResultHelper.CreateExceptionMessage(ex, ex.Message);
                }
            }
            if (!md.FacilityCode.IsNullOrWhiteSpace()) //查询指定设施
            {
                try
                {
                    var result =
                        await AhnqIotContainer.Container.Resolve<QueryFacilityProcess>().ProcessAsync(md.FacilityCode);
                    return ResultHelper.CreateMessage("查询指定设施", obj: result);
                }
                catch (AggregateException ex)
                {
                    ex.InnerExceptions.ToList().ForEach(e =>
                    {
                        LogHelper.Error("查询指定设施出错：{0}", e.Message);
                        LogHelper.Fatal(e.ToString());
                    });
                    return ResultHelper.CreateExceptionMessage(ex, ex.Message);
                }
            }
            if (md.DeviceType) //查询设备类型
            {
                try
                {
                    var result = await AhnqIotContainer.Container.Resolve<DeviceTypeProcess>().ProcessAsync();
                    return ResultHelper.CreateMessage("查询指定设施", obj: result);
                }
                catch (AggregateException ex)
                {
                    ex.InnerExceptions.ToList().ForEach(e =>
                    {
                        LogHelper.Error("查询指定设施出错：{0}", e.Message);
                        LogHelper.Fatal(e.ToString());
                    });
                    return ResultHelper.CreateExceptionMessage(ex, ex.Message);
                }
            }
            if (md.Facility != null && !md.Facility.Facility.IsNullOrWhiteSpace()) //查询设施下的设备
            {
                try
                {
                    var result =
                        await
                            AhnqIotContainer.Container.Resolve<QueryDevicesProcess>().ProcessAsync(md.Facility.Facility);
                    return ResultHelper.CreateMessage("查询设施下的设备", obj: result);
                }
                catch (AggregateException ex)
                {
                    ex.InnerExceptions.ToList().ForEach(e =>
                    {
                        LogHelper.Error("查询设施下的设备出错：{0}", e.Message);
                        LogHelper.Fatal(e.ToString());
                    });
                    return ResultHelper.CreateExceptionMessage(ex, ex.Message);
                }
            }
            if (!md.DeviceCode.IsNullOrWhiteSpace()) //查询指定设备
            {
                try
                {
                    var result =
                        await AhnqIotContainer.Container.Resolve<QueryDeviceProcess>().ProcessAsync(md.DeviceCode);
                    return ResultHelper.CreateMessage("查询指定设备", obj: result);
                }
                catch (AggregateException ex)
                {
                    ex.InnerExceptions.ToList().ForEach(e =>
                    {
                        LogHelper.Error("查询指定设备出错：{0}", e.Message);
                        LogHelper.Fatal(e.ToString());
                    });
                    return ResultHelper.CreateExceptionMessage(ex, ex.Message);
                }
            }
            if (md.MediaCode.IsNullOrWhiteSpace()) return null;
            {
                try
                {
                    var result =
                        await AhnqIotContainer.Container.Resolve<QueryMediaProcess>().ProcessAsync(md.MediaCode);
                    return ResultHelper.CreateMessage("查询指定视频设备", obj: result);
                }
                catch (AggregateException ex)
                {
                    ex.InnerExceptions.ToList().ForEach(e =>
                    {
                        LogHelper.Error("查询指定视频设备出错：{0}", e.Message);
                        LogHelper.Fatal(e.ToString());
                    });
                    return ResultHelper.CreateExceptionMessage(ex, ex.Message);
                }
            }


            return null;
        }
    }
}