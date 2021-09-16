using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ChatApp.Messages
{
    public class MessageDto : EntityDto<Guid>
    {
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public Guid ChannelId { get; set; }
    }

    public class CreateUpdateMessageDto
    {
        [Required]
        [StringLength(2048)]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Guid ChannelId { get; set; }
    }
}