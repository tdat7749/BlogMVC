using Blog.Application.Catalog.PostService;
using Blog.ViewModel.Common;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult Index(PagingRequest request)
        {
            var listPost = _postService.GetAllPost(request);
            return View(listPost);
        }
    }
}
