using System.Threading.Tasks;

namespace Glipotions.ProductOrder.Data;

public interface IProductOrderDbSchemaMigrator
{
    Task MigrateAsync();
}
