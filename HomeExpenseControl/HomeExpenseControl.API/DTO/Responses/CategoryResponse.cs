using HomeExpenseControl.Domain.Enums;

namespace HomeExpenseControl.Api.DTO.Responses
{
    public class CategoryResponse
    {
        public Guid IdCategory { get; set; }
        public string CategoryDescription { get; set; }
        public CategoryPurposeEnum CategoryPurpose { get; set; }

        public CategoryResponse(Guid idCategory, string categoryDescription, CategoryPurposeEnum categoryPurpose)
        {
            IdCategory = idCategory;
            CategoryDescription = categoryDescription;
            CategoryPurpose = categoryPurpose;
        }
    }
}
