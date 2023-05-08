using Blog.ViewModel.Catalog.Post;
using Blog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Catalog.PostService
{
    public interface IPostService
    {
        //Admin
        Task<PagingResponse<List<PostVm>>> GetAllPost(PagingRequest request);
        Task<bool> CreatePost();
        Task<bool> UpdatePost();
        Task<bool> DeletePost();


        // CLIENT
        Task<PagingResponse<List<PostVm>>> GetPublicAllPost(PagingRequest request);
        Task<List<PostVm>> GetPostLatest();

    }
}
