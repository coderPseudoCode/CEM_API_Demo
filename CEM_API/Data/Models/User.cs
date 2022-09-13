using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        /// <summary>
        /// 1 =Active 2 =inactive
        /// </summary>
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public string? Uuid { get; set; }
        public string? Username { get; set; }
        public string? LoweredUsername { get; set; }
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OtherNames { get; set; }
        public string Email { get; set; } = null!;
        public string LoweredEmail { get; set; } = null!;
        public bool? EmailConfirmed { get; set; }
        public string Password { get; set; } = null!;
        public string? Salt { get; set; }
        public string? Rand { get; set; }
        public bool? FirstTimeLogin { get; set; }
        public string? Branch { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
