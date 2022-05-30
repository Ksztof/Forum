using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Models.Identities
{
    public class WebAppUser : IdentityUser//TODO: Przenieść Modele BD do folderu MODEL
    {
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }

        public virtual ICollection<WebAppUserClaims> Claims { get; set; }
        public virtual ICollection<WebAppUserLogin> Logins { get; set; }
        public virtual ICollection<WebAppUserToken> Tokens { get; set; }
        public virtual ICollection<WebAppUserRole> UserRoles { get; set; }
    }


    public class WebAppRole : IdentityRole
    {
        public WebAppRole(string roleName)
        {
            Name = roleName;
            NormalizedName = roleName.ToUpper();
            ConcurrencyStamp = DateTime.Now.ToString();
        }

        public WebAppRole()
        {
        }

        public virtual ICollection<WebAppUserRole> UserRoles { get; set; }
        public virtual ICollection<WebAppRoleClaim> RoleClaims { get; set; }
    }

    public class WebAppRoleClaim : IdentityRoleClaim<string>
    {
        public virtual WebAppRole Role { get; set; }
    }

    public class WebAppUserRole : IdentityUserRole<string>
    {
        public virtual WebAppUser User { get; set; }
        public virtual WebAppRole Role { get; set; }
    }

    public class WebAppUserClaims : IdentityUserClaim<string>
    {
        public virtual WebAppUser User { get; set; }
    }

    public class WebAppUserLogin : IdentityUserLogin<string>
    {
        public virtual WebAppUser User { get; set; }
    }

    public class WebAppUserToken : IdentityUserToken<string>
    {
        public virtual WebAppUser User { get; set; }
    }
}
