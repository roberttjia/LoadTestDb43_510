using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class ProductCatalogType
    {
        public ProductCatalogType()
        {
            ProductCatalog = new HashSet<ProductCatalog>();
        }

        public int ProductCatalogTypeId { get; set; }
        public string ProductCatalogTypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public virtual ICollection<ProductCatalog> ProductCatalog { get; set; }
    }
}