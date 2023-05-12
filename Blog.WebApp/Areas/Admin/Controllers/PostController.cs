using Blog.Application.Catalog.CategoryService;
using Blog.Application.Catalog.PostService;
using Blog.Application.Catalog.TagService;
using Blog.ViewModel.Catalog.Post;
using Blog.ViewModel.Common;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        public PostController(IPostService postService,ICategoryService categoryService,ITagService tagService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllPosts([FromBody]PagingRequest request)
        {
            var result = await _postService.GetAllPost(request);
            return new JsonResult(result);
        }

        [HttpPatch]
        public async Task<IActionResult> ChangePublished([FromBody] UpdatePostPublishedModel model)
        {
            var result = await _postService.ChangePublished(model);
            return new JsonResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            var result = await _postService.DeletePost(id);
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePostModel model)
        {
            var result = await _postService.CreatePost(model);
            return new JsonResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromForm] UpdatePostModel model)
        {
            var result = await _postService.UpdatePost(model);
            return new JsonResult(result);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var post = await _postService.GetPostForEdit(id);
            var listTags = await _tagService.GetListTags();
            var listCategories = await _categoryService.GetListCategories();

            ViewBag.ListTags = listTags;
            ViewBag.ListCategories = listCategories;

            var viewPost = new UpdatePostModel()
            {
                Id = post.Id,
                Slug = post.Slug,
                IsPublished = post.Published,
                Body = post.Body,
                CategoryId = post.CategoryId,
                PreviewThumbnail = post.Thumbnail,
                Tags = post.PostInTags.Select(x => x.TagId).ToList(),
                Title = post.Title
            };

            return View(viewPost);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var listTags = await _tagService.GetListTags();
            var listCategories = await _categoryService.GetListCategories();

            ViewBag.ListTags = listTags;
            ViewBag.ListCategories = listCategories;
            return View();
        }
    }
}
