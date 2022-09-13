using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class TblUserLog
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? Message { get; set; }
        public DateTime? LogTime { get; set; }
        public string? Ipaddress { get; set; }
        public string? MoreInfo { get; set; }

        public virtual TblUser? User { get; set; }
    }
}
