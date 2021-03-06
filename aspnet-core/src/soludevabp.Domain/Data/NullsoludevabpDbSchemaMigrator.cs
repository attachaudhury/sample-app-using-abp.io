using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace soludevabp.Data
{
    /* This is used if database provider does't define
     * IsoludevabpDbSchemaMigrator implementation.
     */
    public class NullsoludevabpDbSchemaMigrator : IsoludevabpDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}