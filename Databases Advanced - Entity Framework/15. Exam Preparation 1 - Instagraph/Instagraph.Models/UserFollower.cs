using System;
using System.Collections.Generic;
using System.Text;

namespace Instagraph.Models
{
    public class UserFollower
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int FollowerId { get; set; }
        public User Follower { get; set; }
    }
}
