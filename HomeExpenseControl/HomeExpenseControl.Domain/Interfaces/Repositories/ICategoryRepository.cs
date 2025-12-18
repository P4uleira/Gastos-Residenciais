using HomeExpenseControl.Domain.Entities;

namespace HomeExpenseControl.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(Guid idCategory);
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
    }
}
