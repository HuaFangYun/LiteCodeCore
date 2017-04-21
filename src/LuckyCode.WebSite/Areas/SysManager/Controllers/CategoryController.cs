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
    public class CategoryController : BaseController
    {
        private ICategoryService _categoryService;
        private ILogger _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetListViewModel(int pageIndex, int pageSize)
        {
            var page =await _categoryService.GetPagedList(pageIndex, pageSize);
            return Json(new TableViewModel<CategoryViewModel>() {Rows = page, Total = page.TotalCount}
                );
        }

        public ActionResult Create()
        {
            var model = new CategoryViewModel();
            model.CategoryEntities = _categoryService.AppItemEntities();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.SaveCategory(model);
                    return Redirect("/SysManager/Category/Index");
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
            var model = await _categoryService.GetCategoryViewModel(id);
            model.CategoryEntities = _categoryService.AppItemEntities();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.UpdateCategory(model);
                    return Redirect("/SysManager/Category/Index");
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
                _categoryService.DeleteCategory(id);
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