using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace tamkhoatech.ACWeb.Blazor;

[Dependency(ReplaceServices = true)]
public class ACWebBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ACWeb";
}
