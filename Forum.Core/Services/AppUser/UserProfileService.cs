using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Repositories.AppUser;
using Forum.Domain;

namespace Forum.Core.Services.AppUser
{
    public class UserProfileService : IUserProfileService
    {
        private UserProfileRepository _userProfileRepository = null;
        private UserProfileRepository userProfileRepository
        {
            get
            {
                if (_userProfileRepository == null)
                {
                    _userProfileRepository = new UserProfileRepository();
                }

                return _userProfileRepository;
            }
        }



        public UserProfile Add(UserProfile entity)
        {
            return userProfileRepository.Add(entity);
        }

        public bool Delete(UserProfile entity)
        {
            return userProfileRepository.Delete(entity);
        }



        public UserProfile GetBy(int id)
        {
            var userProfile = userProfileRepository.GetBy(id);
            return userProfile;
        }



        public IEnumerable<UserProfile> GetList()
        {
            var userProfiles = userProfileRepository.GetList();
            return userProfiles.ToList();
        }


        public UserProfile Update(UserProfile entity)
        {
            throw new NotImplementedException();
        }
    }
}
