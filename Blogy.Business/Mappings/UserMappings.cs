using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entites;

namespace Blogy.Business.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<AppUser, ResultUserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
