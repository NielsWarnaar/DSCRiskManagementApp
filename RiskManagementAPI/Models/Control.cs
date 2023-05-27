namespace RiskManagementAPI.Models
{
    public class Control
    {
        public int ControlId { get; set; }

        public string ControlName { get; set; } = null!;

        public string ControlDescription { get; set; } = null!;

        public string ControlType { get; set; } = null!;
    }
}
