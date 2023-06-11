using RiskManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using RiskManagementAPI.DBContext;

namespace RiskManagementAPI.Repositories;

public class ControlRepository : IControlRepository
{
    private readonly RiskDbContext _dbContext;

    public ControlRepository(RiskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Control>> GetControls()
    {
        return await _dbContext.Controls.ToListAsync();
    }

    public async Task<Control> GetControlByID(int ControlID)
    {
        return await _dbContext.Controls.FindAsync(ControlID);
    }

    public async Task AddControl(Control control)
    {
        _dbContext.Controls.Add(control);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateControl(Control control)
    {
        _dbContext.Entry(control).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteControl(int ControlID)
    {
        Control control = await _dbContext.Controls.FindAsync(ControlID);
        _dbContext.Controls.Remove(control);
        await _dbContext.SaveChangesAsync();
    }   

    public async Task<bool> ControlExists(int ControlID)
    {
        return await _dbContext.Controls.AnyAsync(e => e.ControlId == ControlID);
    }
}
