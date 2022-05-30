using Forum.Core.Interfaces.BaseInterface;
using Forum.Domain.Models;

namespace Forum.Core.Interfaces.AppUsers
{
    public interface IAppUserService : IService<AppUser>
    {
        public AppUser GetByEmail(string email);
    }


}
