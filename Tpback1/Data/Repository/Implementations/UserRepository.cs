using AutoMapper;
using Tpback1.Data.Repository.Interfaces;
using Tpback1.Entities;
using Tpback1.Models.Dtos;

namespace Tpback1.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private AgendaContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AgendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Create(CreateAndUpdateUserDto dto)
        {
            _context.Users.Add(_mapper.Map<User>(dto));
            _context.SaveChanges();
        }

        public void Update(UpdateUser dto)
        {
            
            _context.Users.Update(_mapper.Map<User>(dto));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
            _context.SaveChanges();
        }
    }
}
