using Tpback1.Data.Repository.Interfaces;
using Tpback1.Entities;
using AutoMapper;
using Tpback1.Models.Dtos;
using Tpback1.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace Tpback1.Data.Repository.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly AgendaContext _context;
        private readonly IMapper _mapper;
        private object _dbContext;

        public ContactRepository(AgendaContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;

        }


        public Contacts GetById(int id)
        {

            return _context.Contacts.Include(c => c.User).FirstOrDefault(c => c.Id == id);

            return _context.Contacts.Find(id);
        }
        public List<Contacts> GetAllContactsByUserId(int userId)
        {
            return _context.Contacts.Where(c => c.UserId == userId).ToList();
        }

        public List<Contacts> GetBlockedContactsByUser(int userId)
{
            return _context.Contacts.Where(c => c.UserId == userId && c.IsBlocked == true).ToList();
        }

        public List<Contacts> FindAllNotBlockedByUser(int userId)
        {
            return _context.Contacts.Where(c => c.UserId == userId && !c.IsBlocked).ToList();
        }

        public List<Contacts> FindAllBlockedByUser(int userId)
        {
            return _context.Contacts.Where(c => c.UserId == userId && c.IsBlocked).ToList();
        }




        public void Create(CreateAndUpdateContact dto, int userId)
        {
            var contact = _mapper.Map<Contacts>(dto);
            contact.UserId = userId;
            contact.IsBlocked = false;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }



        public List<Contacts> FindAllByUser(int userId)
        {
            var contacts = _context.Contacts.Where(c => c.UserId == userId).ToList();

            return contacts ?? new List<Contacts>();
        }



        public class RepositoryException : Exception
        {
            public RepositoryException(string message) : base(message)
            {
            }
        }


        public void UpdateContact(Contacts contact)
        {
            var contactItem = _context.Contacts.Find(contact.Id);

            if (contactItem != null)
            {
                contactItem.Name = contact.Name;
                contactItem.CelularNumber = contact.CelularNumber;
                contactItem.TelephoneNumber = contact.TelephoneNumber;
                contactItem.Description = contact.Description;
                contactItem.UserId = contact.UserId;


                _context.Entry(contactItem).State = EntityState.Modified;

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("Error al guardar los cambios: " + ex.InnerException?.Message);
                    throw new RepositoryException(ex.InnerException?.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error general: " + ex.Message);
                    throw new RepositoryException(ex.Message);
                }
            }
        }


        public void UnblockContact(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id && c.IsBlocked);
            if (contact != null)
            {
                contact.IsBlocked = false;
                _context.SaveChanges();


            }
        }

        public void BlockContact(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id && !c.IsBlocked);
            if (contact != null)
            {
                contact.IsBlocked = true;
                _context.SaveChanges();


            }
        }

        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
            _context.SaveChanges();
        }
        public bool IsExistsContact(int id)
        {
            return (_context.Contacts.Any(c => c.Id.Equals(id)));
        }
    }


}
