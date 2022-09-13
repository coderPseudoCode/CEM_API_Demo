using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class AuditLog
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
        public string? SessionId { get; set; }
        public string? User { get; set; }
        public string IpAddress { get; set; } = null!;
        public string Method { get; set; } = null!;
        public string Path { get; set; } = null!;
        public string? Data { get; set; }
        public string? UserAgent { get; set; }
        public string? ContentType { get; set; }
    }
}
