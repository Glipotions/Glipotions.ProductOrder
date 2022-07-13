using Volo.Abp.Settings;

namespace Glipotions.ProductOrder.Settings;

public class ProductOrderSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ProductOrderSettings.MySetting1));
    }
}
