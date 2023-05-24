using Blog.Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.System.Carousel
{
    public class UpdateCarouselModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Url { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
    }
}
