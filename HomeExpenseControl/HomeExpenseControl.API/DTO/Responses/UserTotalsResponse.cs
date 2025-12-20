namespace HomeExpenseControl.Api.DTO.Responses
{
    public record UserTotalsResponse(string UserName, decimal TotalIncome, decimal TotalExpense, decimal Balance);
    
}
