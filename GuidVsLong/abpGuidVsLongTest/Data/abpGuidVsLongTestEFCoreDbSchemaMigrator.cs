using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace abpGuidVsLongTest.Data;

public class abpGuidVsLongTestEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public abpGuidVsLongTestEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the abpGuidVsLongTestDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<abpGuidVsLongTestDbContext>()
            .Database
            .MigrateAsync();
    }
}
