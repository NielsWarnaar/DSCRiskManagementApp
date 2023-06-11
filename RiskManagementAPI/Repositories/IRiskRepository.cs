using RiskManagementAPI.Models;

namespace RiskManagementAPI.Repositories;

public interface IRiskRepository
{
    Task<IEnumerable<Risk>> GetRisks();
    Task<Risk> GetRiskByID(int RiskID);
    Task AddRisk(Risk risk);
    Task UpdateRisk(Risk risk);
    Task DeleteRisk(int RiskID);
}
