using Xunit;

namespace ChatApp.MongoDB
{
    [CollectionDefinition(ChatAppTestConsts.CollectionDefinitionName)]
    public class ChatAppMongoCollection : ChatAppMongoDbCollectionFixtureBase
    {

    }
}
