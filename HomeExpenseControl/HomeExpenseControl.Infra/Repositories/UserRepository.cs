using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Interfaces.Repositories;
using HomeExpenseControl.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeExpenseControl.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HomeExpenseControlContext _context;

        public UserRepository(HomeExpenseControlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid idUser)
        {
            var user = await _context.Users.FindAsync(idUser);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
        }

        public async Task<User> GetByIdAsync(Guid idUser)
        {
            return await _context.Users.FindAsync(idUser);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
