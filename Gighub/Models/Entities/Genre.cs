using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gighub.Models.Entities
{
    public class Genre
    {
        public Genre()
        {
            Gigs = new Collection<Gig>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Gig> Gigs { get; set; }

    }
}
