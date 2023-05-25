using Blog.Application.Catalog.CategoryService;
using Blog.Application.System.AuthenService;
using Blog.Application.System.MailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Controllers
{
    [AllowAnonymous]
    [Route("quen-mat-khau")]
    public class ForgotPasswordController : BaseController
    {
        private readonly IAuthenService _authenService;
        public ForgotPasswordController(ICategoryService categoryService,IAuthenService authenService) : base(categoryService)
        {
            _authenService = authenService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("send-token")]
        [HttpPost]
        public async Task<IActionResult> SendToken([FromBody] string email)
        {
            var result = await _authenService.ForgotPassword(email);
            return new JsonResult(result);
        }
    }
}
