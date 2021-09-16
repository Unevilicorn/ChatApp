using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace ChatApp.MongoDB
{
    [DependsOn(
        typeof(ChatAppTestBaseModule),
        typeof(ChatAppMongoDbModule)
        )]
    public class ChatAppMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var stringArray = ChatAppMongoDbFixture.ConnectionString.Split('?');
                        var connectionString = stringArray[0].EnsureEndsWith('/')  +
                                                   "Db_" +
                                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}
