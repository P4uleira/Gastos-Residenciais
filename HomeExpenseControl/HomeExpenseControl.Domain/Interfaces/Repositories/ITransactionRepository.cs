using HomeExpenseControl.Domain.Entities;

namespace HomeExpenseControl.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetByIdAsync(Guid idTransaction);
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task AddAsync(Transaction transaction);
        Task<IEnumerable<UserTotals>> GetTotalsByUserAsync();
        Task<OverallTotals> GetOverallTotals();
    }
}
