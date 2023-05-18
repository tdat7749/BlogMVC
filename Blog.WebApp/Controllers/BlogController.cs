using Blog.Application.Catalog.PostService;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Controllers
{
    [Route("bai-viet")]
    public class BlogController : Controller
    {
        private readonly IPostService _postService;

        public BlogController(IPostService postService)
        {
            _postService = postService;
        }

        [Route("{slug}")]
        public async  Task<IActionResult> Index(string slug)
        {
            var post = await _postService.GetPostBySlug(slug);
            if(post == null)
            {

            }
            return View(post);
        }
    }
}
