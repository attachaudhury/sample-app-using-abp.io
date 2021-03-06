using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace soludevabp
{
    [Dependency(ReplaceServices = true)]
    public class soludevabpBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "soludevabp";
    }
}
