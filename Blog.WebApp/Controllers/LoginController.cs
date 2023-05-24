using Blog.Application.Catalog.CategoryService;
using Blog.Application.System.AuthenService;
using Blog.ViewModel.System.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Controllers
{
    [Route("/dang-nhap")]
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        private readonly IAuthenService _authenService;
        public LoginController(ICategoryService categoryService,IAuthenService authenService) : base(categoryService)
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
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            var result = await _authenService.Login(model);
            return new JsonResult(result);
        }

        [Route("/dang-xuat")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return RedirectToAction("Index","Home");
        }
    }
}
