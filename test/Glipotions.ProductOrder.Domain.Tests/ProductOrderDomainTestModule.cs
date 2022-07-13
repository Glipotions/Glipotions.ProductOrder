using Glipotions.ProductOrder.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Glipotions.ProductOrder;

[DependsOn(
    typeof(ProductOrderEntityFrameworkCoreTestModule)
    )]
public class ProductOrderDomainTestModule : AbpModule
{

}
