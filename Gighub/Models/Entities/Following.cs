using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gighub.Models.Entities
{
    public class Following
    {
        public string FollowerId { get; set; }
        public ApplicationUser Follower { get; set; }

        public string FolloweeId { get; set; }
        public ApplicationUser Followee { get; set; }
    }
}
