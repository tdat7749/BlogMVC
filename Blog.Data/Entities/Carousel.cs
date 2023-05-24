﻿using Blog.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Entities
{
    public class Carousel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
