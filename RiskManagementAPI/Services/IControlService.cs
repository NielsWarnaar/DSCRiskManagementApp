using RiskManagementAPI.Models;

namespace RiskManagementAPI.Services;

public interface IControlService
{
    Task<IEnumerable<Control>> GetControls();
    Task<Control> GetControlById(int id);
    Task CreateControl(Control control);
    Task UpdateControl(Control control);
    Task DeleteControl(int id);
}
