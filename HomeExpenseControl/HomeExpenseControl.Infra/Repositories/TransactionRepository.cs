using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Enums;
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

        public async Task<IEnumerable<UserTotals>> GetTotalsByUserAsync()
        {
            return await _context.Users
                .Select(u => new UserTotals
                {

                    UserName =  u.UserName,
                    TotalIncome = u.Transactions
                        .Where(t => t.TransactionType == TransactionTypeEnum.Receita)
                        .Sum(t => (decimal?)t.TransactionAmount) ?? 0,

                    TotalExpense = u.Transactions
                        .Where(t => t.TransactionType == TransactionTypeEnum.Despesa)
                        .Sum(t => (decimal?)t.TransactionAmount) ?? 0
                })
                .Select(x => new UserTotals
                {
                    UserName = x.UserName,
                    TotalIncome = x.TotalIncome,
                    TotalExpense = x.TotalExpense,
                    Balance = x.TotalIncome - x.TotalExpense
                })
                .ToListAsync();
        }
        
        public async Task<OverallTotals> GetOverallTotals()
        {
            return await _context.Transactions
                .GroupBy(_ => 1) // Aqui estou forçando um unico grupo de linha (1 linha)
                .Select(g => new OverallTotals
                {
                    TotalIncome = g
                        .Where(t => t.TransactionType == TransactionTypeEnum.Receita)
                        .Sum(t => (decimal?)t.TransactionAmount) ?? 0,

                    TotalExpense = g
                        .Where(t => t.TransactionType == TransactionTypeEnum.Despesa)
                        .Sum(t => (decimal?)t.TransactionAmount) ?? 0
                })
                .Select(x => new OverallTotals
                {
                    TotalIncome = x.TotalIncome,
                    TotalExpense = x.TotalExpense,
                    Balance = x.TotalIncome - x.TotalExpense
                })
                .FirstOrDefaultAsync()
                ?? new OverallTotals();
        }

    }
}
