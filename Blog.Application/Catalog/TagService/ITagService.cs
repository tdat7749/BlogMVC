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
        Task<bool> UpdateTag(UpdateTagModel model);
        Task<bool> CreateTag(CreateTagModel model);
        Task<bool> DeleteTag(int id);

        // Client
        Task<List<TagVm>> GetAllPublicTags();
    }
}
