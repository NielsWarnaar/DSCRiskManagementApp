using RiskManagementAPI.Models;

namespace RiskManagementAPI.Repositories;

public interface INormRepository
{
    Task<IEnumerable<Norm>> GetNorms();
    Task<Norm> GetNormByID(int NormID);
    Task<IEnumerable<Norm>> GetNormByRiskId(int RiskId);
    Task AddNorm(Norm norm);
    Task UpdateNorm(Norm norm);
    Task DeleteNorm(int NormID);
    Task<bool> NormExists(int NormID);
}
