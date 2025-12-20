namespace HomeExpenseControl.Domain.Entities
{
    public class UserTotals
    {
        public string UserName { get; set; } = string.Empty;
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance { get; set; }
    }
}
