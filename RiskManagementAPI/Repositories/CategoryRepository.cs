using RiskManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using RiskManagementAPI.DBContext;

namespace RiskManagementAPI.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly RiskDbContext _dbContext;

    public CategoryRepository(RiskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryByID(int CategoryID)
    {
        return await _dbContext.Categories.FindAsync(CategoryID);
    }

    public async Task AddCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateCategory(Category category)
    {
        _dbContext.Entry(category).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCategory(int CategoryID)
    {
        Category category = await _dbContext.Categories.FindAsync(CategoryID);
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> CategoryExists(int CategoryID)
    {
        return await _dbContext.Categories.AnyAsync(e => e.CategoryId == CategoryID);
    }
}