using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class Payment
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
        public string OffenseCode { get; set; } = null!;
        public string FineCode { get; set; } = null!;
        public string PaymentType { get; set; } = null!;
    }
}
