using Blog.Data.Entities;
using Blog.ViewModel.Catalog.Tag;
using Blog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Catalog.TagService
{
    public interface ITagService
    {
        //ADMIN
        Task<PagingResponse<List<TagVm>>> GetAllTags(PagingRequest request);
        Task<JsonResponse> UpdateTag(UpdateTagModel model);
        Task<JsonResponse> CreateTag(CreateTagModel model);
        Task<JsonResponse> DeleteTag(int id);

        Task<JsonResponse> ChangeStatus(UpdateTagStatusModel model);

        Task<Tag> GetTag(int id);

        // Client
        Task<List<TagVm>> GetAllPublicTags();
    }
}
