using RiskManagementAPI.Models;

namespace RiskManagementAPI.Services;

public interface IRiskHistoryService
{
    Task<IEnumerable<RiskHistory>> GetAllRiskHistory();
    Task<RiskHistory> GetRiskHistoryById(int id);
    Task<IEnumerable<RiskHistory>> GetRiskHistoryByRiskId(int riskId);
    Task CreateRiskHistory(RiskHistory riskHistory);
    Task UpdateRiskHistory(RiskHistory riskHistory);
    Task DeleteRiskHistory(int id);
    Task<bool> RiskHistoryExists(int id);
}
