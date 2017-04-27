using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.Log;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ahnqiot.Ef.Test
{
    public class SysUserTest
    {
        private ISysAreaService _sysAreaService;
        private ISysDepartmentService _sysDepartmentService;
        private ISysRoleService _sysRoleService;
        private ISysUserService _sysUserService;
        private IAreaStationService _areaStationService;
        private IFacilityService _facilityService;
        private IDeviceTypeService _deviceTypeService;

        public SysUserTest(ISysAreaService sysAreaService, ISysDepartmentService sysDepartmentService, ISysRoleService sysRoleService, ISysUserService sysUserService, IAreaStationService areaStationService,
             IFacilityService facilityService,
             IDeviceTypeService deviceTypeService)
        {
            _sysAreaService = sysAreaService;
            _sysDepartmentService = sysDepartmentService;
            _sysRoleService = sysRoleService;
            _sysUserService = sysUserService;
            _areaStationService = areaStationService;
            _facilityService = facilityService;
            _deviceTypeService = deviceTypeService;
        }

        public async Task Test()
        {
            //try
            //{
            //    await _sysAreaService.AddSysAreaAsync("dwa465", "flsdakjlsdaf", "00009", 100);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //var list = await _sysAreaService.GetAllAsync();
            //LogHelper.Info(list.Count().ToString());
            ////await CreateSysArea();
            ////await AddRole();
            ////await AddUser();

            ////await AddDepartment();
            ////await AddAreaStation();
            ////await AddFacilityType();
            await AddDeviceType();
        }

        public async Task AddSysArea()
        {
             _sysAreaService.InitData();
        }

        public async void AddDepartment()
        {
             _sysDepartmentService.InitData();
        }

        public async void AddRole()
        {
             _sysRoleService.InitData();
        }

        public async void AddUser()
        {
            SysUserDto dto = new SysUserDto();
            dto.Serialnum = Guid.NewGuid().ToString();
            dto.LoginName = "chenqi";
            dto.UserName = "陈奇";
            dto.Email = "chenqi_lscy@163.com";
            dto.QQ = "1497353329";
            dto.Password = "123456";

            // _sysUserService = Ioc.CurrentIoc.Resolve<ISysUserService>();
            await _sysUserService.AddAsync(dto);
        }

        public async void AddAreaStation()
        {
             _areaStationService.InitData();
        }

        /// <summary>
        /// 初始化话设施类型
        /// </summary>
        /// <returns></returns>
        public async void AddFacilityType()
        {
             _facilityService.InitData();
        }

        /// <summary>
        /// 初始化设备类型
        /// </summary>
        /// <returns></returns>
        public async Task AddDeviceType()
        {
            await _deviceTypeService.GetAllAsync();
        }
    }
}