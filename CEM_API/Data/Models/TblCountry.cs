using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class TblCountry
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
