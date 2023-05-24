using Blog.Application.System.CommentService;
using Blog.ViewModel.Common;
using Blog.ViewModel.System.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> GetComment([FromBody] PagingRequest request)
        {
            request.PageSize = 10;
            var result = await _commentService.GetComment(request);

            return new JsonResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditCommentModel model)
        {
            var result = await _commentService.EditComment(model);
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCommentModel model)
        {
            var result = await _commentService.AddComment(model);
            return new JsonResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result = await _commentService.DeleteComment(id);
            return new JsonResult(result);
        }
    }
}
