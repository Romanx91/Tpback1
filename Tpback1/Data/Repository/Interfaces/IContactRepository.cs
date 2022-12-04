using Tpback1.Entities;
using Tpback1.Models.Dtos;

namespace Tpback1.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public List<Contacts> GetAllByUser(int id);
        public void Create(CreateAndUpdateContact dto, int id);
        public void Update(UpdateContact dto, int id);
        public void Delete(int id);

    }
}
