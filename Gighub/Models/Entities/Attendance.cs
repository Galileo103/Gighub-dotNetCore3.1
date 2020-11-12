using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gighub.Models.Entities
{
    public class Attendance
    {
        public int GigId { get; set; }
        public Gig Gig { get; set; }

        public string AttendeeId { get; set; }
        public ApplicationUser Attendee { get; set; }
    }
}
