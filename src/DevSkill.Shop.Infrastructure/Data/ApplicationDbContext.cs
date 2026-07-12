using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    IsActive = true,
                    ImageName = "electronics.jpg"
                },
                new Category
                {
                    Id = 2,
                    Name = "Fashion",
                    IsActive = true,
                    ImageName = "fashion.jpg"
                },
                new Category
                {
                    Id = 3,
                    Name = "Books",
                    IsActive = true,
                    ImageName = "books.jpg"
                }
            );
        }
    }
}