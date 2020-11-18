using Gighub.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gighub.Models.Entities
{
    public class Notification
    {
        public int Id { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime DateTime { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        public int GigId { get; private set; }
        public virtual Gig Gig { get; private set; }

        protected Notification()
        {
        }

        private Notification(NotificationType type, int gigId)
        {
            NotificationType = type;
            GigId = gigId;
            DateTime = DateTime.Now;
        }

        public static Notification GigCreated(int gigId)
        {
            return new Notification(NotificationType.GigCreated, gigId);
        }

        public static Notification GigUpdated(int gigId, DateTime originalDateTime, string originalVenue)
        {
            var notification = new Notification(NotificationType.GigUpdated, gigId);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;

            return notification;
        }

        public static Notification GigCanceled(int gigId)
        {
            return new Notification(NotificationType.GigCanceled, gigId);
        }
    }
}
