using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class AdminUser
    {
        public long Id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? UserPhone { get; set; }
        public string? Email { get; set; }
        public string? UserAddress { get; set; }
        public string? Supervisor { get; set; }
        public string UserId { get; set; } = null!;
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public string? DateofBirth { get; set; }
        public DateTime? Logtime { get; set; }
        public string? Logby { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string? LastupdateBy { get; set; }
        public int? Status { get; set; }
        public string? UserPhoto { get; set; }
    }
}
