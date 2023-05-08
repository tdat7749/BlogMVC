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
            var result = await _categoryService.CreateCategory(model);
            if (result == false) return new JsonResult(new { message = "Slug đã tồn tại", success = false });

            return new JsonResult(new { message = "Tạo mới thành công !", success = true });
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeStatus([FromBody] UpdateCategoryStatusModel model)
        {
            var result = await _categoryService.ChangeStatus(model);
            if(result == false) return new JsonResult(new { message = "ID danh mục này không tồn tại", success = false });

            return new JsonResult(new { message = "Cập nhật trạng thái thành công !", success = true });

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]UpdateCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                var category = new Category()
                {
                    Id = model.Id,
                    Slug = model.Slug,
                    Name = model.Name,
                    Status = model.Status
                };
                return View(category);
            }
            var result = await _categoryService.UpdateCategory(model);
            if(result == false) return BadRequest();

            return RedirectToAction("Index","Category");
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (result == false) return new JsonResult(new { message = $"Không tồn tại mã = {id}", success = false });

            return new JsonResult(new { message = "Xóa thành công !", success = true });
        }
    }
}
    