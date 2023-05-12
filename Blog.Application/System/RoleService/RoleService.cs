using Blog.Data.Entities;
using Blog.ViewModel.Common;
using Blog.ViewModel.System.Role;
using Blog.ViewModel.System.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.System.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<UserApplication> _userManager;


        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<UserApplication> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<List<RoleVm>> GetListRoles()
        {
            var listRole = await _roleManager.Roles.ToListAsync();

            var listRoleVm = listRole.Select(x => new RoleVm()
            {
                Id = x.Id,
                Role = x.Name
            }).ToList();

            return listRoleVm;
        }

        public async Task<JsonResponse> RegisterRoles(RegisterRoleModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return new JsonResponse()
                    {
                        Message = "Người dùng không tồn tại",
                        Success = false
                    };
                }

                var listCurrentRoles = await _userManager.GetRolesAsync(user);

                // Thêm các role chưa có vào
                foreach (var item in model.ListRoles)
                {
                    //Nếu trong list role muốn update có role đã nằm sẵn trong listCurrentRole rồi thì bỏ qua
                    if (listCurrentRoles.Contains(item))
                    {
                        continue;
                    }
                    else //Nếu chưa có thì add role đó vào user
                    {
                        var result = await _userManager.AddToRoleAsync(user, item);
                        if (!result.Succeeded)
                        {
                            return new JsonResponse()
                            {
                                Message = "Đăng ký quyền cho người dùng thất bại",
                                Success = false
                            };
                        }
                    }
                }

                // Xóa các role khi update
                foreach (var item in listCurrentRoles)
                {
                    //Nếu có role trong listCurrentRoles có tồn tại trong listRole thì bỏ qua, nghĩa là không cần phải xóa
                    if (model.ListRoles.Contains(item))
                    {
                        continue;
                    }
                    else // Ngược lại nếu không có thì xóa đi
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, item);
                        if (!result.Succeeded)
                        {
                            return new JsonResponse()
                            {
                                Message = "Đăng ký quyền cho người dùng thất bại",
                                Success = false
                            };
                        }
                    }
                }

                return new JsonResponse()
                {
                    Message = "Đăng ký quyền thành công",
                    Success = true
                };

            }
            catch (Exception)
            {
                return new JsonResponse()
                {
                    Message = "Có lỗi xảy ra",
                    Success = false
                };
            }
        }

        public async Task<List<string>> GetListRolesUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            var listRoles = (List<string>)await _userManager.GetRolesAsync(user);


            return listRoles;
        }
    }
}
