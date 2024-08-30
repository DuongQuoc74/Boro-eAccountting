using tamkhoatech.ACWeb.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace tamkhoatech.ACWeb;

[DependsOn(
    typeof(ACWebEntityFrameworkCoreTestModule)
    )]
public class ACWebDomainTestModule : AbpModule
{

}
