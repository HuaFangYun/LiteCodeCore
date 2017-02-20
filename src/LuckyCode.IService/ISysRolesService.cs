using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.Core;
using LiteCode.Core.Utility;
using LiteCode.ViewModels.SiteManager;

namespace LiteCode.IService
{
    public interface ISysRolesService
    {
        Task<SysRoleViewModel> SaveSysRole(SysRoleViewModel model);
        Task<SysRoleViewModel> UpdateSysModule(SysRoleViewModel model);
        Task DeleteSysRole(string id);
        Task<PagedList<SysRoleViewModel>> GetPagedList(int pageIndex, int pageSize);
        Task<SysRoleViewModel> GetSysRoleViewModel(string id);
        Task SaveRoleModule(SysRoleModuleViewModel model);
        Task<List<SysRoleModulePurviewViewModel>> GetModulePurviewViewModel(string roleid);
        Task<List<ListItemEntity>> GetRoleItemEntities();
    }
}
