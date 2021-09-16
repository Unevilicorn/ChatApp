using ChatApp.MongoDB;
using Volo.Abp.Modularity;

namespace ChatApp
{
    [DependsOn(
        typeof(ChatAppMongoDbTestModule)
        )]
    public class ChatAppDomainTestModule : AbpModule
    {

    }
}