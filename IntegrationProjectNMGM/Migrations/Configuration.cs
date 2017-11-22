namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using IntegrationProjectNMGM.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<IntegrationProjectNMGM.Models.ProductDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "IntegrationProjectNMGM.Models.ProductDbContext";
        }

        protected override void Seed(IntegrationProjectNMGM.Models.ProductDbContext context)
        {
            context.Reviews.AddOrUpdate(
               p => p.ReviewId,
               new Review { ReviewId = 1, Rating = 1, ProductId = 1, ReviewDescription = "Product 1 is kinda useless" },
               new Review { ReviewId = 2, Rating = 4, ProductId = 1, ReviewDescription = "I like it!!!" },
               new Review { ReviewId = 3, Rating = 5, ProductId = 1, ReviewDescription = "Problem: grandma is stuck" }
             );

            context.Categories.AddOrUpdate(
                p => p.CategoryId,
                new Category { CategoryId = 1, CategoryName = "root", ParentCategory = 0 },
                new Category { CategoryId = 2, CategoryName = "Bicycles", ParentCategory = 1 },
                new Category { CategoryId = 3, CategoryName = "Accessories", ParentCategory = 1 },
                new Category { CategoryId = 4, CategoryName = "Mountain Bikes", ParentCategory = 2 },
                new Category { CategoryId = 5, CategoryName = "Road Bikes", ParentCategory = 2 },
                new Category { CategoryId = 6, CategoryName = "Clothing", ParentCategory = 3 },
                new Category { CategoryId = 7, CategoryName = "Protective Gear", ParentCategory = 3 },
                new Category { CategoryId = 8, CategoryName = "Bike Attachements", ParentCategory = 3 }
            );
        }
    }
}
