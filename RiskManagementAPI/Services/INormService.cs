using RiskManagementAPI.Models;

namespace RiskManagementAPI.Services;

public interface INormService
{
    Task<IEnumerable<Norm>> GetNorms();
    Task<Norm> GetNorm(int id);
    Task<IEnumerable<Norm>> GetNormByRiskId(int riskId);
    Task CreateNorm(Norm norm);
    Task UpdateNorm(Norm norm);
    Task DeleteNorm(int id);
    Task<bool> NormExists(int id);
}
