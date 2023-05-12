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

        Task<List<CategoryVm>> GetListCategories();
        Task<PagingResponse<List<CategoryVm>>> GetAllCategories(PagingRequest request);
        Task<JsonResponse> CreateCategory(CreateCategoryModel model);
        Task<JsonResponse> UpdateCategory(UpdateCategoryModel model);
        Task<JsonResponse> DeleteCategory(int id);

        Task<JsonResponse> ChangeStatus(UpdateCategoryStatusModel model);

        Task<Category> GetCategory(int id);


        // for user

        Task<List<CategoryVm>> GetAllPublicCategories();
    }
}
