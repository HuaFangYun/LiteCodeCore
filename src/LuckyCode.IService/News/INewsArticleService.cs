using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiteCode.Core;
using Lucky.ViewModels.Models.News;

namespace Lucky.IService.News
{
    public interface INewsArticleService
    {
        void DeleteNewsArticles(Guid id);
        ArticleViewModel SaveNewsArticles(ArticleViewModel model);
        Task<ArticleViewModel> UpdateNewsArticles(ArticleViewModel model);
        PagedList<ArticleViewModel> GetPagedList(int pageIndex, int pageSize);
        Task<ArticleViewModel> GetNewsArticlesViewModel(Guid id);

        List<ArticleTopOneViewModel> GetArticleTopOneViewModel(long categoryid);
        List<ArticleFromCategoryId> GetArticleFromCategoryViewModel(long categoryid,int num);

    }
}
