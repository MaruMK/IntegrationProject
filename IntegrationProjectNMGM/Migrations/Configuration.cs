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
                new Category { CategoryId = 1, CategoryName = "root", ParentCategoryId = 0 },
                new Category { CategoryId = 2, CategoryName = "Bicycles", ParentCategoryId = 1 },
                new Category { CategoryId = 3, CategoryName = "Accessories", ParentCategoryId = 1 },
                new Category { CategoryId = 4, CategoryName = "Mountain Bikes", ParentCategoryId = 2 },
                new Category { CategoryId = 5, CategoryName = "Road Bikes", ParentCategoryId = 2 },
                new Category { CategoryId = 6, CategoryName = "Clothing", ParentCategoryId = 3 },
                new Category { CategoryId = 7, CategoryName = "Protective Gear", ParentCategoryId = 3 },
                new Category { CategoryId = 8, CategoryName = "Bike Attachements", ParentCategoryId = 3 }
            );
        }
    }
}
