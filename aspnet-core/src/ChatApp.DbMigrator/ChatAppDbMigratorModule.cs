using ChatApp.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ChatApp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ChatAppMongoDbModule),
        typeof(ChatAppApplicationContractsModule)
        )]
    public class ChatAppDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
