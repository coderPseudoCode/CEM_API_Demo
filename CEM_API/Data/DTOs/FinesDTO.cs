namespace CEM_API.Data.DTOs
{
    public class FinesDTO
    {
        public string? Status { get; set; }
        public string Category { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string OffenseCode { get; set; } = null!;
        public string? AdditionalInfo { get; set; }
        public double Fine1 { get; set; }
    }
}
