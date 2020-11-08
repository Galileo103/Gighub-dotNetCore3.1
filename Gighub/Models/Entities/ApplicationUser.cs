using Microsoft.AspNetCore.Identity;

namespace Gighub.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Website { get; set; }
        public bool IsActive { get; set; }
        public string PhotoUrl { get; set; }
    }
}
