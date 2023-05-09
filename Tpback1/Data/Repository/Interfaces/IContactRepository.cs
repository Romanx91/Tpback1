using Microsoft.AspNetCore.Mvc;
using Tpback1.Entities;
using Tpback1.Models.Dtos;

namespace Tpback1.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public Contacts GetById(int id);
        public List<Contacts> FindAllNotBlockedByUser(int userId);
        public List<Contacts> FindAllBlockedByUser(int userId);
        public List<Contacts> FindAllBlockedByUserWithCalls(int userId);
        public List<Contacts> GetAllContactsByUserId(int userId);
        public List<Contacts> FindAllByUser(int userId);
        public void Create(CreateAndUpdateContact dto, int userId);
        public void UpdateContact(Contacts contact);
        public void Delete(int id);
        public bool IsExistsContact(int id);
        public void BlockContact(int id);
        public void UnblockContact(int id);
        public Call GetCallByContactId(int contactId);
        public void DeleteCallsByContactId(int contactId);
    }
}
