using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Interfaces.Repositories;
using HomeExpenseControl.Domain.Interfaces.Services;

namespace HomeExpenseControl.Domain.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task CreateTransaction(Transaction transaction)
        {
            await _transactionRepository.AddAsync(transaction);
        }
        public async Task<Transaction> GetTransactionById(Guid idTransaction)
        {
            return await _transactionRepository.GetByIdAsync(idTransaction);
        }
        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return await _transactionRepository.GetAllAsync();
        }
    }
}
