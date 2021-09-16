using System.Threading.Tasks;

namespace ChatApp.Data
{
    public interface IChatAppDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
