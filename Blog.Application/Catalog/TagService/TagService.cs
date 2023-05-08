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
        public async Task<bool> CreateTag(CreateTagModel model)
        {
            try
            {
                var tag = new Tag()
                {
                    Name = model.Name,
                    Slug = model.Slug,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Status = Status.Disable
                };

                _context.Tags.Add(tag);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<bool> DeleteTag(int id)
        {
            try
            {
                var tag = await _context.Tags.FindAsync(id);
                if (tag == null) return false;

                _context.Tags.Remove(tag);
                return await _context.SaveChangesAsync() > 0;
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
            var query = from c in _context.Tags
                        select c;



            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            TotalRecord = query.Count();

            query = query.Skip(request.PageSize * (request.PageIndex - 1)).Take(request.PageSize);


            TotalPage = (int)Math.Ceiling((double)TotalRecord / query.Count());

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

        public async Task<bool> UpdateTag(UpdateTagModel model)
        {
            try
            {
                var tag = await _context.Tags.FindAsync(model.Id);
                if (tag == null) return false;

                tag.Slug = model.Slug;
                tag.Status = model.Status;
                tag.UpdatedAt = DateTime.Now;
                tag.Name = model.Name;

                _context.Tags.Update(tag);

                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
