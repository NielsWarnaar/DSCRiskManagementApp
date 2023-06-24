namespace RiskManagementAPI.Models;

public class RiskHistory
{
    public int RiskHistoryId { get; set; }
    public string RiskName { get; set; } = null!;
    public int RiskValueInherent { get; set; }
    public int RiskValueControlled { get; set; }
    public int ProbabilityValueInherent { get; set; }
    public int ImpactValueInherent { get; set; }
    public int ProbabilityValueControlled { get; set; }
    public int ImpactValueControlled { get; set; }
    public string Description { get; set; } = null!;
    public string ActionType { get; set; } = null!;
    public string OutstandingActions { get; set; } = null!;
    public string Classification { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime HistoryDate { get; set; }

    // Navigation Properties
    public int RiskId { get; set; }
}
