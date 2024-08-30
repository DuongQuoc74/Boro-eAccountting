using System.Threading.Tasks;

namespace tamkhoatech.ACWeb.Data;

public interface IACWebDbSchemaMigrator
{
    Task MigrateAsync();
}
