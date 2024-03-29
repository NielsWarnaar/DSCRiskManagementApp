﻿using RiskManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using RiskManagementAPI.DBContext;

namespace RiskManagementAPI.Repositories;

public class RiskHistoryRepository : IRiskHistoryRepository
{
    private readonly RiskDbContext _dbContext;

    public RiskHistoryRepository(RiskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<RiskHistory>> GetRiskHistories()
    {
        return await _dbContext.RiskHistories.ToListAsync();
    }

    public async Task<RiskHistory> GetRiskHistoryByID(int RiskHistoryID)
    {
        return await _dbContext.RiskHistories.FindAsync(RiskHistoryID);
    }

    public async Task<IEnumerable<RiskHistory>> GetRiskHistoryByRiskId(int RiskID)
    {
        return await _dbContext.RiskHistories
            .Where(risk => risk.RiskId == RiskID)
            .ToListAsync();
    }

    public async Task AddRiskHistory(RiskHistory riskHistory)
    {
        _dbContext.RiskHistories.Add(riskHistory);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRiskHistory(RiskHistory riskHistory)
    {
        _dbContext.Entry(riskHistory).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRiskHistory(int RiskHistoryID)
    {
        RiskHistory riskHistory = await _dbContext.RiskHistories.FindAsync(RiskHistoryID);
        _dbContext.RiskHistories.Remove(riskHistory);
        await _dbContext.SaveChangesAsync();
    }
//    public async Task<IEnumerable<RiskHistory>> GetRiskHistoriesByRiskID(int RiskID)
//    {
//        return await _dbContext.RiskHistories.Where(r => r.RiskII == RiskID).ToListAsync();
//    }
    public async Task<bool> RiskHistoryExists(int RiskHistoryID)
    {
        return await _dbContext.RiskHistories.AnyAsync(e => e.RiskHistoryId == RiskHistoryID);
    }
}
