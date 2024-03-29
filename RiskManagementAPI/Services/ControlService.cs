﻿using RiskManagementAPI.Models;
using RiskManagementAPI.Repositories;

namespace RiskManagementAPI.Services;

public class ControlService : IControlService
{
    private readonly IControlRepository _controlRepository;

    public ControlService(IControlRepository controlRepository)
    {
        _controlRepository = controlRepository;
    }

    public async Task<IEnumerable<Control>> GetControls()
    {
        return await _controlRepository.GetControls();
    }

    public async Task<Control> GetControlById(int id)
    {
        return await _controlRepository.GetControlByID(id);
    }

    public async Task<IEnumerable<Control>> GetControlByRiskId(int riskId)
    {
        return await _controlRepository.GetControlByRiskId(riskId);
    }

    public async Task CreateControl(Control control)
    {
        await _controlRepository.AddControl(control);
    }

    public async Task UpdateControl(Control control)
    {
        await _controlRepository.UpdateControl(control);
    }

    public async Task DeleteControl(int id)
    {
        await _controlRepository.DeleteControl(id);
    }
    public async Task<bool> ControlExists(int id)
    {
        return await _controlRepository.ControlExists(id);
    }
}
