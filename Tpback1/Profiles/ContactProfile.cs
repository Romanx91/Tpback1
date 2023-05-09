using AutoMapper;
using Tpback1.Entities;
using Tpback1.Models.Dtos;

namespace Tpback1.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            
            CreateMap<Contacts, CreateAndUpdateContact>();
            CreateMap<CreateAndUpdateContact, Contacts>();
            CreateMap<Contacts, ContactDto>();
            CreateMap<ContactDto, Contacts>();
            CreateMap<Call, CallInfoDto>()
           .ForMember(dest => dest.TimeCall, opt => opt.MapFrom(src => src.TimeCall.ToString("dd/MM/yyyy - HH:mm")));
            CreateMap<Contacts, BlockedContactWithCallInfoDto>()
           .ForMember(dest => dest.CallInfo, opt => opt.MapFrom(src => src.Call));

        }
    }
}
