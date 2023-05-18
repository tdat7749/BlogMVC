using Blog.ViewModel.Common;
using Blog.ViewModel.System.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.System.CommentService
{
    public interface ICommentService
    {
        Task<PagingResponse<List<CommentVm>>> GetComment(PagingRequest request);

        Task<JsonResponse> EditComment(EditCommentModel model);
        Task<JsonResponse> AddComment(AddCommentModel model);
        Task<JsonResponse> DeleteComment(int id);

    }
}
