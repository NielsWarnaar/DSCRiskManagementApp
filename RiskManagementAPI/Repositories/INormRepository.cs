using RiskManagementAPI.Models;

namespace RiskManagementAPI.Repositories;

public interface INormRepository
{
    Task<IEnumerable<Norm>> GetNorms();
    Task<Norm> GetNormByID(int NormID);
    Task AddNorm(Norm norm);
    Task UpdateNorm(Norm norm);
    Task DeleteNorm(int NormID);
}
