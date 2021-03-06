using soludevabp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace soludevabp
{
    [DependsOn(
        typeof(soludevabpEntityFrameworkCoreTestModule)
        )]
    public class soludevabpDomainTestModule : AbpModule
    {

    }
}