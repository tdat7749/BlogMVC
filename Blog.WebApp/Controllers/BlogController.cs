using Blog.Application.Catalog.CategoryService;
using Blog.Application.Catalog.PostService;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Controllers
{
    [Route("bai-viet")]
    public class BlogController : BaseController
    {
        private readonly IPostService _postService;

        public BlogController(ICategoryService categoryService,IPostService postService) : base(categoryService)
        {
            _postService = postService;
        }

        [Route("{slug}")]
        [HttpGet("")]
        public async  Task<IActionResult> Index(string slug)
        {
            var post = await _postService.GetPostBySlug(slug);
            ViewData["ListMostView"] = await _postService.GetPostMostView();
            if (String.IsNullOrEmpty(slug))
            {
                return NotFound();
            }
            return View(post);
        }
    }
}
