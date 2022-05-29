using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Interfaces.BaseInterface;
using Forum.Domain;

namespace Forum.Core.Repositories.AppUser
{
    public class UserProfileRepository : Repository, IUserProfileRepository
    {
        public UserProfile Add(UserProfile entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var userProfile = db.UserProfiles.Add(entity);
                db.SaveChanges();
                return userProfile.Entity;
            }
        }

        public bool Delete(UserProfile entity)
        {
            using (ForumDb db = new ForumDb())
            {
                db.UserProfiles.Remove(entity);
                db.SaveChanges();
                return true;
            }
        }

        public UserProfile GetBy(int id)
        {
            using (ForumDb db = new ForumDb())
            {
                var userProfile = db.UserProfiles.Where(x => x.AppUserId == id).First();
                return userProfile;
            }
        }

        public IEnumerable<UserProfile> GetList()
        {
            using (ForumDb db = new ForumDb())
            {
                var userProfiles = db.UserProfiles.OrderBy(x => x.AppUserId);
                return userProfiles.AsEnumerable();
            }
        }

        public UserProfile Update(UserProfile entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var userProfile = db.UserProfiles.Update(entity);
                return userProfile.Entity;
            }
        }
    }
}
