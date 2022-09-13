namespace CEM_API.Data.DTOs
{
    public class DefaultersDTO
    {
        public string? Status { get; set; }
        public string Category { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? AdditionalInfo { get; set; }
        public int NoOfOffence { get; set; }
        public string? PhotoPath { get; set; }
    }
}
