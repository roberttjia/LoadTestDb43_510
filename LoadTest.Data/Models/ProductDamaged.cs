using System;

namespace LoadTest.Data.Models
{
    public class ProductDamaged
    {
        public int ProductDamagedId { get; set; }
        public int ProductStockId { get; set; }
        public string DamageType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DamageDate { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual ProductStock ProductStock { get; set; } = null!;
    }
}