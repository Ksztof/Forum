using Forum.Core.Models.AppUserModels;
using Forum.Domain.Models;
using Forum.Domain.Models.Account;
using Forum.Domain.Models.Identities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Interfaces.Account
{
    public interface IAccountService: IAccountServiceBase<RegisterFM, Domain.Models.AppUser, int, FormModelAppUser, ClaimsPrincipal, IdentityResult>
    {
    }
}
