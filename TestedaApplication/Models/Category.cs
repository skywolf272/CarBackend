﻿using System.Collections.Generic;

namespace TestedaApplication.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Car> Cars { get; set; }

    }
}
