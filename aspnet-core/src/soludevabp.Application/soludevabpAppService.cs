using System;
using System.Collections.Generic;
using System.Text;
using soludevabp.Localization;
using Volo.Abp.Application.Services;

namespace soludevabp
{
    /* Inherit your application services from this class.
     */
    public abstract class soludevabpAppService : ApplicationService
    {
        protected soludevabpAppService()
        {
            LocalizationResource = typeof(soludevabpResource);
        }
    }
}
