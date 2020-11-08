using System;

namespace Gighub.Models.Entities
{
    public class Gig
    {
        public int Id { get; set; }
        public string ArtistId { get; set; }
        public virtual ApplicationUser Artist { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public byte GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
