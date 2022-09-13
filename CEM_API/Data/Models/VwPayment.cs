using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class VwPayment
    {
        public string Name { get; set; } = null!;
        public double Fine { get; set; }
        public string PaymentType { get; set; } = null!;
        public string? Uuid { get; set; }
    }
}
