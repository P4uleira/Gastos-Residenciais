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
            var newUser = new User(user.UserName, user.UserAge);

            await _userRepository.AddAsync(newUser);
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
