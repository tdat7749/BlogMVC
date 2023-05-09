using Blog.Data.EF;
using Blog.Data.Entities;
using Blog.Data.Enums;
using Blog.ViewModel.Catalog.Tag;
using Blog.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Catalog.TagService
{
    public class TagService : ITagService
    {

        private readonly BlogDbContext _context;
        public TagService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResponse> ChangeStatus(UpdateTagStatusModel model)
        {
            try
            {
                var tag = await _context.Tags.FindAsync(model.Id);
                if (tag == null) return new JsonResponse()
                {
                    Message = $"Không tồn tại tag với ID = {model.Id}",
                    Success = false
                };

                tag.Status = model.Status;

                _context.Tags.Update(tag);
                await _context.SaveChangesAsync();
                return new JsonResponse()
                {
                    Message = "Đổi trạng thái thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<JsonResponse> CreateTag(CreateTagModel model)
        {
            try
            {
                var checkSlugTag = await _context.Tags.FirstOrDefaultAsync(x => x.Slug == model.Slug);
                if (checkSlugTag != null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Slug = {model.Slug} đã tồn tại",
                        Success = false
                    };
                }
                var tag = new Tag()
                {
                    Name = model.Name,
                    Slug = model.Slug,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Status = Status.Disable
                };

                _context.Tags.Add(tag);
                await _context.SaveChangesAsync();
                return new JsonResponse()
                {
                    Message = "Tạo mới thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<JsonResponse> DeleteTag(int id)
        {
            try
            {
                var tag = await _context.Tags.FindAsync(id);
                if (tag == null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Không tồn tại tag với Id = {id}",
                        Success = false
                    };
                }

                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
                return new JsonResponse()
                {
                    Message = "Xóa thành công",
                    Success = true
                };
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        public async Task<List<TagVm>> GetAllPublicTags()
        {
            var query = from t in _context.Tags
                        where t.Status == Status.Enable
                        select t;

            var result = await query.Select(x => new TagVm()
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Status = x.Status,
            }).ToListAsync();

            return result;
        }

        public async Task<PagingResponse<List<TagVm>>> GetAllTags(PagingRequest request)
        {

            int TotalPage, TotalRecord;
            var query = from t in _context.Tags
                        select t;



            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            TotalRecord = query.Count();

            query = query.Skip(request.PageSize * (request.PageIndex - 1)).Take(request.PageSize);


            TotalPage = (int)Math.Ceiling((double)TotalRecord / request.PageSize);

            var result = await query.Select(x => new TagVm()
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Status = x.Status
            }).ToListAsync();

            return new PagingResponse<List<TagVm>>()
            {
                Data = result,
                TotalPage = TotalPage,
                TotalRecord = TotalRecord
            };
        }

        public async Task<Tag> GetTag(int id)
        {
            try
            {
                var tag = await _context.Tags.FindAsync(id);
                if (tag == null) return null;

                return tag;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<JsonResponse> UpdateTag(UpdateTagModel model)
        {
            try
            {
                var tag = await _context.Tags.FindAsync(model.Id);
                if (tag == null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Không tồn tại tag với Id = {model.Id}",
                        Success = false
                    };
                }

                var checkSlugTag = await _context.Tags.FirstOrDefaultAsync(x => x.Slug == model.Slug);
                if (checkSlugTag != null && checkSlugTag != tag)
                {
                    return new JsonResponse()
                    {
                        Message = $"Slug = {model.Slug} đã tồn tại",
                        Success = false
                    };
                }

                tag.Slug = model.Slug;
                tag.Status = model.Status;
                tag.UpdatedAt = DateTime.Now;
                tag.Name = model.Name;

                _context.Tags.Update(tag);

                await _context.SaveChangesAsync();

                return new JsonResponse()
                {
                    Message = "Cập nhật thành công",
                    Success = true
                };

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
