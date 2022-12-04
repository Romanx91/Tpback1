using AutoMapper;
using Tpback1.Entities;
using Tpback1.Models.Dtos;

namespace Tpback1.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<UpdateContact,  Contacts>();
            CreateMap<CreateAndUpdateContact, Contacts>();
           
        }
    }
}
