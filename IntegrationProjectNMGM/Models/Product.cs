﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace IntegrationProjectNMGM.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double MSRP { get; set; }
        public double CurrentPrice { get; set; }
        public bool Enabled { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<Review> Reveiws { get; set; }

        public virtual ICollection<ProductCategories> ProductCategories { get; set; }
    }
}