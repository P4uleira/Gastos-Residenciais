using HomeExpenseControl.Domain.Enums;

namespace HomeExpenseControl.Domain.Entities
{
    public class Category
    {
        public Guid idCategory { get; private set; }
        public string CategoryDescription { get; private set; }
        public CategoryPurposeEnum CategoryPurpose { get; private set; }
        public ICollection<Transaction> Transactions { get; }
        protected Category() { }

        public Category(string categoryDescription, CategoryPurposeEnum categoryPurpose)
        {
            SetCategoryDescription(categoryDescription);
            SetCategoryPurpose(categoryPurpose);
        }

        public void SetCategoryDescription(string categortyDescription)
        {
            if (string.IsNullOrEmpty(categortyDescription))
                throw new ArgumentException("Descrição obrigatória");

            CategoryDescription = categortyDescription;
        }

        public void SetCategoryPurpose(CategoryPurposeEnum categoryPurpose)
        {
            if(!Enum.IsDefined(typeof(CategoryPurposeEnum), categoryPurpose))
                throw new ArgumentException("Finalidade não encontrada");

            CategoryPurpose = categoryPurpose;
        }
    }
}
