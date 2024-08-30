using tamkhoatech.ACWeb.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace tamkhoatech.ACWeb.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ACWebController : AbpControllerBase
{
    protected ACWebController()
    {
        LocalizationResource = typeof(ACWebResource);
    }
}
