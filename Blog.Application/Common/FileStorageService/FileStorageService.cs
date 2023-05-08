using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Common.FileStorageService
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public bool UploadImageAsync(IFormFile file)
        {
            try
            {
                if(file != null)
                {
                    var fileName = DateTime.Now.ToString("yyyyMMddHmmss") + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),_webHostEnvironment.WebRootPath,"upload-images",fileName);
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);
                    return true;
                }
                return false;
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
    }
}
