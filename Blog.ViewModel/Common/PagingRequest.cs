using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.Common
{
    public class PagingRequest : PagingBase
    {
        //tìm kiếm
        public string Keyword { get; set; }

        //filter
        // chia như thế này không biết có đúng hay không, nhưng nếu filter thì dùng 1 trong những cái dưới đây
        public int? PostId { get; set; }

        public string UserName { get; set; }
        public int? CategoryId { get; set; }
        public int? TagId { get; set; }

    }
}
