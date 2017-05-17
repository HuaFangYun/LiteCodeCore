using System.Threading.Tasks;
using LiteCode.WebSite.Areas.SysManager;
using LuckyCode.Core;
using LuckyCode.IService;
using LuckyCode.ViewModels.SiteManager;
using LuckyCode.WebFrameWork.TagHelper.MVCPager;
using Microsoft.AspNetCore.Mvc;

namespace LuckyCode.WebSite.Areas.SysManager.Controllers
{

    public class SysApplicationController : BaseController
    {
        private IPagerdMetaService _metaService;
        private ISysApplicationService _sysApplicationService;
        public SysApplicationController(ISysApplicationService sysApplicationService, IPagerdMetaService metaService)
        {
            _sysApplicationService = sysApplicationService;
            _metaService = metaService;
        }
        // GET: SysApplication
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetListViewModel(int pageIndex, int pageSize)
        {
            PagedList<SysApplicationViewModel> paged =await _sysApplicationService.GetPagedList(pageIndex,pageSize);
            return this.Json(new { total = paged.TotalCount, rows = paged });
        }

        public async Task<IActionResult> TestPager(int pageIndex)
        {
            PagedList<SysApplicationViewModel> paged = await _sysApplicationService.GetPagedList(pageIndex, 5);
            ViewBag.Full = _metaService.GetMetaData(paged.TotalCount, pageIndex, 4);
            return View(paged);
        }
        public ActionResult Create()
        {
            return View(new SysApplicationViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SysApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _sysApplicationService.SaveSysApplication(model);
                return Redirect("/SysManager/SysApplication/Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model =await _sysApplicationService.GetApplicationViewModel(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SysApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _sysApplicationService.UpdateSysApplication(model);
                return Redirect("/SysManager/SysApplication/Index");
            }
            return View(model);
        }

        public async Task<ActionResult> Delete(string id)
        {
           await _sysApplicationService.DeleteSysApplication(id);
            return Json("true");
        }
    }
}