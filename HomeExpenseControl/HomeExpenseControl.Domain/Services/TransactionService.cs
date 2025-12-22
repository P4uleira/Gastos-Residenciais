using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Enums;
using HomeExpenseControl.Domain.Exceptions;
using HomeExpenseControl.Domain.Interfaces.Repositories;
using HomeExpenseControl.Domain.Interfaces.Services;

namespace HomeExpenseControl.Domain.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TransactionService(ITransactionRepository transactionRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task CreateTransaction(Transaction transaction)
        {
            var user = await _userRepository.GetByIdAsync(transaction.UserId)
            ?? throw new DomainException("Usuário não encontrado");

            if (user.UserAge < 18 && transaction.TransactionType == TransactionTypeEnum.Receita)
                throw new DomainException("Usuário menor de idade não pode cadastrar receita");

            var category = await _categoryRepository.GetByIdAsync(transaction.CategoryId)
                ?? throw new DomainException("Categoria não encontrada");

            if ((CategoryPurposeEnum)transaction.TransactionType != category.CategoryPurpose && CategoryPurposeEnum.Ambas != category.CategoryPurpose)
                throw new DomainException("Categoria incompatível com o tipo da transação");

            var newTransaction = new Transaction(transaction.TransactionDescription, transaction.TransactionAmount, transaction.TransactionType, category.IdCategory, user.idUser);

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

        public async Task<IEnumerable<UserTotals>> GetTotalsByUserAsync()
        {
            return await _transactionRepository.GetTotalsByUserAsync();
        }

        public async Task<OverallTotals> GetOverallTotals()
        {
            return await _transactionRepository.GetOverallTotals();
        }
    }
}
