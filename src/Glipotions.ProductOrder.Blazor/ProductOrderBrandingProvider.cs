using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Glipotions.ProductOrder.Blazor;

[Dependency(ReplaceServices = true)]
public class ProductOrderBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ProductOrder";
}
