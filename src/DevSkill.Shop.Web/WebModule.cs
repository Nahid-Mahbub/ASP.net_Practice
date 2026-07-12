using Autofac;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Application.Features.Teams;
using DevSkill.Shop.Infrastructure.Data;
using DevSkill.Shop.Infrastructure.Data.Repositories;
using DevSkill.Shop.Application.Features.Products;
using DevSkill.Shop.Application.Features.Stocks;
using DevSkill.Shop.Application.Features.Categories;

namespace DevSkill.Shop.Web

{
    public class WebModule : Module
    {
        private readonly string _connectionString;

        public WebModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TeamRepository>()
                .As<ITeamRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>()
                .As<ICategoryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductImageRepository>()
                .As<IProductImageRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StockRepository>()
                .As<IStockRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>()
                .As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}