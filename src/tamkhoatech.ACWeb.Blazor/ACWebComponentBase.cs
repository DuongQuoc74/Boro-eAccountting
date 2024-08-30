using tamkhoatech.ACWeb.Localization;
using Volo.Abp.AspNetCore.Components;

namespace tamkhoatech.ACWeb.Blazor;

public abstract class ACWebComponentBase : AbpComponentBase
{
    protected ACWebComponentBase()
    {
        LocalizationResource = typeof(ACWebResource);
    }
}
