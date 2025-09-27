using System;

namespace LoadTest.Data.Models
{
    public class CustomerPhone
    {
        public int CustomerPhoneId { get; set; }
        public int CustomerId { get; set; }
        public string Phone { get; set; } = string.Empty;
        public bool? IsPrimary { get; set; }
        public DateTime InsertDate { get; set; }
        
        public virtual Customer Customer { get; set; } = null!;
    }
}