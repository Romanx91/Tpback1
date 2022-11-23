using AutoMapper;
using Tpback1.Entities;
using Tpback1.Models;

namespace Tpback1.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, CreateAndUpdateContact>();
        }
    }
}
