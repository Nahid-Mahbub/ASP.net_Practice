using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Practice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Practice.Infrastructure.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString, Assembly migrationAssembly)
        {
            // This method can be used to add extension methods for DbContext if needed in the future.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString,
                x => x.MigrationsAssembly(migrationAssembly.GetName().Name)));
        }
    }
}
