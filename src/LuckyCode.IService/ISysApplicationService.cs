using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.Core;
using LiteCode.Core.Utility;
using LiteCode.ViewModels.SiteManager;

namespace LiteCode.IService
{
    public interface ISysApplicationService
    {
        Task DeleteSysApplication(string id);
        Task<SysApplicationViewModel> SaveSysApplication(SysApplicationViewModel model);
        Task<SysApplicationViewModel> UpdateSysApplication(SysApplicationViewModel model);
        Task<PagedList<SysApplicationViewModel>> GetPagedList();
        Task<SysApplicationViewModel> GetApplicationViewModel(string id);
        Task<List<ListItemEntity>> AppItemEntities();
    }
}
