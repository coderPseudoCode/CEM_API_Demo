using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class RptDefaulter
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public int NoOfOffence { get; set; }
        public double Fine { get; set; }
        public string? Status { get; set; }
        public string OffenseCode { get; set; } = null!;
    }
}
