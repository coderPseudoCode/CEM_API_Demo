using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblUserLogs = new HashSet<TblUserLog>();
        }

        public Guid Id { get; set; }
        public Guid? RoleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? CountryId { get; set; }
        public string? Gender { get; set; }
        public string? PhotoPath { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsLockedOut { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastLockoutDate { get; set; }
        public int? FailedPasswordCount { get; set; }
        public DateTime? InsertDate { get; set; }
        public Guid? InsertBy { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? LastModifiedBy { get; set; }

        public virtual ICollection<TblUserLog> TblUserLogs { get; set; }
    }
}
