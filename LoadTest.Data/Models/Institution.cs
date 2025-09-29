using System;

namespace LoadTest.Data.Models
{
    public partial class Institution
    {
        public int InstitutionId { get; set; }
        public int VoucherCountdown { get; set; }
        public string InstitutionName { get; set; } = string.Empty;
        public string DialogTitle { get; set; } = string.Empty;
        public string Established { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string LocalArea { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public byte[]? InstitutionLogo { get; set; }
        public DateTime InsertDate { get; set; }
    }
}