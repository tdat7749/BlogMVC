using Blog.ViewModel.Common;
using Blog.ViewModel.System.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.System.AuthenService
{
    public interface IAuthenService
    {
        Task<JsonResponse> Register(RegisterModel model);
        Task<JsonResponse> Login(LoginModel model);

        Task<JsonResponse> ForgotPassword(string email);
        Task<JsonResponse> Logout();
    }
}
