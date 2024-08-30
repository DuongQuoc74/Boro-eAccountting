using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace tamkhoatech.ACWeb.Data;

/* This is used if database provider does't define
 * IACWebDbSchemaMigrator implementation.
 */
public class NullACWebDbSchemaMigrator : IACWebDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
