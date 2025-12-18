using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Interfaces.Repositories;
using HomeExpenseControl.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeExpenseControl.Infra.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly HomeExpenseControlContext _context;

        public TransactionRepository(HomeExpenseControlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<Transaction> GetByIdAsync(Guid idTransaction)
        {
            return await _context.Transactions.FindAsync(idTransaction);
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }
    }
}
