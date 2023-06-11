using RiskManagementAPI.Models;

namespace RiskManagementAPI.Repositories;

public interface IControlRepository
{
    Task<IEnumerable<Control>> GetControls();
    Task<Control> GetControlByID(int ControlID);
    Task AddControl(Control control);
    Task UpdateControl(Control control);
    Task DeleteControl(int ControlID);
    Task<bool> ControlExists(int ControlID);
}
