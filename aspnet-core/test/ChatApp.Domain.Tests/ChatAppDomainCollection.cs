using ChatApp.MongoDB;
using Xunit;

namespace ChatApp
{
    [CollectionDefinition(ChatAppTestConsts.CollectionDefinitionName)]
    public class ChatAppDomainCollection : ChatAppMongoDbCollectionFixtureBase
    {

    }
}
