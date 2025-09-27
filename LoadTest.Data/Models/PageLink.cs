using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class PageLink
    {
        public PageLink()
        {
            PageLinkAssign = new HashSet<PageLinkAssign>();
        }

        public int PageLinkId { get; set; }
        public int PageLinkCategoryId { get; set; }
        public string PageName { get; set; } = string.Empty;
        public string PageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual PageLinkCategory PageLinkCategory { get; set; } = null!;
        public virtual ICollection<PageLinkAssign> PageLinkAssign { get; set; }
    }
}