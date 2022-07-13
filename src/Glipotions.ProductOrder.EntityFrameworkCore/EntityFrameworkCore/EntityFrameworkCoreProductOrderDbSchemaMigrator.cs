using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Glipotions.ProductOrder.Data;
using Volo.Abp.DependencyInjection;

namespace Glipotions.ProductOrder.EntityFrameworkCore;

public class EntityFrameworkCoreProductOrderDbSchemaMigrator
    : IProductOrderDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreProductOrderDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ProductOrderDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ProductOrderDbContext>()
            .Database
            .MigrateAsync();
    }
}
