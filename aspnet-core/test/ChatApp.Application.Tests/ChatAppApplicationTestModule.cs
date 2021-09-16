using Volo.Abp.Modularity;

namespace ChatApp
{
    [DependsOn(
        typeof(ChatAppApplicationModule),
        typeof(ChatAppDomainTestModule)
        )]
    public class ChatAppApplicationTestModule : AbpModule
    {

    }
}