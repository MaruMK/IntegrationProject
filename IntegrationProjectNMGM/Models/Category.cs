using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrationProjectNMGM.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Category ParentCategory { get; set; }

        public virtual ICollection<ProductCategories> ProductCategories { get; set; }
    }
}