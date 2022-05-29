using Forum.Core.Interfaces.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Interfaces.AppUsers
{
    public interface IUserProfileRepository : IRepository<Forum.Domain.UserProfile>
    {

    }
}
