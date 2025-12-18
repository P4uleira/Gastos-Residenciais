using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Interfaces.Repositories;
using HomeExpenseControl.Domain.Interfaces.Services;

namespace HomeExpenseControl.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task DeleteUser(Guid idUser)
        {
            await _userRepository.DeleteAsync(idUser);
        }

        public async Task<User> GetUserById(Guid idUser)
        {
            return await _userRepository.GetByIdAsync(idUser);
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }
     
    }
}
