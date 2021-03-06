using soludevabp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace soludevabp.Permissions
{
    public class soludevabpPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var bookStoreGroup = context.AddGroup(soludevabpPermissions.GroupName, L("Permission:soludevabp"));

            var booksPermission = bookStoreGroup.AddPermission(soludevabpPermissions.Companies.Default, L("Permission:Companies"));
            booksPermission.AddChild(soludevabpPermissions.Companies.Create, L("Permission:Companies.Create"));
            booksPermission.AddChild(soludevabpPermissions.Companies.Edit, L("Permission:Companies.Edit"));
            booksPermission.AddChild(soludevabpPermissions.Companies.Delete, L("Permission:Companies.Delete"));


            var authorsPermission = bookStoreGroup.AddPermission(
    soludevabpPermissions.Listings.Default, L("Permission:Listings"));

            authorsPermission.AddChild(
                soludevabpPermissions.Listings.Create, L("Permission:Listings.Create"));

            authorsPermission.AddChild(
                soludevabpPermissions.Listings.Edit, L("Permission:Listings.Edit"));

            authorsPermission.AddChild(
                soludevabpPermissions.Listings.Delete, L("Permission:Listings.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<soludevabpResource>(name);
        }
    }
}
