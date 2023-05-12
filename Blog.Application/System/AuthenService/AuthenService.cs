using Blog.Data.EF;
using Blog.Data.Entities;
using Blog.ViewModel.Common;
using Blog.ViewModel.System.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.System.AuthenService
{
    public class AuthenService : IAuthenService
    {
        private readonly BlogDbContext _context;
        private readonly UserManager<UserApplication> _userManage;
        private readonly SignInManager<UserApplication> _signInManager;

        public AuthenService(BlogDbContext context, UserManager<UserApplication> userManage, SignInManager<UserApplication> signInManager)
        {
            _context = context;
            _userManage = userManage;
            _signInManager = signInManager;
        }

        public async Task<JsonResponse> Login(LoginModel model)
        {
            try {
                // Mã hóa thông tin người dùng thành Base64

                //var userNameBytes = Encoding.UTF8.GetBytes(model.UserName);
                //var passwordBytes = Encoding.UTF8.GetBytes(model.Password);
                //var userNameBase64 = Convert.ToBase64String(userNameBytes);
                //var passwordBase64 = Convert.ToBase64String(passwordBytes);

                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (!result.Succeeded)
                {
                    var user = await _userManage.FindByNameAsync(model.UserName);
                    if (user == null)
                    {
                        return new JsonResponse()
                        {
                            Message = "Tài khoản không tồn tại",
                            Success = false
                        };
                    }
                    result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe,false);

                    if (!result.Succeeded)
                    {
                        return new JsonResponse()
                        {
                            Message = "Sai mật khẩu",
                            Success = false
                        };
                    }
                }

                if (result.IsLockedOut)
                {
                    return new JsonResponse()
                    {
                        Message = "Tài khoản đã bị khóa",
                        Success = false
                    };
                }

                return new JsonResponse()
                {
                    Message = "Đăng nhập thành công",
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

        public Task<JsonResponse> Logout()
        {
            throw new NotImplementedException();
        }

        public Task<JsonResponse> Register(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
