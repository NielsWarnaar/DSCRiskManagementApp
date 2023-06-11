using RiskManagementAPI.Models;
using RiskManagementAPI.Repositories;

namespace RiskManagementAPI.Services;

public class RiskHistoryService : IRiskHistoryService
{
    private readonly IRiskHistoryRepository _riskHistoryRepository;

    public RiskHistoryService(IRiskHistoryRepository riskHistoryRepository)
    {
        _riskHistoryRepository = riskHistoryRepository;
    }

    public async Task<IEnumerable<RiskHistory>> GetAllRiskHistory()
    {
        return await _riskHistoryRepository.GetRiskHistories();
    }

    public async Task<RiskHistory> GetRiskHistoryById(int id)
    {
        return await _riskHistoryRepository.GetRiskHistoryByID(id);
    }
    public async Task<IEnumerable<RiskHistory>> GetRiskHistoryByRiskId(int riskId)
    {
        return await _riskHistoryRepository.GetRiskHistoryByRiskId(riskId);
    }

    public async Task CreateRiskHistory(RiskHistory riskHistory)
    {
        await _riskHistoryRepository.AddRiskHistory(riskHistory);
    }

    public async Task UpdateRiskHistory(RiskHistory riskHistory)
    {
        await _riskHistoryRepository.UpdateRiskHistory(riskHistory);
    }

    public async Task DeleteRiskHistory(int id)
    {
        await _riskHistoryRepository.DeleteRiskHistory(id);
    }

    public async Task<bool> RiskHistoryExists(int id)
    {
        return await _riskHistoryRepository.RiskHistoryExists(id);
    }
}
