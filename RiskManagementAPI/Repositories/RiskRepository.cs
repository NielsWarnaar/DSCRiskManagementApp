using RiskManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using RiskManagementAPI.DBContext;

namespace RiskManagementAPI.Repositories;

public class RiskRepository : IRiskRepository
{
    private readonly RiskDbContext _dbContext;

    public RiskRepository(RiskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Risk>> GetRisks()
    {
        return await _dbContext.Risks.ToListAsync();
    }

    public async Task<Risk> GetRiskByID(int RiskID)
    {
        return await _dbContext.Risks.FindAsync(RiskID);
    }

    public async Task<IEnumerable<Risk>> GetRiskByCategoryId(int CategoryId)
    {
        return await _dbContext.Risks
            .Where(risk => risk.CategoryId == CategoryId)
            .ToListAsync();
    }

    public async Task AddRisk(Risk risk)
    {
        _dbContext.Risks.Add(risk);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRisk(Risk risk)
    {
        _dbContext.Entry(risk).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRisk(int RiskID)
    {
        Risk risk = await _dbContext.Risks.FindAsync(RiskID);
        _dbContext.Risks.Remove(risk);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> RiskExists(int RiskID)
    {
        return await _dbContext.Risks.AnyAsync(e => e.RiskId == RiskID);
    }
}
