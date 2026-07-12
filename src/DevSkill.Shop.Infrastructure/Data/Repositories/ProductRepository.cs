using DevSkill.Shop.Application.Features.Products;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Infrastructure.Data.Repositories
{
    public class ProductRepository
        : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}