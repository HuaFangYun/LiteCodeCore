using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.ViewModels;
using LiteCode.WebSite.Areas.SysManager;
using Lucky.IService;
using Lucky.IService.News;
using Lucky.ViewModels.Models;
using Lucky.ViewModels.Models.News;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lucky.SiteManager.Controllers
{
    public class NewsArticleController : BaseController
    {
        private string indexUrl= "/SysManager/NewsArticle/Index";
        private INewsArticleService _articleService;
        private ICategoryService _categoryService;
        private ILogger _logger;
        public NewsArticleController(INewsArticleService articleService, ICategoryService categoryService,ILogger<NewsArticleController> logger)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _logger = logger;
        }
        // GET: NewsArticle
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListViewModel(int pageIndex, int pageSize)
        {
            var page = _articleService.GetPagedList(pageIndex, pageSize);
            return Json(new TableViewModel<ArticleViewModel>() {Rows = page,Total = page.TotalCount});
        }

        public ActionResult Create()
        {
            var model=new ArticleViewModel();
            model.CategoryEntities = _categoryService.AppItemEntities();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                _articleService.SaveNewsArticles(model);
                return Redirect(indexUrl);
            }
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model =await _articleService.GetNewsArticlesViewModel(id);
            model.CategoryEntities = _categoryService.AppItemEntities();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                _articleService.UpdateNewsArticles(model);
                return Redirect(indexUrl);
            }
            return RedirectToAction("Edit", new {id = model.ArticleId});
        }

        public ActionResult Delete(Guid id)
        {
            _articleService.DeleteNewsArticles(id);
            return Json(true);
        }
    }
}