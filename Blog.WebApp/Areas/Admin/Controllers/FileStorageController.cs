using Blog.Application.Common.FileStorageService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class FileStorageController : Controller
    {
        private readonly IFileStorageService _fileStorageService;

        public FileStorageController(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        public IActionResult UploadExplorer()
        {
            var dir = _fileStorageService.FileExplorer();
            ViewBag.DirInfo = dir.GetFiles();
            return View();
        }

        [HttpPost]
        public JsonResult UploadImage(IFormFile upload)
        {
            var result = _fileStorageService.UploadImageAsync(upload);
            return new JsonResult(result);

        }
    }
}
