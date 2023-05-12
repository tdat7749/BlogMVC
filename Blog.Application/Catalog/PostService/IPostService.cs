using Blog.Data.Entities;
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
        Task<PagingResponse<List<PostListVm>>> GetAllPost(PagingRequest request);
        Task<JsonResponse> CreatePost(CreatePostModel model);
        Task<JsonResponse> UpdatePost(UpdatePostModel model);
        Task<JsonResponse> DeletePost(int id);
        Task<JsonResponse> ChangePublished(UpdatePostPublishedModel model);
        Task<Post> GetPostForEdit(int id);


        // CLIENT
        Task<PagingResponse<List<PostListVm>>> GetPublicAllPost(PagingRequest request);
        Task<List<PostListVm>> GetPostLatest();
        Task<PostVm> GetPostBySlug(string slug);

        void PlusViewPost(int id);

    }
}
