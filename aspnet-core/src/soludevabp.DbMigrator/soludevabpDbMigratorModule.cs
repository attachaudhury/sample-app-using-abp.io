using soludevabp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace soludevabp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(soludevabpEntityFrameworkCoreDbMigrationsModule),
        typeof(soludevabpApplicationContractsModule)
        )]
    public class soludevabpDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
