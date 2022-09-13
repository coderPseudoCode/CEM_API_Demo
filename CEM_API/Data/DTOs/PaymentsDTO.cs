namespace CEM_API.Data.DTOs
{
    public class PaymentsDTO
    {
        public string? Status { get; set; }
        public string OffenseCode { get; set; } = null!;
        public string FineCode { get; set; } = null!;
        public string PaymentType { get; set; } = null!;
    }
}
