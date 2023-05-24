using Blog.Application.Catalog.CategoryService;
using Blog.Application.System.AuthenService;
using Blog.ViewModel.System.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Controllers
{
    [Route("dang-ky")]
    [AllowAnonymous]
    public class RegisterController : BaseController
    {
        private readonly IAuthenService _authenService;

        public RegisterController(ICategoryService categoryService,IAuthenService authenService) : base(categoryService)
        {
            _authenService = authenService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _authenService.Register(model);
            return new JsonResult(result);
        }
    }
}
