using Blog.ViewModel.Catalog.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.Catalog.Post
{
    public class PostVm
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Slug { get; set; }
        public string Body { get; set; }
        public bool Published { get; set; }

        public int View { get; set; }

        public string Thumbnail { get; set; }
        public string Category { get; set; }
        public List<TagVm> ListTags { get; set; }
    }
}
