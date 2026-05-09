using Autofac;

namespace DevSkill.Shop.Infrastructure.Modules;

public class WebModule : Module
{
    protected override void Load(ContainerBuilder? builder)
    {
        // Future services registration

        // Example:
        // builder.RegisterType<ProductService>()
        //        .As<IProductService>()
        //        .InstancePerLifetimeScope();
    }
}