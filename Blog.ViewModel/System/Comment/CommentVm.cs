using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.System.Comment
{
    public class CommentVm
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int PostId { get; set; }
        public string CreatedAt { get; set; }
        public string UserId {get;set;}
        public string UserName {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }
}
