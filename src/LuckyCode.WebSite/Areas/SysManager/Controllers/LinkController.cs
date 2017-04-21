using System;
using System.Threading.Tasks;
using LiteCode.WebSite.Areas.SysManager;
using LuckyCode.IService.News;
using LuckyCode.ViewModels;
using LuckyCode.ViewModels.News;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LuckyCode.WebSite.Areas.SysManager.Controllers
{
    public class LinksController : BaseController
    {
        private ILinkService _linkService;
        private ILogger _logger;
        public LinksController(ILinkService linkService,ILogger<LinksController> logger)
        {
            _linkService = linkService;
            _logger = logger;
        }
        // GET: Link
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListViewModel(int pageIndex, int pageSize)
        {
            var page = _linkService.GetPagedList(pageIndex, pageSize);
            return Json(new TableViewModel<LinkViewModel>() { Rows = page, Total = page.TotalCount });
        }

        public ActionResult Create()
        {
            var model = new LinkViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(LinkViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _linkService.SaveLink(model);
                    return Redirect("/SysManager/Links/Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(string id)
        {
            var model = await _linkService.GetLinkViewModel(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(LinkViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _linkService.UpdateLink(model);
                    return Redirect("/SysManager/Links/Index");
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
            try
            {
                _linkService.DeleteLink(id);
                return Json(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Json(false);
        }
    }
}