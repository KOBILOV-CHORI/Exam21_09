namespace Infrastructure.Services.Category;

public interface ICategoryService
{
    Task<IEnumerable<Domain.Models.Category>> GetCategoriesAsync();
    Task<bool> DeleteCategoryAsync(Guid id);
    Task<bool> UpdateCategoryAsync(Domain.Models.Category comment);
    Task<bool> AddCategoryAsync(Domain.Models.Category comment);
    Task<Domain.Models.Category>? GetCategoryByIdAsync(Guid id);
}