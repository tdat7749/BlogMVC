using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Slug { get; set; }
        public string Body { get; set; }
        public bool Published { get; set; }

        public int View { get; set; }
        

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string UserId { get; set; }
        public UserApplication User { get; set; } 

        public List<Comment> Comments { get; set; }
        public List<PostInTag> PostInTags { get; set; }

    }
}
