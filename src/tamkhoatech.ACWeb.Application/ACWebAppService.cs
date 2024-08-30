using System;
using System.Collections.Generic;
using System.Text;
using tamkhoatech.ACWeb.Localization;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb;

/* Inherit your application services from this class.
 */
public abstract class ACWebAppService : ApplicationService
{
    protected ACWebAppService()
    {
        LocalizationResource = typeof(ACWebResource);
    }
}
