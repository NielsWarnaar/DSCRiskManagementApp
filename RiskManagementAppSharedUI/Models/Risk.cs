using System.ComponentModel.DataAnnotations;


namespace RiskManagementAppSharedUI.Models;

public class Risk
{
    public int RiskId { get; set; }

    public string RiskName { get; set; } = null!;
    public int RiskValueInherent { get; set; }
    public int RiskValueControlled { get; set; }
    [Required(ErrorMessage = "RiskValueControlled is required.")]
    public int ProbabilityValueInherent { get; set; }
    [Required]
    public int ImpactValueInherent { get; set; }
    [Required]
    public int ProbabilityValueControlled { get; set; }
    [Required]
    public int ImpactValueControlled { get; set; }
    public string Description { get; set; } = null!;
    public string ActionType { get; set; } = null!;
    public string OutstandingActions { get; set; } = null!;
    public string Classification { get; set; } = null!;

    public DateTime CreationDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public DateTime DueDate { get; set; }

    // Navigation Properties
    public ICollection<Control>? Controls { get; set; }

    public ICollection<Norm>? Norms { get; set; }
    public Category? Category { get; set; }
    public int? CategoryId { get; set; }
    public int? NormId { get; set; }
}
