using System;

namespace LoadTest.Data.Models
{
    public class PageLinkAssign
    {
        public int PageLinkAssignId { get; set; }
        public int PageLinkId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public bool CanView { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual PageLink PageLink { get; set; } = null!;
    }
}