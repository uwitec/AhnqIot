#region Code File Comment
// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： Init.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-13 16:48
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using NewLife.Configuration;
using NewLife.Reflection;
using SmartIot.Tool.DefaultService.DB;
using SmartIot.ConfigTool.Model;
namespace SmartIot.ConfigTool.Core
{
    public class CreateMap
    {
        static CreateMap()
        {
        }

     
        public static void Start()
        {

            //创建dbmodel和dto的映射
            CreateObjectMapper();
        }

  

        public static void CreateObjectMapper()
        {
            Mapper.CreateMap<SensorDeviceUnit, SensorDeviceUnitDto>();
            Mapper.CreateMap<SensorDeviceUnitDto, SensorDeviceUnit>();
            Mapper.CreateMap<IEnumerable<SensorDeviceUnit>, List<SensorDeviceUnitDto>>();
            Mapper.CreateMap<IEnumerable<SensorDeviceUnitDto>, List<SensorDeviceUnit>>();

            Mapper.CreateMap<ControlDeviceUnit, ControlDeviceUnitDto>();
            Mapper.CreateMap<ControlDeviceUnitDto, ControlDeviceUnit>();
            Mapper.CreateMap<IEnumerable<ControlDeviceUnit>, List<ControlDeviceUnitDto>>();
            Mapper.CreateMap<IEnumerable<ControlDeviceUnitDto>, List<ControlDeviceUnit>>();

            Mapper.CreateMap<Camera, CameraDto>();
            Mapper.CreateMap<CameraDto, Camera>();
            Mapper.CreateMap<IEnumerable<Camera>, List<CameraDto>>();
            Mapper.CreateMap<IEnumerable<CameraDto>, List<Camera>>();

            Mapper.CreateMap<Farm, FarmDto>();
            Mapper.CreateMap<FarmDto, Farm>();
            Mapper.CreateMap<IEnumerable<Farm>, List<FarmDto>>();
            Mapper.CreateMap<IEnumerable<FarmDto>, List<Farm>>();

            Mapper.CreateMap<Facility, FacilityDto>();
            Mapper.CreateMap<FacilityDto, Facility>();
            Mapper.CreateMap<IEnumerable<Facility>, List<FacilityDto>>();
            Mapper.CreateMap<IEnumerable<FacilityDto>, List<Facility>>();

            Mapper.CreateMap<ShowDevice, ShowDeviceDto>();
            Mapper.CreateMap<ShowDeviceDto, ShowDevice>();
            Mapper.CreateMap<IEnumerable<ShowDevice>, List<ShowDeviceDto>>();
            Mapper.CreateMap<IEnumerable<ShowDeviceDto>, List<ShowDevice>>();

            Mapper.CreateMap<CommunicateDevice, CommunicateDeviceDto>();
            Mapper.CreateMap<CommunicateDeviceDto, CommunicateDevice>();
            Mapper.CreateMap<IEnumerable<CommunicateDevice>, List<CommunicateDeviceDto>>();
            Mapper.CreateMap<IEnumerable<CommunicateDeviceDto>, List<CommunicateDevice>>();

            Mapper.CreateMap<ModularDevice, ModularDeviceDto>();
            Mapper.CreateMap<ModularDeviceDto, ModularDevice>();
            Mapper.CreateMap<IEnumerable<ModularDevice>, List<ModularDeviceDto>>();
            Mapper.CreateMap<IEnumerable<ModularDeviceDto>, List<ModularDevice>>();

        }

    }
}