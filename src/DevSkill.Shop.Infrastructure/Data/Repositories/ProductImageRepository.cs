using DevSkill.Shop.Application.Features;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Infrastructure.Data.Repositories
{
    public class ProductImageRepository
        : Repository<ProductImage, int>, IProductImageRepository
    {
        public ProductImageRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}