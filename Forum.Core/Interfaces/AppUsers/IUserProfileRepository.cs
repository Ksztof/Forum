using Forum.Core.Interfaces.BaseInterface;
using Forum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Interfaces.AppUsers
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {

    }
}
