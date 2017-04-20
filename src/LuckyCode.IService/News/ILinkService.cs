using System.Collections.Generic;
using System.Threading.Tasks;
using LiteCode.Core;
using Lucky.ViewModels.Models.News;

namespace Lucky.IService.News
{
    public interface ILinkService
    {
        void DeleteLink(string id);
        LinkViewModel SaveLink(LinkViewModel model);
        LinkViewModel UpdateLink(LinkViewModel model);
        PagedList<LinkViewModel> GetPagedList(int pageIndex, int pageSize);
        Task<LinkViewModel> GetLinkViewModel(string id);
       
    }
}
