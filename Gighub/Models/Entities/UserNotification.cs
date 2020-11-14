using Gighub.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gighub.Models.Entities
{
    public class UserNotification
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int NotificationId { get; set; }
        public virtual Notification Notification { get; set; }

        public bool IsRead { get; set; }
    }
}
