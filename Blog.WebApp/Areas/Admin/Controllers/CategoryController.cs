using Blog.Application.Catalog.CategoryService;
using Blog.Data.Entities;
using Blog.ViewModel.Catalog.Category;
using Blog.ViewModel.Common;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllCategories([FromBody] PagingRequest request)
        {
            var result = await _categoryService.GetAllCategories(request);

            return new JsonResult(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _categoryService.CreateCategory(model);
            return new JsonResult(result);
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeStatus([FromBody] UpdateCategoryStatusModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _categoryService.ChangeStatus(model);

            return new JsonResult(result);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]UpdateCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _categoryService.UpdateCategory(model);
            return new JsonResult(result);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _categoryService.DeleteCategory(id);

            return new JsonResult(result);
        }
    }
}
    