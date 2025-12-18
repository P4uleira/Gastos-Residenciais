using HomeExpenseControl.Domain.Enums;

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

        protected Transaction() { } // EF

        public Transaction(string transactionDescription, decimal transactionAmount, TransactionTypeEnum transactionType, Category category, User user)
        {
            SetDescription(transactionDescription);
            SetValue(transactionAmount);
            SetType(transactionType);
            SetCategory(category);
            SetUser(user);
        }

        public void SetDescription(string transactionDescription)
        {
            if (string.IsNullOrWhiteSpace(transactionDescription))
                throw new ArgumentException("Descrição da transação é obrigatória.");

            TransactionDescription = transactionDescription;
        }

        public void SetValue(decimal transactionAmount)
        {
            if (transactionAmount <= 0)
                throw new ArgumentException("O valor da transação deve ser positivo.");

            TransactionAmount = transactionAmount;
        }

        private void SetType(TransactionTypeEnum transactionType)
        {
            if (!Enum.IsDefined(typeof(TransactionTypeEnum), transactionType))
                throw new ArgumentException("Tipo de transação inválido.");

            TransactionType = transactionType;
        }

        public void SetCategory(Category category)
        {
            if (category is null)
                throw new ArgumentException("Categoria é obrigatória.");

            if (User.UserAge < 18 && TransactionType == TransactionTypeEnum.Receita)
                throw new ArgumentException("Usuários menores de 18 anos só podem registrar despesas.");

            if (category.CategoryPurpose != CategoryPurposeEnum.Ambas &&
                (TransactionTypeEnum)category.CategoryPurpose != TransactionType)
            {
                throw new ArgumentException(
                    $"Categoria com finalidade {category.CategoryPurpose} não é compatível com a transação {TransactionType}."
                );
            }

            Category = category;
            CategoryId = category.idCategory;
        }

        private void SetUser(User user)
        {
            if (user is null)
                throw new ArgumentException("Usuário é obrigatório.");

            User = user;
            UserId = user.idUser;
        }
    }


}
}
