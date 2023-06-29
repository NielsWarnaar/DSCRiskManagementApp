using RiskManagementAPI.Models;

namespace RiskManagementAPI.Services;

public interface IControlService
{
    Task<IEnumerable<Control>> GetControls();
    Task<Control> GetControlById(int id);
    Task<IEnumerable<Control>> GetControlByRiskId(int riskId);
    Task CreateControl(Control control);
    Task UpdateControl(Control control);
    Task DeleteControl(int id);
    Task<bool> ControlExists(int id);
}
