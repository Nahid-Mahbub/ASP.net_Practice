using DevSkill.Shop.Application.Features.Categories;
using DevSkill.Shop.Domain.Entities;


namespace DevSkill.Shop.Infrastructure.Data.Repositories
{
    public class CategoryRepository
        : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}