using System.Collections.Generic;

namespace Gighub.Models.Entities
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Gig> Gigs { get; set; }

    }
}
