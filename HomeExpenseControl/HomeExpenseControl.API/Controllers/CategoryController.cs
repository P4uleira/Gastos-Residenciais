using HomeExpenseControl.Api.DTO.Requests;
using HomeExpenseControl.Api.DTO.Responses;
using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeExpenseControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetAll()
        {
            var categoryList = await _categoryService.GetAllCategories();
            var categoryResponse = categoryList.Select(category => new CategoryResponse(category.idCategory, category.CategoryDescription, category.CategoryPurpose));
            return Ok(categoryResponse);
        }

        [HttpGet("{idCategory}")]
        public async Task<ActionResult<CategoryResponse>> GetById(Guid idCategory)
        {
            var category = await _categoryService.GetCategoryById(idCategory);

            return Ok(new CategoryResponse(category.idCategory, category.CategoryDescription, category.CategoryPurpose));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryRequest categoryRequest)
        {
            try
            {
                var category = new Category(categoryRequest.CategoryDescription, categoryRequest.CategoryPurpose);
                await _categoryService.CreateCategory(category);

                return Ok(new CategoryResponse(category.idCategory, category.CategoryDescription, category.CategoryPurpose));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
