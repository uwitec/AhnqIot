using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
namespace AhnqIot.Dto
{
    [Serializable]
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(10, typeof(AgrDiagnosticModelDto))]
    [ProtoInclude(11, typeof(FacilityDto))]
    [ProtoInclude(12, typeof(DeviceDto))]
    [ProtoInclude(13, typeof(DeviceTypeDto))]
    [ProtoInclude(14, typeof(FacilityCameraDto))]
    [ProtoInclude(15, typeof(FacilityProduceInfoDto))]
    [ProtoInclude(16, typeof(FacilityTypeDto))]
    [ProtoInclude(17, typeof(FarmDto))]
    [ProtoInclude(18, typeof(CompanyDto))]
    [ProtoInclude(19, typeof(AgrDiagnosticInfoDto))]
    [ProtoInclude(20, typeof(DeviceDataInfoDto))]
    [ProtoInclude(21, typeof(DeviceTimeSharingStatisticsDto))]
    [ProtoInclude(22, typeof(DeviceRunLogDto))]
    [ProtoInclude(23, typeof(DeviceDataExceptionLogDto))]
    [ProtoInclude(24, typeof(FacilityCameraRunLogDto))]
    [ProtoInclude(25, typeof(CameraStationsDto))]
    [ProtoInclude(26, typeof(SysDepartmentDto))]
    [ProtoInclude(27, typeof(CameraStationPresetPointDto))]
    [ProtoInclude(28, typeof(PictureRepDto))]
    [ProtoInclude(29, typeof(CameraStationPicsDto))]
    [ProtoInclude(30, typeof(CameraStationRunLogDto))]
    [ProtoInclude(31, typeof(CameraStationOnlineStatisticsDto))]
    [ProtoInclude(32, typeof(FacilityCameraPresetPointDto))]
    [ProtoInclude(33, typeof(FacilityPicsDto))]
    [ProtoInclude(34, typeof(FacilityCameraRunStatisticsDto))]
    [ProtoInclude(35, typeof(FacilityCameraDto))]
    [ProtoInclude(36, typeof(AreaStationDto))]
    [ProtoInclude(37, typeof(AreaStationDataInfoDto))]
    [ProtoInclude(38, typeof(WeatherDeviceDto))]
    [ProtoInclude(39, typeof(WeatherDeviceTypeDto))]
    [ProtoInclude(40, typeof(WeatherStationDto))]
    [ProtoInclude(41, typeof(WeatherStationOnlineStatisticsDto))]
    [ProtoInclude(42, typeof(DeviceExceptionSetDto))]
    [ProtoInclude(43, typeof(SysRoleDto))]
    [ProtoInclude(44, typeof(CompanyUserDto))]
    public  class BaseDto
    {
        /// <summary>
        ///     编码
        /// </summary>
        [ProtoMember(1)]
        public string Serialnum { get; set; }

        /// <summary>
        ///     创建用户
        /// </summary>
        [ProtoMember(2)]
        public string CreateSysUserSerialnum { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        [ProtoMember(3)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///     更新用户
        /// </summary>
        [ProtoMember(4)]
        public string UpdateSysUserSerialnum { get; set; }

        /// <summary>
        ///     更新时间
        /// </summary>
        [ProtoMember(5)]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        ///     顺序
        /// </summary>
        [ProtoMember(6)]
        public int Sort { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        [ProtoMember(7)]
        public string Remark { get; set; }
    }
}
