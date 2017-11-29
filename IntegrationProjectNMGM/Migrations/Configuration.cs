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
               new Review { UserID = 1, Rating = 1, ProductId = 1, ReviewDescription = "Product 1 is kinda useless"},
               new Review { UserID = 1, Rating = 4, ProductId = 1, ReviewDescription = "I like it!!!"},
               new Review { UserID = 1, Rating = 5, ProductId = 1, ReviewDescription = "Problem: grandma is stuck"}
             );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Categories.AddOrUpdate(
                p => p.CategoryId,
                new Models.Category { CategoryId = 1, CategoryName = "root", ParentCategoryId = 0 },
                new Models.Category { CategoryId = 2, CategoryName = "Bicycles", ParentCategoryId = 1 },
                new Models.Category { CategoryId = 3, CategoryName = "Accessories", ParentCategoryId = 1 },
                new Models.Category { CategoryId = 4, CategoryName = "Mountain Bikes", ParentCategoryId = 2 },
                new Models.Category { CategoryId = 5, CategoryName = "Road Bikes", ParentCategoryId = 2 },
                new Models.Category { CategoryId = 6, CategoryName = "Clothing", ParentCategoryId = 3 },
                new Models.Category { CategoryId = 7, CategoryName = "Protective Gear", ParentCategoryId = 3 },
                new Models.Category { CategoryId = 8, CategoryName = "Attachements", ParentCategoryId = 3 }
                );
            context.Products.AddOrUpdate(
                p => p.ProductId,
                new Product { ProductName = "Bike1", MSRP = 13.30, CurrentPrice = 1.17, Description = "This is a sample Product" }
                );

            context.Images.AddOrUpdate(
               p => p.ImageId,
               new Image { ImageId = 1, ImageName = "bikeImg1", ImagePath = "../../Content/Images/Products/sampleBike.jpg", ProductId = 1 },
               new Image { ImageId = 2, ImageName = "bikeImg2", ImagePath = "../../Content/Images/Products/sampleBike2.jpg", ProductId = 1 }
             );
        }
    }
}
