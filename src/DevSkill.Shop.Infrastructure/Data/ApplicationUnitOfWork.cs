using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Application.Features.Products;
using DevSkill.Shop.Application.Features.Stocks;
using DevSkill.Shop.Application.Features.Teams;

using DevSkill.Shop.Application.Features.Categories;
using DevSkill.Shop.Infrastructure.Data.Repositories;

namespace DevSkill.Shop.Infrastructure.Data
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ITeamRepository Teams { get; }
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public IStockRepository Stocks { get; }
        public IProductImageRepository ProductImages { get; }

        public ApplicationUnitOfWork(
            ApplicationDbContext dbContext,
            ITeamRepository teamRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IStockRepository stockRepository,
            IProductImageRepository productImageRepository)
            : base(dbContext)
        {
            Teams = teamRepository;
            Categories = categoryRepository;
            Products = productRepository;
            Stocks = stockRepository;
            ProductImages = productImageRepository;
        }
    }
}