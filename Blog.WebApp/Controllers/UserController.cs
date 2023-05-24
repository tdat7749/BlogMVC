using Blog.Application.Catalog.CategoryService;
using Blog.Application.Catalog.PostService;
using Blog.Application.Catalog.TagService;
using Blog.Application.System.UserService;
using Blog.ViewModel.Catalog.Post;
using Blog.ViewModel.Common;
using Blog.ViewModel.System.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.WebApp.Controllers
{
    [Route("tai-khoan")]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        public UserController(IUserService userService,IPostService postService,ICategoryService categoryService,ITagService tagService) : base(categoryService)
        {
            _userService = userService;
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        [AllowAnonymous]
        [Route("")]        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUserId = User.FindFirstValue("Id");
            var result = await _userService.GetUser(currentUserId);
            return View(result);
        }

        [AllowAnonymous]
        [Route("thong-tin-ca-nhan")]
        [HttpGet]
        public async Task<IActionResult> Information()
        {
            var currentUserId = User.FindFirstValue("Id");
            var result = await _userService.GetUser(currentUserId);
            return PartialView("_Information",result);
        }

        [AllowAnonymous]
        [Route("doi-mat-khau")]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return PartialView("_ChangePassword");
        }

        [AllowAnonymous]
        [Route("tat-ca-bai-viet")]
        [HttpGet]
        public IActionResult AllPosts()
        {
            return PartialView("_AllPosts");
        }

        [Authorize(Roles = "Tác Giả, Quản Trị Viên")]
        [Route("tao-bai-viet")]
        [HttpGet]
        public async Task<IActionResult> CreatePost()
        {
            var listTags = await _tagService.GetListTags();
            var listCategories = await _categoryService.GetListCategories();

            ViewBag.ListTags = listTags;
            ViewBag.ListCategories = listCategories;
            return PartialView("_CreatePost");
        }

        [AllowAnonymous]
        [Route("thay-hinh-dai-dien")]
        [HttpPatch]
        public async Task<IActionResult> ChangeAvatar([FromForm] ChangeUserAvatarModel model)
        {
            var result = await _userService.ChangeAvatar(model);
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateUserModel model)
        {
            var result = await _userService.UpdateUser(model);
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [Route("doi-mat-khau")]
        [HttpPatch]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var result = await _userService.ChangePassword(model);
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AllPost([FromBody] PagingRequest request)
        {
            request.PageSize = 6;
            var result = await _postService.GetListPostPersonal(request);
            return new JsonResult(result);
        }

        [Authorize(Roles ="Tác Giả, Quản Trị Viên")]
        [Route("create-post")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePostModel model)
        {
            var result = await _postService.CreatePost(model);
            return new JsonResult(result);
        }

    }
}
