using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblRolePermissions = new HashSet<TblRolePermission>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsDefault { get; set; }
        public Guid? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? LastModifiedBy { get; set; }

        public virtual ICollection<TblRolePermission> TblRolePermissions { get; set; }
    }
}
