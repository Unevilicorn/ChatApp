using ChatApp.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace ChatApp.Messages
{
    public class MessageAppService : CrudAppService<Message, MessageDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMessageDto>, IMessageAppService
    {
        private readonly IIdentityUserRepository _userRepository;
        private readonly ICurrentUser _currentUser;

        public MessageAppService(IRepository<Message, Guid> repository, IIdentityUserRepository userRepository, ICurrentUser currentUser) : base(repository)
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
            GetPolicyName = ChatAppPermissions.Messages.Default;
            GetListPolicyName = ChatAppPermissions.Messages.Default;
            CreatePolicyName = ChatAppPermissions.Messages.Create;
        }

        public async override Task<MessageDto> CreateAsync(CreateUpdateMessageDto input)
        {
            Console.WriteLine(input.UserId);
            return await base.CreateAsync(input);
        }

        public async override Task<MessageDto> GetAsync(Guid id)
        {
            var message = await Repository.GetAsync(id);
            var messageDto = ObjectMapper.Map<Message, MessageDto>(message);

            var user = await _userRepository.GetAsync(message.UserId);
            messageDto.UserName = user.UserName;

            return messageDto;
        }

        public async override Task<PagedResultDto<MessageDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Message.PostDate);
            }

            var queryable = await Repository.GetQueryableAsync();

            var messages = await AsyncExecuter.ToListAsync(
                queryable
                    .OrderBy(input.Sorting)
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount)
            );

            var messageDtos = ObjectMapper.Map<List<Message>, List<MessageDto>>(messages);

            var userDictionary = await GetUserDictionaryAsync(messages);

            messageDtos.ForEach(messageDto => messageDto.UserName = userDictionary[messageDto.UserId].UserName);

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<MessageDto>(
                totalCount,
                messageDtos
            );
        }

        public async Task<ListResultDto<IdentityUserLookupDto>> GetUserLookupAsync()
        {
            var users = await _userRepository.GetListAsync();

            return new ListResultDto<IdentityUserLookupDto>(ObjectMapper.Map<List<IdentityUser>, List<IdentityUserLookupDto>>(users));
        }

        public Guid GetCurrentUserId()
        {
            return (Guid)_currentUser.Id;
        }

        private async Task<Dictionary<Guid, IdentityUser>> GetUserDictionaryAsync(List<Message> messages)
        {
            var userIds = messages
                .Select(b => b.UserId)
                .Distinct()
                .ToArray();

            var usersList = await _userRepository.GetListAsync();

            var users = await AsyncExecuter.ToListAsync(
                usersList.AsQueryable().Where(a => userIds.Contains(a.Id))
            );

            return users.ToDictionary(x => x.Id, x => x);
        }
    }
}
