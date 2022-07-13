using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Glipotions.ProductOrder.Data;

/* This is used if database provider does't define
 * IProductOrderDbSchemaMigrator implementation.
 */
public class NullProductOrderDbSchemaMigrator : IProductOrderDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
