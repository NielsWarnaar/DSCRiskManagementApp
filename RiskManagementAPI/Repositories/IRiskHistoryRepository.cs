using RiskManagementAPI.Models;

namespace RiskManagementAPI.Repositories;

public interface IRiskHistoryRepository
{
    Task<IEnumerable<RiskHistory>> GetRiskHistories();
    Task<RiskHistory> GetRiskHistoryByID(int RiskHistoryID);
    Task AddRiskHistory(RiskHistory riskHistory);
    Task UpdateRiskHistory(RiskHistory riskHistory);
    Task DeleteRiskHistory(int RiskHistoryID);
    Task<bool> RiskHistoryExists(int RiskHistoryID);
}
