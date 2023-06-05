using System.ComponentModel.DataAnnotations;


namespace RiskManagementShared.Models;

public class Risk
{

    public int RiskId { get; set; }

    // For connection with category
    public int CategoryId { get; set; }

    [MaxLength(255)]
    public string Description { get; set; } = null!;
    public string ActionType { get; set; } = null!;
    public string OutstandingActions { get; set; } = null!;
    public string Classification { get; set; } = null!;

    public DateTime CreationDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public DateTime DueDate { get; set; }

}
