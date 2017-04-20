using System;
using System.Threading.Tasks;
using LiteCode.Core;
using Lucky.ViewModels.Models.News;

namespace Lucky.IService.News
{
   public interface INewsBannerService
    {
        void DeleteNewsBanner(Guid id);
        NewsBannerViewModel SaveNewsBanner(NewsBannerViewModel model);
        NewsBannerViewModel UpdateNewsBanner(NewsBannerViewModel model);
        PagedList<NewsBannerViewModel> GetPagedList(int pageIndex, int pageSize);
        Task<NewsBannerViewModel> GetNewsBannerViewModel(Guid id);
        
    }
}
