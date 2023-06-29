namespace RiskManagementAPI.Models
{
    public class Norm
    {
        public int NormId { get; set; }

        public string NormName { get; set; } = null!;

        public string NormDescription { get; set; } = null!;

        public ICollection<Risk>? Risks { get; set; }

        public int RiskId { get; set; }
    }
}
