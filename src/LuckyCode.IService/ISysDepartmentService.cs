using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.Core;
using LiteCode.Core.Utility;
using LiteCode.ViewModels.SiteManager;

namespace LiteCode.IService
{
    public interface ISysDepartmentService
    {
        Task<SysDepartmentViewModel> SaveSysDepartment(SysDepartmentViewModel model);
        Task<SysDepartmentViewModel> UpdateSysDeparment(SysDepartmentViewModel model);
        Task DeleteDepartment(string id);
        Task<PagedList<SysDepartmentViewModel>> GetPagedList(int pageIndex, int pageSize);
        Task<SysDepartmentViewModel> GetSysDepartmentViewModel(string id);
        Task<List<ListItemEntity>> GetDepartmentTree();
    }
}
