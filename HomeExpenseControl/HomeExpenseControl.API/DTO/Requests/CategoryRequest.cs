using HomeExpenseControl.Domain.Enums;

namespace HomeExpenseControl.Api.DTO.Requests
{
    public class CategoryRequest
    {
        public string CategoryDescription { get; set; }
        public CategoryPurposeEnum CategoryPurpose { get; set; }

    }
}
