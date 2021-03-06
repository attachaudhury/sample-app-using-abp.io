using soludevabp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace soludevabp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class soludevabpController : AbpController
    {
        protected soludevabpController()
        {
            LocalizationResource = typeof(soludevabpResource);
        }
    }
}