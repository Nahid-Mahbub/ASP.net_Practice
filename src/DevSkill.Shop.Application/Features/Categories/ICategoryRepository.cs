using DevSkill.Shop.Domain.Contracts;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Application.Features.Categories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}