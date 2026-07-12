using DevSkill.Shop.Domain.Contracts;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Application.Features.Stocks
{
    public interface IStockRepository : IRepository<Stock, int>
    {
    }
}