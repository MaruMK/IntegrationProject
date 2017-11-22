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
        }
    }
}
