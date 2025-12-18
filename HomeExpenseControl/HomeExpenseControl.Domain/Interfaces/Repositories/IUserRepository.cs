using HomeExpenseControl.Domain.Entities;

namespace HomeExpenseControl.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid idUser);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task DeleteAsync(Guid idUser);
    }
}
