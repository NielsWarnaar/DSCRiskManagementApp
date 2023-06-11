using RiskManagementAPI.Models;

namespace RiskManagementAPI.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> GetCategoryByID(int CategoryID);
    Task AddCategory(Category category);
    Task UpdateCategory(Category category);
    Task DeleteCategory(int CategoryID);
    Task<bool> CategoryExists(int CategoryID);
}
