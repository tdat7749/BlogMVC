using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.System.Carousel
{
    public class CreateCarouselModel
    {
        public string Name { get; set; }
        public IFormFile Url { get; set; }
        public int SortOrder { get; set; }
    }
}
