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
    public class NewsBannerController : BaseController
    {
        private string indexUrl = "/SysManager/NewsBanner/Index";
        private INewsBannerService _bannerService;
        private ILogger _logger;

        public NewsBannerController(ILogger<NewsBannerController> logger, INewsBannerService bannerService)
        {
            _bannerService = bannerService;
            _logger = logger;
        }

        // GET: NewsBanner
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetListViewModel(int pageIndex, int pageSize)
        {
            var page = _bannerService.GetPagedList(pageIndex, pageSize);
            return Json(new TableViewModel<NewsBannerViewModel>() {Rows = page,Total = page.TotalCount});
        }

        public ActionResult Create()
        {
            var model=new NewsBannerViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(NewsBannerViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var self = this;
                try
                {
                    _bannerService.SaveNewsBanner(model);
                    return Redirect(indexUrl);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _bannerService.GetNewsBannerViewModel(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(NewsBannerViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bannerService.UpdateNewsBanner(model);
                    return Redirect(indexUrl);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            return Json(true);
        }
    }
}