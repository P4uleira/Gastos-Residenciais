namespace HomeExpenseControl.Api.DTO.Responses
{
    public record OverallTotalsResponse (decimal TotalIncome, decimal TotalExpense, decimal Balance);
}
