using Blog.Data.Entities;
using Blog.Data.Enums;
using Blog.ViewModel.Catalog.Category;
using Blog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Catalog.CategoryService
{
    public interface ICategoryService
    {
        // for ADMIN

        Task<PagingResponse<List<CategoryVm>>> GetAllCategories(PagingRequest request);
        Task<bool> CreateCategory(CreateCategoryModel model);
        Task<bool> UpdateCategory(UpdateCategoryModel model);
        Task<bool> DeleteCategory(int id);

        Task<bool> ChangeStatus(UpdateCategoryStatusModel model);

        Task<Category> GetCategory(int id);


        // for user

        Task<List<CategoryVm>> GetAllPublicCategories();
    }
}
