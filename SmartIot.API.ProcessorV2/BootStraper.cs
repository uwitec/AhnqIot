#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： BootStraper.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-26 11:08
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using AhnqIot.Infrastructure.DI;
using Autofac;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest;
using SmartIot.API.ProcessorV2.Core;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Collect;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Control;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Control.InnerProcess;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Manage;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Manage.InnerProcess;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Query;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Query.InnerProcess;

namespace SmartIot.API.ProcessorV2
{
    public class BootStraper
    {
        static BootStraper()
        {
            Init();
        }

        private static void Init()
        {
            AhnqIotContainer.Builder.RegisterType<AwApplication>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<SensorDataProcess>().AsSelf();

            AhnqIotContainer.Builder.RegisterType<ManageDataProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<FacilityAddProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<FacilityUpdateProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<DeviceAddProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<DeviceUpdateProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<MediaAddProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<MediaUpdateProcess>().AsSelf();

            AhnqIotContainer.Builder.RegisterType<QueryDataProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<FacilityTypeProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<DeviceTypeProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<QueryDevicesProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<QueryDeviceProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<QueryFacilitysProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<QueryFacilityProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<QueryMediaProcess>().AsSelf();

            AhnqIotContainer.Builder.RegisterType<ControlDataProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<ControlQueryProcess>().AsSelf();
            AhnqIotContainer.Builder.RegisterType<ControlResultProcess>().AsSelf();
        }

        public static void Start()
        {
        }
    }
}