using Blog.Application.Catalog.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.WebApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly ICategoryService _categoryService;
        public BaseController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        private async Task ExecutingAsync()
        {
            ViewData["Categories"] = await _categoryService.GetAllPublicCategories();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            // Trong C# dấu gạch dưới ( _ ) thể hiện cho việc dùng biến giả
            // biến này không quan tâm tới việc hàm đó trả về gì
            _ = ExecutingAsync();
            base.OnActionExecuting(context);
        }
    }
}
