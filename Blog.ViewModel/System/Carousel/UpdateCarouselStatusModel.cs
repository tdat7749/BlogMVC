﻿using Blog.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.System.Carousel
{
    public class UpdateCarouselStatusModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
}
