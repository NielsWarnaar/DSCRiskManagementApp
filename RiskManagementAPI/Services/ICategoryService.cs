using RiskManagementAPI.Models;

namespace RiskManagementAPI.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> GetCategoryById(int id);
    Task CreateCategory(Category category);
    Task UpdateCategory(Category category);
    Task DeleteCategory(int id);
    Task<bool> CategoryExists(int id);
}
