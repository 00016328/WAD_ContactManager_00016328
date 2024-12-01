using AutoMapper;
using WAD_contactManager_00016328.DTOs;
using WAD_contactManager_00016328.Models;

namespace WAD_contactManager_00016328.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // mapping Contact to ContactDto
            CreateMap<Contact, ContactDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.Name));
            CreateMap<ContactDto, Contact>().ReverseMap();
        }
    }
}
