using Blog.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.Catalog.Category
{
    public class UpdateCategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public string Slug { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public Status Status { get; set; }
    }
}
