using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.ViewModel.Common;

namespace Blog.Application.Common.FileStorageService
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<JsonResponse> UploadImageAsync(IFormFile file)
        {
            try
            {
                if(file != null)
                {
                    var fileName = DateTime.Now.ToString("yyyyMMddHmmss") + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), _webHostEnvironment.WebRootPath, "upload-images", fileName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
                    return new JsonResponse()
                    {
                        Message = $"Upload thành công",
                        Success = true,
                    };
                }
                return new JsonResponse()
                {
                    Message = "Upload thất bại",
                    Success = false
                };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public DirectoryInfo FileExplorer()
        {
            var dir = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), _webHostEnvironment.WebRootPath, "upload-images"));
            return dir;
        }

        public async Task<string> SaveThumbnailAsync(IFormFile file, string slug)
        {
            try
            {
                var fileName = slug + file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), _webHostEnvironment.WebRootPath, "thumbnail", fileName);
                var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
                return fileName;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteThumbnail(string fileName)
        {
            try
            {
                var pathFile = Path.Combine(Directory.GetCurrentDirectory(), _webHostEnvironment.WebRootPath, "thumbnail", fileName);
                if (File.Exists(pathFile))
                {
                    File.Delete(pathFile);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<string> SaveAvatarAsync(IFormFile file, string id)
        {
            try
            {
                var fileName = id + file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), _webHostEnvironment.WebRootPath, "avatar", fileName);
                var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
                return fileName;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteAvatar(string fileName)
        {
            try
            {
                var pathFile = Path.Combine(Directory.GetCurrentDirectory(), _webHostEnvironment.WebRootPath, "avatar", fileName);
                if (File.Exists(pathFile))
                {
                    File.Delete(pathFile);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
