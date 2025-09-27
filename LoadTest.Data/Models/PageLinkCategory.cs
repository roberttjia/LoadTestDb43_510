using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class PageLinkCategory
    {
        public PageLinkCategory()
        {
            PageLink = new HashSet<PageLink>();
        }

        public int PageLinkCategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PageLink> PageLink { get; set; }
    }
}