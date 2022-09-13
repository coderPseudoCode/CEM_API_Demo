using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class Defaulter
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
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? AdditionalInfo { get; set; }
        public int NoOfOffence { get; set; }
        public string? PhotoPath { get; set; }
    }
}
