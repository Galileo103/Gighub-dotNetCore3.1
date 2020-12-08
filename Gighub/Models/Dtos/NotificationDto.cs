using Gighub.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gighub.Models.Dtos
{
    public class NotificationDto
    {
        public NotificationType NotificationType { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }

        public virtual GigDto Gig { get; set; }
    }
}
