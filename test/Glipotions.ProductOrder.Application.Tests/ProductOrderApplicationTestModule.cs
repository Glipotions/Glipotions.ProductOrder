using Volo.Abp.Modularity;

namespace Glipotions.ProductOrder;

[DependsOn(
    typeof(ProductOrderApplicationModule),
    typeof(ProductOrderDomainTestModule)
    )]
public class ProductOrderApplicationTestModule : AbpModule
{

}
