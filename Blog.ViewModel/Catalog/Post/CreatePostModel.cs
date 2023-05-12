using Blog.ViewModel.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.Catalog.Post
{
    public class CreatePostModel
    {
        public string Title { get; set; }

        public string Slug { get; set; }
        public string Body { get; set; }

        public IFormFile Thumbnail { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }

        public List<int> Tags { get; set; }
        public IFormFile File { get; set; }

    }
}
