using RiskManagementAPI.Models;

namespace RiskManagementAPI.Services;

public interface IRiskService
{
    Task<IEnumerable<Risk>> GetRisks();
    Task<Risk> GetRiskById(int id);
    Task<IEnumerable<Risk>> GetRiskByCategoryId(int categoryId);
    Task AddRisk(Risk risk);
    Task UpdateRisk(Risk risk);
    Task DeleteRisk(int id);
    Task<bool> RiskExists(int id);
}
