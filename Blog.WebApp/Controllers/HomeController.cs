using Blog.Application.Catalog.CategoryService;
using Blog.Application.Catalog.PostService;
using Blog.Application.Common.FileStorageService;
using Blog.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.WebApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {

        private readonly IPostService _postService;
        public HomeController(ICategoryService categoryService,IPostService postService) : base(categoryService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["ListLatestPort"] = await _postService.GetPostLatest();
            ViewData["ListMostView"] = await _postService.GetPostMostView();
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}