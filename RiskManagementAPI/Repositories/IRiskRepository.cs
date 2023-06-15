using RiskManagementAPI.Models;

namespace RiskManagementAPI.Repositories;

public interface IRiskRepository
{
    Task<IEnumerable<Risk>> GetRisks();
    Task<Risk> GetRiskByID(int RiskID);
    Task<IEnumerable<Risk>> GetRiskByCategoryId(int CategoryId);
    Task AddRisk(Risk risk);
    Task UpdateRisk(Risk risk);
    Task DeleteRisk(int RiskID);
    Task<bool> RiskExists(int RiskID);
}
