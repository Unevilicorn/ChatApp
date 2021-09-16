using ChatApp.Messages;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace ChatApp
{
    public class ChatAppDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Message, Guid> _messageRepository;
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly IRepository<IdentityRole, Guid> _roleRepository;

        public ChatAppDataSeederContributor(IRepository<Message, Guid> messageRepository, IRepository<IdentityUser, Guid> userRepository, IRepository<IdentityRole, Guid> roleRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _messageRepository.CountAsync() > 0)
            {
                return;
            }

            var userRole = await _roleRepository.InsertAsync(new IdentityRole(Guid.NewGuid(), "users"));

            var unobolocorn = await _userRepository.InsertAsync(new IdentityUser(Guid.NewGuid(), "unobolocorn", "unobolocorn@fakeemail.com"));
            var unbilibilicorn = await _userRepository.InsertAsync(new IdentityUser(Guid.NewGuid(), "unbilibilicorn", "unbilibilicorn@fakeemail.com"));

            unobolocorn.AddRole(userRole.Id);
            unbilibilicorn.AddRole(userRole.Id);

            await _messageRepository.InsertAsync(
                new Message
                {
                    Content = "Hi",
                    PostDate = new DateTime(2021, 09, 13, 1, 1, 1),
                    UserId = unobolocorn.Id
                }, autoSave: true);

            await _messageRepository.InsertAsync(
                new Message
                {
                    Content = "no",
                    PostDate = new DateTime(2021, 09, 13, 1, 2, 1),
                    UserId = unbilibilicorn.Id
                }, autoSave: true);

            await _messageRepository.InsertAsync(
                new Message
                {
                    Content = "bye",
                    PostDate = new DateTime(2021, 09, 14, 4, 1, 1),
                    UserId = unobolocorn.Id
                }, autoSave: true);
        }
    }
}