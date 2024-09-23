using Domain.Models;
using Infrastructure.Services.Category;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("Category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpPost("Category")]
    public async Task<bool> AddCategory(Category category)
    {
        var result = await _categoryService.AddCategoryAsync(category);
        return result;
    }
    [HttpPut("Category")]
    public async Task<bool> UpdateCategory(Category category)
    {
        var result = await _categoryService.UpdateCategoryAsync(category);
        return result;
    }
    [HttpDelete("Category")]
    public async Task<bool> DeleteCategory(Guid id)
    {
        var result = await _categoryService.DeleteCategoryAsync(id);
        return result;
    }
    [HttpGet("Category")]
    public async Task<Category> GetCategoryById(Guid id)
    {
        var result = await _categoryService.GetCategoryByIdAsync(id);
        return result;
    }
    [HttpGet("GetCategories")]
    public async Task<IEnumerable<Category>> GetCategories()
    {
        var result = await _categoryService.GetCategoriesAsync();
        return result;
    }
}