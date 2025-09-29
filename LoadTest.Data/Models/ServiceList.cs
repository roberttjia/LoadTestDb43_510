using System;

namespace LoadTest.Data.Models
{
    public class ServiceList
    {
        public int ServiceListId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual Service Service { get; set; } = null!;
    }
}