using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class Offense
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
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Fine { get; set; }
        public string? Institution { get; set; }
    }
}
