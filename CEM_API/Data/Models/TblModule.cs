using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class TblModule
    {
        public TblModule()
        {
            TblRolePermissions = new HashSet<TblRolePermission>();
        }

        public int Id { get; set; }
        public int? DisplayOrder { get; set; }
        public string? ModuleName { get; set; }
        public string? PageIcon { get; set; }
        public string? PageUrl { get; set; }
        public string? PageSlug { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public int? ParentModuleId { get; set; }

        public virtual ICollection<TblRolePermission> TblRolePermissions { get; set; }
    }
}
