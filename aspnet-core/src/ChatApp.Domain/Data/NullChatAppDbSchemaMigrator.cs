using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ChatApp.Data
{
    /* This is used if database provider does't define
     * IChatAppDbSchemaMigrator implementation.
     */
    public class NullChatAppDbSchemaMigrator : IChatAppDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}