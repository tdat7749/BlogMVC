using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Common.FileStorageService
{
    public interface IFileStorageService
    {
        bool UploadImageAsync(IFormFile file);

        DirectoryInfo FileExplorer();
    }
}
