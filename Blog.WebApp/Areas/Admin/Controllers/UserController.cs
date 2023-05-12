using Blog.Application.System.RoleService;
using Blog.Application.System.UserService;
using Blog.ViewModel.Common;
using Blog.ViewModel.System.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public UserController(IUserService userService,IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GetAllUsers([FromBody] PagingRequest request)
        {
            var result = await _userService.GetAllUser(request);

            return new JsonResult(result);
        }


        [HttpPatch]
        public async Task<IActionResult> ChangeAvatar([FromForm] ChangeUserAvatarModel model)
        {
            var result = await _userService.ChangeAvatar(model);

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userService.GetUser(id);

            return View(user);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateUserModel model)
        {
            var result = await _userService.UpdateUser(model);

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Role(string id)
        {
            
            ViewBag.ListCurrentRoles = await _roleService.GetListRolesUser(id);
            ViewBag.CurrentId = id;
            var listRole = await _roleService.GetListRoles();


            return View(listRole);
        }

        [HttpPut]
        public async Task<IActionResult> RegisterRoles([FromBody] RegisterRoleModel model)
        {
            var result = await _roleService.RegisterRoles(model);

            return new JsonResult(result);
        }

    }
}
