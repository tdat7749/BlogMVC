using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.System.Comment
{
    public class AddCommentModel
    {
        public string Comment { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
    }
}
