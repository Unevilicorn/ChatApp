using ChatApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ChatApp.Permissions
{
    public class ChatAppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var bookStoreGroup = context.AddGroup(ChatAppPermissions.GroupName, L("Permission:ChatApp"));

            var booksPermission = bookStoreGroup.AddPermission(ChatAppPermissions.Messages.Default, L("Permission:Messages"));
            booksPermission.AddChild(ChatAppPermissions.Messages.Create, L("Permission:Messages.Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ChatAppResource>(name);
        }
    }
}