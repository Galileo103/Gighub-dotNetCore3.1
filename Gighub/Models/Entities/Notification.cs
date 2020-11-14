using Gighub.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gighub.Models.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public NotificationType NotificationType { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }

        public int GigId { get; set; }
        public virtual Gig Gig { get; set; }
    }
}
