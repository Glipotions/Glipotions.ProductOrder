using Glipotions.ProductOrder.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Glipotions.ProductOrder.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ProductOrderController : AbpControllerBase
{
    protected ProductOrderController()
    {
        LocalizationResource = typeof(ProductOrderResource);
    }
}
