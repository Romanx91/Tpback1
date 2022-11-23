using Tpback1.Entities;
using Tpback1.Models;

namespace Tpback1.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public List<Contact> GetAll();
        public void Create(CreateAndUpdateContact dto);
        public void Update(CreateAndUpdateContact dto);
        public void Delete(int id);
    }
}
