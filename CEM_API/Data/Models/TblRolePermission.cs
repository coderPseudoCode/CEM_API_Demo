using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class TblRolePermission
    {
        public int Id { get; set; }
        public int? ModuleId { get; set; }
        public Guid? RoleId { get; set; }
        public bool? IsView { get; set; }
        public bool? IsAdd { get; set; }
        public bool? IsEdit { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblModule? Module { get; set; }
        public virtual TblRole? Role { get; set; }
    }
}
