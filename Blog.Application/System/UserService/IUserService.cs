using Blog.Data.Entities;
using Blog.ViewModel.Common;
using Blog.ViewModel.System.Role;
using Blog.ViewModel.System.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.System.UserService
{
    public interface IUserService
    {
        public Task<PagingResponse<List<UserVm>>> GetAllUser(PagingRequest request);

        public Task<UserApplication> GetUser(string id);
        public Task<JsonResponse> UpdateUser(UpdateUserModel model);
        public Task<JsonResponse> BlockUser(string id);
        public Task<JsonResponse> UnBlockUser(string id);
        public Task<JsonResponse> ChangeAvatar(ChangeUserAvatarModel model);
        public Task<UserVm> GetUserByUserName(string userName);

        public Task<JsonResponse> ChangePassword(ChangePasswordModel model);

    }
}
