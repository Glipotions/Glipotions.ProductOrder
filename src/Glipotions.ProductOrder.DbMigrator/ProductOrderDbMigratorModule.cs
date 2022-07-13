using Glipotions.ProductOrder.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Glipotions.ProductOrder.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProductOrderEntityFrameworkCoreModule),
    typeof(ProductOrderApplicationContractsModule)
    )]
public class ProductOrderDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
