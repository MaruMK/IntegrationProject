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

            context.Images.AddOrUpdate(
               p => p.ImageId,
               new Image { ImageId = 1, ImageName = "bikeImg1", ImagePath = "../../Content/Images/sampleBike.jpg", ProductId = 1 },
               new Image { ImageId = 2, ImageName = "bikeImg2", ImagePath = "../../Content/Images/sampleBike2.jpg", ProductId = 1 }
             );
        }
    }
}
