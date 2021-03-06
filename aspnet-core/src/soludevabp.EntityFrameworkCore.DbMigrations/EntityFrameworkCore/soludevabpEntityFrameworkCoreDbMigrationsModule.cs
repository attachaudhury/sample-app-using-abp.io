using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace soludevabp.EntityFrameworkCore
{
    [DependsOn(
        typeof(soludevabpEntityFrameworkCoreModule)
        )]
    public class soludevabpEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<soludevabpMigrationsDbContext>();
        }
    }
}
