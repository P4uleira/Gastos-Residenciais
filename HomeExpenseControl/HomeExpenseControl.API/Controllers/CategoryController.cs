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
            var userResponse = categoryList.Select(category => new CategoryResponse(category.idCategory, category.CategoryDescription, category.CategoryPurpose));
            return Ok(userResponse);
        }

        [HttpGet("{idCategory}")]
        public async Task<ActionResult<CategoryResponse>> GetById(Guid idCategory)
        {
            var category = await _categoryService.GetCategoryById(idCategory);
            if (category == null)
                return NotFound();

            return Ok(new CategoryResponse(category.idCategory, category.CategoryDescription, category.CategoryPurpose));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryRequest categoryRequest)
        {
            var category = new Category (categoryRequest.CategoryDescription, categoryRequest.CategoryPurpose);
            await _categoryService.CreateCategory(category);
            return Ok();
        }

    }
}
