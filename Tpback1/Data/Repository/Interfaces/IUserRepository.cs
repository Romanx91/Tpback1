using Tpback1.Entities;
using Tpback1.Models.Dtos;

namespace Tpback1.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User? ValidateUser(AuthenticationRequestBody authRequestBody);
        public User? GetById(int userId);
        public List<User> GetAll();
        public void CreateUser(CreateAndUpdateUserDto dto);
        public void Update(UpdateUser dto);
        public void Delete(int id);
        bool UserExists(int userId);

    }
}
