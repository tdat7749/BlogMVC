using Blog.Data.EF;
using Blog.Data.Entities;
using Blog.Data.Enums;
using Blog.ViewModel.Catalog.Category;
using Blog.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Catalog.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogDbContext _context;
        public CategoryService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResponse> ChangeStatus(UpdateCategoryStatusModel model)
        {
            try
            {
                var category = await _context.Categories.FindAsync(model.Id);
                if (category == null) return new JsonResponse()
                {
                    Message = $"Không tồn tại danh mục với ID = {model.Id}",
                    Success = false
                };

                category.Status = model.Status;

                _context.Categories.Update(category);
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

        public async Task<JsonResponse> CreateCategory(CreateCategoryModel model)
        {
            try
            {
                var checkSlug = await _context.Categories.FirstOrDefaultAsync(c => c.Slug == model.Slug);
                if(checkSlug != null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Slug = {model.Slug} đã tồn tại",
                        Success = false
                    };
                }
                var category = new Category()
                {
                    Name = model.Name,
                    Slug = model.Slug,
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return new JsonResponse()
                {
                    Message = "Tạo mới thành công",
                    Success = true
                }; ;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<JsonResponse> DeleteCategory(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Không tồn tại danh mục với Id = {id}",
                        Success = false
                    };
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return new JsonResponse()
                {
                    Message = "Xóa thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<PagingResponse<List<CategoryVm>>> GetAllCategories(PagingRequest request)
        {
            int TotalPage, TotalRecord;
            var query = from c in _context.Categories
                        select c;


            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            TotalRecord = query.Count();

            query = query.Skip(request.PageSize * (request.PageIndex - 1)).Take(request.PageSize);


            TotalPage = (int)Math.Ceiling((double)TotalRecord / request.PageSize);

            var result = await query.Select(x => new CategoryVm()
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Status = x.Status
            }).ToListAsync();

            return new PagingResponse<List<CategoryVm>>()
            {
                Data = result,
                TotalPage = TotalPage,
                TotalRecord = TotalRecord
            };
        }

        public async Task<List<CategoryVm>> GetAllPublicCategories()
        {
            var query = from c in _context.Categories
                        where c.Status == Status.Enable
                        select c;

            var result = await query.Select(x => new CategoryVm()
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Status = x.Status
            }).ToListAsync();

            return result;
        }

        public async Task<Category> GetCategory(int id)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null) return null;
                return category;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<JsonResponse> UpdateCategory(UpdateCategoryModel model)
        {
            try
            {
                var category = await _context.Categories.FindAsync(model.Id);

                if (category == null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Không tồn tại danh mục với Id = ${model.Id}",
                        Success = true
                    };
                }

                var checkSlugCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Slug == model.Slug);
                if (checkSlugCategory != null && checkSlugCategory != category)
                {
                    return new JsonResponse()
                    {
                        Message = $"Slug = ${model.Slug} đã tồn tại",
                        Success = false
                    };
                }

                category.Name = model.Name;
                category.Status = model.Status;
                category.Slug = model.Slug;
                category.UpdatedAt = DateTime.Now;

                _context.Categories.Update(category);
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
