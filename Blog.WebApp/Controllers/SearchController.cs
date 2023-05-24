using Blog.Application.Catalog.CategoryService;
using Blog.Application.Catalog.PostService;
using Blog.ViewModel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Controllers
{
    [Route("tim-kiem")]
    [AllowAnonymous]
    public class SearchController : BaseController
    {
        private readonly IPostService _postService;
        public SearchController(ICategoryService categoryService,IPostService postService) : base(categoryService)
        {
            _postService = postService;
        }

        [Route("tag/{slug}")]
        [HttpGet]
        public async Task<IActionResult> Tag()
        {
            ViewData["ListMostView"] = await _postService.GetPostMostView();
            return View();
        }

        [Route("tagsearch")]
        [HttpPost]
        public async Task<IActionResult> TagSearch([FromBody]PagingSearchRequest request)
        {
            request.PageSize = 10;
            var result = await _postService.GetPostByTag(request);
            return new JsonResult(result);
        }

        [Route("danh-muc/{slug}")]
        [HttpGet]
        public async Task<IActionResult> Category()
        {
            ViewData["ListMostView"] = await _postService.GetPostMostView();
            return View();
        }

        [Route("categorysearch")]
        [HttpPost]
        public async Task<IActionResult> CategorySearch([FromBody] PagingSearchRequest request)
        {
            request.PageSize = 10;
            var result = await _postService.GetPostByCategory(request);
            return new JsonResult(result);
        }

        [Route("tu-khoa/{slug}")]
        [HttpGet]
        public async Task<IActionResult> Title()
        {
            ViewData["ListMostView"] = await _postService.GetPostMostView();
            return View();
        }

        [Route("titlesearch")]
        [HttpPost]
        public async Task<IActionResult> TitleSearch([FromBody] PagingSearchRequest request)
        {
            request.PageSize = 10;
            var result = await _postService.GetPostByKeyword(request);
            return new JsonResult(result);
        }
    }
}
