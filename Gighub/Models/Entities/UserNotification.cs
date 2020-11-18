using Gighub.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gighub.Models.Entities
{
    public class UserNotification
    {
        public string UserId { get; private set; }
        public virtual ApplicationUser User { get; private set; }

        public int NotificationId { get; private set; }
        public virtual Notification Notification { get; private set; }

        public bool IsRead { get; set; }

        protected UserNotification()
        {
        }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (notification == null)
            {
                throw new ArgumentNullException("notification");
            }

            User = user;
            Notification = notification;
        }
    }
}
