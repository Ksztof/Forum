using Forum.Core.Interfaces.BaseInterface;
using Forum.Domain;

namespace Forum.Core.Interfaces.AppUsers
{
    public interface IAppUserService : IService<AppUser>
    {
        public AppUser GetByEmail(string email);
    }


}
