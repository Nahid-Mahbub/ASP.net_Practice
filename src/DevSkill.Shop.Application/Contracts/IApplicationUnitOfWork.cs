using DevSkill.Shop.Application.Features.Products;
using DevSkill.Shop.Application.Features.Stocks;
using DevSkill.Shop.Application.Features.Teams;
using DevSkill.Shop.Domain.Contracts;
using DevSkill.Shop.Application.Features.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using DevSkill.Shop.Infrastructure.Data.Repositories;

namespace DevSkill.Shop.Application.Contracts
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        ITeamRepository Teams { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IStockRepository Stocks { get; }
        IProductImageRepository ProductImages { get; }
    }
}
