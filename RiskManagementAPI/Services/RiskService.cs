using Microsoft.CodeAnalysis.CSharp.Syntax;
using RiskManagementAPI.Models;
using RiskManagementAPI.Repositories;
using RiskManagementAPI.Controllers;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace RiskManagementAPI.Services;

public class RiskService : IRiskService
{
    private readonly IRiskRepository _riskRepository;

    private readonly IRiskHistoryRepository? _riskHistoryRepository;

    public RiskService(IRiskRepository riskRepository, IRiskHistoryRepository riskHistoryRepository)
    {
        _riskRepository = riskRepository;
        _riskHistoryRepository = riskHistoryRepository;
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
        var riskHistory = new RiskHistory();

/*        riskHistory.RiskId = risk.RiskId;
        riskHistory.RiskName = risk.RiskName;
        riskHistory.Description = risk.Description;
        riskHistory.ActionType = risk.ActionType;
        riskHistory.OutstandingActions = risk.OutstandingActions;
        riskHistory.Classification = risk.Classification;
        riskHistory.CreationDate = risk.CreationDate;
        riskHistory.LastUpdated = risk.LastUpdated;
        riskHistory.DueDate = risk.DueDate;
        riskHistory.HistoryDate = DateTime.Now;

        await _riskHistoryRepository.AddRiskHistory(riskHistory);*/

        await _riskRepository.AddRisk(risk);
    }

    public async Task UpdateRisk(Risk risk)
    {
        var riskHistory = new RiskHistory();
        //var oldRisk = await _riskRepository.GetRiskByID(risk.RiskId);

        riskHistory.RiskId = risk.RiskId;
        riskHistory.RiskName = risk.RiskName;
        riskHistory.Description = risk.Description;
        riskHistory.ActionType = risk.ActionType;
        riskHistory.OutstandingActions = risk.OutstandingActions;
        riskHistory.Classification = risk.Classification;
        riskHistory.CreationDate = risk.CreationDate;
        riskHistory.LastUpdated = risk.LastUpdated;
        riskHistory.DueDate = risk.DueDate;
        riskHistory.HistoryDate = DateTime.Now;

        if (!await _riskRepository.RiskExists(risk.RiskId))
        {
            throw new Exception("Risk not found");
        }

        await _riskHistoryRepository.AddRiskHistory(riskHistory);
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
