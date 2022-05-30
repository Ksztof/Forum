using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileC = Forum.Domain.Models.UserProfile;

namespace Forum.Core.Models.UserProfile
{
    public class UserProfileShowFm
    {
        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DisplayName { get; set; }
    }
}
