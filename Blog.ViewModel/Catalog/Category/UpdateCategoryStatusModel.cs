using Blog.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.Catalog.Category
{
    public class UpdateCategoryStatusModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
}
