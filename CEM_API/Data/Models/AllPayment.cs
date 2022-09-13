using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class AllPayment
    {
        public DateTimeOffset? PaymentDate { get; set; }
        public string? Collector { get; set; }
        public string Defaulter { get; set; } = null!;
        public string OffenseCode { get; set; } = null!;
        public double Amount { get; set; }
    }
}
