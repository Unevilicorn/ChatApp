using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ChatApp.Messages
{
    public interface IMessageAppService : ICrudAppService<MessageDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMessageDto>
    {
        Task<ListResultDto<IdentityUserLookupDto>> GetUserLookupAsync();
    }

    public class IdentityUserLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}