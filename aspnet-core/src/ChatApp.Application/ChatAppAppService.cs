using System;
using System.Collections.Generic;
using System.Text;
using ChatApp.Localization;
using Volo.Abp.Application.Services;

namespace ChatApp
{
    /* Inherit your application services from this class.
     */
    public abstract class ChatAppAppService : ApplicationService
    {
        protected ChatAppAppService()
        {
            LocalizationResource = typeof(ChatAppResource);
        }
    }
}
