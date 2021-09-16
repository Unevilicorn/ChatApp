using Volo.Abp.Settings;

namespace ChatApp.Settings
{
    public class ChatAppSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ChatAppSettings.MySetting1));
        }
    }
}
