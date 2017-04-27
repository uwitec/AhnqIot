using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Hxj.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Bussiness
{
   public class SysMenuService : ServiceBase<SysMenu, SysMenuDto>, ISysMenuService
    {
        public ISysRoleMenuService sysRoleMenuService { get; set; }
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public async   Task<IEnumerable<SysMenuDto>> GetAllAsync()
        {
            return GetDtoModels(await Repository.GetAllAsync());
        }
        /// <summary>
        /// 根据角色编码获取
        /// </summary>
        /// <param name="roleId">角色编码</param>
        /// <returns></returns>
        public async Task<SysMenuDto> GetByRoleIdAsync(string roleId)
        {
            var menu =await  sysRoleMenuService.GetAsync(m => m.SysRoleSerialnum.Equals(roleId));
            /*if (menu != null) */return GetDtoModel(await Repository.GetByIdAsync(menu?.SysMenuSerialnum));
            //else return null;
        }
        /// <summary>
        /// 根据编码获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SysMenuDto> GetByIdAsync(string id)
        {
            return GetDtoModel(await Repository.GetByIdAsync(id));
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(SysMenuDto dto)
        {
            Repository.Add(GetDbModel(dto));
            return await Repository.CommitAsync() > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string id)
        {
            Repository.Delete(id);
            return await Repository.CommitAsync() > 0;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(SysMenuDto dto)
        {
            Repository.Update(GetDbModel(dto));
            return await Repository.CommitAsync() > 0;
        }
    }
}
