#region Code File Comment
// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： Init.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-13 16:48
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Hxj.Repository;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using AutoMapper;
using NewLife.Configuration;
using NewLife.Reflection;

namespace AhnqIot.Bussiness.Core
{
    public class BussinessBootStraper
    {
        static BussinessBootStraper()
        {
        }

        /// <summary>
        /// 业务逻辑层启动初始化工作
        /// </summary>
        public static void Start()
        {
            RepositoryBootStraper.Start();

            //注册本类库的类型
            RegisterTypes();
            //初始化数据库数据

            //创建dbmodel和dto的映射
            CreateObjectMapper();
        }

        //注册所有继承IService<>的类型到对象容器中去
        public static void RegisterTypes()
        {
            var allTypes = Assembly.GetCallingAssembly().GetTypes();
            var type = typeof(IService<>);
            allTypes.Where(t => !t.IsGenericType && t.IsClass).ToList().ForEach(t =>
              {
                  var ins = t.GetInterfaces();
                  if (ins.Any(i => i.Name.Equals(type.Name)))
                  {
                      var tfrom = ins.FirstOrDefault(i => !i.Name.Equals(type.Name));
                      //注册到容器中
                      AhnqIotContainer.Builder.RegisterType(t).As(tfrom).SingleInstance().PropertiesAutowired();
                      //LogHelper.Trace("AhnqIot.Bussiness.Register:{0}=>{1}", tfrom.Name, t.Name);
                  }
              });
        }

        public static void CreateObjectMapper()
        {
            Mapper.CreateMap<SysAreaDto, SysArea>();
            Mapper.CreateMap<SysArea, SysAreaDto>();
            Mapper.CreateMap<IEnumerable<SysAreaDto>, List<SysArea>>();
            Mapper.CreateMap<IEnumerable<SysArea>, List<SysAreaDto>>();

            Mapper.CreateMap<SysRoleDto, SysRole>();
            Mapper.CreateMap<SysRole, SysRoleDto>();
            Mapper.CreateMap<IEnumerable<SysRoleDto>, List<SysRole>>();
            Mapper.CreateMap<IEnumerable<SysRole>, List<SysRoleDto>>();//系统角色


            Mapper.CreateMap<SysUserDto, SysUser>();
            Mapper.CreateMap<SysUser, SysUserDto>();//系统用户

            Mapper.CreateMap<SysDepartmentDto, SysDepartment>();
            Mapper.CreateMap<SysDepartment, SysDepartmentDto>();
            Mapper.CreateMap<IEnumerable<SysDepartmentDto>, List<SysDepartment>>();
            Mapper.CreateMap<IEnumerable<SysDepartment>, List<SysDepartmentDto>>();//系统机构

            Mapper.CreateMap<FarmDto, Farm>();
            Mapper.CreateMap<Farm, FarmDto>();//基地

            Mapper.CreateMap<DeviceDto, Device>();
            Mapper.CreateMap<Device, DeviceDto>();
            Mapper.CreateMap<IEnumerable<DeviceDto>, List<Device>>();
            Mapper.CreateMap<IEnumerable<Device>, List<DeviceDto>>();//设备

            Mapper.CreateMap<DeviceTypeDto, DeviceType>();
            Mapper.CreateMap<DeviceType, DeviceTypeDto>();
            Mapper.CreateMap<IEnumerable<DeviceTypeDto>, List<DeviceType>>();
            Mapper.CreateMap<IEnumerable<DeviceType>, List<DeviceTypeDto>>();//设备类型

            Mapper.CreateMap<FacilityTypeDto, FacilityType>();
            Mapper.CreateMap<FacilityType, FacilityTypeDto>();
            Mapper.CreateMap<IEnumerable<FacilityTypeDto>, List<FacilityType>>();
            Mapper.CreateMap<IEnumerable<FacilityType>, List<FacilityTypeDto>>();//设施类型

            Mapper.CreateMap<IEnumerable<SysDepartmentDto>, List<SysDepartment>>();
            Mapper.CreateMap<IEnumerable<SysDepartment>, List<SysDepartmentDto>>();
            Mapper.CreateMap<SysDepartmentDto, SysDepartment>();
            Mapper.CreateMap<SysDepartment, SysDepartmentDto>();//系统机构

            Mapper.CreateMap<CompanyPicsDto, CompanyPics>();
            Mapper.CreateMap<CompanyPics, CompanyPicsDto>();//企业图片

            Mapper.CreateMap<CompanyDto, Company>();
            Mapper.CreateMap<Company, CompanyDto>();//企业

            Mapper.CreateMap<IEnumerable<DeviceDataInfoDto>, List<DeviceDataInfo>>();//设备历史数据
            Mapper.CreateMap<IEnumerable<DeviceDataInfo>, List<DeviceDataInfoDto>>();
            Mapper.CreateMap<DeviceDataInfoDto, DeviceDataInfo>();//设备历史数据
            Mapper.CreateMap<DeviceDataInfo, DeviceDataInfoDto>();

            Mapper.CreateMap<IEnumerable<DeviceRunLogDto>, List<DeviceRunLog>>();//设备运行记录
            Mapper.CreateMap<IEnumerable<DeviceRunLog>, List<DeviceRunLogDto>>();
            Mapper.CreateMap<DeviceRunLogDto, DeviceRunLog>();//设备运行记录
            Mapper.CreateMap<DeviceRunLog, DeviceRunLogDto>();

            Mapper.CreateMap<IEnumerable<DeviceControlLogDto>, List<DeviceControlLog>>();//设备控制记录
            Mapper.CreateMap<IEnumerable<DeviceControlLog>, List<DeviceControlLogDto>>();
            Mapper.CreateMap<DeviceControlLogDto, DeviceControlLog>();//设备控制记录
            Mapper.CreateMap<DeviceControlLog, DeviceControlLogDto>();

            Mapper.CreateMap<FacilityDto, Facility>();
            Mapper.CreateMap<Facility, FacilityDto>();
            Mapper.CreateMap<IEnumerable<FacilityDto>, List<Facility>>();
            Mapper.CreateMap<IEnumerable<Facility>, List<FacilityDto>>();//设施

            Mapper.CreateMap<FacilityCameraDto, FacilityCamera>();
            Mapper.CreateMap<FacilityCamera, FacilityCameraDto>();
            Mapper.CreateMap<IEnumerable<FacilityCameraDto>, List<FacilityCamera>>();
            Mapper.CreateMap<IEnumerable<FacilityCamera>, List<FacilityCameraDto>>();//设施摄像机

            Mapper.CreateMap<CameraStationPresetPointDto, CameraStationPresetPoint>();
            Mapper.CreateMap<CameraStationPresetPoint, CameraStationPresetPointDto>();
            Mapper.CreateMap<IEnumerable<CameraStationPresetPointDto>, List<CameraStationPresetPoint>>();
            Mapper.CreateMap<IEnumerable<CameraStationPresetPoint>, List<CameraStationPresetPointDto>>();//实景监测点预置点

            Mapper.CreateMap<FacilityCameraPresetPointDto, FacilityCameraPresetPoint>();
            Mapper.CreateMap<FacilityCameraPresetPoint, FacilityCameraPresetPointDto>();
            Mapper.CreateMap<IEnumerable<FacilityCameraPresetPointDto>, List<FacilityCameraPresetPoint>>();
            Mapper.CreateMap<IEnumerable<FacilityCameraPresetPoint>, List<FacilityCameraPresetPointDto>>();//设施摄像机预置点


            Mapper.CreateMap<CameraStationPicsDto, CameraStationPics>();
            Mapper.CreateMap<CameraStationPics, CameraStationPicsDto>();
            Mapper.CreateMap<IEnumerable<CameraStationPicsDto>, List<CameraStationPics>>();
            Mapper.CreateMap<IEnumerable<CameraStationPics>, List<CameraStationPicsDto>>();//实景监测点图片

            Mapper.CreateMap<FacilityPicsDto, FacilityPics>();
            Mapper.CreateMap<FacilityPics, FacilityPicsDto>();
            Mapper.CreateMap<IEnumerable<FacilityPicsDto>, List<FacilityPics>>();
            Mapper.CreateMap<IEnumerable<FacilityPics>, List<FacilityPicsDto>>();//设施摄像机图片

            Mapper.CreateMap<CameraStationOnlineStatisticsDto, CameraStationOnlineStatistics>();
            Mapper.CreateMap<CameraStationOnlineStatistics, CameraStationOnlineStatisticsDto>();
            Mapper.CreateMap<IEnumerable<CameraStationOnlineStatisticsDto>, List<CameraStationOnlineStatistics>>();
            Mapper.CreateMap<IEnumerable<CameraStationOnlineStatistics>, List<CameraStationOnlineStatisticsDto>>();//实景监测点运行统计

            Mapper.CreateMap<FacilityCameraRunStatisticsDto, FacilityCameraRunStatistics>();
            Mapper.CreateMap<FacilityCameraRunStatistics, FacilityCameraRunStatisticsDto>();
            Mapper.CreateMap<IEnumerable<FacilityCameraRunStatisticsDto>, List<FacilityCameraRunStatistics>>();
            Mapper.CreateMap<IEnumerable<FacilityCameraRunStatistics>, List<FacilityCameraRunStatisticsDto>>();//设施摄像机运行统计


            Mapper.CreateMap<CameraStationRunLogDto, CameraStationRunLog>();
            Mapper.CreateMap<CameraStationRunLog, CameraStationRunLogDto>();
            Mapper.CreateMap<IEnumerable<CameraStationRunLogDto>, List<CameraStationRunLog>>();
            Mapper.CreateMap<IEnumerable<CameraStationRunLog>, List<CameraStationRunLogDto>>();//实景监测点运行日志

            Mapper.CreateMap<PictureRepDto, PictureRep>();
            Mapper.CreateMap<PictureRep, PictureRepDto>();
            Mapper.CreateMap<IEnumerable<PictureRepDto>, List<PictureRep>>();
            Mapper.CreateMap<IEnumerable<PictureRep>, List<PictureRepDto>>();//图片库

            Mapper.CreateMap<FacilityCameraRunLogDto, FacilityCameraRunLog>();
            Mapper.CreateMap<FacilityCameraRunLog, FacilityCameraRunLogDto>();
            Mapper.CreateMap<IEnumerable<FacilityCameraRunLogDto>, List<FacilityCameraRunLog>>();
            Mapper.CreateMap<IEnumerable<FacilityCameraRunLog>, List<FacilityCameraRunLogDto>>();//设施摄像机运行记录



            Mapper.CreateMap<IEnumerable<FacilityProduceInfoDto>, List<FacilityProduceInfo>>();
            Mapper.CreateMap<IEnumerable<FacilityProduceInfo>, List<FacilityProduceInfoDto>>();//设施农作物信息

            Mapper.CreateMap<AgrProductObjectGrowthInfoDto, AgrProductObjectGrowthInfo>();
            Mapper.CreateMap<AgrProductObjectGrowthInfo, AgrProductObjectGrowthInfoDto>();//农作物生长信息

            Mapper.CreateMap<AgrDiagnosticModelDto, AgrDiagnosticModel>();
            Mapper.CreateMap<AgrDiagnosticModel, AgrDiagnosticModelDto>();
            Mapper.CreateMap<IEnumerable<AgrDiagnosticModelDto>, List<AgrDiagnosticModel>>();
            Mapper.CreateMap<IEnumerable<AgrDiagnosticModel>, List<AgrDiagnosticModelDto>>();//诊断模型

            Mapper.CreateMap<AgrDiagnosticInfoDto, AgrDiagnosticInfo>();
            Mapper.CreateMap<AgrDiagnosticInfo, AgrDiagnosticInfoDto>();//诊断信息

            Mapper.CreateMap<DeviceTimeSharingStatisticsDto, DeviceTimeSharingStatistics>();
            Mapper.CreateMap<DeviceTimeSharingStatistics, DeviceTimeSharingStatisticsDto>();
            Mapper.CreateMap<IEnumerable<DeviceTimeSharingStatisticsDto>, List<DeviceTimeSharingStatistics>>();
            Mapper.CreateMap<IEnumerable<DeviceTimeSharingStatistics>, List<DeviceTimeSharingStatisticsDto>>();//设备分时统计数据

            Mapper.CreateMap<IEnumerable<DeviceRunningStatistics>, List<DeviceRunningStatisticsDto>>();//设备运行统计数据

            Mapper.CreateMap<DeviceControlCommandDto, DeviceControlCommand>();
            Mapper.CreateMap<DeviceControlCommand, DeviceControlCommandDto>();//控制指令

            Mapper.CreateMap<DeviceExceptionSetDto, DeviceExceptionSet>();
            Mapper.CreateMap<DeviceExceptionSet, DeviceExceptionSetDto>();
            Mapper.CreateMap<IEnumerable<DeviceExceptionSetDto>, List<DeviceExceptionSet>>();
            Mapper.CreateMap<IEnumerable<DeviceExceptionSet>, List<DeviceExceptionSetDto>>();//设备异常区间

            Mapper.CreateMap<DeviceDataExceptionLogDto, DeviceDataExceptionLog>();
            Mapper.CreateMap<DeviceDataExceptionLog, DeviceDataExceptionLogDto>();
            Mapper.CreateMap<IEnumerable<DeviceDataExceptionLogDto>, List<DeviceDataExceptionLog>>();
            Mapper.CreateMap<IEnumerable<DeviceDataExceptionLog>, List<DeviceDataExceptionLogDto>>();//设备数据异常日志

            Mapper.CreateMap<CameraStationsDto, CameraStations>();
            Mapper.CreateMap<CameraStations, CameraStationsDto>();
            Mapper.CreateMap<IEnumerable<CameraStationsDto>, List<CameraStations>>();
            Mapper.CreateMap<IEnumerable<CameraStations>, List<CameraStationsDto>>();//实景监测点

            Mapper.CreateMap<AreaStationDto, AreaStation>();
            Mapper.CreateMap<AreaStation, AreaStationDto>();
            Mapper.CreateMap<IEnumerable<AreaStationDto>, List<AreaStation>>();
            Mapper.CreateMap<IEnumerable<AreaStation>, List<AreaStationDto>>();//区域气象站

            Mapper.CreateMap<AreaStationDataInfoDto, AreaStationDataInfo>();
            Mapper.CreateMap<AreaStationDataInfo, AreaStationDataInfoDto>();
            Mapper.CreateMap<IEnumerable<AreaStationDataInfoDto>, List<AreaStationDataInfo>>();
            Mapper.CreateMap<IEnumerable<AreaStationDataInfo>, List<AreaStationDataInfoDto>>();//区域气象站历史数据

            Mapper.CreateMap<WeatherDeviceDto, WeatherDevice>();
            Mapper.CreateMap<WeatherDevice, WeatherDeviceDto>();
            Mapper.CreateMap<IEnumerable<WeatherDeviceDto>, List<WeatherDevice>>();
            Mapper.CreateMap<IEnumerable<WeatherDevice>, List<WeatherDeviceDto>>();//小气候仪设备

            Mapper.CreateMap<WeatherDeviceTypeDto, WeatherDeviceType>();
            Mapper.CreateMap<WeatherDeviceType, WeatherDeviceTypeDto>();
            Mapper.CreateMap<IEnumerable<WeatherDeviceTypeDto>, List<WeatherDeviceType>>();
            Mapper.CreateMap<IEnumerable<WeatherDeviceType>, List<WeatherDeviceTypeDto>>();//小气候仪设备类型

            Mapper.CreateMap<WeatherStationDto, WeatherStation>();
            Mapper.CreateMap<WeatherStation, WeatherStationDto>();
            Mapper.CreateMap<IEnumerable<WeatherStationDto>, List<WeatherStation>>();
            Mapper.CreateMap<IEnumerable<WeatherStation>, List<WeatherStationDto>>();//气象站

            Mapper.CreateMap<WeatherStationOnlineStatisticsDto, WeatherStationOnlineStatistics>();
            Mapper.CreateMap<WeatherStationOnlineStatistics, WeatherStationOnlineStatisticsDto>();
            Mapper.CreateMap<IEnumerable<WeatherStationOnlineStatisticsDto>, List<WeatherStationOnlineStatistics>>();
            Mapper.CreateMap<IEnumerable<WeatherStationOnlineStatistics>, List<WeatherStationOnlineStatisticsDto>>();//气象站在线统计

            //Mapper.CreateMap<WeatherWarn, WeatherStationOnlineStatistics>();
            //Mapper.CreateMap<WeatherStationOnlineStatistics, WeatherStationOnlineStatisticsDto>();
            //Mapper.CreateMap<IEnumerable<WeatherStationOnlineStatisticsDto>, List<WeatherStationOnlineStatistics>>();
            //Mapper.CreateMap<IEnumerable<WeatherStationOnlineStatistics>, List<WeatherStationOnlineStatisticsDto>>();//

            


            Mapper.CreateMap<AgrProduceConditionDto, AgrProduceCondition>();
            Mapper.CreateMap<AgrProduceCondition, AgrProduceConditionDto>();
            Mapper.CreateMap<IEnumerable<AgrProduceConditionDto>, List<AgrProduceCondition>>();
            Mapper.CreateMap<IEnumerable<AgrProduceCondition>, List<AgrProduceConditionDto>>();//农业气象指标

            Mapper.CreateMap<CompanyUserDto, CompanyUser>();
            Mapper.CreateMap<CompanyUser, CompanyUserDto>();
            Mapper.CreateMap<IEnumerable<CompanyUserDto>, List<CompanyUser>>();
            Mapper.CreateMap<IEnumerable<CompanyUser>, List<CompanyUserDto>>();//企业用户

            Mapper.CreateMap<AWProductDto, AWProduct>();
            Mapper.CreateMap<AWProduct, AWProductDto>();
            Mapper.CreateMap<IEnumerable<AWProductDto>, List<AWProduct>>();
            Mapper.CreateMap<IEnumerable<AWProduct>, List<AWProductDto>>();//农气产品

            //var dto = new SysUserDto();
            //var model = Mapper.Map<SysUser>(dto);
            //var dto2 = Mapper.Map<SysUserDto>(model);
        }


        public static void InitDatabaseData()
        {
            var enableInitData = Config.GetConfig("enable-initdta", false);
            if (enableInitData)
            {
                var allTypes = Assembly.GetExecutingAssembly().GetTypes();
                var type = typeof(IService<>);

                var usefuleTypes = allTypes.Where(t => !t.IsGenericType && t.IsClass);

                var sortTuple = new List<Tuple<Type, Type, InitDataAttribute>>();
                var unsortTuple = new List<Tuple<Type, Type>>();

                usefuleTypes.ToList().ForEach(t =>
                {
                    var attr = t.GetCustomAttribute(typeof(InitDataAttribute));
                    var ins = t.GetInterfaces();
                    if (ins.Any(i => i.Name.Equals(type.Name)))
                    {
                        var tfrom = ins.FirstOrDefault(i => !i.Name.Equals(type.Name));

                        if (attr != null)
                        {
                            sortTuple.Add(new Tuple<Type, Type, InitDataAttribute>(tfrom, t, attr as InitDataAttribute));
                        }
                        else
                        {
                            unsortTuple.Add(new Tuple<Type, Type>(tfrom, t));
                        }
                    //var instance = AhnqIotContainer.Container.Resolve(tfrom);
                    ////反射获取InitData并执行
                    //var ms = t.GetMethods();
                    //var method = ms.FirstOrDefault(m => m.Name.Equals("InitData"));
                    ////var method = t.GetMethod("InitData");
                    //method?.Invoke(instance, new object[] { });
                }
                });

                sortTuple.OrderBy(tuple => tuple.Item3.Sort).ToList().ForEach(tuple =>
                  {
                      var instance = AhnqIotContainer.Container.Resolve(tuple.Item1);
                //反射获取InitData并执行
                var ms = tuple.Item2.GetMethods();
                      var method = ms.FirstOrDefault(m => m.Name.Equals("InitData"));
                //var method = t.GetMethod("InitData");
                method?.Invoke(instance, new object[] { });
                  });

                unsortTuple.ForEach(tuple =>
                {
                    var instance = AhnqIotContainer.Container.Resolve(tuple.Item1);
                //反射获取InitData并执行
                var ms = tuple.Item2.GetMethods();
                    var method = ms.FirstOrDefault(m => m.Name.Equals("InitData"));
                //var method = t.GetMethod("InitData");
                method?.Invoke(instance, new object[] { });
                });
            }

        }
    }
}