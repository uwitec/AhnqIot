using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Bussiness.Interface
{
   public interface ISysMenuService:IService<SysMenuDto>
    {
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SysMenuDto>> GetAllAsync();
        /// <summary>
        /// 根据角色编码获取
        /// </summary>
        /// <param name="roleId">角色编码</param>
        /// <returns></returns>
        Task<SysMenuDto> GetByRoleIdAsync(string roleId);
        /// <summary>
        /// 根据编码获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SysMenuDto> GetByIdAsync(string id);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> AddAsync(SysMenuDto dto);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(string id);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(SysMenuDto dto);
    }
}
