using RiskManagementAPI.Models;
using RiskManagementAPI.Repositories;

namespace RiskManagementAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _categoryRepository.GetCategories();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await _categoryRepository.GetCategoryByID(id);
    }

    public async Task CreateCategory(Category category)
    {
        await _categoryRepository.AddCategory(category);
    }

    public async Task UpdateCategory(Category category)
    {
        await _categoryRepository.UpdateCategory(category);
    }

    public async Task DeleteCategory(int id)
    {
        await _categoryRepository.DeleteCategory(id);
    }
    public async Task<bool> CategoryExists(int id)
    {
        return await _categoryRepository.CategoryExists(id);
    }
}
