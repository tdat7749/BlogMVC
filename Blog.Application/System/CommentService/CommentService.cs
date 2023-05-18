using Blog.Data.EF;
using Blog.Data.Entities;
using Blog.ViewModel.Common;
using Blog.ViewModel.System.Comment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.System.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly BlogDbContext _context;
        public CommentService(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<JsonResponse> AddComment(AddCommentModel model)
        {
            try
            {
                if (String.IsNullOrEmpty(model.Comment))
                {
                    return new JsonResponse()
                    {
                        Message = "Bình luận của bạn đang trống",
                        Success = false
                    };
                }

                var comment = new Comment()
                {
                    Content = model.Comment,
                    UserId = model.UserId,
                    PostId = model.PostId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return new JsonResponse()
                {
                    Message = "Thêm bình luận thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new JsonResponse()
                {
                    Message = "Có lỗi xảy ra, vui lòng thử lại sau",
                    Success = false
                };
            }
        }

        public async Task<JsonResponse> DeleteComment(int id)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(id);
                if (comment == null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Bình luận này không tồn tại hoặc bị lỗi",
                        Success = false
                    };
                }

                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
                return new JsonResponse()
                {
                    Message = "Xóa bình luận thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new JsonResponse()
                {
                    Message = "Có lỗi xảy ra, vui lòng thử lại sau",
                    Success = false
                };
            }
        }

        public async Task<JsonResponse> EditComment(EditCommentModel model)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(model.Id);
                if (comment == null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Bình luận này không tồn tại hoặc bị lỗi",
                        Success = false
                    };
                }

                comment.Content = model.Comment;

                _context.Comments.Update(comment);
                await _context.SaveChangesAsync();
                return new JsonResponse()
                {
                    Message = "Sửa bình luận thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new JsonResponse()
                {
                    Message = "Có lỗi xảy ra, vui lòng thử lại sau",
                    Success = false
                };
            }
        }

        public async Task<PagingResponse<List<CommentVm>>> GetComment(PagingRequest request)
        {
            try
            {
                int TotalPage, TotalRecord;

                var query = (from c in _context.Comments
                             join u in _context.Users on c.UserId equals u.Id
                             where c.PostId == request.PostId
                             select new { c, u });

                TotalRecord = query.Count();

                TotalPage = (int)Math.Ceiling((double)TotalRecord /request.PageSize);

                query = query.OrderByDescending(x => x.c.CreatedAt).Skip(request.PageSize * (request.PageIndex - 1)).Take(request.PageSize);


                var result = await query.Select(x => new CommentVm()
                {
                    Id = x.c.Id,
                    Comment = x.c.Content,
                    CreatedAt = x.c.CreatedAt.ToString(),
                    PostId = x.c.PostId,
                    UserId = x.c.UserId,
                    UserName = x.u.UserName,
                    FirstName = x.u.FirstName,
                    LastName = x.u.LastName,
                    Avatar = x.u.Avatar
                }).ToListAsync();

                return new PagingResponse<List<CommentVm>>()
                {
                    Data = result,
                    TotalPage = TotalPage,
                    TotalRecord = TotalRecord
                };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
