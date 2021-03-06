using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using soludevabp.Data;
using Volo.Abp.DependencyInjection;

namespace soludevabp.EntityFrameworkCore
{
    public class EntityFrameworkCoresoludevabpDbSchemaMigrator
        : IsoludevabpDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoresoludevabpDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the soludevabpMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<soludevabpMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}