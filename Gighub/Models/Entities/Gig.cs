using Gighub.Models.Enums;
using Gighub.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gighub.Models.Entities
{
    public class Gig
    {
        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public int Id { get; set; }
        public bool IsCanceled { get; private set; }
        public string ArtistId { get; set; }
        public virtual ApplicationUser Artist { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public byte GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public ICollection<Attendance> Attendances  { get; private set; }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.GigCanceled(Id);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Update(GigFormViewModel viewModel)
        {
            var notification = Notification.GigUpdated(Id, DateTime, Venue);

            Venue = viewModel.Venue;
            DateTime = viewModel.GetDateTime();
            GenreId = viewModel.Genre;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        // TODO:: Implament Create Gig Notification
        public void Create()
        {
            var notification = Notification.GigCreated(Id);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}
