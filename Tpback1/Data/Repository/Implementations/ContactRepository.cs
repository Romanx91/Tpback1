using Tpback1.Data.Repository.Interfaces;
using Tpback1.Entities;
using AutoMapper;
using Tpback1.Models.Dtos;
using Tpback1.Models;

namespace Tpback1.Data.Repository.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly AgendaContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(AgendaContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }
        public List<Contacts> GetAllByUser(int id)
        {

            return _context.Contacts.Where(c => c.User.Id == id).ToList();
        }

        public void Create(CreateAndUpdateContact dto, int id)
        {
            Contacts contact = _mapper.Map<Contacts>(dto);
            contact.UserId = id;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Update(UpdateContact dto, int id)
        {
            Contacts contact = _mapper.Map<Contacts>(dto);
            contact.UserId = id;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
            _context.SaveChanges();
        }

        public Task FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
