using Blog.ViewModel.Common;
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
        Task<JsonResponse> UploadImageAsync(IFormFile file);

        DirectoryInfo FileExplorer();

        Task<string> SaveThumbnailAsync(IFormFile file,string slug);
        void DeleteThumbnail(string fileName);

        Task<string> SaveAvatarAsync(IFormFile file, string id);
        void DeleteAvatar(string fileName);
    }
}
