using DevSkill.Shop.Application.Features.Stocks;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Infrastructure.Data.Repositories
{
    public class StockRepository
        : Repository<Stock, int>, IStockRepository
    {
        public StockRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}