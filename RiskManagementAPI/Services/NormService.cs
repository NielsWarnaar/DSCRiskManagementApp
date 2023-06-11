using RiskManagementAPI.Models;
using RiskManagementAPI.Repositories;

namespace RiskManagementAPI.Services;

public class NormService : INormService
{
    private readonly INormRepository _normRepository;

    public NormService(INormRepository normRepository)
    {
        _normRepository = normRepository;
    }

    public async Task<IEnumerable<Norm>> GetNorms()
    {
        return await _normRepository.GetNorms();
    }

    public async Task<Norm> GetNorm(int id)
    {
        return await _normRepository.GetNormByID(id);
    }

    public async Task CreateNorm(Norm norm)
    {
        await _normRepository.AddNorm(norm);
    }

    public async Task UpdateNorm(Norm norm)
    {
        await _normRepository.UpdateNorm(norm);
    }

    public async Task DeleteNorm(int id)
    {
        await _normRepository.DeleteNorm(id);
    }
    public async Task<bool> NormExists(int id)
    {
        return await _normRepository.NormExists(id);
    }
}

