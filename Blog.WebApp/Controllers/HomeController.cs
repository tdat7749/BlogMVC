using Blog.Application.Common.FileStorageService;
using Blog.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileStorageService _fileStorageService;

        public HomeController(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}