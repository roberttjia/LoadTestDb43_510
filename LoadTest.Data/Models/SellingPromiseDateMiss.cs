using System;

namespace LoadTest.Data.Models
{
    public class SellingPromiseDateMiss
    {
        public int SellingPromiseDateMissId { get; set; }
        public int SellingId { get; set; }
        public DateTime PromisedDate { get; set; }
        public DateTime ActualDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; }
        public string Notes { get; set; } = string.Empty;

        public virtual Selling Selling { get; set; } = null!;
    }
}