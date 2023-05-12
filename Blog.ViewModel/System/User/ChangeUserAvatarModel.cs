using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.System.User
{
    public class ChangeUserAvatarModel
    {
        public string Id { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
