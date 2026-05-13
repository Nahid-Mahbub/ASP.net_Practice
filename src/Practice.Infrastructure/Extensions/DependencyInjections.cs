using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Practice.Infrastructure.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Scoped bindings
            //services.AddScoped<IMembership, ImprovedMembership>();

            return services;
        }
    }
}
