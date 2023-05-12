using Blog.Application.Catalog.TagService;
using Blog.Data.Entities;
using Blog.ViewModel.Catalog.Tag;
using Blog.ViewModel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllTags([FromBody]PagingRequest request)
        {
            var result = await _tagService.GetAllTags(request);
            return new JsonResult(result);
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeStatus([FromBody] UpdateTagStatusModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _tagService.ChangeStatus(model);

            return new JsonResult(result);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _tagService.DeleteTag(id);

            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _tagService.CreateTag(model);

            return new JsonResult(result);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var tag = await _tagService.GetTag(id);
            return View(tag);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateTagModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _tagService.UpdateTag(model);

            return new JsonResult(result);
        }

    }
}
