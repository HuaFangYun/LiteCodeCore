using System.Collections.Generic;
using System.Threading.Tasks;
using LiteCode.Core;
using LiteCode.Core.Utility;
using Lucky.ViewModels.Models.News;

namespace Lucky.IService.News
{
    public interface ICategoryService
    {
        void DeleteCategory(string id);
        CategoryViewModel SaveCategory(CategoryViewModel model);
        CategoryViewModel UpdateCategory(CategoryViewModel model);
        Task<PagedList<CategoryViewModel>> GetPagedList(int pageIndex, int pageSize);
        Task<CategoryViewModel> GetCategoryViewModel(string id);
        List<ListItemEntity> AppItemEntities();
    }
}
