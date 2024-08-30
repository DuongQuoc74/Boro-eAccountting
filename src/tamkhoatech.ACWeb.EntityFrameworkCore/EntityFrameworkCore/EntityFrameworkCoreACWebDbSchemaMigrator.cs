using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using tamkhoatech.ACWeb.Data;
using Volo.Abp.DependencyInjection;

namespace tamkhoatech.ACWeb.EntityFrameworkCore;

public class EntityFrameworkCoreACWebDbSchemaMigrator
    : IACWebDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreACWebDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ACWebDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ACWebDbContext>()
            .Database
            .MigrateAsync();
    }
}
