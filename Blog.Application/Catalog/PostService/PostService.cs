using Blog.ViewModel.Catalog.Post;
using Blog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Catalog.PostService
{
    public class PostService : IPostService
    {
        public Task<bool> CreatePost()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePost()
        {
            throw new NotImplementedException();
        }

        public Task<PagingResponse<List<PostVm>>> GetAllPost(PagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostVm>> GetPostLatest()
        {
            throw new NotImplementedException();
        }

        public Task<PagingResponse<List<PostVm>>> GetPublicAllPost(PagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePost()
        {
            throw new NotImplementedException();
        }
    }
}
