using System;
using System.Collections.Generic;

namespace CEM_API.Data.Models
{
    public partial class TblSetting
    {
        public long Id { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? Phone { get; set; }
        public string? EmailAddress { get; set; }
        public string? WebAddress { get; set; }
        public decimal? VatRate { get; set; }
        public string? Vatregistration { get; set; }
        public string? Footermsg { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string? LastUpdateBy { get; set; }
        public DateTime? Logtime { get; set; }
        public string? LogBy { get; set; }
    }
}
