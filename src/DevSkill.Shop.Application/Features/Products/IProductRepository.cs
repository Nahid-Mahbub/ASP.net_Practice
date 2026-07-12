using DevSkill.Shop.Domain.Contracts;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Application.Features.Products
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}