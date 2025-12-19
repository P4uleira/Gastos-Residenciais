using HomeExpenseControl.Domain.Enums;
using HomeExpenseControl.Domain.Exceptions;

namespace HomeExpenseControl.Domain.Entities
{
    public class Transaction
    {
        public Guid IdTransaction { get; private set; }
        public string TransactionDescription { get; private set; }
        public decimal TransactionAmount { get; private set; }
        public TransactionTypeEnum TransactionType { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        protected Transaction() { }

        public Transaction(string transactionDescription, decimal transactionAmount, TransactionTypeEnum transactionType, Guid categoryId, Guid userId)
        {
            SetDescription(transactionDescription);
            SetValue(transactionAmount);
            SetType(transactionType);
            SetCategory(categoryId);
            SetUser(userId);
        }

        public void SetDescription(string transactionDescription)
        {
            if (string.IsNullOrWhiteSpace(transactionDescription))
                throw new DomainException("Descrição da transação é obrigatória.");

            TransactionDescription = transactionDescription;
        }

        public void SetValue(decimal transactionAmount)
        {
            if (transactionAmount <= 0)
                throw new DomainException("O valor da transação deve ser positivo.");

            TransactionAmount = transactionAmount;
        }

        private void SetType(TransactionTypeEnum transactionType)
        {
            if (!Enum.IsDefined(typeof(TransactionTypeEnum), transactionType))
                throw new DomainException("Tipo de transação inválido.");

            TransactionType = transactionType;
        }

        public void SetCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                throw new DomainException("Categoria é obrigatória.");

            CategoryId = categoryId;
        }

        private void SetUser(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new DomainException("Usuário é obrigatório.");

            UserId = userId;
        }
    }
}
