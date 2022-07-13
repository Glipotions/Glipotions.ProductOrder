using System;
using System.Collections.Generic;
using System.Text;
using Glipotions.ProductOrder.Localization;
using Volo.Abp.Application.Services;

namespace Glipotions.ProductOrder;

/* Inherit your application services from this class.
 */
public abstract class ProductOrderAppService : ApplicationService
{
    protected ProductOrderAppService()
    {
        LocalizationResource = typeof(ProductOrderResource);
    }
}
