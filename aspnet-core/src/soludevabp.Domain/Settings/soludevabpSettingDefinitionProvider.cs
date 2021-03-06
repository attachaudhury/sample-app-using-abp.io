using Volo.Abp.Settings;

namespace soludevabp.Settings
{
    public class soludevabpSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(soludevabpSettings.MySetting1));
        }
    }
}
