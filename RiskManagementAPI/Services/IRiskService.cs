using RiskManagementAPI.Models;

namespace RiskManagementAPI.Services;

public interface IRiskService
{
    Task<IEnumerable<Risk>> GetRisks();
    Task<Risk> GetRiskById(int id);
    Task AddRisk(Risk risk);
    Task UpdateRisk(Risk risk);
    Task DeleteRisk(int id);
    Task<bool> RiskExists(int id);
}
