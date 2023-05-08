using Blog.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.Catalog.Tag
{
    public class TagVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public Status Status { get; set; }
    }
}
