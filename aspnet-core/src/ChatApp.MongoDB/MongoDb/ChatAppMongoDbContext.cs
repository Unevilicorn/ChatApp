using ChatApp.Messages;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ChatApp.MongoDB
{
    [ConnectionStringName("Default")]
    public class ChatAppMongoDbContext : AbpMongoDbContext
    {
        public IMongoCollection<Message> Messages => Collection<Message>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);
        }
    }
}