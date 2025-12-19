using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Enums;

namespace HomeExpenseControl.Api.DTO.Requests
{
    public class TransactionRequest
    {
        public string TransactionDescription { get; set; }
        public decimal TransactionAmount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
