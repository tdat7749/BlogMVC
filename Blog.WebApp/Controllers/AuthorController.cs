﻿using Blog.Application.Catalog.CategoryService;
using Blog.Application.Catalog.PostService;
using Blog.Application.System.UserService;
using Blog.ViewModel.Common;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Controllers
{
    [Route("thanh-vien")]
    public class AuthorController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        public AuthorController(ICategoryService categoryService,IUserService userService, IPostService postService) : base(categoryService)
        {
            _userService = userService;
            _postService = postService;
        }


        [HttpGet("{username}")]
        public async Task<IActionResult> Index(string username)
        {
            var user = await _userService.GetUserByUserName(username);
            return View(user);
        }

        public async Task<IActionResult> GetListPostsUser([FromBody]PagingRequest request)
        {
            request.PageSize = 10;
            var listPost = await _postService.GetListPostsUser(request);

            return new JsonResult(listPost);
        }
    }
}
