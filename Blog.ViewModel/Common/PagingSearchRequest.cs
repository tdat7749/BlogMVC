using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.Common
{
    public class PagingSearchRequest : PagingBase
    {
        public string Slug { get; set; }
    }
}
