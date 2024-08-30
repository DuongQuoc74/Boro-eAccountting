using Volo.Abp.Modularity;

namespace tamkhoatech.ACWeb;

[DependsOn(
    typeof(ACWebApplicationModule),
    typeof(ACWebDomainTestModule)
    )]
public class ACWebApplicationTestModule : AbpModule
{

}
