using tamkhoatech.ACWeb.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace tamkhoatech.ACWeb.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ACWebEntityFrameworkCoreModule),
    typeof(ACWebApplicationContractsModule)
    )]
public class ACWebDbMigratorModule : AbpModule
{

}
