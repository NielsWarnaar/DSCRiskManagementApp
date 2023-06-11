using RiskManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using RiskManagementAPI.DBContext;

namespace RiskManagementAPI.Repositories;

public class NormRepository : INormRepository
{
    private readonly RiskDbContext _dbContext;

    public NormRepository(RiskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Norm>> GetNorms()
    {
        return await _dbContext.Norms.ToListAsync();
    }

    public async Task<Norm> GetNormByID(int NormID)
    {
        return await _dbContext.Norms.FindAsync(NormID);
    }

    public async Task AddNorm(Norm norm)
    {
        _dbContext.Norms.Add(norm);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateNorm(Norm norm)
    {
        _dbContext.Entry(norm).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteNorm(int NormID)
    {
        Norm norm = await _dbContext.Norms.FindAsync(NormID);
        _dbContext.Norms.Remove(norm);
        await _dbContext.SaveChangesAsync();
    }   

    public async Task<bool> NormExists(int NormID)
    {
        return await _dbContext.Norms.AnyAsync(e => e.NormId == NormID);
    }
}
