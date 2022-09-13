namespace CEM_API.Data.DTOs
{
    public class OffensesDTO
    {
        public string? Status { get; set; }
        public string Name { get; set; } = null!;
        public double Fine { get; set; }
        public string? Institution { get; set; }
    }
}
