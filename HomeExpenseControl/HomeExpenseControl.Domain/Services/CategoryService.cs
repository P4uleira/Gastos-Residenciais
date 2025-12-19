using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Interfaces.Repositories;
using HomeExpenseControl.Domain.Interfaces.Services;

namespace HomeExpenseControl.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService (ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategory(Category category)
        {
            var newCategory = new Category(category.CategoryDescription, category.CategoryPurpose);

            await _categoryRepository.AddAsync(newCategory);
        }
        public async Task<Category> GetCategoryById(Guid idCategory)
        {
            return await _categoryRepository.GetByIdAsync(idCategory);
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllAsync();
        }
    }
}
