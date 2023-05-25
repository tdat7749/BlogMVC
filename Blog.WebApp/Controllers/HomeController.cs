using Blog.Application.Catalog.CategoryService;
using Blog.Application.Catalog.PostService;
using Blog.Application.Common.FileStorageService;
using Blog.Application.System.CarouselService;
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
        private readonly ICarouselService _carouselService;
        public HomeController(ICategoryService categoryService,IPostService postService,ICarouselService carouselService) : base(categoryService)
        {
            _postService = postService;
            _carouselService = carouselService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["ListLatestPost"] = await _postService.GetPostLatest();
            ViewData["ListMostView"] = await _postService.GetPostMostView();
            ViewData["ListCarousel"] = await _carouselService.GetPublicCarousel();
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