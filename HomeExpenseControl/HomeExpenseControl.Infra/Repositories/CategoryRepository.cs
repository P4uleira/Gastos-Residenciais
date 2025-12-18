using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Interfaces.Repositories;
using HomeExpenseControl.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeExpenseControl.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HomeExpenseControlContext _context;

        public CategoryRepository(HomeExpenseControlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetByIdAsync(Guid idCategory)
        {
            return await _context.Categories.FindAsync(idCategory);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
