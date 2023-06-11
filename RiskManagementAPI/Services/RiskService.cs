using RiskManagementAPI.Models;
using RiskManagementAPI.Repositories;

namespace RiskManagementAPI.Services;

public class RiskService : IRiskService
{
    private readonly IRiskRepository _riskRepository;

    public RiskService(IRiskRepository riskRepository)
    {
        _riskRepository = riskRepository;
    }

    public async Task<IEnumerable<Risk>> GetRisks()
    {
        return await _riskRepository.GetRisks();
    }

    public async Task<Risk> GetRiskById(int id)
    {
        return await _riskRepository.GetRiskByID(id);
    }

    public async Task AddRisk(Risk risk)
    {
        await _riskRepository.AddRisk(risk);
    }

    public async Task UpdateRisk(Risk risk)
    {
        await _riskRepository.UpdateRisk(risk);
    }

    public async Task DeleteRisk(int id)
    {
        await _riskRepository.DeleteRisk(id);
    }

    public async Task<bool> RiskExists(int id)
    {
        return await _riskRepository.RiskExists(id);
    }
}
