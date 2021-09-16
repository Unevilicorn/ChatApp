using ChatApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ChatAppController : AbpController
    {
        protected ChatAppController()
        {
            LocalizationResource = typeof(ChatAppResource);
        }
    }
}