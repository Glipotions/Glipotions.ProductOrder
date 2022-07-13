using Glipotions.ProductOrder.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Glipotions.ProductOrder.Permissions;

public class ProductOrderPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProductOrderPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ProductOrderPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProductOrderResource>(name);
    }
}
