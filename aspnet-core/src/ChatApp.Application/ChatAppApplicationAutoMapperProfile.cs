using AutoMapper;
using ChatApp.Messages;
using Microsoft.AspNetCore.Identity;

namespace ChatApp
{
    public class ChatAppApplicationAutoMapperProfile : Profile
    {
        public ChatAppApplicationAutoMapperProfile()
        {
            CreateMap<Message, MessageDto>();
            CreateMap<CreateUpdateMessageDto, Message>();

            CreateMap<IdentityUser, IdentityUserLookupDto>();
        }
    }
}