using AutoMapper;
using Gighub.Models.Dtos;
using Gighub.Models.Entities;

namespace Gighub.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>(); // means you want to map from User to UserDTO
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}
