using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.Core;
using LiteCode.Core.Utility;
using LiteCode.ViewModels.SiteManager;

namespace LiteCode.IService
{
    public interface ISysModulesService
    {
        Task<SysModuleViewModel> SaveSysModule(SysModuleViewModel model);
        Task<SysModuleViewModel> UpdateSysModule(SysModuleViewModel model);
        Task DeleteSysModule(string id);
        Task<PagedList<SysModuleViewModel>> GetPagedList(int pageIndex, int pageSize);
        Task<SysModuleViewModel> GetModuleViewModel(string id);
        Task<List<ListItemEntity>> ModuleItemEntities();
        Task<List<SysModuleBase>> GetModuleBases();
        Task<List<string>> GetControllerNameList();
        Task<List<SysModuleViewModel>> GetSysModuleViewModels(string roleId);
        Task UpdateModuleSort(SysModuleSortViewModel[] items);
        Task<List<SysModuleSortViewModel>> GetModuleSortViewModels(string id);
        Task<bool> ValidateActionName(string id, string controllerName, string actionName);
    }
}
