using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntegrationProjectNMGM.Models
{
    public class IntegrationProjectNMGMContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public IntegrationProjectNMGMContext() : base("name=IntegrationProjectNMGMContext")
        {
        }

        public System.Data.Entity.DbSet<IntegrationProjectNMGM.Models.Category> Categories { get; set; }
        public System.Data.Entity.DbSet<IntegrationProjectNMGM.Models.Product> Products { get; set; }
    }
}
