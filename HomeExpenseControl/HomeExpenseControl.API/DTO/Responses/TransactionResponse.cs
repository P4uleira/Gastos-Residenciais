using HomeExpenseControl.Domain.Enums;

namespace HomeExpenseControl.Api.DTO.Responses
{
    public class TransactionResponse
    {
        public Guid IdTransaction { get; set; }
        public string TransactionDescription { get; set; }
        public decimal TransactionAmount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public TransactionResponse(Guid idTransaction, string transactionDescription, decimal transactionAmount, TransactionTypeEnum transactionType, Guid categoryId, Guid userId)
        {
            IdTransaction = idTransaction;
            TransactionDescription = transactionDescription;
            TransactionAmount = transactionAmount;
            TransactionType = transactionType;
            CategoryId = categoryId;
            UserId = userId;
        }
    }
}
