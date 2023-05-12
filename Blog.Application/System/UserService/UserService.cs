using Blog.Application.Common.FileStorageService;
using Blog.Data.EF;
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

namespace Blog.Application.System.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApplication> _userManager;
        private readonly IFileStorageService _fileStorageService;
        private readonly BlogDbContext _context;
        public UserService(UserManager<UserApplication> userManager, IFileStorageService fileStorageService, BlogDbContext context)
        {
            _userManager = userManager;
            _fileStorageService = fileStorageService;
            _context = context;
        }

        public async Task<JsonResponse> BlockUser(string id)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(id);
                if(user == null)
                {
                    return new JsonResponse()
                    {
                        Message = "Người dùng này không tồn tại hoặc có lỗi xảy ra",
                        Success = false
                    };
                }
                // Lấy thời gian kết thúc là max 
                var lockoutEndDate = DateTimeOffset.MaxValue;

                var result = await _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);

                if (!result.Succeeded)
                {
                    return new JsonResponse()
                    {
                        Message = "Khóa tài khoản thất bại",
                        Success = false
                    };
                }

                return new JsonResponse()
                {
                    Message = "Khóa tài khoản thành công",
                    Success = false
                };
            }
            catch (Exception)
            {
                return new JsonResponse()
                {
                    Message = "Có lỗi xảy ra",
                    Success = false,
                };
            }
        }

        public async Task<JsonResponse> ChangeAvatar(ChangeUserAvatarModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return new JsonResponse()
                    {
                        Message = "Người dùng này không tồn tại hoặc có lỗi xảy ra",
                        Success = false
                    };
                }

                if(user.Avatar != "abc.jpg")
                {
                    _fileStorageService.DeleteAvatar(user.Avatar);
                }
                user.Avatar = await _fileStorageService.SaveAvatarAsync(model.Avatar, model.Id);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return new JsonResponse()
                {
                    Message = "Đổi ảnh đại diện thành công",
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

        public async Task<PagingResponse<List<UserVm>>> GetAllUser(PagingRequest request)
        {
            int TotalPage, TotalRecord;
            var query = from u in _context.Users
                        select u;


            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.Keyword));
            }

            TotalRecord = query.Count();

            query = query.Skip(request.PageSize * (request.PageIndex - 1)).Take(request.PageSize);


            TotalPage = (int)Math.Ceiling((double)TotalRecord / request.PageSize);

            var result = await query.Select(x => new UserVm()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                UserName = x.UserName
            }).ToListAsync();

            return new PagingResponse<List<UserVm>>()
            {
                Data = result,
                TotalPage = TotalPage,
                TotalRecord = TotalRecord
            };
        }

        public async Task<UserApplication> GetUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if(user == null)
                {
                    return null;
                }

                var userVm = new UserApplication()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Avatar = user.Avatar,
                    PhoneNumber = user.PhoneNumber
                };

                return userVm;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


        public async Task<JsonResponse> UnBlockUser(string id)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(id);
                if (user == null)
                {
                    return new JsonResponse()
                    {
                        Message = "Người dùng này không tồn tại hoặc có lỗi xảy ra",
                        Success = false
                    };
                }
                // Lấy thời gian trước khi khóa tài khoản để mở
                var lockoutEndDate = DateTimeOffset.Now.AddDays(-100);

                var result = await _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);

                if (!result.Succeeded)
                {
                    return new JsonResponse()
                    {
                        Message = "Mở khóa tài khoản thất bại",
                        Success = false
                    };
                }

                return new JsonResponse()
                {
                    Message = "Mở khóa tài khoản thành công",
                    Success = false
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

        public async Task<JsonResponse> UpdateUser(UpdateUserModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if(user == null)
                {
                    return new JsonResponse()
                    {
                        Message = "Người dùng này không tồn tại",
                        Success = false
                    };
                }

                var checkEmailUser = await _userManager.FindByEmailAsync(model.Email);
                if(checkEmailUser != null && checkEmailUser != user)
                {
                    return new JsonResponse()
                    {
                        Message = "Email này đã có người sử dụng",
                        Success = false
                    };
                }

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return new JsonResponse()
                {
                    Message = "Cập nhật thông tin thành công",
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
    }
}
