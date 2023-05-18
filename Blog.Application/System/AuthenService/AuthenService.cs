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
using System.Security.Claims;

namespace Blog.Application.System.AuthenService
{
    public class AuthenService : IAuthenService
    {
        private readonly BlogDbContext _context;
        private readonly UserManager<UserApplication> _userManager;
        private readonly SignInManager<UserApplication> _signInManager;

        public AuthenService(BlogDbContext context, UserManager<UserApplication> userManage, SignInManager<UserApplication> signInManager)
        {
            _context = context;
            _userManager = userManage;
            _signInManager = signInManager;
        }

        public async Task<JsonResponse> Login(LoginModel model)
        {
            try
            {
                // Mã hóa thông tin người dùng thành Base64

                //var userNameBytes = Encoding.UTF8.GetBytes(model.UserName);
                //var passwordBytes = Encoding.UTF8.GetBytes(model.Password);
                //var userNameBase64 = Convert.ToBase64String(userNameBytes);
                //var passwordBase64 = Convert.ToBase64String(passwordBytes);

                var user = await _userManager.FindByNameAsync(model.UserName);


                if (user == null)
                {
                    return new JsonResponse()
                    {
                        Message = "Tài khoản không tồn tại",
                        Success = false
                    };
                }

                var claims = new List<Claim>()
                    {
                    new Claim("FirstName",user.FirstName),
                    new Claim("LastName",user.LastName),
                    new Claim("Email",user.Email),
                    new Claim("Id",user.Id),
                    new Claim("UserName",user.UserName),
                    new Claim("Avatar",user.Avatar),
                    new Claim("PhoneNumber",user.PhoneNumber)
                    };

                await _userManager.AddClaimsAsync(user, claims);

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                if (!result.Succeeded)
                {
                    return new JsonResponse()
                    {
                        Message = "Sai tài khoản hoặc mật khẩu",
                        Success = false
                    };
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

        public async Task<JsonResponse> Register(RegisterModel model)
        {
            var checkUser = await _userManager.FindByNameAsync(model.UserName);
            if(checkUser != null)
            {
                return new JsonResponse()
                {
                    Message = "Tài khoản này đã tồn tại",
                    Success = false
                };
            }

            var checkEmailUser = await _userManager.FindByEmailAsync(model.Email);
            if(checkEmailUser != null)
            {
                return new JsonResponse()
                {
                    Message = "Email này đã tồn tại",
                    Success = false
                };
            }

            if(model.Password != model.ConfirmPassword)
            {
                return new JsonResponse()
                {
                    Message = "Mật khẩu và xác nhận mật khẩu không khớp",
                    Success = false
                };
            }

            var newUser = new UserApplication()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.Lastname,
                Email = model.Email,
                Avatar = "abc.jpg"
            };

            var user = await _userManager.CreateAsync(newUser,model.Password);
            if (!user.Succeeded)
            {
                return new JsonResponse()
                {
                    Message = "Đăng ký thất bại, vui lòng thử lại sau",
                    Success = false
                };
            }

            return new JsonResponse()
            {
                Message = "Đăng ký thành công",
                Success = true
            };
        }
    }
}
