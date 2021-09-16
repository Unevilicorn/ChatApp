using System;
using Volo.Abp.Domain.Entities;

namespace ChatApp.Messages
{
    public class Message : AggregateRoot<Guid>
    {
        public string Content { get; set; }
        public DateTime PostDate { get; set; }

        public Guid UserId { get; set; }

        public Guid ChannelId { get; set; }
    }
}