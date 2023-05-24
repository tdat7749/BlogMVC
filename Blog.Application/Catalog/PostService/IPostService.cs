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

        // Hàm này để cho người khác vào xem trang cá nhân của tác giả thì hiện lên (chỉ hiện thị những bài public)
        Task<PagingResponse<List<PostListVm>>> GetListPostsUser(PagingRequest request);

        // Hàm này hiển thị các bài viết của bản thân tài khoản
        Task<PagingResponse<List<PostListVm>>> GetListPostPersonal(PagingRequest request);
        Task<List<PostListVm>> GetPostMostView();
        void PlusViewPost(int id);

        Task<PagingResponse<List<PostListVm>>> GetPostByTag(PagingSearchRequest request);
        Task<PagingResponse<List<PostListVm>>> GetPostByCategory(PagingSearchRequest request);
        Task<PagingResponse<List<PostListVm>>> GetPostByKeyword(PagingSearchRequest request);


    }
}
