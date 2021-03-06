using Volo.Abp.Modularity;

namespace soludevabp
{
    [DependsOn(
        typeof(soludevabpApplicationModule),
        typeof(soludevabpDomainTestModule)
        )]
    public class soludevabpApplicationTestModule : AbpModule
    {

    }
}