using Glipotions.ProductOrder.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Glipotions.ProductOrder.Blazor;

public abstract class ProductOrderComponentBase : AbpComponentBase
{
    protected ProductOrderComponentBase()
    {
        LocalizationResource = typeof(ProductOrderResource);
    }
}
