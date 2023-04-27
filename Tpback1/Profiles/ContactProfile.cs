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

        }
    }
}
