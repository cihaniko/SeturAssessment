using AutoMapper;
using ContactService.Entities.Concrete;
using ContactService.Entities.Dto;

namespace ContactService.Utilities.AutoMapper
{
    public class MapperCustomize : Profile
    {
        public MapperCustomize()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<ContactDetails, ContactDetailsDto>().ReverseMap();
        }

    }
}
