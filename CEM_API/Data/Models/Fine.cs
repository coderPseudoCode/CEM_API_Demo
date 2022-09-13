using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class Fine
    {
        public int Id { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public string? Uuid { get; set; }
        public string Category { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string OffenseCode { get; set; } = null!;
        public string? AdditionalInfo { get; set; }
        public double Fine1 { get; set; }
        public string FineCode { get; set; } = null!;
    }
}
